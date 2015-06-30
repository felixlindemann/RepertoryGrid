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
    public class UnitTest3
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
        public void TestMakeGrid()
        {
            String cmd = "args <- list( name=c(\"element_1\", \"element_2\", \"element_3\", \"element_4\"),\n" +
                         "\tl.name=c(\"left_1\", \"left_2\", \"left_3\"),\n" +
                         "\tr.name=c(\"right_1\", \"right_2\", \"right_3\"),\n" +
                         "\tscores=c(\n\t" +
                         "\t1,0,1,0,\n\t" +
                         "\t1,1,1,0,\n\t" +
                         "\t1,0,1,0)\n  )\n" +
                         "# make grid object \n" +
                         "x <- makeRepgrid(args) \n" +
                         "x <- setScale(x, -3, 3)\n" +
                         "x";

            ProjectService ps = new ProjectService(R);
             ps.AddInterview((new Interview(ps.CurrentProject)));
            InterviewService IS =ps.InterviewServices.Last();
            IS.CurrentInterview.GridName = "x";
            IS.R.Evaluate(cmd, false);
            IS.GetFromR(  true);

            Assert.IsTrue(IS.CurrentInterview.Elements[0].Name == "element_1");
            Assert.IsTrue(IS.CurrentInterview.Elements[1].Name == "element_2");
            Assert.IsTrue(IS.CurrentInterview.Elements[2].Name == "element_3");
            Assert.IsTrue(IS.CurrentInterview.Elements[3].Name == "element_4");

            Assert.IsTrue(IS.CurrentInterview.Constructs[0].ContrastPol == "left_1");
            Assert.IsTrue(IS.CurrentInterview.Constructs[0].ConstructPol == "right_1");

            Assert.IsTrue(IS.CurrentInterview.Constructs[1].ContrastPol == "left_2");
            Assert.IsTrue(IS.CurrentInterview.Constructs[1].ConstructPol == "right_2");


            Assert.IsTrue(IS.CurrentInterview.Constructs[2].ContrastPol == "left_3");
            Assert.IsTrue(IS.CurrentInterview.Constructs[2].ConstructPol == "right_3");

            List<Element> elements = IS.CurrentInterview.Elements;
            List<Construct> constructs = IS.CurrentInterview.Constructs;

            int[,] scores = { { 1, 0, 1, 0 }, { 1, 1, 1, 0 }, { 1, 0, 1, 0 } };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.IsTrue(IS.getScore(elements[j], constructs[i]).ScaleItemId == scores[i, j]);
                }
            }
            IS.SetToR(false,"y");
            ps.AddInterview((new Interview(ps.CurrentProject)));
            InterviewService ISn = ps.InterviewServices.Last();
            ISn.CurrentInterview.GridName = "y";
            ISn.GetFromR(   true);

            Assert.IsTrue(IS.CurrentInterview.Elements.Count == 4);
            Assert.IsTrue(ISn.CurrentInterview.Elements.Count == 4);
            Assert.IsTrue(IS.CurrentInterview.Constructs.Count == 3);
            Assert.IsTrue(ISn.CurrentInterview.Constructs.Count == 3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.IsTrue(
                        IS.getScore(elements[j], constructs[i]).ScaleItemId ==
                       ISn.getScore(elements[j], constructs[i]).ScaleItemId);
                }
            }
        }
    }
}
