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
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml.Serialization;

namespace RssToolkit.Rss
{
    /// <summary>
    /// Helper class
    /// </summary>
    public static class RssXmlHelper
    {
        private const string TimeZoneCacheKey = "DateTimeParser";

        /// <summary>
        /// Resolves the app relative link to URL.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <returns>string</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2234:PassSystemUriObjectsInsteadOfStrings"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings")]
        public static string ResolveAppRelativeLinkToUrl(string link)
        {
            if (string.IsNullOrEmpty(link))
            {
                throw new ArgumentException(string.Format(Resources.RssToolkit.Culture, Resources.RssToolkit.ArgmentException, "link"));
            }

            if (!string.IsNullOrEmpty(link) && link.StartsWith("~/"))
            {
                HttpContext context = HttpContext.Current;

                if (context != null)
                {
                    string query = null;
                    int iquery = link.IndexOf('?');

                    if (iquery >= 0)
                    {
                        query = link.Substring(iquery);
                        link = link.Substring(0, iquery);
                    }

                    link = VirtualPathUtility.ToAbsolute(link);
                    link = new Uri(context.Request.Url, link).ToString();

                    if (iquery >= 0)
                    {
                        link += query;
                    }
                }
            }

            return link;
        }

        /// <summary>
        /// Deserialize from XML using string reader.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <typeparam name="T">RssDocumentBase</typeparam>
        /// <returns>T</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static T DeserializeFromXmlUsingStringReader<T>(string xml) where T : RssDocumentBase
        {
            if (string.IsNullOrEmpty(xml))
            {
                throw new ArgumentException(string.Format(Resources.RssToolkit.Culture, Resources.RssToolkit.ArgmentException, "xml"));
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader strngReader = new StringReader(xml))
            {
                return (T)xmlSerializer.Deserialize(strngReader);
            }
        }

        /// <summary>
        /// Returns XML of the Generic Type.
        /// </summary>
        /// <param name="rssDocument">The RSS document.</param>
        /// <typeparam name="T">RssDocumentBase</typeparam>
        /// <returns>string</returns>
        public static string ToXml<T>(T rssDocument) where T : RssDocumentBase
        {
            if (rssDocument == null)
            {
                throw new ArgumentNullException("rssDocument");
            }

            string xml = string.Empty;

            using (StringWriter output = new StringWriter(new StringBuilder(), System.Globalization.CultureInfo.InvariantCulture))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(output, rssDocument);
                xml = output.ToString();
            }

            return xml;
        }

        /// <summary>
        /// Gets the type of the document.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="xml">The XML.</param>
        /// <returns>DocumentType</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#")]
        public static DocumentType GetDocumentType(string url, out string xml)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException(string.Format(Resources.RssToolkit.Culture, Resources.RssToolkit.ArgmentException, "url"));
            }

            string cachedXml = DownloadManager.GetFeed(url);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(cachedXml);
            xml = cachedXml;
            
            if (xmlDocument.DocumentElement.LocalName.Equals("rss", StringComparison.InvariantCultureIgnoreCase))
            {
                return DocumentType.Rss;
            }
            else if (xmlDocument.DocumentElement.LocalName.Equals("opml", StringComparison.InvariantCultureIgnoreCase))
            {
                return DocumentType.Opml;
            }
            else if (xmlDocument.DocumentElement.LocalName.Equals("feed", StringComparison.InvariantCultureIgnoreCase))
            {
                return DocumentType.Atom;
            }
            else if (xmlDocument.DocumentElement.LocalName.Equals("rdf", StringComparison.InvariantCultureIgnoreCase))
            {
                return DocumentType.Rdf;
            }

            return DocumentType.Unknown;
        }

        /// <summary>
        /// Gets the data set.
        /// </summary>
        /// <value>The data set.</value>
        /// <param name="xml">XML</param>
        /// <returns>DataSet</returns>
        public static DataSet ToDataSet(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                throw new ArgumentException(string.Format(Resources.RssToolkit.Culture, Resources.RssToolkit.ArgmentException, "xml"));
            }

            DataSet dataset = new DataSet();
            dataset.Locale = System.Globalization.CultureInfo.InvariantCulture;
            using (StringReader stringReader = new StringReader(xml))
            {
                dataset.ReadXml(stringReader);
            }

            return dataset;
        }

        /// <summary>
        /// Loads the RSS from opml URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <typeparam name="T">RssDocumentBase</typeparam>
        /// <returns>Generic of RssDocumentBase</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#")]
        public static T LoadRssFromOpmlUrl<T>(string url) where T: RssDocumentBase
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException(string.Format(Resources.RssToolkit.Culture, Resources.RssToolkit.ArgmentException, "url"));
            }

            // resolve app-relative URLs
            url = RssXmlHelper.ResolveAppRelativeLinkToUrl(url);

            RssAggregator aggregator = new RssAggregator();
            aggregator.LoadFromUrl(url);
            string rssXml = aggregator.RssXml;

            return RssXmlHelper.DeserializeFromXmlUsingStringReader<T>(rssXml);
        }

        /// <summary>
        /// Converts the atom to RSS.
        /// </summary>
        /// <param name="documentType">Rss Document Type</param>
        /// <param name="inputXml">The input XML.</param>
        /// <returns>string</returns>
        public static string ConvertToRss(DocumentType documentType, string inputXml)
        {
            string returnValue;
            Assembly assembly = Assembly.GetExecutingAssembly();
            string xslFileName;

            switch (documentType)
            {
                case DocumentType.Atom:
                    xslFileName = Constants.AtomToRssXsl;
                    break;
                case DocumentType.Rdf:
                    xslFileName = Constants.RdfToRssXsl;
                    break;
                default:
                    return null;
            }

            Stream stream = assembly.GetManifestResourceStream(xslFileName);
            using (StringWriter outputWriter = new StringWriter(System.Globalization.CultureInfo.InvariantCulture))
            {
                using (StringReader stringReader = new StringReader(inputXml))
                {
                    XPathDocument xpathDoc = new XPathDocument(stringReader);
                    XslCompiledTransform transform = new XslCompiledTransform();
                    using (XmlTextReader styleSheetReader = new XmlTextReader(stream))
                    {
                        transform.Load(styleSheetReader);
                        transform.Transform(xpathDoc, null, outputWriter);
                    }
                }

                returnValue = outputWriter.ToString();
            }

            return returnValue;
        }

        /// <summary>
        /// Parse is able to parse RFC2822/RFC822 formatted dates.
        /// It has a fallback mechanism: if the string does not match,
        /// the normal DateTime.Parse() function is called.
        /// 
        /// Copyright of RssBandit.org
        /// Author - t_rendelmann
        /// </summary>
        /// <param name="dateTime">Date Time to parse</param>
        /// <returns>DateTime instance</returns>
        /// <exception cref="FormatException">On format errors parsing the datetime</exception>
        public static DateTime Parse(string dateTime)
        {
            Regex rfc2822 = new Regex(@"\s*(?:(?:Mon|Tue|Wed|Thu|Fri|Sat|Sun)\s*,\s*)?(\d{1,2})\s+(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\s+(\d{2,})\s+(\d{2})\s*:\s*(\d{2})\s*(?::\s*(\d{2}))?\s+([+\-]\d{4}|UT|GMT|EST|EDT|CST|CDT|MST|MDT|PST|PDT|[A-IK-Z])", RegexOptions.Compiled);
            ArrayList months = new ArrayList(new string[] { "ZeroIndex", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" });

            if (dateTime == null)
            {
                return DateTime.Now.ToUniversalTime();
            }

            if (dateTime.Trim().Length == 0)
            {
                return DateTime.Now.ToUniversalTime();
            }

            Match m = rfc2822.Match(dateTime);
            if (m.Success)
            {
                try
                {
                    int dd = Int32.Parse(m.Groups[1].Value, System.Globalization.CultureInfo.InvariantCulture);
                    int mth = months.IndexOf(m.Groups[2].Value);
                    int yy = Int32.Parse(m.Groups[3].Value, System.Globalization.CultureInfo.InvariantCulture);
                    //// following year completion is compliant with RFC 2822.
                    yy = (yy < 50 ? 2000 + yy : (yy < 1000 ? 1900 + yy : yy));
                    int hh = Int32.Parse(m.Groups[4].Value, System.Globalization.CultureInfo.InvariantCulture);
                    int mm = Int32.Parse(m.Groups[5].Value, System.Globalization.CultureInfo.InvariantCulture);
                    int ss = Int32.Parse(m.Groups[6].Value, System.Globalization.CultureInfo.InvariantCulture);
                    string zone = m.Groups[7].Value;

                    DateTime xd = new DateTime(yy, mth, dd, hh, mm, ss);
                    return xd.AddHours(RFCTimeZoneToGMTBias(zone) * -1);
                }
                catch (Exception e)
                {
                    throw new FormatException(string.Format(Resources.RssToolkit.Culture, Resources.RssToolkit.RssText, e.GetType().Name), e);
                }
            }
            else
            {
                // fallback, if regex does not match:
                return DateTime.Parse(dateTime, System.Globalization.CultureInfo.InvariantCulture);
            }
        }


        /// <summary>
        /// Changes Time zone based on GMT
        /// 
        /// Copyright of RssBandit.org
        /// Author - t_rendelmann
        /// </summary>
        /// <param name="zone">The zone.</param>
        /// <returns></returns>
        private static double RFCTimeZoneToGMTBias(string zone)
        {
            Dictionary<string, int> timeZones;

            if (HttpContext.Current != null && HttpContext.Current.Cache[TimeZoneCacheKey] != null)
            {
                timeZones = (Dictionary<string, int>)HttpContext.Current.Cache[TimeZoneCacheKey];
            }
            else
            {
                timeZones = new Dictionary<string, int>();
                timeZones.Add("GMT", 0);
                timeZones.Add("UT", 0);
                timeZones.Add("EST", -5 * 60);
                timeZones.Add("EDT", -4 * 60);
                timeZones.Add("CST", -6 * 60);
                timeZones.Add("CDT", -5 * 60);
                timeZones.Add("MST", -7 * 60);
                timeZones.Add("MDT", -6 * 60);
                timeZones.Add("PST", -8 * 60);
                timeZones.Add("PDT", -7 * 60);
                timeZones.Add("Z", 0);
                timeZones.Add("A", -1 * 60);
                timeZones.Add("B", -2 * 60);
                timeZones.Add("C", -3 * 60);
                timeZones.Add("D", -4 * 60);
                timeZones.Add("E", -5 * 60);
                timeZones.Add("F", -6 * 60);
                timeZones.Add("G", -7 * 60);
                timeZones.Add("H", -8 * 60);
                timeZones.Add("I", -9 * 60);
                timeZones.Add("K", -10 * 60);
                timeZones.Add("L", -11 * 60);
                timeZones.Add("M", -12 * 60);
                timeZones.Add("N", 1 * 60);
                timeZones.Add("O", 2 * 60);
                timeZones.Add("P", 3 * 60);
                timeZones.Add("Q", 4 * 60);
                timeZones.Add("R", 3 * 60);
                timeZones.Add("S", 6 * 60);
                timeZones.Add("T", 3 * 60);
                timeZones.Add("U", 8 * 60);
                timeZones.Add("V", 3 * 60);
                timeZones.Add("W", 10 * 60);
                timeZones.Add("X", 3 * 60);
                timeZones.Add("Y", 12 * 60);
                
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Cache.Insert(TimeZoneCacheKey, timeZones);
                }
            }
                        
            string s;

            if (zone.IndexOfAny(new char[] { '+', '-' }) == 0)  // +hhmm format
            {
                int fact = (zone.Substring(0, 1) == "-" ? -1 : 1);
                s = zone.Substring(1).TrimEnd();
                double hh = Math.Min(23, Int32.Parse(s.Substring(0, 2), System.Globalization.CultureInfo.InvariantCulture));
                double mm = Math.Min(59, Int32.Parse(s.Substring(2, 2), System.Globalization.CultureInfo.InvariantCulture)) / 60;
                return fact * (hh + mm);
            }
            else
            { // named format
                s = zone.ToUpper(System.Globalization.CultureInfo.InvariantCulture).Trim();
                foreach(string key in timeZones.Keys)
                {
                    if (key.Equals(s))
                    {
                        return timeZones[key] / 60;
                    }
                }
            }

            return 0.0;
        }
    }
}
