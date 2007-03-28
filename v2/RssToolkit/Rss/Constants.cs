using System;
using System.Collections.Generic;
using System.Text;
using RssToolkit;

namespace RssToolkit
{
    /// <summary>
    /// Class that contains constant values used by the framework.
    /// </summary>
    public static class Constants
    {
       
        /// <summary>
        /// Xsl for converting Atom format to Rss 2.0
        /// </summary>
        public const string AtomToRssXsl = "RssToolkit.Resources.AtomToRss20.xsl";

        /// <summary>
        /// Xsl for converting Rdf format to Rss 2.0
        /// </summary>
        public const string RdfToRssXsl = "RssToolkit.Resources.RdfToRss20.xsl";

        /// <summary>
        /// Rss 2.0 Xsd Schema
        /// </summary>
        public const string Rss20Xsd = "RssToolkit.Resources.Rss20.xsd";
    }
}
