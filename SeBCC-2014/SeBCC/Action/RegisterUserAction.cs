using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeBCC.Action
{
    public class RegisterUserAction : AbstractAction
    {
        public RegisterUserAction(Browser browser) : base(browser)
        {

        }

        public bool Execute(string username, string password, string email)
        {
            var mainPage = new MainPage(_browser);
            var loginPage = new LogonPage(_browser);
            var registerPage = new RegisterPage(_browser);

            _browser.Go(mainPage.Url);
            mainPage.LogOnLink().Click();
            loginPage.RegisterLink().Click();
            registerPage.Username().SendKeys(username);
            registerPage.Password().SendKeys(password);
            registerPage.Email().SendKeys(email);
            registerPage.ConfirmPassword().SendKeys(password);
            registerPage.RegisterBtn().Click();

            return mainPage.LogonDisplay().Text.Contains("Welcome "+username);
        }
    }
}
