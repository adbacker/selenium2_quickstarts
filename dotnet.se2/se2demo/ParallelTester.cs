using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.MultiCore.Interfaces;
using NUnit.MultiCore.TestRunner;


namespace se2demo
{

        [TestFixture]
        public class ParallelTester
        {
            [Test]
            public void RunTests()
            {
                new ParallelTestRunner().RunTestsInParallel();
            }
        }
    
}
