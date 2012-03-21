using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace se2.dotnet.minimal
{
    [TestFixture]
    public class LoginTest
    {
        [Test]
        public void SimpleLoginTest()
        {

                IWebDriver driver;

                driver = new FirefoxDriver(); 

                //chromedriver needs chromedriver.exe ... parameter is the PATH
                //to wherever the .exe is...
                //driver = new ChromeDriver (@"c:\grid2") {Url = MainPage.Url};

                driver.Url = "http://abacker:2000";         
                driver.Navigate();
                var loginLink = driver.FindElement(By.LinkText("Log On"));
                Assert.IsNotNull(loginLink);

                loginLink.Click();

                var usernameEntry = driver.FindElement(By.Id("username"));
                var passwordEntry = driver.FindElement(By.Id("password"));
                var logOnButton = driver.FindElement(By.XPath("//input[@value='Log On']"));

                Assert.NotNull(usernameEntry);
                Assert.NotNull(passwordEntry);
                Assert.NotNull(logOnButton);

                usernameEntry.SendKeys("test002");
                passwordEntry.SendKeys("pass002");
                logOnButton.Click();

                var welcomeUser = driver.FindElement(By.XPath("//div[@id='logindisplay']/b")).Text;
                Assert.IsTrue(welcomeUser.Equals("test002"));

                driver.Close();
        }
    }
}
