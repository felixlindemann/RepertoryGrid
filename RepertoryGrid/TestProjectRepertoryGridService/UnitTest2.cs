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
    public class UnitTest2
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
        public void TestStatsConstructs()
        {

            ProjectService ps = new ProjectService(R);
            InterviewService IS = ps.AddInterview((new Interview(ps.CurrentProject)));
            IS.CurrentInterview.GridName = "fbb2003";
            IS.GetFromR(null, true);

            /*
            ####################################
            Desriptive statistics for constructs
            ####################################

                                        vars n mean   sd median trimmed  mad min max range  skew kurtosis   se
            (1) clever - not bright        1 8 3.75 2.31    4.0    3.75 2.97   1   7     6  0.02    -1.84 0.82
            (2) disorganiz - organized     2 8 4.00 1.77    4.5    4.00 2.22   2   6     4 -0.13    -1.96 0.63
            (3) listens - doesn't he       3 8 3.50 2.14    3.0    3.50 2.22   1   7     6  0.35    -1.40 0.76
            (4) no clear v - clear view    4 8 4.38 1.60    4.0    4.38 1.48   3   7     4  0.38    -1.68 0.56
            (5) understand - no underst    5 8 3.50 1.85    2.5    3.50 0.74   2   6     4  0.41    -1.90 0.65
            (6) ambitious - no ambitio     6 8 4.50 1.51    4.5    4.50 2.22   3   7     4  0.33    -1.58 0.53
            (7) respected - not respec     7 8 3.25 1.75    3.0    3.25 1.48   1   6     5  0.23    -1.67 0.62
            (8) distant - warm             8 8 4.12 1.96    4.0    4.12 1.48   1   7     6 -0.05    -1.46 0.69
            (9) rather agg - not aggres    9 8 3.62 1.92    3.0    3.62 2.22   1   7     6  0.36    -1.25 0.68
             */
            DataFrame df = IS.StatsConstructs(false);
            Assert.IsTrue(df.RowNames[0] == "(1) clever - not bright");
            Assert.IsTrue(df.RowNames[1] == "(2) disorganiz - organized");
            Assert.IsTrue(df.RowNames[8] == "(9) rather agg - not aggres");

            Assert.IsTrue(Math.Round((double)df[0, 2], 2) == 3.75);
            Assert.IsTrue(Math.Round((double)df[0, 3], 2) == 2.31);
            Assert.IsTrue(Math.Round((double)df[0, 4], 2) == 4.0);
            Assert.IsTrue(Math.Round((double)df[0, 5], 2) == 3.75);
            Assert.IsTrue(Math.Round((double)df[0, 6], 2) == 2.97);
            Assert.IsTrue(Math.Round((double)df[0, 7], 2) == 1.0);
            Assert.IsTrue(Math.Round((double)df[0, 8], 2) == 7.0);
            Assert.IsTrue(Math.Round((double)df[0, 9], 2) == 6.0);
            Assert.IsTrue(Math.Round((double)df[0, 10], 2) == 0.02);
            Assert.IsTrue(Math.Round((double)df[0, 11], 2) == -1.84);
            Assert.IsTrue(Math.Round((double)df[0, 12], 2) == 0.82);

            /*
             
            ##################################
            Desriptive statistics for elements
            ##################################

                                     vars n mean   sd median trimmed  mad min max range  skew kurtosis   se
            (1) self                    1 9 3.44 1.81      3    3.44 1.48   1   6     5  0.30    -1.60 0.60
            (2) my father               2 9 3.00 1.87      3    3.00 1.48   1   6     5  0.61    -1.22 0.62
            (3) an old flame            3 9 4.89 1.45      5    4.89 1.48   3   7     4 -0.05    -1.72 0.48
            (4) an ethical person       4 9 3.11 0.93      3    3.11 0.00   2   5     3  0.65    -0.54 0.31
            (5) my mother               5 9 4.11 1.69      5    4.11 2.97   2   7     5  0.12    -1.44 0.56
            (6) a rejected teacher      6 9 4.33 2.35      5    4.33 2.97   1   7     6 -0.15    -1.89 0.78
            (7) as I would love to b    7 9 3.44 2.35      3    3.44 2.97   1   7     6  0.19    -1.82 0.78
            (8) a pitied person         8 9 4.44 1.42      5    4.44 1.48   2   7     5 -0.02    -0.75 0.47

             */
            df = IS.StatsElements(false);
            Assert.IsTrue(df.RowNames[0] == "(1) self");
            Assert.IsTrue(df.RowNames[1] == "(2) my father");
            Assert.IsTrue(df.RowNames[7] == "(8) a pitied person");

            Assert.IsTrue(Math.Round((double)df[0, 2], 2) == 3.44);
            Assert.IsTrue(Math.Round((double)df[0, 3], 2) == 1.81);
            Assert.IsTrue(Math.Round((double)df[0, 4], 2) == 3.0);
            Assert.IsTrue(Math.Round((double)df[0, 5], 2) == 3.44);
            Assert.IsTrue(Math.Round((double)df[0, 6], 2) == 1.48);
            Assert.IsTrue(Math.Round((double)df[0, 7], 2) == 1.0);
            Assert.IsTrue(Math.Round((double)df[0, 8], 2) == 6.0);
            Assert.IsTrue(Math.Round((double)df[0, 9], 2) == 5.0);
            Assert.IsTrue(Math.Round((double)df[0, 10], 2) == 0.30);
            Assert.IsTrue(Math.Round((double)df[0, 11], 2) == -1.60);
            Assert.IsTrue(Math.Round((double)df[0, 12], 2) == 0.60);

        }
    }
}
