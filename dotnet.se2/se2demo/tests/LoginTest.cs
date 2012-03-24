using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.MultiCore.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using se2demo.action;
using se2demo.site;

namespace se2demo.tests
{
    [Parallelizable]
    public class LoginTest : BaseTest
    {


        #region unrefactored login test
        //[Test]
        //public void TestLoginFirstTry()
        //{
        //    IWebDriver driver;
            
        //    //driver = new FirefoxDriver(); 

        //    //chromedriver needs chromedriver.exe ... parameter is the PATH
        //    //to wherever the .exe is...
        //    driver = new ChromeDriver(@"c:\grid2") {Url = MainPage.Url};

        //    driver.Navigate();
        //    var loginLink = driver.FindElement(By.LinkText("Log On"));
        //    Assert.IsNotNull(loginLink);
 
        //    loginLink.Click();

        //    var usernameEntry = driver.FindElement(By.Id("username"));
        //    var passwordEntry = driver.FindElement(By.Id("password"));
        //    var logOnButton = driver.FindElement(By.XPath("//input[@value='Log On']"));

        //    Assert.NotNull(usernameEntry);
        //    Assert.NotNull(passwordEntry);
        //    Assert.NotNull(logOnButton);

        //    usernameEntry.SendKeys("test002");
        //    passwordEntry.SendKeys("pass002");
        //    logOnButton.Click();

        //    var welcomeUser = driver.FindElement(By.XPath("//div[@id='logindisplay']/b")).Text;
        //    Assert.IsTrue(welcomeUser.Equals("test002"));

        //    driver.Close();

        //}
        #endregion //unrefactored login test

        #region login test refactor 1

        //cleaner than the unrefactored test...but still has problems
        //test has to know *how* to do stuff...which means *all* tests have to know how to do the 
        //same things...(eg, have to write out the "login" functionality multiple times
        [Test]
        public void TestLoginRefactor2()
        {
            var username = "test002";
            var password = "pass002";

            var mainPage = new MainPage(browser);
            var loginPage = new LoginPage(browser);

            mainPage.NavTo();

            mainPage.linkLogOn().Click();
            loginPage.txtUsername().SendKeys(username);
            loginPage.txtPassword().SendKeys(password);
            loginPage.btnLogOn().Click();

            //string foundUser = mainPage.strWelcomeUserText().Text;
            string foundUser = mainPage.LoggedInUser();

            var loginSuccess = username.Equals(foundUser);
            Assert.True(loginSuccess);

            //Assert.IsTrue(username.Equals(foundUser),"expected user name didn't match found");

        }

        #endregion //login test refactor 1


        #region pageObject login test (refactor 3)

        [Test]
        public void TestLoginPageObject()
        {
            var username = "test002";
            var password = "pass002";
            var loginAction = new LoginAction(browser, username, password);

            var loginSuccess = loginAction.Execute(true);

            Assert.True(loginSuccess, "expected user name didn't match found");
        }


        [Test]
        public void TestBadPasswordLoginFail()
        {
            var username = "test002";
            var password = "badpassword";
            var loginAction = new LoginAction(browser, username, password);
            
            var loginSuccess = loginAction.Execute(true);

            Assert.False(loginSuccess, "user shows as logged in with bad password");
            
            //(this is why we made the page objects available in the action...)
            var foundBadPasswordError = loginAction.LoginPage.logOnErrorBadUsernameOrPassword();
            
            //first make sure the returned element isn't null before we try and retrieve the text
            Assert.NotNull(foundBadPasswordError);

            var expectedBadMsg = loginAction.LoginPage.expectedBadUsernameOrPasswordText();

            Assert.True(expectedBadMsg.Equals(foundBadPasswordError.Text),
                "Bad password error did not match expected");
        }

        #endregion pageObject login test (refactor 3)


    }
}


