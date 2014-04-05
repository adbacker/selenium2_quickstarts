using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SeBCC.Action
{
    public class LogoffAction : AbstractAction
    {
        public LogoffAction(Browser browser) : base(browser)
        {
        }

        public bool Execute()
        {
            var mainPage = new MainPage(_browser);
            mainPage.LogOffLink().Click();
            return (mainPage.LogonDisplay().Text.Contains("Log On"));
        }
    }
}
