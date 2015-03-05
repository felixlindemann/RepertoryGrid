using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepertoryGrid.BaseClasses;
using System.Xml.Linq;

namespace RepertoryGrid.classes
{
    public class Rating
        : NotifyPropertyChanged
    {

        #region variables

        private Guid id = Guid.NewGuid();
        private Element parentElement;
        private Construct parentConstruct;
        private int scaleItemId;

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

        public Rating(Element element, Construct construct, int rating)
        {
             
            this.ParentElement = element; 
            this.ParentConstruct = construct;
            this.ScaleItemId = rating; 
            this.HasChanges = false;

        }

        #endregion

        #region methods

        public XElement getXML()
        {

            return new XElement("Rating",
              new XAttribute("Id", this.Id.ToString()),
              new XAttribute("ParentElement", this.ParentElement.Id.ToString()),
              new XAttribute("ParentConstruct", this.ParentConstruct.Id.ToString()),
              new XAttribute("ScaleItemId", this.ScaleItemId)

              );

        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                Rating cr = (Rating)obj;
                Boolean result = true;

                result =
                        this.ScaleItemId == cr.ScaleItemId &&
                        this.ParentElement.Id.Equals(cr.ParentElement.Id) &&
                        this.ParentConstruct.Id.Equals(cr.ParentConstruct.Id) &&
                        this.Id.Equals(cr.Id)
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
