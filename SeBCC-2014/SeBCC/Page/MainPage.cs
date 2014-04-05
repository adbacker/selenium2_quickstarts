using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeBCC
{
    public class MainPage : AbstractPage
    {
        public MainPage(Browser browser) : base(browser)
        {
        }

        public string Url = "localhost:54836";

        public IWebElement LogOnLink()
        {
            return _browser.Find(By.LinkText("Log On"));
        }

        public IWebElement LogOffLink()
        {
            return _browser.Find(By.LinkText("Log Off"));
        }

        public IWebElement LogonDisplay()
        {
            return _browser.Find(By.Id("logindisplay"));
        }
    }
}
