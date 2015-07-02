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
using OpenRepGridModel.Model;
using OpenRepGridGui.View.mdi;

namespace OpenRepGridGui
{
    public partial class ProjectSetup : Form
    {

        #region variables

        private ProjectService service;
        public ProjectService Service
        {
            get
            {
                return this.service;
            }
            set
            {
                this.service = value;
                this.projectBindingSource.DataSource = this.Service;
                this.projectBindingSource.DataMember = "CurrentProject";

                this.interviewBindingSource.DataSource = this.projectBindingSource;
                this.interviewBindingSource.DataMember = "Interviews";

                this.dataRepeater1.DataSource = this.interviewBindingSource;
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
            /*   this.dataRepeater1.SuspendLayout();
               this.interviewBindingSource.SuspendBinding();
               this.projectBindingSource.SuspendBinding();
               if (e.PropertyName == "CurrentProject")
               {
                  // this.projectBindingSource.DataSource = this.service.CurrentProject;
                   this.interviewBindingSource.DataSource = this.projectBindingSource;
                   this.interviewBindingSource.DataMember = "Interviews";
               }
               else if (e.PropertyName == "InterviewServices")
               {
               }
               this.dataRepeater1.ResumeLayout();
               this.projectBindingSource.ResumeBinding();
               this.interviewBindingSource.ResumeBinding();
             * */
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Should the current Interview really be deleted?", "Confirm Delete",
                    MessageBoxButtons.YesNoCancel) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.service.RemoveInterview((Interview)this.interviewBindingSource.Current);
                }
                else
                {
                    throw new Exception("Aborted by user");
                }
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
                Guid interviewId = ((Interview)interviewBindingSource.Current).Id;
                Form frm = this.MdiParent;
                if (frm.MdiChildren.Any(x => x.GetType() == typeof(mdiInterview) &&
                    ((mdiInterview)x).Service.CurrentInterview.Id.Equals(interviewId)))
                {
                    Form mdi = frm.MdiChildren.Single(x => x.GetType() == typeof(mdiInterview) &&
                    ((mdiInterview)x).Service.CurrentInterview.Id.Equals(interviewId));
                    mdi.WindowState = FormWindowState.Normal;
                    mdi.BringToFront();

                }
                else
                {
                    mdiInterview mdi = new mdiInterview();
                    mdi.MdiParent = this.MdiParent;
                    mdi.Service = this.Service.InterviewServices.Single(x => x.CurrentInterview.Id.Equals(interviewId));
                    mdi.Show();
                    mdi.BringToFront();
                    this.WindowState = FormWindowState.Minimized;
                }

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
                this.dataRepeater1.Enabled = (this.interviewBindingSource.Count > 0);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error while setting the enabled state of the data repeater");
            }
        }


        #endregion

        private void ProjectSetup_Load(object sender, EventArgs e)
        {

        }

    }

}
