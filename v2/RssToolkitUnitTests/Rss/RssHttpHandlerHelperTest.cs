﻿// The following code was generated by Microsoft Visual Studio 2005.
// The test owner should check each test for validity.
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using RssToolkit.Rss;
namespace RssToolkitUnitTest
{
    /// <summary>
    ///This is a test class for RssToolkit.Rss.RssHttpHandlerHelper and is intended
    ///to contain all RssToolkit.Rss.RssHttpHandlerHelper Unit Tests
    ///</summary>
    [TestClass()]
    public class RssHttpHandlerHelperTest
    {
        private TestContext testContextInstance;

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
        ///A test for GenerateChannelLink (string, string, string)
        ///</summary>
        [TestMethod()]
        public void GenerateChannelLinkTest()
        {
            string handlerPath = null; // TODO: Initialize to an appropriate value

            string channelName = null; // TODO: Initialize to an appropriate value

            string userName = null; // TODO: Initialize to an appropriate value

            string expected = null;
            string actual;

            actual = RssToolkit.Rss.RssHttpHandlerHelper.GenerateChannelLink(handlerPath, channelName, userName);

            Assert.AreEqual(expected, actual, "RssToolkit.Rss.RssHttpHandlerHelper.GenerateChannelLink di" +
                    "d not return the expected value.");
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ParseChannelQueryString (HttpRequest, out string, out string)
        ///</summary>
        [DeploymentItem("RssToolkit.dll")]
        [TestMethod()]
        public void ParseChannelQueryStringTest()
        {
            HttpRequest request = null; // TODO: Initialize to an appropriate value

            string channelName;
            string channelName_expected = null; // TODO: Initialize to an appropriate value

            string userName;
            string userName_expected = null; // TODO: Initialize to an appropriate value

            RssToolkitUnitTest.RssToolkit_Rss_RssHttpHandlerHelperAccessor.ParseChannelQueryString(request, out channelName, out userName);

            Assert.AreEqual(channelName_expected, channelName, "channelName_ParseChannelQueryString_expected was not set correctly.");
            Assert.AreEqual(userName_expected, userName, "userName_ParseChannelQueryString_expected was not set correctly.");
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RssHttpHandlerHelper ()
        ///</summary>
        [DeploymentItem("RssToolkit.dll")]
        [TestMethod()]
        public void ConstructorTest()
        {
            RssHttpHandlerHelper target = RssToolkitUnitTest.RssToolkit_Rss_RssHttpHandlerHelperAccessor.CreatePrivate();

            // TODO: Implement code to verify target
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}