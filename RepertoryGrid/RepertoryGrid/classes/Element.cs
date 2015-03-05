using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using RepertoryGrid.BaseClasses;

namespace RepertoryGrid.classes
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
        private int sortIndex = 0;
        private Boolean useForEvaluation = true;
        private List<Rating> ratings = new List<Rating>();

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
        /// Provides Opportunity to sort elements
        /// </summary>
        public int SortIndex
        {
            get { return sortIndex; }
            set { SetPropertyField("SortIndex", ref sortIndex, value); }
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
        /// if true, use for evaluation
        /// </summary>
        public Boolean UseForEvaluation
        {
            get { return useForEvaluation; }
            set { SetPropertyField("UseForEvaluation", ref useForEvaluation, value); }
        }

        /// <summary>
        /// Stores the Rating of the Element for each Construct.
        /// </summary>
        public List<Rating> Ratings
        {
            get { return ratings; }
        }

        #endregion

        #region Constructor

        public Element(Interview interview)
        {
            this.ParentInterview = interview;
            this.ParentInterview.AddElement(this);
            foreach (Construct c in this.ParentInterview.Constructs)
            {
                this.GiveRating(c, int.MaxValue);
            }
            this.HasChanges = false;

        }

        public Element(Interview interview, XElement xml)
        {
            if (xml.Name == "Element")
            {
                this.ParentInterview = interview;
                this.ParentInterview.AddElement(this);

                this.id = Guid.Parse(xml.Attribute("Id").Value);
                this.Name = xml.Attribute("Name").Value;
                this.SortIndex = int.Parse(xml.Attribute("SortIndex").Value);
                this.UseForEvaluation = Boolean.Parse(xml.Attribute("UseForEvaluation").Value);
                this.Remark = xml.Element("Remark").Value;
                foreach (Construct c in this.ParentInterview.Constructs)
                {
                    if (xml.Elements("Rating").Any(x => x.Attribute("ParentConstruct").Value == c.Id.ToString()))
                    {
                        Rating r =
                        GiveRating(c, int.Parse(xml.Elements("Rating")
                                                         .Single(x => x.Attribute("ParentConstruct").Value == c.Id.ToString())
                                                         .Attribute("ScaleItemId").Value));
                        r.Id = Guid.Parse(xml.Elements("Rating")
                                                         .Single(x => x.Attribute("ParentConstruct").Value == c.Id.ToString())
                                                         .Attribute("Id").Value);
                        r.HasChanges = false;
                    }
                    else
                    {
                        GiveRating(c, int.MaxValue);
                    }
                }
                this.HasChanges = false;
            }
            else
            {
                throw new Exception(String.Format("XML-Node doesn't match. Expected: 'Element'. Provided. '{0}'.", xml.Name));
            }
        }

        #endregion

        #region Methods

        public XElement getXML()
        {
            return new XElement("Element",
                new XAttribute("Id", this.Id.ToString()),
                new XAttribute("Name", this.Name),
                new XAttribute("SortIndex", this.SortIndex),
                new XAttribute("UseForEvaluation", this.UseForEvaluation),
                new XElement("Remark", this.Remark),
                this.Ratings.Select(x => x.getXML()));
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
                        this.SortIndex == ce.SortIndex &&
                        this.UseForEvaluation == ce.UseForEvaluation &&
                        this.Id.Equals(ce.Id)
                        ;
                /*
                result = result && this.Ratings.All(x => ce.Ratings.Any(y => x.Id.Equals(y.Id))
                                                      && ce.Ratings.Single(y => y.Id.Equals(x.Id)).ScaleItemId == x.ScaleItemId);

                result = result && ce.Ratings.All(x => this.Ratings.Any(y => x.Id.Equals(y.Id))
                                                      && this.Ratings.Single(y => y.Id.Equals(x.Id)).ScaleItemId == x.ScaleItemId);
                 */
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

        public void CopyRatings(Element from)
        {
            foreach (Rating rating in from.Ratings)
            {
                GiveRating(rating.ParentConstruct, rating.ScaleItemId);
            }
        }

        public Rating GiveRating(Construct c, int value)
        {
            return GiveRating(c.Id, value);
        }

        public Rating GiveRating(Guid Constructid, int value)
        {
            Rating r = null;
            if (this.ParentInterview.Constructs.Any(x => x.Id.Equals(Constructid)))
            {
                Construct c = this.ParentInterview.Constructs.Single(x => x.Id.Equals(Constructid));

                if (this.ParentInterview.Scales.Any(x => x.Id == value))
                {
                    if (this.Ratings.Any(x => x.ParentConstruct.Id.Equals(c.Id)))
                    {
                        r = this.Ratings.Single(x => x.ParentConstruct.Id.Equals(c.Id));
                        r.ScaleItemId = value;
                    }
                    else
                    {
                        r = new Rating(this, c, value);
                        this.AddRatings(r);
                    }

                    FirePropertyChanged("Ratings");
                    return r;
                }
                else
                {
                    throw new KeyNotFoundException(string.Format("The given Rating '{0}' is not part of the scale related to this construct. The Element can't be rated for non existing scale-keys.", value));
                }
            }
            else
            {
                throw new KeyNotFoundException(string.Format("A construct with the id '{0}' could not be found. The Element can't be rated for non existing constructs.", id.ToString()));
            }
        }

        public void AddRatings(Rating r)
        {
            ChangeRatings(r, true);
        }

        public void RemoveRatings(Rating r)
        {
            ChangeRatings(r, false);
        }

        private void ChangeRatings(Rating r, Boolean add)
        {
            if (r == null)
            {
                throw new ArgumentNullException("The value for the rating is null");
            }
            if (add)
            {
                if (this.Ratings.Any(x => x.ParentConstruct.Id.Equals(r.ParentConstruct.Id)))
                {
                    throw new DuplicateWaitObjectException("Rating Already exits");
                }
                r.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(r_PropertyChanged);
                this.Ratings.Add(r);
            }
            else
            {
                if (this.Ratings.Any(x => x.ParentConstruct.Id.Equals(r.ParentConstruct.Id)) == false)
                {
                    throw new NotSupportedException("The rating can't be removed. It's not part of the current Project.");
                }
                this.Ratings.Remove(r);
            }
            this.FirePropertyChanged("Ratings");
            r = null;
        }

        void r_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.HasChanges = (true);
        }

        public void RemoveConstruct(Construct c)
        {
            if (c == null)
            {
                throw new ArgumentNullException("The value for the Construct is null");
            }
            this.Ratings.RemoveAll(x => x.ParentConstruct.Id.Equals(c.Id));
            this.FirePropertyChanged("Ratings");
            c = null;
        }

        #endregion



        public void ResetHasChanges()
        {
            this.HasChanges = false;
            foreach (Rating r in this.Ratings)
            {
                r.HasChanges = false;
            }
        } 
    }
}
