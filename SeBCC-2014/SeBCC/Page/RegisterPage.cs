using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeBCC
{
    public class RegisterPage : AbstractPage

    {
        public RegisterPage(Browser browser) : base(browser)
        {
        }

        public IWebElement Username()
        {
            return _browser.Find(By.Id("UserName"));
        }

        public IWebElement Email()
        {
            return _browser.Find(By.Id("Email"));
        }

        public IWebElement Password()
        {
            return _browser.Find(By.Id("Password"));
        }

        public IWebElement ConfirmPassword()
        {
            return _browser.Find(By.Id("ConfirmPassword"));
        }

        public IWebElement RegisterBtn()
        {
            return _browser.Find(By.XPath(".//input[@value='Register']"));
        }
    }
}
