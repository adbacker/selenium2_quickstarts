using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using se2demo.Util;
using se2demo.site;

namespace se2demo
{
    public sealed class Browser
    {
        private IWebDriver driver;
        private static string testLogLocation = @"c:\\working\\testlog";

        public Browser()
        {
            Driver = getNewDriver();
        }



        private IWebDriver getNewDriver()
        {
            //driver = new FirefoxDriver();
            //driver = new InternetExplorerDriver(@"c:\grid2");
            driver = new ChromeDriver(@"c:\grid2");


            //var capabilities = DesiredCapabilities.HtmlUnitWithJavaScript();
            //var capabilities = DesiredCapabilities.Chrome();
            //driver = new RemoteWebDriver(new Uri("http://localhost:4445/wd/hub"), capabilities);

            #region tuning the driver
            //set the driver to implicitly wait for 30 seconds before throwing an "I can't find it!"
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(30000));
            #endregion //tuning the driver

            return driver;
        }

        public IWebDriver Driver { get; protected set; }


        public IWebElement Element(By elementFindBy)
        {
            try
            {
                var el = Driver.FindElement(elementFindBy);
                return el;    
            }
            catch (NoSuchElementException e)
            {
                //log.Debug("went looking for element X.  Didn't find it.");
            }
            return null;
        }

        public void Go(string url)
        {
            Driver.Url = url;
            Driver.Navigate();
        }

        public void Quit()
        {
            Driver.Quit();
        }


        public void ScreenShot(string name)
        {
            //some drivers don't support taking screenshots - eg, htmlUnit

            Screenshot ss = ((ITakesScreenshot) Driver).GetScreenshot();
            
            //Useful versions for passing it via web services//
            string screenshot = ss.AsBase64EncodedString; 
            byte[] screenshotAsByteArray = ss.AsByteArray;

            String fileDestinatin = Path.Combine(testLogLocation.SafePathName(), name.SafeFileName());
            ss.SaveAsFile(fileDestinatin, ImageFormat.Png); //use any of the built in image formating
            
            //ss.ToString();//same as string screenshot = ss.AsBase64EncodedString;
            
        }
    }
}
