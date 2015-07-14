using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenRepGridModel.Model;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;
using LimeTree.BaseClasses;

namespace OpenRepGridGui.Service
{
    public class ProjectService : NotifyPropertyChanged, IDisposable
    {

        #region Variables

        private RHelper.RHelper rEngine;
        private Project project;
        private List<InterviewService> interviewServices = new List<InterviewService>();

        private Boolean showscale = true;
        private Boolean showmeta = true;
        private Boolean cno = true;
        private Boolean eno = true;
        private int showtrim = 30;
        private int showcut = 30; 

        #endregion

        #region Properties
         

        [Browsable(false)]
        public List<InterviewService> InterviewServices
        {
            get { return interviewServices; }
            set { SetPropertyField("InterviewServices", ref interviewServices, value); }
        }


        [Browsable(false)]
        public Project CurrentProject
        {
            get { return project; }
            set
            {
                SetPropertyField("CurrentProject", ref project, value);
                this.CurrentProject.PropertyChanged += new PropertyChangedEventHandler(CurrentProject_PropertyChanged);
                this.InterviewServices = new List<InterviewService>();
                foreach (Interview interview in this.CurrentProject.Interviews)
                {
                    InterviewService IS = new InterviewService(this, interview);
                    this.InterviewServices.Add(IS);
                }
                this.FirePropertyChanged("InterviewServices");
                this.FirePropertyChanged("CurrentProject");
            }
        }

        void CurrentProject_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.FirePropertyChanged("CurrentProject");
        }

        [Browsable(false)]
        public RHelper.RHelper R
        {
            get { return rEngine; }
            set { rEngine = value; }
        }

        #region Settings

        [CategoryAttribute("R-Console Settings"), ReadOnlyAttribute(false), DescriptionAttribute("Sink diverts R output to a connection. controls the maximum number of columns on a line used in printing vectors, matrices and arrays, and when filling by cat."), DefaultValueAttribute(30)]
        public int SinkWidth
        {
            get
            {
                return this.rEngine.SinkWidth;
            }
            set
            {
                this.rEngine.SinkWidth = value;

            }
        }

        [CategoryAttribute("R-Console Settings"), ReadOnlyAttribute(false), DescriptionAttribute("R.Net installs a console device that writes to Console.Out. Unfortunately, R does not autoprint when embedded, so you have to wrap things in a print call."), DefaultValueAttribute(true)]
        public Boolean AutoPrint
        {
            get
            {
                return this.rEngine.AutoPrint;
            }
            set
            {
                this.rEngine.AutoPrint = value;

            }
        }
        //
        [CategoryAttribute("R-Console Settings"), ReadOnlyAttribute(false), DescriptionAttribute("Describes where The RHome Folder is."), DefaultValueAttribute(@"c:\Program Files\R\R-3.1.2")]
        public String RHome
        {
            get { return this.rEngine.RHome; }
            set { this.rEngine.RHome = value; }
        }

        [CategoryAttribute("OpenRepGrid Settings"), ReadOnlyAttribute(false), DescriptionAttribute("30 (number of chars to trim strings to)"), DefaultValueAttribute(30)]
        public int ShowTrim
        {
            get
            {
                return showtrim;
            }
            set
            {
                showtrim = value;
                this.rEngine.Evaluate(string.Format("settings(show.trim={0})", value));

            }
        }

        [CategoryAttribute("OpenRepGrid Settings"), ReadOnlyAttribute(false), DescriptionAttribute("20 (max no of chars on the sides of a grid)"), DefaultValueAttribute(20)]
        public int ShowCut
        {
            get
            {
                return showcut;
            }
            set
            {
                showcut = value;
                this.rEngine.Evaluate(string.Format("settings(show.cut={0})", value));

            }
        }

        [CategoryAttribute("OpenRepGrid Settings"), ReadOnlyAttribute(false), DescriptionAttribute("TRUE (show grid scale info?)"), DefaultValueAttribute(true)]
        public Boolean ShowScale
        {
            get { return showscale; }
            set
            {
                showscale = value;
                this.rEngine.Evaluate(string.Format("settings(show.scale={0})", value ? "TRUE" : "FALSE"));
            }
        }

        [CategoryAttribute("OpenRepGrid Settings"), ReadOnlyAttribute(false), DescriptionAttribute("TRUE (show grid meta data?)"), DefaultValueAttribute(true)]
        public Boolean ShowMeta
        {
            get { return showmeta; }
            set
            {
                showmeta = value;
                this.rEngine.Evaluate(string.Format("settings(show.meta={0})", value ? "TRUE" : "FALSE"));
            }
        }

        [CategoryAttribute("OpenRepGrid Settings"), ReadOnlyAttribute(false), DescriptionAttribute("TRUE (print construct id?)"), DefaultValueAttribute(true)]
        public Boolean PrintConstructId
        {
            get { return cno; }
            set
            {
                cno = value;
                this.rEngine.Evaluate(string.Format("settings(cno={0})", value ? "TRUE" : "FALSE"));
            }
        }

        [CategoryAttribute("OpenRepGrid Settings"), ReadOnlyAttribute(false), DescriptionAttribute("TRUE (print element id?)"), DefaultValueAttribute(true)]
        public Boolean PrintElementId
        {
            get { return eno; }
            set
            {
                eno = value;
                this.rEngine.Evaluate(string.Format("settings(eno={0})", value ? "TRUE" : "FALSE"));
            }
        }

        #endregion

        #endregion

        #region Constructor

        public ProjectService(RHelper.RHelper r)
        {
            this.rEngine = r;
            this.CurrentProject = new Project();

            this.rEngine.Evaluate("library(OpenRepGrid)");

            this.ShowTrim = this.ShowTrim;
            this.ShowCut = this.ShowCut;
            this.ShowScale = this.ShowScale;
            this.ShowMeta = this.ShowMeta;
            this.PrintConstructId = this.PrintConstructId;
            this.PrintElementId = this.PrintElementId;
         
        }
         

        #endregion

        #region Methods

        public void Save(FileInfo f)
        {
            XElement x = CurrentProject.getXML();
            x.Add(new XAttribute("ShowTrim", this.ShowTrim));
            x.Add(new XAttribute("ShowCut", this.ShowCut));
            x.Add(new XAttribute("ShowScale", this.ShowScale));
            x.Add(new XAttribute("ShowMeta", this.ShowMeta));
            x.Add(new XAttribute("PrintConstructId", this.PrintConstructId));
            x.Add(new XAttribute("PrintElementId", this.PrintElementId));
            x.Add(new XAttribute("AutoPrint", this.R.AutoPrint));
            x.Save(f.FullName);
            this.CurrentProject.ResetHasChanges();
        }

        public void LoadDemoInterview(String gridName)
        {
            addGridFromR(gridName, "");
        }

        public void AddInterview()
        {
            Interview interview = new Interview(this.CurrentProject);
            interview.GridName = "grid_" + Math.Abs(interview.Id.GetHashCode());
            interview.Proband = "<Proband>";

            AddInterview(interview);
        }

        public void AddInterview(Interview i)
        {
            this.CurrentProject.Interviews.Add(i);
            InterviewService IS = new InterviewService(this, i);
            IS.defineDefaultScale();
            this.InterviewServices.Add(IS);
            this.FirePropertyChanged("CurrentProject");
        }

        public void RemoveInterview(int i)
        {
            Interview interview = this.CurrentProject.Interviews[i];
            RemoveInterview(interview);
        }

        public void RemoveInterview(Interview i)
        {

            this.InterviewServices.RemoveAll(x => x.CurrentInterview.Id.Equals(i.Id));
            this.CurrentProject.Interviews.RemoveAll(x => x.Id.Equals(i.Id));
            this.CurrentProject.FirePropertyChanged("Interviews");
            this.FirePropertyChanged("CurrentProject");

        }

        public void ImportFelixLindemann(FileInfo f)
        {
            if (f.Exists == false) throw new FileNotFoundException();
            XElement xml = XElement.Load(f.FullName);
            ImportFelixLindemann(xml);
        }

        public void ImportFelixLindemann(XElement xml)
        {
            if (xml.Name == "Project")
            {
                this.CurrentProject = new Project(xml);
                if ((string)xml.Attribute("ShowTrim") != null)
                {
                    this.ShowTrim = int.Parse(xml.Attribute("ShowTrim").Value);
                }
                if ((string)xml.Attribute("ShowCut") != null)
                {
                    this.ShowCut = int.Parse(xml.Attribute("ShowCut").Value);
                }
                if ((string)xml.Attribute("ShowScale") != null)
                {
                    this.ShowScale = Boolean.Parse(xml.Attribute("ShowScale").Value);
                }
                if ((string)xml.Attribute("ShowMeta") != null)
                {
                    this.ShowMeta = Boolean.Parse(xml.Attribute("ShowMeta").Value);
                }
                if ((string)xml.Attribute("PrintConstructId") != null)
                {
                    this.PrintConstructId = Boolean.Parse(xml.Attribute("PrintConstructId").Value);
                }
                if ((string)xml.Attribute("PrintElementId") != null)
                {
                    this.PrintElementId = Boolean.Parse(xml.Attribute("PrintElementId").Value);
                }
                if ((string)xml.Attribute("AutoPrint") != null)
                {
                    this.R.AutoPrint = Boolean.Parse(xml.Attribute("AutoPrint").Value);
                }


                foreach (XElement xe in xml.Elements("Interview"))
                {
                    ImportFelixLindemann(xe);
                }
                this.FirePropertyChanged("CurrentProject");
                this.CurrentProject.ResetHasChanges();

            }
            else if (xml.Name == "Interview")
            {
                InterviewService iService = new InterviewService(this, new Interview(this.project));

                iService.CurrentInterview.Id = Guid.Parse(xml.Attribute("Id").Value);
                iService.CurrentInterview.Proband = xml.Attribute("Proband").Value;
                iService.CurrentInterview.GridName = xml.Attribute("GridName").Value;
                iService.CurrentInterview.Date = DateTime.Parse(xml.Attribute("Date").Value);
                iService.CurrentInterview.Remark = xml.Element("Remark").Value;
                foreach (XElement xe in xml.Elements("ScaleItem"))
                {
                    ScaleItem s = new ScaleItem(iService.CurrentInterview, xe); // is added to this.Scales in constructor 

                }
                foreach (XElement xe in xml.Elements("Construct"))
                {
                    Construct con = iService.AddConstruct();
                    con.UpdateFromXML(xe);  // is added to this.Constructs in constructor 
                }
                foreach (XElement xe in xml.Elements("Element"))
                {
                    Element elem = iService.AddElement();
                    elem.UpdateFromXML(xe); // is added to this.Elements in constructor 
                    foreach (XElement xRating in xe.Elements("Rating"))
                    {
                        Guid cid = Guid.Parse(xRating.Attribute("ParentConstruct").Value);
                        Predicate<Construct> pc = new Predicate<Construct>(x => x.Id.Equals(cid));
                        // Console.WriteLine("Suche Construct ID: {0}", cid.ToString());
                        if (iService.CurrentInterview.Constructs.Any(x => pc(x)) == false) throw new KeyNotFoundException();
                        Construct c = iService.CurrentInterview.Constructs.Single(x => pc(x));
                        int rating = int.Parse(xRating.Attribute("ScaleItemId").Value);
                       // Console.WriteLine("Element: {0} -- Construct: {1} -- Rating: {2}", elem.Name, c.ConstructPol, rating);
                        Score s = iService.GiveRating(elem, c,rating );
                    }
                }
                this.AddInterview(iService.CurrentInterview);
                this.CurrentProject.FirePropertyChanged("Interviews");
            }
            else
            {
                throw new Exception(String.Format("XML-Node doesn't match. Expected: 'Project' or 'Interview'. Provided. '{0}'.", xml.Name));
            }
        }

        public Boolean HasChanges()
        {
            return this.CurrentProject.HasChanges();
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            if (rEngine == null) return;
            rEngine.Dispose();
        }

        #endregion

        #region Import

        #region Demos

        [Browsable(false)]
        public Dictionary<String, String> DemoData
        {
            get
            {
                Dictionary<String, String> demoData = new Dictionary<string, string>();

                demoData = new Dictionary<string, string>();
                demoData.Add("bell2010", "grid data from a study by Haritos et al. (2004) on role titles; used for demonstration of construct alignment in Bell (2010, p. 46).");
                demoData.Add("bellmcgorry1992", "grid from a psychotic patient used in Bell (1997, p. 6). Data originated from a study by Bell and McGorry (1992).");
                demoData.Add("boeker", "grid from seventeen year old female schizophrenic patient undergoing last stage of psychoanalytically oriented psychotherapy (Böker, 1996, p. 163).");
                demoData.Add("fbb2003", "dataset used in A manual for Repertory Grid Technique (Fransella, Bell, & Bannister, 2003b, p. 60).");
                demoData.Add("feixas2004", "grid from a 22 year old Spanish girl suffering self-worth problems (Feixas & Saúl, 2004, p. 77).");
                demoData.Add("mackay1992", "dataset Grid C used in Mackay’s paper on inter-element correlation (1992, p. 65).");
                demoData.Add("leach2001a", "pre-dataset from sexual child abuse survivor (Leach, Freshwater, Aldridge, & Sunderland, 2001, p. 227).");
                demoData.Add("leach2001b", "post-therapy dataset from sexual child abuse survivor (Leach, Freshwater, Aldridge, & Sunderland, 2001, p. 227).");
                demoData.Add("raeithel", "grid data to demonstrate the use of Bertin diagrams (Raeithel, 1998, p. 223). The context of its administration is unknown.");
                demoData.Add("slater1977a", "drug addict’s grid dataset from (Slater, 1977, p. 32).");
                demoData.Add("slater1977b", "grid dataset (ranked) from a seventeen year old female psychiatric patient (Slater, 1977, p. 110) showing depression, anxiety and self-mutilation. The data was originally reported by Watson (1970).");
                // More to come
                /*  */
                return demoData;
            }
        }

        public void getDemo(String data)
        {

            string msg = "Demo-Grids from literature selected by Mark Heckmann\nPlease check http://docu.openrepgrid.org/data.html \n\n" +
                    "OpenRepGrid (by Mark Heckmann) comes with several datsets already included.\n" +
                    "The data can serve as a starting point to make your first steps using the software.";

            if (!this.project.Remark.Contains(msg))
            {
                this.project.Remark += this.project.Remark + msg;
            }

            this.FirePropertyChanged("CurrentProject");

            addGridFromR(data, "");

        }

        #endregion


        private void addGridFromR(string GridName, string cmd)
        {
            if (cmd.Length > 0) this.R.Evaluate(cmd);

            Interview i = new Interview(this.CurrentProject);
            i.GridName = GridName;

            InterviewService iService = new InterviewService(this, i);
            iService.Reset();
            iService.GetFromR(true);
            this.AddInterview(iService.CurrentInterview);

            this.CurrentProject.FirePropertyChanged("Interviews");
            this.FirePropertyChanged("CurrentProject");
        }

        public void addRandomGrid(String GridName = "RandomGrid", int nc = 10, int ne = 15, int nwc = 5, int nwe = 5, int minScale = -3,
            int maxScale = 3, int options = 1)
        {
            string cmd = string.Format(
                "{7} <- randomGrid(nc = {0}, ne = {1}, nwc = {2}, nwe = {3}, range = c({4}, {5}), prob = NULL, options = {6})",
                nc, ne, nwc, nwe, minScale, maxScale, options, GridName);
            addGridFromR(GridName, cmd);
        }

        public void ImportTXT(FileInfo f, String GridName = "txt")
        {
            if (f.Exists == false) throw new FileNotFoundException();
            string cmd = string.Format("{0} <- importTxt(\"{1}\")",
                 GridName, f.FullName.Replace("\\", "/"));
            addGridFromR(GridName, cmd);
        }

        public void ImportGridCor(FileInfo f, String GridName = "GridCor")
        {
            if (f.Exists == false) throw new FileNotFoundException();
            string cmd = string.Format("{0} <- importGridcor(\"{1}\")",
                 GridName, f.FullName.Replace("\\", "/"));
            addGridFromR(GridName, cmd);
        }

        public void ImportGridCor(String GridName = "GridCor")
        {
            string cmd = string.Format("{0} <- importGridcor()", GridName);
            addGridFromR(GridName, cmd);
        }

        public void ImportGridStat(String GridName = "GridStat")
        {

            string cmd = string.Format("{0} <- importGridstat()", GridName);
            addGridFromR(GridName, cmd);
        }

        public void ImportGridStat(FileInfo f, String GridName = "GridStat")
        {
            if (f.Exists == false) throw new FileNotFoundException();
            string cmd = string.Format("{0} <- importGridstat(\"{1}\")",
                 GridName, f.FullName.Replace("\\", "/"));
            addGridFromR(GridName, cmd);
        }

        public void ImportGridSuite(String GridName = "GridSuite")
        {
            string cmd = string.Format("{0} <- importGridsuite()", GridName);
            addGridFromR(GridName, cmd);
        }

        public void ImportGridSuite(FileInfo f, String GridName = "GridSuite")
        {
            if (f.Exists == false) throw new FileNotFoundException();
            string cmd = string.Format("{0} <- importGridsuite(\"{1}\")",
                GridName,
                f.FullName.Replace("\\", "/"));
            addGridFromR(GridName, cmd);
        }

        public void ImportScivesco(String GridName = "Scivesco")
        {
            string cmd = string.Format("{0} <- importScivesco()", GridName);
            addGridFromR(GridName, cmd);
        }

        public void ImportScivesco(FileInfo f, String GridName = "Scivesco")
        {
            if (f.Exists == false) throw new FileNotFoundException();
            string cmd = string.Format("{0} <- importScivesco(\"{1}\")",
                 GridName, f.FullName.Replace("\\", "/"));
            addGridFromR(GridName, cmd);
        }

        #endregion


    }
}
