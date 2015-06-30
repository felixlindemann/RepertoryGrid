using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using OpenRepGridGui.Service;
using OpenRepGridModel.Model; 

namespace TestProjectRepertoryGridService
{
    [TestClass]
    public class UnitTest6
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
        public void TestPCAOfConstructs()
        {

            ProjectService ps = new ProjectService(R);
            ps.AddInterview((new Interview(ps.CurrentProject)));
            InterviewService IS = ps.InterviewServices.Last();
            IS.CurrentInterview.GridName = "fbb2003";
            IS.GetFromR(true);
            /*
            
            #################
            PCA of constructs
            #################

            Number of components extracted: 3
            Type of rotation: varimax 

            Loadings:
                                                RC1   RC2   RC3  
            clever - not bright                 0.96  0.02  0.25
            disorganized - organized           -0.82 -0.40 -0.17
            listens - doesn't hear              0.92 -0.26  0.12
            no clear view - clear view of life -0.45 -0.15 -0.76
            understands me - no understanding   0.87 -0.07 -0.08
            ambitious - no ambition             0.02  0.13  0.94
            respected - not respected           0.91 -0.01  0.22
            distant - warm                     -0.13  0.74  0.25
            rather aggressive - not aggressive  0.07  0.96  0.00

                            RC1  RC2  RC3
            SS loadings    4.27 1.74 1.69
            Proportion Var 0.47 0.19 0.19
            Cumulative Var 0.47 0.67 0.86

            */
            IS.ConstructPCA(false);
        }

    }
}
