using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenRepGridGui.Service;
using System.IO;

namespace OpenRepGridGui
{
    public partial class ProjectSetup : Form
    {

        #region variables 

        private ProjectService service;

        public ProjectService Service
        {
            get { return service; }
            set { 
                service = value;

                this.Service.PropertyChanged += new PropertyChangedEventHandler(Service_PropertyChanged);
            
            }
        }


        #endregion

        public ProjectSetup()
        {

            InitializeComponent();


        }

        #region Event handler

        void Service_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.dataRepeater1.SuspendLayout();
            this.interviewBindingSource.SuspendBinding();
            this.projectBindingSource.SuspendBinding();
            if (e.PropertyName == "CurrentProject")
            {
                this.projectBindingSource.DataSource = this.service.CurrentProject;
                this.interviewBindingSource.DataSource = this.projectBindingSource;
                this.interviewBindingSource.DataMember = "Interviews";
            }
            else if (e.PropertyName == "InterviewServices")
            {
                this.interviewBindingSource.DataSource = this.projectBindingSource;
                this.interviewBindingSource.DataMember = "Interviews";
            }
            this.dataRepeater1.ResumeLayout();
            this.projectBindingSource.ResumeBinding();
            this.interviewBindingSource.ResumeBinding();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while deleting an interview from the project");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while editing an interview");
            }
        }

        private void interviewBindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                this.dataRepeater1.Enabled = (this.interviewBindingSource.Count >0);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, "Error while setting the enabled state of the data repeater");
            }
        }


        #endregion

    }

}
