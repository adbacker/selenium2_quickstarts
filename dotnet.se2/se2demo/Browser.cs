using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using se2demo.Util;
using se2demo.site;

namespace se2demo
{
    public sealed class Browser
    {
        private static readonly Browser instance = new Browser();
        private IWebDriver driver;
        private static string testLogLocation = @"c:\\working\\testlog";

        private Browser()
        {
            
        }

        private static IWebDriver getNewDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            //driver = new ChromeDriver();
           // var driver = new RemoteWebDriver(new Uri("http://abacker:4445/wd/hub"), DesiredCapabilities.Firefox());


            #region tuning the driver
            //set the driver to implicitly wait for 30 seconds before throwing an "I can't find it!"
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(30000));
            #endregion //tuning the driver

            return driver;
        }

        public static Browser Instance
        {
            get
            {   
                if (instance.driver == null)
                {
                    instance.driver = getNewDriver();
                }
                return instance; 
            }
        }

        public static IWebElement Element(By elementFindBy)
        {
            try
            {
                var el = Instance.driver.FindElement(elementFindBy);
                return el;    
            }
            catch (NoSuchElementException e)
            {
                //log.Debug("went looking for element X.  Didn't find it.");
            }
            return null;
        }

        public static IWebDriver Driver()
        {
            return Instance.driver;
        }


        public static void Go(string url)
        {
            Instance.driver.Url = url;
            Instance.driver.Navigate();
        }

        public static void Quit()
        {
            Instance.driver.Quit();
            Instance.driver = null;
        }

        public static void ScreenShot(string name)
        {
            Screenshot ss = ((ITakesScreenshot) Driver()).GetScreenshot();
            //Use it as you want now
            //string screenshot = ss.AsBase64EncodedString;
            //byte[] screenshotAsByteArray = ss.AsByteArray;
            String fileDestinatin = Path.Combine(testLogLocation.SafePathName(), name.SafeFileName());
            ss.SaveAsFile(fileDestinatin, ImageFormat.Png); //use any of the built in image formating
            //ss.ToString();//same as string screenshot = ss.AsBase64EncodedString;
            
        }
    }
}
