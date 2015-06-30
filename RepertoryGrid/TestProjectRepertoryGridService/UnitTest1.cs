using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepertoryGrid.Service;
using RepertoryGrid.Model;
using System.Diagnostics;
using RDotNet;

namespace TestProjectRepertoryGridService
{
    [TestClass]
    public class UnitTest1
    {

        private TestContext testContextInstance;
        private RHelper.RHelper R;

        private void R_Log(RHelper.RExececutedEventArgs e)
        {

            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Debug.Print("{0}", e.RCmd);
            if (e.Output.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Debug.Print("Result:\n{0}", e.Output);
            }

            Console.ForegroundColor = c;
        }

        [TestInitialize]
        public void InitializeTest()
        {
            this.R = new RHelper.RHelper();
            this.R.rExec += new RHelper.RExececutedEventHandler(R_Log);
            this.R.Evaluate("library(OpenRepGrid)");
            Debug.Print("Disposed"); 
        }
         
        [TestCleanup]
        public void CleanupTest()
        {
            this.R.Dispose();
            Debug.Print("CleanupTest");
        }

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
        public void TestOpenDemoFromR()
        {

            ProjectService ps = new ProjectService(R);
            ps.getDemo(null);
            Assert.IsTrue(ps.CurrentProject.Interviews.Count == ps.DemoData.Keys.Count);

            for (int i = 0; i < ps.CurrentProject.Interviews.Count; i++)
            {
                Assert.IsTrue(ps.CurrentProject.Interviews[i].GridName == ps.DemoData.Keys.ToList()[i]);
            }
        }
         
    }
}
