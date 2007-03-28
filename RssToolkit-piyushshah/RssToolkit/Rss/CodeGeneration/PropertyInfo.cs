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
    /// Stores property information for code generation
    /// </summary>
    internal class PropertyInfo
    {
        private string name;
        private int occurances;
        private bool isattribute;

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
        /// Gets or sets the occurances.
        /// </summary>
        /// <value>The occurances.</value>
        public int Occurances
        {
            get 
            { 
                return occurances; 
            }

            set 
            {
                occurances = value; 
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is attribute.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is attribute; otherwise, <c>false</c>.
        /// </value>
        public bool IsAttribute
        {
            get 
            { 
                return isattribute; 
            }

            set 
            {
                isattribute = value;
            }
        }
    }
}
