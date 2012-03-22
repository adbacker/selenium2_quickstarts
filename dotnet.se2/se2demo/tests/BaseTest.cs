using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.MultiCore.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace se2demo.tests
{
    [TestFixture]
    public class BaseTest
    {
        protected Browser browser;
        
        public BaseTest()
        {

        }

        [SetUp]
        public void Init()
        {
            browser = new Browser();
        }

        [TearDown]
        public void Dispose()
        {
            #region extraToppingsWithSprinkles

            //Browser.ScreenShot(TestContext.CurrentContext.Test.Name + DateTime.Now + ".png");
            #endregion //extraToppingsWithSprinkles

            browser.Quit();
        }

    }
}
