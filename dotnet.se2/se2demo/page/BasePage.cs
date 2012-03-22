using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support;

namespace se2demo.site
{
    public abstract class BasePage
    {
        protected string mainUrl;
        protected Browser browser;

        public BasePage(Browser browser)
        {
            this.browser = browser;
        }


        public void NavTo()
        {
            browser.Go(mainUrl);
        }

        public IWebElement El(By findby)
        {
            return browser.Element(findby);
        }

    }
}
