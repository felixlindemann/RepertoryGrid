using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using LimeTree.BaseClasses;

namespace OpenRepGridModel.Model
{
    public class ScaleItem : NotifyPropertyChanged
    {

        #region variables

        private int id =  int.MaxValue;
        private Interview parentInterview; 
        private String name = ""; 

        #endregion

        #region Properties


        /// <summary>
        /// 
        /// </summary>
        public int Id
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
            set { SetPropertyField("ParentInterview", ref this.parentInterview, value); }
        }
    
        /// <summary>
        /// 
        /// </summary>
        public Boolean IsDefault
        {
            get { return !(this.Id == int.MaxValue || 
                           this.Id == int.MinValue); }
           
        }
    
        /// <summary>
        /// 
        /// </summary>
        public String  Name
        {
            get { return name; }
            set { SetPropertyField("Name", ref name, value); }
        }

        public String DisplayName
        {
            get {
                if (!this.IsDefault)
                {

                    return string.Format("{0}",  this.Name);
                }
                else
                {
                    return string.Format("{0} - {1}", this.Id, this.Name);
                }
            }
        }

        #endregion

        #region Constructors

        public ScaleItem(Interview   parent, int iValue, string sName)
        {
            this.Id = iValue;
            this.ParentInterview = parent;
            this.ParentInterview.Scales.Add(this);
            this.Name = sName;
            this.ResetHasChanges();
        }

        public ScaleItem(Interview parent, XElement xe)
        {
            this.Id = int.Parse(xe.Attribute("Id").Value);
            this.ParentInterview = parent;
            this.ParentInterview.Scales.Add(this);
            this.Name = xe.Attribute("Name").Value;
            this.ResetHasChanges();
        }

        #endregion

        #region Methods

        public Boolean HasChanges() { return this.hasChanges; }
        public XElement getXML()
        {
            return new XElement("ScaleItem",
                new XAttribute("Id", this.Id),
                new XAttribute("Name", this.Name)
            );
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                ScaleItem csi = (ScaleItem)obj;
                Boolean result = true;

                result =
                        this.Name == csi.Name &&
                        this.Id.Equals(csi.Id)
                        ;
              
                return result;

            }
           
            return false;
        }
   
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        

         
        public void ResetHasChanges()
        {
            this.hasChanges = false;
        }
        #endregion
    }
}
