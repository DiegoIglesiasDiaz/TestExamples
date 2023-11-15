using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    [TestClass]
    public class AssemblyInitCleanup
    {
        [AssemblyInitialize()]
        public static void AssemblyInitialize(TestContext tc)
        {
            //this code runs before all test in this assembly
            tc.WriteLine("In MyClasses.TestAssemblyInitCleanup.AssemblyInitialize");
        }
        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            //This code runs after all test have run in this assembly
            // TestContext not available
        }
    }
}
