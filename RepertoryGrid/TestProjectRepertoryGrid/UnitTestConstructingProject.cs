using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepertoryGrid.classes;
using System.Xml.Linq;
using System.Diagnostics;
using RDotNet;

namespace TestProjectRepertoryGrid
{
    [TestClass]
    public class UnitTestConstructingProject
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

        // [TestMethod]
        public void TestMethodConstruct()
        {

            Project p = Project.getDemo01();
            XElement xml = p.getXML();

            Debug.WriteLine(" ------------ XML 1 ------------ ");
            Debug.WriteLine(xml.ToString());

            Project p2 = new Project(xml);
            XElement xml2 = p.getXML();

            Debug.WriteLine(" ------------ XML 2 ------------ ");
            Debug.WriteLine(xml2.ToString());
            if (xml.ToString() != xml2.ToString())
            {
                throw new Exception("Projects are not equal.");
            }
            if (p.Equals(p2) == false)
            {
                throw new Exception("Projects are not equal BUT XML shows equality.");
            }

        }


        [TestMethod]
        public void TestOpenDemoFromR()
        {
            RHelper.RHelper rEngine = new RHelper.RHelper();

            Project p = new Project();
            p.getDemo(rEngine);
            rEngine.Dispose();
        }

    }
}
