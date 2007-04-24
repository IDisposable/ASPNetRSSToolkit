﻿// The following code was generated by Microsoft Visual Studio 2005.
// The test owner should check each test for validity.
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
namespace RssToolkitUnitTest
{
    /// <summary>
    ///This is a test class for RssToolkit.Rss.CodeGeneration.PropertyInfo and is intended
    ///to contain all RssToolkit.Rss.CodeGeneration.PropertyInfo Unit Tests
    ///</summary>
    [TestClass()]
    public class PropertyInfoTest
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
        ///A test for IsAttribute
        ///</summary>
        [DeploymentItem("RssToolkit.dll")]
        [TestMethod()]
        public void PropertyInfoIsAttributeTest()
        {
            object target = RssToolkitUnitTest.RssToolkit_Rss_CodeGeneration_PropertyInfoAccessor.CreatePrivate();

            bool val = true;
            RssToolkitUnitTest.RssToolkit_Rss_CodeGeneration_PropertyInfoAccessor accessor = new RssToolkitUnitTest.RssToolkit_Rss_CodeGeneration_PropertyInfoAccessor(target);
            accessor.IsAttribute = val;

            Assert.AreEqual(val, accessor.IsAttribute, "RssToolkit.Rss.CodeGeneration.PropertyInfo.IsAttribute was not set correctly.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [DeploymentItem("RssToolkit.dll")]
        [TestMethod()]
        public void PropertyInfoNameTest()
        {
            object target = RssToolkitUnitTest.RssToolkit_Rss_CodeGeneration_PropertyInfoAccessor.CreatePrivate();
            string val = "Channel";
            RssToolkitUnitTest.RssToolkit_Rss_CodeGeneration_PropertyInfoAccessor accessor = new RssToolkitUnitTest.RssToolkit_Rss_CodeGeneration_PropertyInfoAccessor(target);
            accessor.Name = val;

            Assert.AreEqual(val, accessor.Name, "RssToolkit.Rss.CodeGeneration.PropertyInfo.Name was not set correctly.");
        }

        /// <summary>
        ///A test for Occurances
        ///</summary>
        [DeploymentItem("RssToolkit.dll")]
        [TestMethod()]
        public void PropertyInfoOccurancesTest()
        {
            object target = RssToolkitUnitTest.RssToolkit_Rss_CodeGeneration_PropertyInfoAccessor.CreatePrivate();
            int val = 2;
            RssToolkitUnitTest.RssToolkit_Rss_CodeGeneration_PropertyInfoAccessor accessor = new RssToolkitUnitTest.RssToolkit_Rss_CodeGeneration_PropertyInfoAccessor(target);
            accessor.Occurances = val;

            Assert.AreEqual(val, accessor.Occurances, "RssToolkit.Rss.CodeGeneration.PropertyInfo.Occurances was not set correctly.");
        }
    }
}