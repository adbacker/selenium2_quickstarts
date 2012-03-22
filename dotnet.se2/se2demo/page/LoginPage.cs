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
        public LoginPage(Browser browser) : base(browser)
        {
            
        }

        public IWebElement txtUsername()
        {
            return El(By.Id("username"));
        }

        public IWebElement txtPassword()
        {
            return El(By.Id("password"));
        }

        public IWebElement btnLogOn()
        {
            return El(By.XPath("//input[@value='Log On']"));
        }

        public IWebElement logOnErrorBadUsernameOrPassword()
        {
            return El(By.XPath("//div[@class='validation-summary-errors']/ul/li"));
        }

        public string expectedBadUsernameOrPasswordText()
        {
            return "The username or password provided is incorrect.";
        }
    }
}
