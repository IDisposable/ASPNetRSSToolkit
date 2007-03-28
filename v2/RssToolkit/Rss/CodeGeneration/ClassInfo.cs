/*=======================================================================
  Copyright (C) Microsoft Corporation.  All rights reserved.
 
  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
  PARTICULAR PURPOSE.
=======================================================================*/
using System;
using System.Collections.Generic;
using System.Text;

namespace RssToolkit.Rss.CodeGeneration
{
    /// <summary>
    /// Is used inside the Code generation process
    /// </summary>
    internal class ClassInfo
    {
        private string name;
        private bool isText;
        private Dictionary<string, PropertyInfo> properties = new Dictionary<string, PropertyInfo>();

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get 
            { 
                return name; 
            }

            set 
            { 
                name = value; 
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this Class is Text NodeType.
        /// </summary>
        /// <value><c>true</c> if this Class is Text NodeType; otherwise, <c>false</c>.</value>
        public bool IsText
        {
            get
            {
                return isText;
            }

            set
            {
                isText = value;
            }
        }

        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        /// <value>The properties.</value>
        internal Dictionary<string, PropertyInfo> Properties
        {
            get 
            { 
                return properties; 
            }
        }
    }
}
