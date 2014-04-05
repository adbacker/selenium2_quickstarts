using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeBCC
{
    public class LogonPage : AbstractPage
    {
        public LogonPage(Browser browser) : base(browser)
        {
        }

        public IWebElement RegisterLink()
        {
            return _browser.Find(By.LinkText("Register"));
        }

        public IWebElement Username()
        {
            return _browser.Find(By.Id("UserName"));
        }

        public IWebElement Password()
        {
            return _browser.Find(By.Id("Password"));
        }

        public IWebElement LogonBtn()
        {
            return _browser.Find(By.XPath(".//input[@value='Log On']"));
        }
    }
}
