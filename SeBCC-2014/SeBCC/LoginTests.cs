using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeBCC.Action;

namespace SeBCC
{
    [TestFixture]
    public class LoginTests
    {
        private Browser browser;

        [SetUp]
        public void SetUp()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            browser = new Browser(driver);
        }


        [Test]
        public void LoginTest()
        {
            var logonAction = new LogonAction(browser);
            var username = "test001";
            var password = username;

            var actionResult = logonAction.Execute(username,password);
            Assert.IsTrue(actionResult);
        }


        [Test]
        public void NewUserTest()
        {
            var rndEnd = new Random();
            var username = "test" + rndEnd.Next(10000);
            var password = username;
            var email = username + "@mailinator.com";
            var registerUserAction = new RegisterUserAction(browser);
            var registerSuccess = registerUserAction.Execute(username, password, email);

            Assert.IsTrue(registerSuccess);
            
            var logoffAction = new LogoffAction(browser);
            logoffAction.Execute();

            var logonAction = new LogonAction(browser);
            var actionResult = logonAction.Execute(username, password);
            Assert.IsTrue(actionResult);
        }

        [TearDown]
        public void TearDown()
        {
            browser.Quit();
        }

    }
}
