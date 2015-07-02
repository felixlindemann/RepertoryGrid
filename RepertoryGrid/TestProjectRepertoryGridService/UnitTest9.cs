using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TestProjectRepertoryGridService
{
    [TestClass]
    public class UnitTest9
    {
        private TestContext testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void TestMethod1()
        {

            object o = new int[] { 2, 10 };

            Debug.Print("o.GetType().ToString(): {0}", o.GetType().ToString());
            Assert.IsTrue(o.GetType() == typeof(int[]));
        }

        [TestMethod]
        public void TestMethod2()
        {

            object o = new double[] { 2, 10 };

            Debug.Print("o.GetType().ToString(): {0}", o.GetType().ToString());
            Assert.IsTrue(o.GetType() == typeof(double[]));
        }
    }
}
