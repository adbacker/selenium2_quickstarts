using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using se2demo.tests;

namespace se2demo.site
{
    public class LoginPage : BasePage
    {
        
        public static By usernameEntryFindBy()
        {
            return By.Id("username");
        }

        public static IWebElement txtUserName()
        {
            return Browser.Element(usernameEntryFindBy());
        }

        public static By passwordEntryFindBy()
        {
            return By.Id("password");
        }
        public static IWebElement txtPasswordEntry()
        {
            return Browser.Element(passwordEntryFindBy());
        }

        public static By logOnButtonFindBy()
        {
            return By.XPath("//input[@value='Log On']");
        }
        public static IWebElement logOnButton()
        {
            return Browser.Element(logOnButtonFindBy());
        }

        public static By logOnErrorBadUsernameOrPasswordFindBy()
        {
            return By.XPath("//div[@class='validation-summary-errors']/ul/li");
        }
        public static string logOnErrorBadUsernameOrPasswordMessage()
        {
            return Browser.Element(logOnErrorBadUsernameOrPasswordFindBy()).Text;
        }
        public static string expectedBadUsernameOrPasswordText()
        {
            return "The username or password provided is incorrect.";
        }
    }
}
