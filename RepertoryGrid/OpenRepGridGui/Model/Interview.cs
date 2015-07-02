using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.ComponentModel;
using LimeTree.BaseClasses;
using OpenRepGridModel.Model;

namespace OpenRepGridModel.Model
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

        public   Boolean HasChanges()
        {
            return this.hasChanges ||
                   this.Constructs.Any(x => x.HasChanges()) ||
                   this.Elements.Any(x => x.HasChanges()) ||
                   this.Scales.Any(x => x.HasChanges());

        }
        #endregion
         
        #region Constructors

        public Interview(Project project)
        {
            this.parentProject = project;
            this.ResetHasChanges();
        }

        #endregion

        #region Methods

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
                Predicate<Construct> p = new Predicate<Construct>(x => ic.Constructs.Any(y => y.Id.Equals(x.Id)));
                Func<Construct, Boolean> f = new Func<Construct, bool>(x => p(x));

                result = result && this.Constructs.All(x => p(x) &&
                    ic.Constructs.Where(a => p(a)).Count() == 1 &&
                    x.Equals(ic.Constructs.Single(y => p(y))));

                if (!result) return false;
                p = new Predicate<Construct>(x => this.Constructs.Any(y => y.Id.Equals(x.Id)));
                f = new Func<Construct, bool>(x => p(x));
                result = result && ic.Constructs.All(x => p(x) &&
                    this.Constructs.Where(a => p(a)).Count() == 1 &&
                    x.Equals(this.Constructs.Single(y => p(y))));


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

        void r_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.ResetHasChanges();
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
            this.hasChanges = false;
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
