using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using LimeTree.BaseClasses;
using OpenRepGridModel.Model;

namespace OpenRepGridModel.Model
{

    /// <summary>
    /// by Felix Lindemann
    /// </summary>
    public class Element : NotifyPropertyChanged
    {

        #region variables

        private Guid id = Guid.NewGuid();
        private Interview parentInterview;
        private String name = "<New Element>";
        private String remark = "";
        private List<Score> scores = new List<Score>();

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
        /// 
        /// </summary>
        public Interview ParentInterview
        {
            get { return parentInterview; }
            set { SetPropertyField("ParentInterview", ref parentInterview, value); }
        }

        /// <summary>
        /// The Label of the Element
        /// </summary>
        public String Name
        {
            get { return name; }
            set { SetPropertyField("Name", ref name, value); }
        }

        /// <summary>
        /// which remarks do you have?
        /// </summary>
        public String Remark
        {
            get { return remark; }
            set { SetPropertyField("Remark", ref remark, value); }
        }


        /// <summary>
        /// Stores the Rating of the Element for each Construct.
        /// </summary>
        public List<Score> Scores
        {
            get { return scores; }
        }

        public   Boolean HasChanges()
        {
            return this.hasChanges ||
                       this.Scores.Any(x => x.HasChanges());
             
        }
        #endregion

        #region Constructor

        public Element(Interview interview)
        {
            this.ParentInterview = interview; 

        }
         

        #endregion

        #region Methods

        public void UpdateFromXML(XElement xml)
        {
            if (xml.Name == "Element")
            { 
                this.id = Guid.Parse(xml.Attribute("Id").Value);
                this.Name = xml.Attribute("Name").Value;
                this.Remark = xml.Element("Remark").Value; 
            }
            else
            {
                throw new Exception(String.Format("XML-Node doesn't match. Expected: 'Element'. Provided. '{0}'.", xml.Name));
            }
        }
        public XElement getXML()
        {
            return new XElement("Element",
                new XAttribute("Id", this.Id.ToString()),
                new XAttribute("Name", this.Name),
                new XElement("Remark", this.Remark),
                this.Scores.Select(x => x.getXML()));
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                Element ce = (Element)obj;
                Boolean result = true;

                result =
                        this.Name == ce.Name &&
                        this.Remark == ce.Remark &&
                        this.Id.Equals(ce.Id)
                        ;

                result = result && this.Scores.All(x =>
                    ce.Scores.Any(y => x.ParentConstruct.Id.Equals(y.ParentConstruct.Id) &&
                                       x.ParentElement.Id.Equals(y.ParentElement.Id) &&
                                       x.ScaleItemId == y.ScaleItemId));


                result = result && ce.Scores.All(x =>
                   this.Scores.Any(y => x.ParentConstruct.Id.Equals(y.ParentConstruct.Id) &&
                                       x.ParentElement.Id.Equals(y.ParentElement.Id) &&
                                       x.ScaleItemId == y.ScaleItemId));
 
                return result;

            }

            return false;
        }

        public override int GetHashCode()
        {
            /*  long hash = 0;
               hash += this.Id.GetHashCode();
               hash += this.Name.GetHashCode();
               hash += this.Remark.GetHashCode();
               hash += this.SortIndex.GetHashCode();
               hash += this.UseForEvaluation.GetHashCode();
               hash += this.ratings.Sum(x => x.Value * x.Key.GetHashCode());
               */
            return base.GetHashCode();
        }

        void r_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
             
        } 

        #endregion



        public void ResetHasChanges()
        {
            this.hasChanges = false;
            foreach (Score r in this.Scores)
            {
                r.ResetHasChanges();
            }
        }

    }

}
