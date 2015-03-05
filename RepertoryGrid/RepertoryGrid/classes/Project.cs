using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepertoryGrid.BaseClasses;
using System.Xml.Linq;
using System.Diagnostics;
using RDotNet;
using System.ComponentModel;

namespace RepertoryGrid.classes
{

    /// <summary>
    /// by Felix Lindemann
    /// </summary>
    public class Project : NotifyPropertyChanged
    {

        #region variables

        private Guid id = Guid.NewGuid();
        private List<Interview> interviews = new List<Interview>();
        private String remark = "";
        private String name = "";

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public Guid Id
        {
            get { return id; }
            set { SetPropertyField("Id", ref id, value); }
        }

        /// <summary>
        /// The name of the project
        /// </summary>
        public String Name
        {
            get { return name; }
            set { SetPropertyField("Name", ref name, value); }
        }

        /// <summary>
        /// the interviews conducted.
        /// </summary>
        public List<Interview> Interviews
        {
            get { return interviews; }
            set { SetPropertyField("Interviews", ref interviews, value); }
        }

        /// <summary>
        /// Remarks about the project
        /// </summary>
        public String Remark
        {
            get { return remark; }
            set { SetPropertyField("Remark", ref remark, value); }
        }

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
                   /*       demoData.Add("feixas2004", "grid from a 22 year old Spanish girl suffering self-worth problems (Feixas & Saúl, 2004, p. 77).");
                     demoData.Add("mackay1992", "dataset Grid C used in Mackay’s paper on inter-element correlation (1992, p. 65).");
                     demoData.Add("leach2001a", "pre-dataset from sexual child abuse survivor (Leach, Freshwater, Aldridge, & Sunderland, 2001, p. 227).");
                     demoData.Add("leach2001b", "post-therapy dataset from sexual child abuse survivor (Leach, Freshwater, Aldridge, & Sunderland, 2001, p. 227).");
                     demoData.Add("raeithel", "grid data to demonstrate the use of Bertin diagrams (Raeithel, 1998, p. 223). The context of its administration is unknown.");
                     demoData.Add("slater1977a", "drug addict’s grid dataset from (Slater, 1977, p. 32).");
                     demoData.Add("slater1977b", "grid dataset (ranked) from a seventeen year old female psychiatric patient (Slater, 1977, p. 110) showing depression, anxiety and self-mutilation. The data was originally reported by Watson (1970).");
                      // More to come
                        */
                return demoData;
            }
        }

        #endregion

        #region Constructor

        public Project()
        {
            this.Id = Guid.NewGuid();
            this.HasChanges = false;
        }

        public Project(XElement xml)
        {
            if (xml.Name == "Project")
            {

                this.id = Guid.Parse(xml.Attribute("Id").Value);
                this.Name = xml.Attribute("Name").Value;
                this.Remark = xml.Element("Remark").Value;
                foreach (XElement xe in xml.Elements("Interview"))
                {
                    Interview i = new Interview(this, xe); // is added to this.Interview in constructor

                }

                this.HasChanges = false;
            }
            else
            {
                throw new Exception(String.Format("XML-Node doesn't match. Expected: 'Project'. Provided. '{0}'.", xml.Name));
            }
        }

        #endregion

        #region Methods

        public XElement getXML()
        {
            return new XElement("Project",
                new XAttribute("Id", this.Id.ToString()),
                new XAttribute("Name", this.Name),
                new XElement("Remark", this.Remark),
                this.Interviews.Select(x => x.getXML())
            );
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                Project c = (Project)obj;
                Boolean result = true;

                result =
                        this.Name == c.Name &&
                        this.Remark == c.Remark &&
                        this.Id.Equals(c.Id)
                        ;
                if (!result) return false;

                if (!result) return false;
                result = result && this.Interviews.All(x => c.Interviews.Any(y => y.Id.Equals(x.Id)) &&
                                                            x.Equals(c.Interviews.Single(y => y.Id.Equals(x.Id))));

                if (!result) return false;
                result = result && c.Interviews.All(x => this.Interviews.Any(y => y.Id.Equals(x.Id)) &&
                                                            x.Equals(this.Interviews.Single(y => y.Id.Equals(x.Id))));

                return result;

            }

            return false;
        }

        public override int GetHashCode()
        {
            /*
            long hash = 0;
            hash += this.Id.GetHashCode();
            hash += this.Name.GetHashCode();
            hash += this.Remark.GetHashCode();
            hash = hash.GetHashCode();
            foreach (Scale s in this.Scales)
            {
                hash += s.GetHashCode();
            }
            hash = hash.GetHashCode();
            foreach (Interview i in this.Interviews)
            {
                hash += i.GetHashCode();
            }
             * */
            return base.GetHashCode();
        }

        public void AddInterview(Interview i)
        {
            changeInterviewList(i, true);
        }

        public void RemoveInterview(Interview i)
        {
            changeInterviewList(i, false);
        }

        private void changeInterviewList(Interview i, Boolean add)
        {
            if (i == null)
            {
                throw new ArgumentNullException("The value for the interview is null");
            }
            if (add)
            {

                if (this.Interviews.Any(x => x.Id.Equals(i.Id)))
                {
                    throw new DuplicateWaitObjectException("The interview can't be added. It's already part of the current Project.");
                }
                this.Interviews.Add(i);
                i.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(i_PropertyChanged);
            }
            else
            {
                if (this.interviews.Any(x => x.Id.Equals(i.Id)) == false)
                {
                    throw new NotSupportedException("The interview can't be removed. It's not part of the current Project.");
                }

                this.Interviews.Remove(i);
            }
            this.FirePropertyChanged("Interviews");
            i = null;
        }

        void i_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.HasChanges = true;
        }

        #endregion

        #region Demo

        public static Project getDemo01()
        {
            Project p = new Project();
            p.Name = "Demo Project";
            p.Remark = "Just for demo Purpose. Random Data used";

            Interview i = new Interview(p);
            i.Proband = "Interview 1";
            i.Remark = "Small one";

            Element e = new Element(i);
            e.Name = "Auto 1";
            e = new Element(i);
            e.Name = "Auto 2";
            e = new Element(i);
            e.Name = "Auto 3";

            Construct c = new Construct(i);
            c.Name = "Marke";
            c.ConstructPol = "High-End Marke";
            c.ContrastPol = "Billig Marke";
            c.SortIndex = 1;
            c.UseForEvaluation = true;



            i.Elements[0].GiveRating(c, 3);
            i.Elements[1].GiveRating(c, 1);
            i.Elements[2].GiveRating(c, -3);

            c = new Construct(i);
            c.Name = "Farbe";
            c.ConstructPol = "Hell";
            c.ContrastPol = "Dunkel";
            c.SortIndex = 2;
            c.UseForEvaluation = true;

            i.Elements[0].GiveRating(c, 2);
            i.Elements[1].GiveRating(c, -3);
            i.Elements[2].GiveRating(c, -3);

            c = new Construct(i);
            c.Name = "Preis";
            c.ConstructPol = "Teuer";
            c.ContrastPol = "Günstig";
            c.SortIndex = 2;
            c.UseForEvaluation = true;

            i.Elements[0].GiveRating(c, 3);
            i.Elements[1].GiveRating(c, 1);
            i.Elements[2].GiveRating(c, -3);
            return p;
        }


        public void getDemo(RHelper.RHelper rEngine, BackgroundWorker bw = null)
        {


            this.Name = "Demo-Project";
            this.Remark = "Demo-Grids from literature selected by Mark Heckmann\nPlease check http://docu.openrepgrid.org/data.html";

            if (bw != null)
            {
                int progress = 1;
                bw.ReportProgress(progress, "Executing R.Code: Loading OpenRepGrid 'library(OpenRepGrid)'");
            }

            rEngine.Evaluate("library(OpenRepGrid)");

            foreach (String key in this.DemoData.Keys)
            {
                rEngine.Evaluate(string.Format("data(\"{0}\")", key));
                Interview interview = new Interview(this);
                interview.getFromR(rEngine, key, bw);
                interview.Proband = key;
                interview.Remark = this.DemoData[key];
            }
            if (bw != null)
            {
                bw.ReportProgress(100, "");
            }
            this.ResetHasChanges();

        }
        public void ResetHasChanges()
        {
            this.HasChanges = false;
            foreach (Interview interview in this.Interviews)
            {
                interview.ResetHasChanges();
            }
        }

        #endregion

    }

}
