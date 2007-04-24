/*=======================================================================
  Copyright (C) Microsoft Corporation.  All rights reserved.
 
  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
  PARTICULAR PURPOSE.
=======================================================================*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Serialization;
using RssToolkit.Rss;

namespace RssToolkit.Rss
{
    /// <summary>
    /// helper class that provides memory and disk caching of the downloaded feeds
    /// </summary>
    public class DownloadManager
    {
        private static DownloadManager _downloadManager = new DownloadManager();
        private Dictionary<string, CacheInfo> _cache;
        private int _defaultTtlMinutes;
        private string _directoryOnDisk;

        private DownloadManager()
        {
            // create in-memory cache
            _cache = new Dictionary<string, CacheInfo>();

            // get default ttl value from config
            _defaultTtlMinutes = GetTtlFromString(ConfigurationManager.AppSettings["defaultRssTtl"], 1);
            
            // prepare disk directory
            _directoryOnDisk = PrepareTempDir();
        }

        /// <summary>
        /// Gets the Feed information.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>string</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#")]
        public static Stream GetFeed(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException(string.Format(Resources.RssToolkit.Culture, Resources.RssToolkit.ArgmentException, "url"));
            }

            return _downloadManager.GetFeedDom(url).Data;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private static string PrepareTempDir()
        {
            string tempDir = null;

            try
            {
                string d = ConfigurationManager.AppSettings["rssTempDir"];
                
                if (string.IsNullOrEmpty(d))
                {
                    if (HostingEnvironment.IsHosted)
                    {
                        d = HttpRuntime.CodegenDir;
                    }
                    else
                    {
                        d = Environment.GetEnvironmentVariable("TEMP");

                        if (string.IsNullOrEmpty(d))
                        {
                            d = Environment.GetEnvironmentVariable("TMP");

                            if (string.IsNullOrEmpty(d))
                            {
                                d = Directory.GetCurrentDirectory();
                            }
                        }
                    }

                    d = Path.Combine(d, "rss");
                }

                if (!Directory.Exists(d))
                {
                    Directory.CreateDirectory(d);
                }

                tempDir = d;
            }
            catch
            {
                // don't cache on disk if can't do it
            }

            return tempDir;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private static string GetTempFileNamePrefixFromUrl(string url)
        {
            try
            {
                Uri uri = new Uri(url);
                return string.Format(
                    System.Globalization.CultureInfo.InvariantCulture,
                    "{0}_{1:x8}",
                    uri.Host.Replace('.', '_'),
                    uri.AbsolutePath.GetHashCode());
            }
            catch
            {
                return "rss";
            }
        }

        private static int GetTtlFromString(string ttlString, int defaultTtlMinutes)
        {
            if (!string.IsNullOrEmpty(ttlString))
            {
                int ttlMinutes;
                if (int.TryParse(ttlString, out ttlMinutes))
                {
                    if (ttlMinutes >= 0)
                    {
                        return ttlMinutes;
                    }
                }
            }

            return defaultTtlMinutes;
        }

        private CacheInfo GetFeedDom(string url)
        {
            CacheInfo dom = null;

            lock (_cache)
            {
                if (_cache.TryGetValue(url, out dom))
                {
                    if (DateTime.UtcNow > dom.Expiry)
                    {
                        _cache.Remove(url);
                        dom = null;
                    }
                }
            }

            if (dom == null || dom.Data != null)
            {
                dom = DownLoadFeedDom(url);

                lock (_cache)
                {
                    _cache[url] = dom;
                }
            }

            return dom;
        }

        private CacheInfo DownLoadFeedDom(string url)
        {
            //// look for disk cache first
            CacheInfo dom = TryLoadFromDisk(url);

            if (dom != null && dom.Data != null)
            {
                return dom;
            }
            else
            {
                dom = new CacheInfo();
            }

            string ttlString = null;
            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            
            MemoryStream documentStream = new MemoryStream();
            doc.Save(documentStream);
            documentStream.Flush();
            documentStream.Position = 0;
            dom.Data = documentStream;

            if (doc.SelectSingleNode("/rss/channel/ttl") != null)
            {
                ttlString = doc.SelectSingleNode("/rss/channel/ttl").Value;
            }

            // set expiry
            int ttlMinutes = GetTtlFromString(ttlString, _defaultTtlMinutes);
            DateTime utcExpiry = DateTime.UtcNow.AddMinutes(ttlMinutes);
            dom.Expiry = utcExpiry;

            //// save to disk
            TrySaveToDisk(doc, url, utcExpiry);

            return dom;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private CacheInfo TryLoadFromDisk(string url)
        {
            if (_directoryOnDisk == null)
            {
                return null; // no place to cache
            }

            // look for all files matching the prefix
            // looking for the one matching url that is not expired
            // removing expired (or invalid) ones
            string pattern = GetTempFileNamePrefixFromUrl(url) + "_*.feed";
            string[] files = Directory.GetFiles(_directoryOnDisk, pattern, SearchOption.TopDirectoryOnly);

            foreach (string feedFilename in files)
            {
                XmlDocument feedDoc = null;
                bool isFeedFileValid = false;
                DateTime utcExpiryFromFeedFile = DateTime.MinValue;
                string urlFromFeedFile = null;

                try
                {
                    feedDoc = new XmlDocument();
                    feedDoc.Load(feedFilename);

                    // look for special XML comment (before the root tag)'
                    // containing expiration and url
                    XmlComment comment = feedDoc.DocumentElement.PreviousSibling as XmlComment;

                    if (comment != null)
                    {
                        string c = comment.Value;
                        int i = c.IndexOf('@');
                        long expiry;

                        if (long.TryParse(c.Substring(0, i), out expiry))
                        {
                            utcExpiryFromFeedFile = DateTime.FromBinary(expiry);
                            urlFromFeedFile = c.Substring(i + 1);
                            isFeedFileValid = true;
                        }
                    }
                }
                catch
                {
                    // error processing one file shouldn't stop processing other files
                }

                // remove invalid or expired file
                if (!isFeedFileValid || utcExpiryFromFeedFile < DateTime.UtcNow)
                {
                    try
                    {
                        File.Delete(feedFilename);
                    }
                    catch
                    {
                        // error processing one file shouldn't stop processing other files
                    }

                    // try next file
                    continue;
                }

                // match url
                if (urlFromFeedFile == url)
                {
                    // found a good one - create DOM and set expiry (as found on disk)
                    CacheInfo dom = new CacheInfo();
                    MemoryStream documentStream = new MemoryStream();
                    feedDoc.Save(documentStream);
                    documentStream.Flush();
                    documentStream.Position = 0;
                    dom.Data = documentStream;
                    dom.Expiry = utcExpiryFromFeedFile;
                    return dom;
                }
            }

            // not found
            return null;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void TrySaveToDisk(XmlDocument doc, string url, DateTime utcExpiry)
        {
            if (_directoryOnDisk == null)
            {
                return;
            }

            doc.InsertBefore(doc.CreateComment(string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}@{1}", utcExpiry.ToBinary(), url)), doc.DocumentElement);

            string fileName = string.Format(
                System.Globalization.CultureInfo.InvariantCulture,
                "{0}_{1:x8}.feed",
                GetTempFileNamePrefixFromUrl(url),
                Guid.NewGuid().ToString().GetHashCode());

            try
            {
                doc.Save(Path.Combine(_directoryOnDisk, fileName));
            }
            catch
            {
                // can't save to disk - not a problem
            }
        }

        private class CacheInfo : IDisposable
        {
            private Stream data;
            private DateTime expiry;

            /// <summary>
            /// Gets or sets the expiry.
            /// </summary>
            /// <value>The expiry.</value>
            public DateTime Expiry
            {
                get 
                { 
                    return expiry; 
                }

                set 
                { 
                    expiry = value; 
                }
            }

            /// <summary>
            /// Gets or sets the data.
            /// </summary>
            /// <value>The data.</value>
            public Stream Data
            {
                get 
                { 
                    return data; 
                }

                set 
                { 
                    data = value; 
                }
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                data.Dispose();
            }
        }
    }
}
