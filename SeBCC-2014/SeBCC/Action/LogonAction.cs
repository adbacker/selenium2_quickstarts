using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SeBCC
{
    public class LogonAction : AbstractAction
    {
        public LogonAction(Browser browser) : base(browser)
        {
        }

        public bool Execute(string username, string password)
        {
            var mainPage = new MainPage(_browser);
            var loginPage = new LogonPage(_browser);
            _browser.Go(mainPage.Url);
            mainPage.LogOnLink().Click();
            loginPage.Username().SendKeys("test001");
            loginPage.Password().SendKeys("test001");
            loginPage.LogonBtn().Click();
            
            return mainPage.LogonDisplay().Text.Contains("Welcome test001");    
        }
    }
}
