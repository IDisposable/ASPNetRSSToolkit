/*=======================================================================
  Copyright (C) Microsoft Corporation.  All rights reserved.
 
  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
  PARTICULAR PURPOSE.
=======================================================================*/

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RssToolkit.Rss
{
    /// <summary>
    /// Abstract class for RSS Document
    /// </summary>
    public abstract class RssDocumentBase
    {
        private string _version;
        private RssChannel _channel;

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        [XmlAttribute("version")]
        public string Version
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
        /// Channel
        /// </summary>
        [XmlIgnore()]
        public RssChannel Channel
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
        /// string XML representation.
        /// </summary>
        /// <returns>string</returns>
        public virtual string ToXml()
        {
            return string.Empty;
        }
    }
}
