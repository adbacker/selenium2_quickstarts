using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace se2demo.site
{
    public class MainPage : BasePage
    {   
        
        public MainPage(Browser browser) : base(browser)
        {
            mainUrl = "http://abacker:2000";
        }


        public IWebElement linkLogOn()
        {
            return El(By.LinkText("Log On"));
        }



        public IWebElement linkLogOff()
        {
            return El(By.LinkText("Log Off"));
        }


        //find by xpath
        public IWebElement strWelcomeUserText()
        {
            return El(By.XPath("//div[@id='logindisplay']/b"));
        }

        /// <summary>
        /// The logged in user name as determined by the "Welcome [User]" header
        /// </summary>
        /// <returns>
        /// true if found
        /// null if not
        /// </returns>
        /// 
        public String LoggedInUser()
        {
            string user = null;


            if (null != strWelcomeUserText())
            {
                user = strWelcomeUserText().Text;
            }
            return user;
        }

    }
}
