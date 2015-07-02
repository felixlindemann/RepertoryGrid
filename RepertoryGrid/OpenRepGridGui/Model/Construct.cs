using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq; 
using LimeTree.BaseClasses;

namespace OpenRepGridModel.Model
{
    /// <summary>
    /// by Felix Lindemann
    /// </summary>
    public class Construct : NotifyPropertyChanged
    {

        #region variables

        private Guid id = Guid.NewGuid(); 
        private Interview parentInterview;
        private String name = "";
        private String contrastPol = "";
        private String constructPol = "";
        private String remark = ""; 

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
        /// the label of the Construct
        /// </summary>
        public String Name
        {
            get { return name; }
            set { SetPropertyField("Name", ref name, value); }
        }

        /// <summary>
        /// the label of the contrasting pole
        /// </summary>
        public String ContrastPol
        {
            get { return contrastPol; }
            set { SetPropertyField("ContrastPol", ref contrastPol, value); }
        }

        /// <summary>
        /// the label of the constructing pole
        /// </summary>
        public String ConstructPol
        {
            get { return constructPol; }
            set { SetPropertyField("ConstructPol", ref constructPol, value); }
        }

        /// <summary>
        /// which remarks do you have?
        /// </summary>
        public String Remark
        {
            get { return remark; }
            set { SetPropertyField("Remark", ref remark, value); }
        }

        public Boolean HasChanges() { return this.hasChanges; }

        #endregion

        #region Constructors

        public Construct(Interview interview)
        {
            this.ParentInterview = interview; 
            this.ConstructPol = "<Construct Pole>";
            this.ContrastPol = "<Contrast Pole>";
            this.Name = "<Construct Name>";
            this.Remark = "";  
            this.ResetHasChanges();
        }

                        
        #endregion

        #region Methods

        public XElement getXML()
        {
            return new XElement("Construct",
                new XAttribute("Id", this.Id.ToString()), 
                new XAttribute("Name", this.Name),
                new XAttribute("ContrastPol", this.ContrastPol),
                new XAttribute("ConstructPol", this.ConstructPol), 
                new XElement("Remark", this.Remark)
            );
        }
         
        public override bool Equals(object obj)
        {
            if(obj.GetType() == this.GetType()){
                Construct c = (Construct)obj;
                Boolean result = true;

                result =
                        this.Name == c.Name && 
                        this.ParentInterview.Id.Equals(c.ParentInterview.Id) &&
                        this.Remark == c.Remark && 
                        this.ConstructPol == c.ConstructPol &&
                        this.ContrastPol == c.ContrastPol &&
                        this.Id.Equals(c.Id)  
                        ;
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
            hash += this.ConstructPol.GetHashCode();
            hash += this.ContrastPol.GetHashCode();
            hash += this.SortIndex.GetHashCode();
            hash += this.UseForEvaluation.GetHashCode();
             */
            return base.GetHashCode();
        }

        public void UpdateFromXML(XElement xml)
        {
            if (xml.Name == "Construct")
            {
                this.id = Guid.Parse(xml.Attribute("Id").Value);
                this.ConstructPol = xml.Attribute("ConstructPol").Value;
                this.ContrastPol = xml.Attribute("ContrastPol").Value;
                this.Name = xml.Attribute("Name").Value;
                this.Remark = xml.Element("Remark").Value;

                this.ResetHasChanges();
            }
            else
            {
                throw new Exception(String.Format("XML-Node doesn't match. Expected: 'Construct'. Provided. '{0}'.", xml.Name));
            }
        }
        #endregion

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.Append(base.ToString());
            b.Append("\t");
            b.Append(string.Format("lPole: {0} - RPole{1}", this.ContrastPol, this.ConstructPol));
                
            return b.ToString();
        }
            
        public void ResetHasChanges()
        {
            this.hasChanges = false; 
        }  
    }
}
