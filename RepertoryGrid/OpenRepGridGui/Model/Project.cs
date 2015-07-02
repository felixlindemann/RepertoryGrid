using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Diagnostics;
using System.ComponentModel;
using LimeTree.BaseClasses;

namespace OpenRepGridModel.Model
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

        public   Boolean HasChanges()
        {
            return this.hasChanges || this.Interviews.Any(x => x.HasChanges());
        }

        #endregion

        #region Constructor

        public Project()
        {
            this.Id = Guid.NewGuid();
            this.ResetHasChanges();
        }

        public Project(XElement xml)
        {
            if (xml.Name == "Project")
            {

                this.id = Guid.Parse(xml.Attribute("Id").Value);
                this.Name = xml.Attribute("Name").Value;
                this.Remark = xml.Element("Remark").Value;
                this.Interviews.Clear();

                this.ResetHasChanges();
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


        void i_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.ResetHasChanges();
        }

        public void ResetHasChanges()
        {
            this.hasChanges = false;
            foreach (Interview interview in this.Interviews)
            {
                interview.ResetHasChanges();
            }
        }

        #endregion

    }

}
