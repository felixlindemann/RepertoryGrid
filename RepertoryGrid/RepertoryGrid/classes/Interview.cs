using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepertoryGrid.BaseClasses;
using System.Xml.Linq;
using System.IO;
using RDotNet;
using System.ComponentModel;

namespace RepertoryGrid.classes
{
    /// <summary>
    /// by Felix Lindemann
    /// </summary>
    public class Interview : NotifyPropertyChanged
    {

        #region variables

        private Guid id = Guid.NewGuid();
        private Project parentProject;
        private String proband = "";
        private String gridName = "grid";
        private DateTime date = DateTime.Now;
        private String remark = "";
        private List<Element> elements = new List<Element>();
        private List<Construct> constructs = new List<Construct>();
        private List<ScaleItem> scales = new List<ScaleItem>();
        private List<ImageFile> images = new List<ImageFile>();
        private StringBuilder rscript = new StringBuilder();
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
        /// The related Project
        /// </summary>
        public Project ParentProject
        {
            get { return parentProject; }
            set { SetPropertyField("ParentProject", ref parentProject, value); }
        }

        /// <summary>
        /// the name of the interviewee
        /// </summary>
        public String Proband
        {
            get { return proband; }
            set { SetPropertyField("Proband", ref proband, value); }
        }

        /// <summary>
        /// the name of the interviewee
        /// </summary>
        public String GridName
        {
            get { return gridName; }
            set { SetPropertyField("GridName", ref gridName, value); }
        }
        /// <summary>
        /// The Date&Time the Interview took place
        /// </summary>
        public DateTime Date
        {
            get { return date; }
            set { SetPropertyField("Date", ref date, value); }
        }

        /// <summary>
        /// Provides the remarks
        /// </summary>
        public String Remark
        {
            get { return remark; }
            set { SetPropertyField("Remark", ref remark, value); }
        }

        /// <summary>
        /// the elements mentiond by the interviewee
        /// </summary>
        public List<Element> Elements
        {
            get { return elements; }
            set { SetPropertyField("Elements", ref elements, value); }
        }

        /// <summary>
        /// The constructs mentioned by the Interviewee
        /// </summary>
        public List<Construct> Constructs
        {
            get { return constructs; }
            set { SetPropertyField("Constructs", ref constructs, value); }
        }

        /// <summary>
        /// The used Scales in the project
        /// </summary>
        public List<ScaleItem> Scales
        {
            get { return scales; }
            set { SetPropertyField("Scales", ref scales, value); }
        }

        /// <summary>
        /// The constructs mentioned by the Interviewee
        /// </summary>
        public List<ImageFile> Images
        {
            get { return images; }
            set { SetPropertyField("Images", ref images, value); }
        }

        #endregion

        #region Constructors

        public Interview(Project project)
        {
            this.parentProject = project;
            this.ParentProject.AddInterview(this);
            this.defineDefaultScale(-3, 3);

            this.HasChanges = false;

        }

        public Interview(Project project, XElement xml)
        {
            if (xml.Name == "Interview")
            {
                this.parentProject = project;
                this.parentProject.AddInterview(this);

                this.Id = Guid.Parse(xml.Attribute("Id").Value);
                this.Proband = xml.Attribute("Proband").Value;
                this.GridName = xml.Attribute("GridName").Value;
                this.Date = DateTime.Parse(xml.Attribute("Date").Value);
                this.Remark = xml.Element("Remark").Value;
                foreach (XElement xe in xml.Elements("ScaleItem"))
                {
                    ScaleItem s = new ScaleItem(this, xe); // is added to this.Scales in constructor
                }

                foreach (XElement xe in xml.Elements("Construct"))
                {
                    Construct c = new Construct(this, xe);  // is added to this.Constructs in constructor
                }
                foreach (XElement xe in xml.Elements("Element"))
                {
                    Element c = new Element(this, xe); // is added to this.Elements in constructor
                };
                this.HasChanges = false;
            }
            else
            {
                throw new Exception(String.Format("XML-Node doesn't match. Expected: 'Interview'. Provided. '{0}'.", xml.Name));
            }
        }

        public String rScript
        {
            get { return this.rscript.ToString(); }
        }

        #endregion

        #region Methods

        public void ExecuteR(  String cmd )
        {
            this.rscript.Append(cmd);
            this.rscript.Append(Environment.NewLine);
            this.FirePropertyChanged("rScript");
        }

        public void ResetR() { rscript = new StringBuilder(); }
        
        private void defineDefaultScale(int min = -3, int max = 3)
        {
            if (min >= max) throw new ArgumentOutOfRangeException("The min Value must be larger than the max Value");
            ScaleItem si;

            si = new ScaleItem(this, int.MaxValue, "NAN");
            si = new ScaleItem(this, int.MinValue, "Not rated (interviewee doesn't want to rate this item)");
            if (max - min == 6)
            {
                si = new ScaleItem(this, 0 + min, "The contrast (left) pole applies totally");
                si = new ScaleItem(this, 1 + min, "The contrast (left) pole applies not totally, the construct (right) pole does not apply");
                si = new ScaleItem(this, 2 + min, "The contrast (left) pole rather applies than the construct (right) pole");
                si = new ScaleItem(this, 3 + min, "Neither the contrast (left) pole nor the construct (right) pole aplly");
                si = new ScaleItem(this, 4 + min, "The construct (right) pole rather applies than the contrast (left) pole");
                si = new ScaleItem(this, 5 + min, "The construct (right) pole applies not totally, the contrast (left) pole does not apply");
                si = new ScaleItem(this, 6 + min, "The construct (right) pole applies totally");
            }
            else
            {
                for (int i = min; i <= max; i++)
                {
                    si = new ScaleItem(this, i, "");
                }
            }

        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                Interview ic = (Interview)obj;
                Boolean result = true;

                result =
                        this.GridName == ic.GridName &&
                        this.Proband == ic.Proband &&
                        this.Remark == ic.Remark &&
                        this.Date.ToString() == ic.Date.ToString() &&
                        this.Id.Equals(ic.Id)
                        ;

                if (!result) return false;
                result = result && this.Constructs.All(x => ic.Constructs.Any(y => y.Id.Equals(x.Id)) &&
                                                            x.Equals(ic.Constructs.Single(y => y.Id.Equals(x.Id))));

                if (!result) return false;

                result = result && ic.Constructs.All(x => this.Constructs.Any(y => y.Id.Equals(x.Id)) &&
                                                            x.Equals(this.Constructs.Single(y => y.Id.Equals(x.Id))));


                if (!result) return false;
                result = result && this.Elements.All(x => ic.Elements.Any(y => y.Id.Equals(x.Id)) &&
                                                          x.Equals(ic.Elements.Single(y => y.Id.Equals(x.Id))));

                result = result && ic.Elements.All(x => this.Elements.Any(y => y.Id.Equals(x.Id)) &&
                                                          x.Equals(this.Elements.Single(y => y.Id.Equals(x.Id))));


                if (!result) return false;
                result = result && this.Scales.All(x => ic.Scales.Any(y => y.Id.Equals(x.Id)) &&
                                                        x.Equals(ic.Scales.Single(y => y.Id.Equals(x.Id))));
                if (!result) return false;
                result = result && ic.Scales.All(x => this.Scales.Any(y => y.Id.Equals(x.Id)) &&
                                                        x.Equals(this.Scales.Single(y => y.Id.Equals(x.Id))));

                if (!result) return false;
                /* */
                return result;

            }

            return false;
        }

        public XElement getXML()
        {
            return new XElement("Interview",
                new XAttribute("Id", this.Id.ToString()),
                new XAttribute("Proband", this.Proband),
                new XAttribute("GridName", this.GridName),
                new XAttribute("Date", this.Date.ToString()),
                new XElement("Remark", this.Remark),
                this.Constructs.Select(x => x.getXML()),
                this.Elements.Select(x => x.getXML()),
                this.Scales.Select(x => x.getXML())
            );
        }

        public void AddConstruct(Construct c)
        {
            ChangeConstruct(c, true);
        }

        public void RemoveConstruct(Construct c)
        {
            ChangeConstruct(c, false);
        }

        private void ChangeConstruct(Construct c, Boolean add)
        {
            if (add)
            {
                if (this.Constructs.Any(x => x.Id.Equals(c.Id)))
                {
                    throw new DuplicateWaitObjectException("Construct alread exists");
                }
                this.Constructs.Add(c);
                c.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(r_PropertyChanged);
            }
            else
            {
                foreach (Element e in this.Elements)
                {
                    e.RemoveConstruct(c);
                }
                this.Constructs.RemoveAll(x => x.Id.Equals(c.Id));
            }
            FirePropertyChanged("Constructs");
        }

        void r_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.HasChanges = true;
        }

        public void AddElement(Element e)
        {
            ChangeElement(e, true);
        }

        public void RemoveElement(Element e)
        {
            ChangeElement(e, false);
        }

        private void ChangeElement(Element e, Boolean add)
        {
            if (add)
            {
                if (this.Elements.Any(x => x.Id.Equals(e.Id)))
                {
                    throw new DuplicateWaitObjectException("Element alread exists");
                }
                this.Elements.Add(e);
                e.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(r_PropertyChanged);
            }
            else
            {
                this.Elements.RemoveAll(x => x.Id.Equals(e.Id));
            }
            FirePropertyChanged("Elements");
        }

        public void AddScaleItem(ScaleItem s)
        {
            ChangeScaleItem(s, true);
        }

        public void RemoveScaleItem(ScaleItem s)
        {
            ChangeScaleItem(s, false);
        }

        private void ChangeScaleItem(ScaleItem s, Boolean add)
        {
            if (add)
            {
                if (this.Scales.Any(x => x.Id.Equals(s.Id)))
                {
                    throw new DuplicateWaitObjectException("ScaleItem alread exists");
                }
                s.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(r_PropertyChanged);
                this.Scales.Add(s);
            }
            else
            {
                if (this.Elements.Any(x => x.Ratings.Any(y => y.ScaleItemId == s.Id)))
                {
                    throw new NotSupportedException("This ScaleItem can't be deleted. It is still used for Rating an Element!");
                }
                this.Scales.RemoveAll(x => x.Id.Equals(s.Id));
            }
            FirePropertyChanged("Scales");
        }

        public void initR( RHelper.RHelper r )
        {


            List<Element> FilteredElements = this.Elements.Where(x => x.UseForEvaluation)
                                                  .OrderBy(x => x.SortIndex)
                                                  .ThenBy(x => x.Name)
                                                  .ToList();
            List<Construct> FilteredConstructs = this.Constructs.Where(x => x.UseForEvaluation)
                                                  .OrderBy(x => x.SortIndex)
                                                  .ThenBy(x => x.Name)
                                                  .ToList();
            this.rscript = new StringBuilder();
            this.FirePropertyChanged("rScript");

            String cmd = "";
            cmd = string.Format(@"# R-Project Script for OpenRepGrid produced: {0} by: {1}", DateTime.Now.ToUniversalTime(), "Repertory Grid by Felix Lindemann");
            r.Evaluate(cmd);

            cmd = string.Format(@"# Interviewee: {0} - Date of interview: {1}", this.Proband, this.Date.ToUniversalTime());
            r.Evaluate(cmd);

            cmd = @"# for further information check http://markheckmann.github.io/openrepgrid-site/";
            r.Evaluate(cmd);

            cmd = "library(OpenRepGrid)";
            r.Evaluate(cmd);

            cmd = string.Format("{0} <- makeEmptyRepgrid()", this.GridName);
            r.Evaluate(cmd);

            cmd = string.Format("{0} <- setScale({0}, {1}, {2})", this.GridName,
                        this.Scales.Where(x => x.IsDefault).Min(x => x.Id),
                        this.Scales.Where(x => x.IsDefault).Max(x => x.Id));
            r.Evaluate(cmd);

            foreach (Element element in FilteredElements)
            {
                cmd = string.Format("{0} <- addElement({0}, name=\"{1}\")", this.GridName, element.Name);
                r.Evaluate(cmd);

            }
            foreach (Construct c in FilteredConstructs)
            {

                cmd = string.Format("{0} <- addConstruct({0}, \"{1}\", \"{2}\", l.preferred = TRUE,  r.emerged = TRUE, c(", this.GridName, c.ContrastPol, c.ConstructPol);

                foreach (Element element in FilteredElements)
                {
                    Rating rating = element.Ratings.Single(x => x.ParentConstruct.Id.Equals(c.Id));
                    if (rating.ScaleItemId == int.MaxValue || rating.ScaleItemId == int.MinValue)
                    {
                        cmd = cmd + "NA";
                    }
                    else
                    {
                        cmd = cmd + rating.ScaleItemId;
                    }
                    cmd = cmd + ",";
                }
                cmd = cmd.Remove(cmd.Length - 1, 1) + "))";
                r.Evaluate(cmd);

            }
            r.Evaluate(this.GridName);
        }

        public void getFromR(RHelper.RHelper rEngine, String rGridName = "grid", BackgroundWorker bw = null)
        {
            this.GridName = rGridName;

            int scaleMin = rEngine.getInt(string.Format("{0}@scale$min", this.GridName));
            int scaleMax = rEngine.getInt(string.Format("{0}@scale$max", this.GridName));

            this.Scales.Clear();
            this.defineDefaultScale(scaleMin, scaleMax);

            GenericVector rConstructs = rEngine.getGenericVector(string.Format("{0}@constructs", this.GridName));
            GenericVector rElements = rEngine.getGenericVector(string.Format("{0}@elements", this.GridName));

            int I = rElements.Length;
            int J = rConstructs.Length;

            for (int i = 0; i < I; i++)
            {
                GenericVector rElement = rElements.ToList()[i].AsList();
                String[] av = rElement.ToList()[0].AsCharacter().ToArray();
                Element element = new Element(this);
                element.Name = av[0];
                element.SortIndex = i + 1;
                if (bw != null)
                {
                    if (bw.CancellationPending) throw new Exception("Process Cancelled");
                    int progress = (int)(
                        (this.ParentProject.Interviews.Count * 100)
                        / this.ParentProject.DemoData.Keys.Count
                    );
                    bw.ReportProgress(progress,
                        string.Format("Importing Interview {0}/{4}: Element {1}/{2} --> {5}%",
                        (this.ParentProject.Interviews.Count),
                        (i + 1), I, element.Name,
                        this.ParentProject.DemoData.Keys.Count, progress));
                }

                for (int j = 0; j < J; j++)
                {
                    if (bw != null)
                    {
                        if (bw.CancellationPending) throw new Exception("Process Cancelled");
                    }
                    Construct construct = null;
                    if (i == 0)
                    {
                        construct = new Construct(this);
                        GenericVector rConstruct = rConstructs.ToList()[j].AsList();
                        String lPole = rConstruct.ToList()[0].AsCharacter().ToArray()[0];
                        String rPole = rConstruct.ToList()[1].AsCharacter().ToArray()[0];
                        construct.ConstructPol = rPole;
                        construct.ContrastPol = lPole;
                        construct.SortIndex = j + 1;
                        construct.Name = "";
                        construct.HasChanges = false;
                    }
                    else
                    {
                        construct = this.Constructs[j];
                    }
                    if (bw != null)
                    {
                        if (bw.CancellationPending) throw new Exception("Process Cancelled");
                    }
                    int rating = rEngine.getInt(string.Format("{0}@ratings[{1}]", this.GridName, ((i) * J + (j + 1))));
                    element.GiveRating(construct, rating);
                }
            }

        }

        public override int GetHashCode()
        {
            /*
            long hash = 0;
            hash += this.Id.GetHashCode();
            hash += this.Proband .GetHashCode();
            hash += this.Remark.GetHashCode();
            hash += this.Date.GetHashCode();
            hash = hash.GetHashCode();
            foreach (Construct c in this.Constructs)
            {
                hash += c.GetHashCode();
            }
            hash = hash.GetHashCode();
            foreach (Element e in this.Elements)
            {
                hash += e.GetHashCode();
            } 
             * */
            return base.GetHashCode();
        }


        #endregion


        public void ResetHasChanges()
        {
            this.HasChanges = false;
            foreach (ScaleItem o in this.Scales)
            {
                o.ResetHasChanges();
            }
            foreach (Construct o in this.Constructs)
            {
                o.ResetHasChanges();
            }
            foreach (Element o in this.Elements)
            {
                o.ResetHasChanges();
            }
        }
         
    }
}
