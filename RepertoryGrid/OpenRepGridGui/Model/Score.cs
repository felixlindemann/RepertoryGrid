using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using LimeTree.BaseClasses;
using OpenRepGridModel.Model;

namespace OpenRepGridModel.Model
{
    public class Score
        : NotifyPropertyChanged
    {

        #region variables
         
        private Element parentElement;
        private Construct parentConstruct;
        private int scaleItemId;

        #endregion

        #region Properties
         

        /// <summary>
        /// 
        /// </summary>
        public Element ParentElement
        {
            get { return parentElement; }
            set { SetPropertyField("ParentElement", ref parentElement, value); }
        }
     
        /// <summary>
        /// 
        /// </summary>
        public Construct ParentConstruct
        {
            get { return parentConstruct; }
            set { SetPropertyField("ParentConstruct", ref parentConstruct, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ScaleItemId
        {
            get { return scaleItemId; }
            set { SetPropertyField("ScaleItemId", ref scaleItemId, value); }
        }

        #endregion

        #region Constructors

        public Score(Element element, Construct construct, int rating)
        {
             
            this.ParentElement = element;
            this.ParentElement.Scores.Add(this);
            this.ParentConstruct = construct;
            this.ScaleItemId = rating; 
            this.HasChanges = false;

        }

        #endregion

        #region methods

        public string getRatingForR()
        {
            if (this.ScaleItemId == int.MaxValue ||
                this.ScaleItemId == int.MaxValue)
            {
                return "NA";
            }
            return this.ScaleItemId.ToString();
        }

        public XElement getXML()
        {

            return new XElement("Rating", 
              new XAttribute("ParentElement", this.ParentElement.Id.ToString()),
              new XAttribute("ParentConstruct", this.ParentConstruct.Id.ToString()),
              new XAttribute("ScaleItemId", this.ScaleItemId)

              );

        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                Score cr = (Score)obj;
                Boolean result = true;

                result =
                        this.ScaleItemId == cr.ScaleItemId &&
                        this.ParentElement.Id.Equals(cr.ParentElement.Id) &&
                        this.ParentConstruct.Id.Equals(cr.ParentConstruct.Id)  
                        ;

                return result;

            }
            return false;
        }
  
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
