/*=======================================================================
  Copyright (C) Microsoft Corporation.  All rights reserved.
 
  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
  PARTICULAR PURPOSE.
=======================================================================*/

using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace RssToolkit.Rss 
{
    /// <summary>
    /// RssDocument
    /// </summary>
    [Serializable()]
    [XmlRoot("rss")]
    public class RssDocument : RssDocumentBase
    {
        private string _version;
        private RssChannel _channel;
        private string _url;

        /// <summary>
        /// Initializes a new instance of the <see cref="RssDocument"/> class.
        /// </summary>
        public RssDocument()
        {
        }

        #region "Properties"
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        [XmlAttribute("version")]
        public new string Version
        {
            get
            { 
                return _version; 
            }
            
            set
            {
                _version = value; 
            }
        }

        /// <summary>
        /// Gets or sets the channel.
        /// </summary>
        /// <value>The channel.</value>
        [XmlElement("channel")]
        public new RssChannel Channel
        {
            get
            {
                return _channel;
            }

            set
            {
                _channel = value;
            }
        }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <value>The URL.</value>
        internal string Url
        {
            get 
            {
                return _url; 
            }
        }
        #endregion


        /// <summary>
        /// Loads from URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#")]
        public void LoadFromUrl(string url) 
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException(string.Format(Resources.RssToolkit.Culture, Resources.RssToolkit.ArgmentException, "url"));
            }

            // resolve app-relative URLs
            url = RssXmlHelper.ResolveAppRelativeLinkToUrl(url);

            // download the feed
            string rssString = DownloadManager.GetFeed(url);
            LoadFromXml(rssString);

            //// remember the url
            _url = url;
        }

        /// <summary>
        /// Loads from XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public void LoadFromXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                throw new ArgumentException(string.Format(Resources.RssToolkit.Culture, Resources.RssToolkit.ArgmentException, "xml"));
            }

            RssDocument rss = RssXmlHelper.DeserializeFromXmlUsingStringReader<RssDocument>(xml);

            LoadFromDom(rss);
        }

        /// <summary>
        /// Loads the RSS from opml URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#")]
        public void LoadFromOpmlUrl(string url)
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

            LoadFromXml(rssXml);
        }

        /// <summary>
        /// Loads the RSS from opml XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        public void LoadFromOpmlXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                throw new ArgumentException(string.Format(Resources.RssToolkit.Culture, Resources.RssToolkit.ArgmentException, "xml"));
            }

            RssAggregator aggregator = new RssAggregator();
            aggregator.LoadFromXml(xml);
            string rssXml = aggregator.RssXml;

            LoadFromXml(rssXml);
        }

        /// <summary>
        /// Coverts to DataSet
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet ToDataSet() 
        {
            return RssXmlHelper.ToDataSet(ToXml());
        }

        /// <summary>
        /// Select method for programmatic databinding
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable SelectItems()
        {
            return SelectItems(-1);
        }

        /// <summary>
        /// Selects the items.
        /// </summary>
        /// <param name="maxItems">The max items.</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable SelectItems(int maxItems)
        {
            return SelectItems(maxItems, false);
        }

        /// <summary>
        /// Selects the items.
        /// </summary>
        /// <param name="maxItems">The max items.</param>
        /// <param name="reverseOrder">if set to <c>true</c> [reverse order].</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable SelectItems(int maxItems, bool reverseOrder)
        {
            DataSet dataset = this.ToDataSet();
            DataView view = dataset.Tables["item"].DefaultView;

            if (reverseOrder)
            {
                if (view.Table.Columns.Contains("pubDateParsed"))
                {
                    view.Sort = "pubDateParsed asc";
                }
            }

            if (maxItems > 0)
            {
                DataTable clonedTable = view.Table.Clone();
                for (int counter = 0; counter <= maxItems - 1; counter++)
                {
                    if (counter >= view.Count)
                    {
                        break;
                    }

                    clonedTable.ImportRow(view[counter].Row);
                }

                return new DataView(clonedTable, view.RowFilter, view.Sort, view.RowStateFilter);
            }
            else
            {
                return view;
            }
        }

        /// <summary>
        /// Converts To Xml
        /// </summary>
        /// <returns>string</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public override string ToXml()
        {
            return RssXmlHelper.ToXml<RssDocument>(this);
        }

        private void LoadFromDom<RssDocumentGeneric>(RssDocumentGeneric rss) where RssDocumentGeneric : RssDocument
        {
            this.Channel = rss.Channel;
            this.Version = rss.Version;
        }
    }
}
