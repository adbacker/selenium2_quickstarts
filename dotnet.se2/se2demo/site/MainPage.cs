using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace se2demo.site
{
    public class MainPage
    {
        public static void NavTo()
        {
            Browser.Go(Url);
        }
        
        public static String Url = "http://abacker:2000";
        
        //find by link text
        public static By LogOnLinkFindBy()
        {
            return By.LinkText("Log On");
        }
        public static IWebElement LogOnLink()
        {
            return Browser.Element(LogOnLinkFindBy());
        }

        public static By LogOffLinkFindBy()
        {
            return By.LinkText("Log Off");
        }
        public static IWebElement LogOffLink()
        {
            return Browser.Element(LogOffLinkFindBy());
        }

        //find by xpath
        public static By WelcomeUserTextFindBy()
        {
            return By.XPath("//div[@id='logindisplay']/b");
        }

        /// <summary>
        /// The logged in user name as determined by the "Welcome [User]" header
        /// </summary>
        /// <returns>
        /// true if found
        /// null if not
        /// </returns>
        public static String LoggedInUser()
        {
            string user = null;

            var welcomeUserElement = Browser.Element(WelcomeUserTextFindBy());
            if (null != welcomeUserElement)
            {
                user = welcomeUserElement.Text;
            }
            return user;
        }


        #region methods for pageObject pattern

        public static bool LogIn(string username, string password)
        {
            MainPage.NavTo();

            MainPage.LogOnLink().Click();

            LoginPage.txtUserName().SendKeys(username);
            LoginPage.txtPasswordEntry().SendKeys(password);
            LoginPage.logOnButton().Click();
            return VerifyLogin(username);
        }

        private static bool VerifyLogin(string username)
        {
            string foundUser = MainPage.LoggedInUser();
            return username.Equals(foundUser);
        }

        #endregion //methods for pageObject pattern





    }
}
