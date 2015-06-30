using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using RepertoryGrid.Service;
using RepertoryGrid.Model;
using RDotNet;

namespace TestProjectRepertoryGridService
{
    [TestClass]
    public class UnitTest5
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

            InterviewService IS = ps.AddInterview((new Interview(ps.CurrentProject)));
            IS.CurrentInterview.GridName = "fbb2003";
            IS.GetFromR(null, true);
            /*
            distance(fbb2003)

            ############################
            Distances between constructs
            ############################

            Distance method:  euclidean 

                                                1     2     3     4     5     6     7     8     9
            (1) clever - not bright     1       10.39  2.45  9.54  3.74  6.78  2.83  8.19  7.68
            (2) disorganiz - organized  2              9.38  4.58  8.49  7.07  9.27  7.14  8.54
            (3) listens - doesn't he    3                    8.89  2.45  7.21  3.46  8.43  8.43
            (4) no clear v - clear view 4                          7.81  7.42  8.31  7.35  7.62
            (5) understand - no underst 5                                7.07  4.00  7.28  7.28
            (6) ambitious - no ambitio  6                                      6.32  5.57  6.56
            (7) respected - not respec  7                                            7.94  6.71
            (8) distant - warm          8                                                  5.10
            (9) rather agg - not aggres 9           
            
             */
            NumericMatrix nm = IS.DistanceConstructs(false);
            double[,] values = new double[9, 9];
            values[0, 1] = 10.39;
            values[0, 2] = 2.45;
            values[0, 3] = 9.54;
            values[0, 4] = 3.74;
            values[0, 5] = 6.78;
            values[0, 6] = 2.83;
            values[0, 7] = 8.19;
            values[0, 8] = 7.68;

            values[1, 2] = 9.38;
            values[1, 3] = 4.58;
            values[1, 4] = 8.49;
            values[1, 5] = 7.07;
            values[1, 6] = 9.27;
            values[1, 7] = 7.14;
            values[1, 8] = 8.54;

            values[2, 3] = 8.89;
            values[2, 4] = 2.45;
            values[2, 5] = 7.21;
            values[2, 6] = 3.46;
            values[2, 7] = 8.43;
            values[2, 8] = 8.43;

            values[3, 4] = 7.81;
            values[3, 5] = 7.42;
            values[3, 6] = 8.31;
            values[3, 7] = 7.35;
            values[3, 8] = 7.62;

            values[4, 5] = 7.07;
            values[4, 6] = 4.00;
            values[4, 7] = 7.28;
            values[4, 8] = 7.28;

            values[5, 6] = 6.32;
            values[5, 7] = 5.57;
            values[5, 8] = 6.56;

            values[6, 7] = 7.94;
            values[6, 8] = 6.71;

            values[7, 8] = 5.10;
            for (int i = 0; i < 8; i++)
            {
                for (int j = i + 1; j < 9; j++)
                {
                    Assert.IsTrue(Math.Round((double)nm[i, j], 2) == values[i, j]);
                }
            }
        }

    }
}
