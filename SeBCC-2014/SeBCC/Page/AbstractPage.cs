using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeBCC
{
    public class AbstractPage
    {
        protected Browser _browser;
        
        public AbstractPage(Browser browser)
        {
            _browser = browser;
        }
    }
}
