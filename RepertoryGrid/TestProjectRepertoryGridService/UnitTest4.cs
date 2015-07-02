using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting; 
using RDotNet;
using System.Diagnostics;
using OpenRepGridGui.Service;
using OpenRepGridModel.Model;

namespace TestProjectRepertoryGridService
{
    [TestClass]
    public class UnitTest4
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
            Debug.Print("InitializeTest");
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
        public void TestCorrelationOfConstructs()
        {

            ProjectService ps = new ProjectService(R);
            ps.AddInterview((new Interview(ps.CurrentProject)));
            InterviewService IS =ps.InterviewServices.Last();
            IS.CurrentInterview.GridName = "mackay1992";
            IS.GetFromR(  true);

            NumericMatrix m = IS.Correlation(false).AsNumericMatrix();
            /* http://docu.openrepgrid.org/constructs_correlation.html
            ##############################
            Correlation between constructs
            ##############################

            Type of correlation:  pearson 

                                    1    2    3    4    5    6
            Quick - *Slow       1     0.38 0.77 0.13 0.52 0.29
            *Satisfied - Bitter 2          0.18 0.82 0.56 0.29
            Talkative - *Quiet  3               0.14 0.72 0.58
            *Succesful - Loser  4                    0.64 0.47
            Emotional - *Calm   5                         0.92
            *Caring - Selfish   6            
             
             */
            double[,] values = new double[6, 6];
            values[0, 1] = 0.38;
            values[0, 2] = 0.77;
            values[0, 3] = 0.13;
            values[0, 4] = 0.52;
            values[0, 5] = 0.29;

            values[1, 2] = 0.18;
            values[1, 3] = 0.82;
            values[1, 4] = 0.56;
            values[1, 5] = 0.29;

            values[2, 3] = 0.14;
            values[2, 4] = 0.72;
            values[2, 5] = 0.58;

            values[3, 4] = 0.64;
            values[3, 5] = 0.47;

            values[4, 5] = 0.92;
            for (int i = 0; i < 5; i++)
            {
                for (int j = i + 1; j < 6; j++)
                {
                    Assert.IsTrue(Math.Round(m[i, j], 2) == values[i, j]);
                }
            }
            /* http://docu.openrepgrid.org/constructs_correlation.html#root-mean-square-correlation-1
            ##########################################
            Root-mean-square correlation of constructs
            ##########################################

                                                    RMS
            (1) clever - not bright                0.66
            (2) disorganized - organized           0.58
            (3) listens - doesn't hear             0.61
            (4) no clear view - clear view of life 0.46
            (5) understands me - no understanding  0.53
            (6) ambitious - no ambition            0.30
            (7) respected - not respected          0.62
            (8) distant - warm                     0.25
            (9) rather aggressive - not aggressive 0.29

            Average of statistic 0.48 
            Standard deviation of statistic 0.15 
             
             */
            ps.AddInterview((new Interview(ps.CurrentProject)));
            IS = ps.InterviewServices.Last();
            IS.CurrentInterview.GridName = "fbb2003";
            IS.GetFromR(  true);
            DataFrame df = IS.CorrelationRMS(false);
            String[] rowNames = {  
                                "(1) clever - not bright", 
                                "(2) disorganized - organized",
                                "(3) listens - doesn't hear",
                                "(4) no clear view - clear view of life",
                                "(5) understands me - no understanding",
                                "(6) ambitious - no ambition",
                                "(7) respected - not respected",
                                "(8) distant - warm",
                                "(9) rather aggressive - not aggressive"};
            Double[] rms = { 0.66, .58, .61, .46, .53, .30, .62, .25, .29 };

            for (int i = 0; i < 8; i++)
            {
                Assert.IsTrue(df.RowNames[i] == rowNames[i]);
                Assert.IsTrue(Math.Round((double)df[i, 0], 2) == rms[i]);
            }
            /*
             http://docu.openrepgrid.org/constructs_correlation.html#somers-d-1
             Direction: columns are set as dependent
                                                      1    2    3    4    5    6    7    8    9
            (1) clever - not bright              1  1.0 -0.6  0.9 -0.5  0.6  0.2  0.8  0.0 -0.1
            (2) disorganized - organized         2 -0.7  1.0 -0.6  0.4 -0.3 -0.2 -0.7 -0.1 -0.4
            (3) listens - doesn't hear           3  1.0 -0.5  1.0 -0.4  0.8  0.1  0.7  0.0 -0.2
            (4) no clear view - clear view of l  4 -0.6  0.4 -0.5  1.0 -0.2 -0.6 -0.5 -0.2 -0.2
            (5) understands me - no understandin 5  0.8 -0.3  0.9 -0.2  1.0  0.0  0.6  0.0 -0.2
            (6) ambitious - no ambition          6  0.2 -0.2  0.1 -0.5  0.0  1.0  0.3  0.2  0.1
            (7) respected - not respected        7  0.8 -0.7  0.7 -0.4  0.5  0.3  1.0 -0.1  0.0
            (8) distant - warm                   8  0.0 -0.1  0.0 -0.2  0.0  0.2 -0.1  1.0  0.5
            (9) rather aggressi - not aggressive 9 -0.1 -0.4 -0.2 -0.2 -0.2  0.1  0.0  0.5  1.0
             * 
             * constructD(fbb2003)
             */
            values = new double[,]   {
                {  1.0, -0.6,  0.9, -0.5,  0.6,  0.2,  0.8,  0.0, -0.1},
                { -0.7,  1.0, -0.6,  0.4, -0.3, -0.2, -0.7, -0.1, -0.4},
                {  1.0, -0.5,  1.0, -0.4,  0.8,  0.1,  0.7,  0.0, -0.2},
                { -0.6,  0.4, -0.5,  1.0, -0.2, -0.6, -0.5, -0.2, -0.2},
                {  0.8, -0.3,  0.9, -0.2,  1.0,  0.0,  0.6,  0.0, -0.2},
                {  0.2, -0.2,  0.1, -0.5,  0.0,  1.0,  0.3,  0.2,  0.1},
                {  0.8, -0.7,  0.7, -0.4,  0.5,  0.3,  1.0, -0.1,  0.0},
                {  0.0, -0.1,  0.0, -0.2,  0.0,  0.2, -0.1,  1.0,  0.5},
                { -0.1, -0.4, -0.2, -0.2, -0.2,  0.1,  0.0,  0.5,  1.0}
            };

            NumericMatrix sD = IS.ConstructD( );
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.IsTrue(Math.Round(sD[i, j], 1) == values[i, j]);
                }
            }
        }
    }
}
