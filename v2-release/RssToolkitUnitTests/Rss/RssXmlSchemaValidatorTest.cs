﻿// The following code was generated by Microsoft Visual Studio 2005.
// The test owner should check each test for validity.
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using RssToolkit.Rss;
using System.Xml.Schema;
using System.Xml;
namespace RssToolkitUnitTest
{
    /// <summary>
    ///This is a test class for RssToolkit.Rss.RssXmlSchemaValidator and is intended
    ///to contain all RssToolkit.Rss.RssXmlSchemaValidator Unit Tests
    ///</summary>
    [TestClass()]
    public class RssXmlSchemaValidatorTest
    {
        private TestContext testContextInstance;
        private static string invalidXml = @"<?xml version='1.0' encoding='iso-8859-1' ?>
                                <rss version='2.0' xmlns:media='http://search.yahoo.com/mrss/'>
	                                <channl>
		                                <title>Yahoo! News: Top Stories</title>
                                        <title>Yahoo! News: Top Stories</title>
		                                <copyright>Copyright (c) 2007 Yahoo! Inc. All rights reserved.</copyright>
		                                <link>http://news.yahoo.com/i/716</link>
		                                <description>Top Stories</description>
		                                <language>en-us</language>
		                                <lastBuildDate>Wed, 14 Feb 2007 23:10:27 GMT</lastBuildDate>
		                                <ttl>5</ttl>
		                                <image>
			                                <title>Yahoo! News</title>
			                                <width>142</width>
			                                <height>18</height>
			                                <link>http://news.yahoo.com/i/716</link>
			                                <url>http://us.i1.yimg.com/us.yimg.com/i/us/nws/th/main_142b.gif</url>
		                                </image>
		                                <item>
			                                <title>
				                                Bush: Iran is source of deadly weapons
				                                (AP)
			                                </title>
			                                <link>http://us.rd.yahoo.com/dailynews/rss/topstories/*http://news.yahoo.com/s/ap/20070214/ap_on_go_pr_wh/bush</link>
			                                <guid isPermaLink='false'>ap/20070214/bush</guid>
			                                <pubDate>Wed, 14 Feb 2007 23:05:49 GMT</pubDate>
			                                <description>&#60;p>&#60;a href='http://us.rd.yahoo.com/dailynews/rss/topstories/*http://news.yahoo.com/s/ap/20070214/ap_on_go_pr_wh/bush'>&#60;img src='http://d.yimg.com/us.yimg.com/p/afp/20070214/capt.sge.sjp12.140207164239.photo00.photo.default-512x353.jpg?x=130&amp;y=89&amp;sig=6o.nRJlRJq_zQYDs3VnTgg--' align='left' height='89' width='130' alt='US President George W. Bush speaks during a press conference in the East Room of the White House in Washington, DC. Bush said the new US-led effort to secure Baghdad was under way but warned it will &amp;quot;take time&amp;quot; and that there will be violence from those trying to derail his plan.(AFP/Jim Watson)' border='0' />&#60;/a>AP - Challenged on the accuracy of U.S. intelligence, President Bush said Wednesday there is no doubt the Iranian government is providing armor-piercing weapons to kill American soldiers in Iraq. But he backed away from claims the top echelon of Iran&#039;s government was responsible.&#60;/p>&#60;br clear='all'/></description>
			                                <media:content url='http://d.yimg.com/us.yimg.com/p/afp/20070214/capt.sge.sjp12.140207164239.photo00.photo.default-512x353.jpg?x=130&amp;y=89&amp;sig=6o.nRJlRJq_zQYDs3VnTgg--' type='image/jpeg' height='89' width='130'/>
			                                <media:text type='html'>&#60;p>&#60;a href='http://us.rd.yahoo.com/dailynews/rss/topstories/*http://news.yahoo.com/s/ap/20070214/ap_on_go_pr_wh/bush'>&#60;img src='http://d.yimg.com/us.yimg.com/p/afp/20070214/capt.sge.sjp12.140207164239.photo00.photo.default-512x353.jpg?x=130&amp;y=89&amp;sig=6o.nRJlRJq_zQYDs3VnTgg--' align='left' height='89' width='130' alt='photo' title='US President George W. Bush speaks during a press conference in the East Room of the White House in Washington, DC. Bush said the new US-led effort to secure Baghdad was under way but warned it will &amp;quot;take time&amp;quot; and that there will be violence from those trying to derail his plan.(AFP/Jim Watson)' border='0'/>&#60;/a>&#60;/p>&#60;br clear='all'/></media:text>
			                                <media:credit role='publishing company'>(AP)</media:credit>

		                                </item>
	                                </channl>
                                </rss>";

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for IsValidXml
        ///</summary>
        [TestMethod()]
        public void RssXmlSchemaValidatorIsValidXmlTest()
        {
            RssXmlSchemaValidator target = new RssXmlSchemaValidator();
            string validXml = RssToolkitUnitTest.Utility.RssUtility.RssXml;
            
            Assembly assbly = Assembly.Load("RssToolkit");
            Stream strm1 = assbly.GetManifestResourceStream(RssToolkit.Constants.Rss20Xsd);
            Stream strm2 = assbly.GetManifestResourceStream(RssToolkit.Constants.Rss20Xsd);


            target.ValidXmlDoc(validXml, new XmlTextReader(strm1)); 
            Assert.IsTrue(target.IsValidXml, "RssToolkit.Rss.RssXmlSchemaValidator.IsValidXml was not set correctly.");


            target.ValidXmlDoc(invalidXml, new XmlTextReader(strm2));
            Assert.IsFalse(target.IsValidXml, "RssToolkit.Rss.RssXmlSchemaValidator.IsValidXml was not set correctly.");
        }

        /// <summary>
        ///A test for ValidationCallBack (object, ValidationEventArgs)
        ///</summary>
        [DeploymentItem("RssToolkit.dll")]
        [TestMethod()]
        public void RssXmlSchemaValidatorValidationCallBackTest()
        {
            RssXmlSchemaValidator target = new RssXmlSchemaValidator();
            string validXml = RssToolkitUnitTest.Utility.RssUtility.RssXml;

            Assembly assbly = Assembly.Load("RssToolkit");
            Stream strm1 = assbly.GetManifestResourceStream(RssToolkit.Constants.Rss20Xsd);
            Stream strm2 = assbly.GetManifestResourceStream(RssToolkit.Constants.Rss20Xsd);


            target.ValidXmlDoc(validXml, new XmlTextReader(strm1));
            Assert.IsTrue(target.IsValidXml, "RssToolkit.Rss.RssXmlSchemaValidator.IsValidXml was not set correctly.");


            target.ValidXmlDoc(invalidXml, new XmlTextReader(strm2));
            Assert.IsFalse(target.IsValidXml, "RssToolkit.Rss.RssXmlSchemaValidator.IsValidXml was not set correctly.");

            Assert.AreEqual("The element 'rss' has invalid child element 'channl'. List of possible elements expected: 'channel'.", target.ValidationError);
        }

        /// <summary>
        ///A test for ValidationError
        ///</summary>
        [TestMethod()]
        public void RssXmlSchemaValidatorValidationErrorTest()
        {
            RssXmlSchemaValidator target = new RssXmlSchemaValidator();
            string validXml = RssToolkitUnitTest.Utility.RssUtility.RssXml;

            Assembly assbly = Assembly.Load("RssToolkit");
            Stream strm1 = assbly.GetManifestResourceStream(RssToolkit.Constants.Rss20Xsd);
            Stream strm2 = assbly.GetManifestResourceStream(RssToolkit.Constants.Rss20Xsd);


            target.ValidXmlDoc(validXml, new XmlTextReader(strm1));
            Assert.IsTrue(target.IsValidXml, "RssToolkit.Rss.RssXmlSchemaValidator.IsValidXml was not set correctly.");


            target.ValidXmlDoc(invalidXml, new XmlTextReader(strm2));
            Assert.IsFalse(target.IsValidXml, "RssToolkit.Rss.RssXmlSchemaValidator.IsValidXml was not set correctly.");

            Assert.AreEqual("The element 'rss' has invalid child element 'channl'. List of possible elements expected: 'channel'.", target.ValidationError);
        }

        /// <summary>
        ///A test for ValidXmlDoc (string, string, XmlReader)
        ///</summary>
        [TestMethod()]
        public void RssXmlSchemaValidatorValidXmlDocTest()
        {
            RssXmlSchemaValidator target = new RssXmlSchemaValidator();
            string validXml = RssToolkitUnitTest.Utility.RssUtility.RssXml;

            Assembly assbly = Assembly.Load("RssToolkit");
            Stream strm1 = assbly.GetManifestResourceStream(RssToolkit.Constants.Rss20Xsd);
            Stream strm2 = assbly.GetManifestResourceStream(RssToolkit.Constants.Rss20Xsd);


            target.ValidXmlDoc(validXml, new XmlTextReader(strm1));
            Assert.IsTrue(target.IsValidXml, "RssToolkit.Rss.RssXmlSchemaValidator.IsValidXml was not set correctly.");


            target.ValidXmlDoc(invalidXml, new XmlTextReader(strm2));
            Assert.IsFalse(target.IsValidXml, "RssToolkit.Rss.RssXmlSchemaValidator.IsValidXml was not set correctly.");

            Assert.AreEqual("The element 'rss' has invalid child element 'channl'. List of possible elements expected: 'channel'.", target.ValidationError);
        }
    }
}