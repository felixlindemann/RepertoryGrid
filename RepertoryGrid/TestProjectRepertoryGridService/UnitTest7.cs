﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting; 
using System.Diagnostics;
using OpenRepGridGui.Service;
using OpenRepGridModel.Model;

namespace TestProjectRepertoryGridService
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für UnitTest7
    /// </summary>
    [TestClass]
    public class UnitTest7
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
        public void TestClustering()
        {

            ProjectService ps = new ProjectService(R);
            ps.AddInterview((new Interview(ps.CurrentProject)));
            InterviewService IS = ps.InterviewServices.Last();
            IS.CurrentInterview.GridName = "bell2010";
            IS.GetFromR( true);
            IS.R.Evaluate(IS.CurrentInterview.GridName);

            Dictionary<String, object> d = new Dictionary<string, object>();
            d.Add("along", 1);
            d.Add("print", false);
            IS.cluster(d);

            IS.R.Evaluate(IS.CurrentInterview.GridName);
        }

    }
}
