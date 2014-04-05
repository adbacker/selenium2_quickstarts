using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeBCC
{
    public class AbstractAction
    {
        protected Browser _browser;
        
        public AbstractAction(Browser browser)
        {
            _browser = browser;
        }


    }
}
