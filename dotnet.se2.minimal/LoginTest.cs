using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;


namespace se2.dotnet.minimal
{
    [NUnit.Framework.TestFixture]
    public class LoginTest
    {

        #region setup
//
//        private IWebDriver driver;
//        
//        [SetUp]
//        public void Init()
//        {
//            driver = new ChromeDriver(@"c:\grid2");
//        }
        #endregion setup


        [Test]
        public void SimpleLoginTest()
        {
                IWebDriver driver;
                //driver = new FirefoxDriver(); 
               
                //internet explorer needs the path to it's
                //helper executable ...but don't worry, you won't
                //want to use IE for reasons that'll become very 
                //evident...!
                //driver = new InternetExplorerDriver(@"c:\grid2");
                
            
                //chrome needs chromedriver.exe ... parameter is the PATH
                //to wherever the .exe is...
                driver = new ChromeDriver(@"c:\grid2");


                #region waitforit..
                //sometimes selenium jumps the gun and declares an element isn't available
                //when, if it'd just wait a second (or 10) the element would be available.
                //here we tell selenium to hold it's horses and wait a cotton pickin' minute
                //if it can't find something, wait up to 10 seconds for it to appear
                //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                #endregion //waitforit..

                driver.Url = "http://localhost:54836";
                driver.Navigate();
                
                var loginLink = driver.FindElement(By.LinkText("Log On"));

                Assert.IsNotNull(loginLink);
     

                #region i can haz login?
                /*loginLink.Click();    
                var usernameEntry = driver.FindElement(By.Id("UserName"));
                var passwordEntry = driver.FindElement(By.Id("Password"));
                var logOnButton = driver.FindElement(By.XPath("//input[@value='Log On']"));

                Assert.NotNull(usernameEntry);
                Assert.NotNull(passwordEntry);
                Assert.NotNull(logOnButton);

                usernameEntry.SendKeys("test002");
                passwordEntry.SendKeys("test002");
                logOnButton.Click();



                var logoffLink = driver.FindElement(By.LinkText("Log Off"));
                Assert.NotNull(logoffLink,"log off element not found");    
            */
                #endregion i can haz login?
                
            
                driver.Close();
                driver.Quit();
        }
    }
}
