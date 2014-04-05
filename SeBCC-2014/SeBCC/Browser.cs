using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeBCC
{
    public class Browser
    {
        private IWebDriver _driver;
        
        public Browser(IWebDriver driver)
        {
            _driver = driver;
            _driver.Manage().Window.Maximize();
        }

        public void Go(string Url)
        {
            _driver.Url = Url;
            _driver.Navigate();
        }

        public IWebElement Find(By by)
        {
            return _driver.FindElement(by);
        }

        public void Quit()
        {
            _driver.Quit();
        }
    }
}
