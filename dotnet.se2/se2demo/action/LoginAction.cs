using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using se2demo.site;

namespace se2demo.action
{
    public class LoginAction : BaseAction
    {
        public MainPage MainPage { get; protected set; }
        public LoginPage LoginPage { get; protected set; }

        private string username;
        private string password;
        
        
        public LoginAction(Browser browser, string username, string password) : base(browser)
        {
            MainPage = new MainPage(browser);
            LoginPage = new LoginPage(browser);
            this.username = username;
            this.password = password;
        }


        private bool VerifyLogin()
        {
            string foundUser = string.Empty;
            try
            {
                foundUser = MainPage.strWelcomeUserText().Text;
            }
            catch(NullReferenceException e)
            {
                //in the case of a failed login, the username element
                //just isn't there..catch this
            }

            return username.Equals(foundUser);
        }

        public override bool Execute(bool verify = false)
        {

            MainPage.NavTo();

            MainPage.linkLogOn().Click();
            LoginPage.txtUsername().SendKeys(username);
            LoginPage.txtPassword().SendKeys(password);
            LoginPage.btnLogOn().Click();

            //if we've been asked to verify the action succeeded
            if (verify)
            {
                return VerifyLogin();  
            }
            return false;
        }
    }
}
