using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace se2demo.action
{
    public abstract class BaseAction
    {
        protected Browser browser;

        public BaseAction(Browser browser)
        {
            this.browser = browser;
        }

        public abstract bool Execute(bool verify = false);

    }
}
