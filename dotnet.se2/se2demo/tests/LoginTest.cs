using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.MultiCore.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
        public void TestLogin()
        {
            var username = "test002";
            var password = "pass002";

            MainPage.NavTo();

            MainPage.LogOnLink().Click();

            LoginPage.txtUserName().SendKeys(username);
            LoginPage.txtPasswordEntry().SendKeys(password);
            LoginPage.logOnButton().Click();

            string foundUser = MainPage.LoggedInUser();

            Assert.IsTrue(username.Equals(foundUser),"expected user name didn't match found");

        }

        #endregion //login test refactor 1


        #region pageObject login test (refactor 3)
        [Test]
        public void TestLoginPageObject()
        {
            var username = "test002";
            var password = "pass002";

            var loginSuccess = MainPage.LogIn(username, password);     
            Assert.True(loginSuccess);


            //string foundUser = MainPage.LoggedInUser();
            //Assert.IsTrue(username.Equals(foundUser));      
        }

        [Test]
        public void TestBadLoginPageObject()
        {
            var username = "test002";
            var password = "badpassword";

            var loginSuccess = MainPage.LogIn(username, password);
            Assert.False(loginSuccess);
            var foundBadPasswordError = LoginPage.logOnErrorBadUsernameOrPasswordMessage();
            Assert.NotNull(foundBadPasswordError);
            Assert.True(LoginPage.expectedBadUsernameOrPasswordText().Equals(foundBadPasswordError),"Bad password error did not match expected");
        }

        #endregion pageObject login test (refactor 3)


    }
}


