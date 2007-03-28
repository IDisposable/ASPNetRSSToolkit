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

namespace RssToolkit.Opml
{
    /// <summary>
    /// used in Outline class and RssAggregator
    /// </summary>
    internal class OutlineInfo
    {
        private OpmlOutline outline;
        private int index;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutlineInfo"/> class.
        /// </summary>
        /// <param name="ol">The ol.</param>
        /// <param name="index">The index.</param>
        public OutlineInfo(OpmlOutline ol, int index)
        {
            if (ol == null)
            {
                throw new ArgumentNullException("ol");
            }

            this.outline = ol;
            this.index = index;
        }

        /// <summary>
        /// Gets or sets the outline.
        /// </summary>
        /// <value>The outline.</value>
        public OpmlOutline Outline
        {
            get 
            { 
                return outline; 
            }
        }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>The index.</value>
        public int Index
        {
            get 
            { 
                return index; 
            }
        }
    }
}
