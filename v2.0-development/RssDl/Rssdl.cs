using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using RssToolkit.Rss;
using RssToolkit.Rss.CodeGeneration;

namespace RssToolkit
{
    /// <summary>
    /// Generates code files based on a Rss or Opml URL
    /// </summary>
    public sealed class Rssdl
    {
        private Rssdl()
        {
        }

        /// <summary>
        /// The Main entry point
        /// </summary>
        /// <param name="args">Arguments.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters", MessageId = "System.Exception.#ctor(System.String)")]
        public static void Main(string[] args)
        {
            Console.WriteLine("Simple RSS Compiler v2.0");
            Console.WriteLine();

            // Process command line
            if (args.Length != 2)
            {
                Console.WriteLine("usage: rssdl.exe url-or-file outputcode.cs");
                return;
            }

            string url = args[0];
            string codeFilename = args[1];
            string classNamePrefix = Path.GetFileNameWithoutExtension(codeFilename);

            // Load the channel data from supplied url
            string codeString;
            try
            {
                using (Stream feedStream = DownloadManager.GetFeed(url))
                {
                    using (XmlTextReader reader = new XmlTextReader(feedStream))
                    {
                        codeString = RssXmlHelper.ConvertToRssXml(reader);

                        try
                        {
                            // Open the output code file
                            using (TextWriter codeWriter = new StreamWriter(codeFilename, false))
                            {
                                // Get the language from file extension
                                string lang = Path.GetExtension(codeFilename);

                                if (lang != null && lang.Length > 1 && lang.StartsWith("."))
                                {
                                    lang = lang.Substring(1).ToUpperInvariant();
                                }
                                else
                                {
                                    lang = "CS";
                                }

                                // Generate source
                                try
                                {
                                    RssCodeGenerator.GenerateCode(codeString, url, lang, string.Empty, classNamePrefix, codeWriter, true);
                                    Console.WriteLine("Done -- generated '{0}'.", codeFilename);
                                    return;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("*** Error generating '{0}' *** {1}: {2}", codeFilename, e.GetType().Name, e.Message);
                                }
                            }

                            File.Delete(codeFilename);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("*** Failed to open '{0}' for writing *** {1}: {2}", codeFilename, e.GetType().Name, e.Message);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("*** Failed to load '{0}' *** {1}: {2}", url, e.GetType().Name, e.Message);
            }
        }
    }
}
