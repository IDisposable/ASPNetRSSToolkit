/*=======================================================================
  Copyright (C) Microsoft Corporation.  All rights reserved.
 
  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
  PARTICULAR PURPOSE.
=======================================================================*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace RssToolkit.Rss.CodeGeneration
{
    /// <summary>
    /// To generate dictionary used in code generation
    /// </summary>
    internal static class RssCodeTreeGenerator
    {
        private static Stack<ParentInfo> stack = new Stack<ParentInfo>();

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <param name="xml">The xml.</param>
        /// <returns>Dictionary</returns>
        public static Dictionary<string, ClassInfo> ConvertToDictionary(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                throw new ArgumentException(string.Format(Resources.RssToolkit.Culture, Resources.RssToolkit.ArgmentException, "xml"));
            }

            Dictionary<string, ClassInfo> table = new Dictionary<string, ClassInfo>();
            StringReader stringReader = new StringReader(xml);
            XmlTextReader reader = new XmlTextReader(stringReader);
            Parse(reader, table);
            return table;
        }

        private static void Parse(XmlTextReader reader, Dictionary<string, ClassInfo> table)
        {
            ParentInfo parent = null;
            string previousNode = null;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element ||
                    reader.NodeType == XmlNodeType.EndElement)
                {
                    ////Got an element. This will be the name of a class.
                    string className = reader.LocalName;
                    if (reader.IsStartElement() || reader.IsEmptyElement)
                    {
                        ParseStartElements(reader, table, parent, className);
                    }
                    else
                    {
                        ParseEndElements(parent, table, className);
                    }

                    previousNode = className;
                }
                else if (reader.NodeType == XmlNodeType.Text)
                {
                    AddTextNode(previousNode, table);
                }
            }
        }

        private static void ParseStartElements(XmlTextReader reader, Dictionary<string, ClassInfo> table, ParentInfo parent, string className)
        {
            if (stack.Count != 0)
            {
                ////Get the parent
                parent = stack.Peek();
                ////Get the child element from inside the parent
                if (parent.ChildCount.ContainsKey(className))
                {
                    ////increment the Occurance of the child element inside the parent
                    int childCount = parent.ChildCount[className];
                    parent.ChildCount[className] = ++childCount;
                }
                else
                {
                    ////if child does not exist in the parent add it will Occurance = 1
                    parent.ChildCount.Add(className, 1);
                }
            }

            if (!reader.IsEmptyElement)
            {
                ////If its not an empty element push it in the stack which
                ////contains all parent elements
                stack.Push(new ParentInfo());
            }

            if (!table.ContainsKey(className))
            {
                ////Create a ClassInfo everytime we hit an element and it is not already
                ////contained in the global table.
                ClassInfo classInfo = new ClassInfo();
                classInfo.Name = className;

                ////Add all the attributes here....
                for (int index = 0; index < reader.AttributeCount; index++)
                {
                    PropertyInfo p = new PropertyInfo();
                    reader.MoveToAttribute(index);
                    p.Name = reader.LocalName;
                    p.IsAttribute = true;
                    classInfo.Properties[p.Name] = p;
                }

                table.Add(className, classInfo);
            }
            else
            {
                ClassInfo classInfo = table[className];
                
                ////Add any new attributes that are not already defined in the classInfo....
                for (int index = 0; index < reader.AttributeCount; index++)
                {
                    reader.MoveToAttribute(index);
                    string localName = reader.LocalName;
                    if (!classInfo.Properties.ContainsKey(localName))
                    {
                        PropertyInfo propertyInfo = new PropertyInfo();
                        propertyInfo.Name = localName;
                        propertyInfo.IsAttribute = true;
                        classInfo.Properties[propertyInfo.Name] = propertyInfo;
                    }
                }
            }
        }

        private static void ParseEndElements(ParentInfo parent, Dictionary<string, ClassInfo> table, string className)
        {
            parent = stack.Pop();
            ClassInfo classInfo = table[className];
            Dictionary<string, PropertyInfo> classMembers = classInfo.Properties;
            foreach (string childName in parent.ChildCount.Keys)
            {
                int childCount = parent.ChildCount[childName];
                int existingChildCount = 0;
                if (classMembers.ContainsKey(childName))
                {
                    existingChildCount = classMembers[childName].Occurances;
                }
                else
                {
                    PropertyInfo property = new PropertyInfo();
                    property.Name = childName;
                    property.Occurances = 0;
                    classMembers[childName] = property;
                }

                if (childCount > existingChildCount)
                {
                    classMembers[childName].Occurances = childCount;
                }
            }

            if (stack.Count != 0)
            {
                parent = stack.Peek();
            }
            else
            {
                parent = null;
            }
        }

        private static void AddTextNode(string className, Dictionary<string, ClassInfo> table)
        {
            if (!string.IsNullOrEmpty(className))
            {
                ClassInfo classInfo = table[className];
                classInfo.IsText = true;
            }
        }

        private class ParentInfo
        {
            private Dictionary<string, int> childCount = new Dictionary<string, int>();

            /// <summary>
            /// Initializes a new instance of the <see cref="ParentInfo"/> class.
            /// </summary>
            public ParentInfo()
            {
            }

            /// <summary>
            /// Gets or sets the child count.
            /// </summary>
            /// <value>The child count.</value>
            public Dictionary<string, int> ChildCount
            {
                get 
                { 
                    return childCount; 
                }
            }
        }
    }
}
