using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RepertoryGrid.classes;
using System.Xml.Linq;
using RDotNet;
using System.IO;
using System.Diagnostics;

namespace RepertoryGrid
{
    public partial class FormProject : Form
    {

        #region Variables

        private RHelper.RHelper rengine;
        private FormInterview frmInterview;
        private FormProjectInspector frmInspector;
        private Project project;

        #endregion

        #region Properties

        public RHelper.RHelper rEngine
        {
            get { return rengine; }
            set { rengine = value; }
        }

        public Project CurrentProject
        {
            get { return project; }
            set
            {
                project = value;
                projectChanged();
            }
        }

        #endregion

        #region Constructors

        public FormProject()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void FormProject_Load(object sender, EventArgs e)
        {
            try
            {
                ShowSideBar();
                this.rEngine = new RHelper.RHelper();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error Occured during Loading the Application:");

            }
        }

        private void FormProject_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Check4Changes();
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message, "Closing failed.");
            }
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            ShowSideBar();
        }

        private void buttonAddInterview_Click(object sender, EventArgs e)
        {
            this.AddInterview();
        }

        private void öffnenToolStripButton_Click(object sender, EventArgs e)
        {
            this.LoadProjectFromXML();
        }

        private void toolStripButtonLoadDemos_Click(object sender, EventArgs e)
        {
            this.LoadDemos();
        }

        private void projectBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.SaveProject();
        }

        private void toolStripButtonChangeProjectDetails_Click(object sender, EventArgs e)
        {
            this.OpenFormProjectInspector();
        }

        private void toolStripButtonShowSideBar_Click(object sender, EventArgs e)
        {
            this.ShowSideBar();
        }

        private void neuToolStripButton_Click(object sender, EventArgs e)
        {
            this.newProject();
        }

        void frmInspector_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmInspector != null)
            {
                frmInspector.Dispose();
                frmInspector = null;
            }
        }

        void frmInterview_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmInterview != null)
            {
                frmInterview.Dispose();
                frmInterview = null;
            }
        }

        private void buttonOpenInterview_Click(object sender, EventArgs e)
        {
            OpenInterview(sender);
        }

        private void buttonDeleteInterview_Click(object sender, EventArgs e)
        {

        }

        private void FormProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.rEngine == null) return;
            this.rEngine.Dispose();
            this.rEngine = null;
        }

        #endregion

        #region formMethods

        private void OpenInterview(object sender)
        {
            try
            {
                if (sender.GetType() == typeof(Button))
                {
                    Button btn = (Button)sender;
                    if (btn.Tag.GetType() == typeof(Guid))
                    {
                        this.Validate();
                        Guid id = (Guid)btn.Tag;
                        this.ShowSideBar();
                        OpenCurrentInterview(id);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Open Interview failed");
            }
        }

        private void projectChanged()
        {
            try
            {
                this.dataRepeater1.DataSource = null;
                this.interviewsBindingSource.DataMember = "";
                this.interviewsBindingSource.DataSource =null;
                if (this.CurrentProject == null)
                {
                    this.interviewsBindingSource.DataSource = null;
                    this.interviewsBindingSource.ResumeBinding();

                }
                else
                {

                    this.interviewsBindingSource.ResetBindings(false);
                    this.interviewsBindingSource.DataMember = "";
                    this.interviewsBindingSource.DataSource = CurrentProject.Interviews;
                    this.interviewsBindingSource.ResumeBinding();
                    this.dataRepeater1.DataSource = this.interviewsBindingSource;
                    this.interviewsBindingSource.MoveLast();
                    this.dataRepeater1.Update();
                }
                ShowSideBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "projectChanged(): An Error Occured:");

            }
        }

        private void changeEnabled(Boolean isEnabled = true)
        {
            this.projectBindingNavigatorSaveItem.Enabled = isEnabled;
            this.toolStripButtonChangeProjectDetails.Enabled = isEnabled;
            this.toolStripButtonChangeProjectDetails.Enabled = isEnabled;
            this.toolStripButtonShowSideBar.Enabled = isEnabled;
        }

        private void LoadDemos()
        {
            try
            {
                Check4Changes();
                FormStatus frm = new FormStatus();
                frm.rEngine = this.rEngine;
                frm.backgroundWorker1.RunWorkerAsync();
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.CurrentProject = null;
                    this.CurrentProject = frm.CurrentProject;
                    this.CurrentProject.ResetHasChanges();
                    panel1.Enabled = true;
                    panel1.Visible = true;
                    this.interviewsBindingSource.MoveFirst();
                }
                else
                {
                    throw new OperationCanceledException("The Operation has been aborted");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading of Demos failed.");
            }
        }

        private void newProject()
        {
            try
            {
                Check4Changes();
                this.CurrentProject = new Project();
                this.CurrentProject.ResetHasChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Creating New Project failed");

            }
        }

        private void ShowSideBar()
        {
            try
            {

                changeEnabled(this.CurrentProject != null);

                if (this.CurrentProject == null)
                {
                    this.panelSideBar.Enabled = false;
                }
                else
                {
                    this.panelSideBar.Enabled = !this.panelSideBar.Enabled;
                }

                this.panelSideBar.Visible = this.panelSideBar.Enabled;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error Occured during changing visibility of SideBar:");
                ShowSideBar();
            }
        }

        private void AddInterview()
        {
            try
            {
                this.interviewsBindingSource.SuspendBinding();
                Interview interview = new Interview(this.CurrentProject);
                projectChanged();
                this.panelSideBar.Enabled = true;
                this.panelSideBar.Visible = true;
                this.interviewsBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error Occured during load:");

            }
        }

        private void OpenCurrentInterview(Guid id)
        {
            if (this.CurrentProject.Interviews.Any(x => x.Id.Equals(id))==false)
            { 
                throw new KeyNotFoundException("The Requested Interview could not be found");
            }
            if (frmInterview == null)
            {
                Interview interview = this.CurrentProject.Interviews.Single(x => x.Id.Equals(id));


                frmInterview = new FormInterview();
                frmInterview.CurrentInterview = interview;
                frmInterview.rEngine = this.rEngine;
                frmInterview.MdiParent = this;
                frmInterview.FormClosed += new FormClosedEventHandler(frmInterview_FormClosed);
                frmInterview.Show();
                frmInterview.BringToFront();

            }
            else
            {
                frmInterview.Show();
                frmInterview.BringToFront();
            }
        }

        private void SaveProject()
        {
            try
            {
                if (CurrentProject == null)
                {
                    throw new NoNullAllowedException("The current project has not been defined. This is neccassary!");
                }
                SaveFileDialog s = new SaveFileDialog();
                s.Title = "Choose XML-Grid";
                s.Filter = "XML-File (*.xml)|*.xml";
                s.AddExtension = true;
                s.CheckPathExists = true;
                s.OverwritePrompt = true;

                if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    XElement xe = CurrentProject.getXML();
                    xe.Save(s.FileName);
                    MessageBox.Show("The project has successfully been saved.");

                    this.CurrentProject.ResetHasChanges();
                }
                else
                {
                    MessageBox.Show("The project has not been saved.");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace, String.Format("An Error Occured during Saving Project: {0}", ex.Message));

            }
        }

        private void LoadProjectFromXML()
        {
            try
            {
                Check4Changes();
                using (OpenFileDialog opf = new OpenFileDialog())
                {
                    opf.Title = "Choose XML-Grid";
                    opf.Filter = "XML-File (*.xml)|*.xml|All-Files (*.*)|*.*";
                    if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        FileInfo f = new FileInfo(opf.FileName);
                        if (f.Exists)
                        {
                            XElement xe = XElement.Load(f.FullName);
                            this.CurrentProject = new Project(xe);
                            this.CurrentProject.ResetHasChanges();
                        }
                        else
                        {
                            MessageBox.Show("The selected File does not exists");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error Occured during load:");

            }
        }

        private void OpenFormProjectInspector()
        {

            if (frmInspector == null)
            {
                frmInspector = new FormProjectInspector();
                frmInspector.CurrentProject = CurrentProject;
                frmInspector.MdiParent = this;
                frmInspector.FormClosed += new FormClosedEventHandler(frmInspector_FormClosed);
                frmInspector.Show();
                frmInspector.BringToFront();
            }
            else
            {
                frmInspector.Show();
                frmInspector.BringToFront();
            }
        }

        private void DeleteInterview()
        {
            try
            {
                // TODO Implement DeleteInterview
                throw new NotImplementedException("'DeleteInterview' has not been implemented yet.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error Occured during deleting:");

            }
        }

        private void Check4Changes()
        {
            if (this.CurrentProject != null)
            {
                if (CurrentProject.HasChanges)
                {
                    if (MessageBox.Show("The Project has unsaved changes. Do you want to Save these changes?", "Confirm unsaved Changes", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        throw new Exception("The Operation was aborted due to uncofirmed Changes");
                    }
                }
            }
        }

        private void toolStripStatusLabel1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // http://openrepgrid.org/#projects
                Process.Start("http://openrepgrid.org/#projects");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error Occured:");

            }
        }

        #endregion
         
    }
}
