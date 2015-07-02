using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RepertoryGrid.Service; 
using System.Diagnostics;
using RepertoryGrid.Model;
using System.IO;

namespace RepertoryGridGUI
{
    public partial class FormProject : Form
    {

        #region Variables

        private ProjectService projectService;
        private RHelper.RHelper r;

        #endregion

        #region Properties

        public RHelper.RHelper R
        {
            get { return r; }
            set { r = value; }
        }

        public ProjectService ProjectSrv
        {
            get { return projectService; }
            set { projectService = value; }
        }

        #endregion

        #region Constructor

        public FormProject()
        {
            InitializeComponent();
            try
            {
                this.R = new RHelper.RHelper();
                this.R.rExec += new RHelper.RExececutedEventHandler(R_rExec);
                this.R.Execute("library(OpenRepGrid)");
                this.ProjectSrv = new ProjectService(this.R);
                this.projectBindingSource.DataSource = this.ProjectSrv.CurrentProject;
                this.ProjectSrv.PropertyChanged += new PropertyChangedEventHandler(ProjectSrv_PropertyChanged);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during start-up");
                this.Close();
            }

        }

        #endregion

        #region Methods

        private void check4Changes()
        {
            if (this.ProjectSrv.CurrentProject.HasChanges)
            {
                if (MessageBox.Show("Unsaved Changes have been detected. Should they be saved?", "Confirm Saving Changes", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    throw new Exception("Action aborted");
                }
            }
        }

        #endregion

        #region Eventhandler

        void ProjectSrv_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.dataRepeater1.SuspendLayout();
            this.interviewsBindingSource.SuspendBinding();
            this.projectBindingSource.SuspendBinding();
            if (e.PropertyName == "CurrentProject")
            {
                this.projectBindingSource.DataSource = this.ProjectSrv.CurrentProject;
                this.interviewsBindingSource.DataSource = this.projectBindingSource;
                this.interviewsBindingSource.DataMember = "Interviews";
            }
            else if (e.PropertyName == "InterviewServices")
            {
                this.interviewsBindingSource.DataSource = this.projectBindingSource;
                this.interviewsBindingSource.DataMember = "Interviews";
            }
            this.dataRepeater1.ResumeLayout();
            this.projectBindingSource.ResumeBinding();
            this.interviewsBindingSource.ResumeBinding();
        }

        private void R_rExec(RHelper.RExececutedEventArgs e)
        {
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}", e.RCmd);
            if (e.Output.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Result:\n{0}", e.Output);
            }

            Console.ForegroundColor = c;
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                check4Changes();
                this.ProjectSrv.CurrentProject.Interviews.Clear();
                this.ProjectSrv.CurrentProject.Name = "<new project>";
                this.ProjectSrv.CurrentProject.Id = Guid.NewGuid();
                this.ProjectSrv.CurrentProject.Remark = "";
                this.ProjectSrv.InterviewServices = new List<InterviewService>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while saving Changes to Project"); 
            }
        }

        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                check4Changes();
                this.ProjectSrv.CurrentProject.Interviews.Clear();
                this.ProjectSrv.CurrentProject.Name = "<new project>";
                this.ProjectSrv.CurrentProject.Id = Guid.NewGuid();
                this.ProjectSrv.CurrentProject.Remark = "";
                this.ProjectSrv.InterviewServices = new List<InterviewService>();

                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Felix Lindemann (*.xml)|*.xml|All Files (*.*)|*.*";
                opf.Multiselect = false;
                if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.ProjectSrv.ImportFelixLindemann(new System.IO.FileInfo(opf.FileName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while saving Changes to Project");
                throw;
            }
        }

        private void loadDemosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.menuStrip1.Enabled = false;
                this.toolStripProgressBar1.Visible = true;
                this.toolStripStatusLabelStatus.Visible = true;
                this.dataRepeater1.SuspendLayout();
                this.dataRepeater1.DataSource = null;
                this.ProjectSrv.getDemo(backgroundWorker1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while saving Changes to Project");

            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            this.toolStripProgressBar1.Visible = false;
            this.toolStripStatusLabelStatus.Visible = false;


            this.menuStrip1.Enabled = true;
            this.ProjectSrv.CurrentProject.ResetHasChanges();
            this.dataRepeater1.DataSource = this.interviewsBindingSource;
            this.dataRepeater1.ResumeLayout();

            if (e.Cancelled) throw new OperationCanceledException();

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                this.toolStripProgressBar1.Value = e.ProgressPercentage;
                this.toolStripStatusLabelStatus.Text = string.Format("Status: {0}", e.UserState);
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void addInterviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.ProjectSrv.AddInterview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while Adding an Interview to Project");

            }
        }

        private void loadRandomDemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.ProjectSrv.AddRandomGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while Adding a random Interview to Project");

            }
        }

        private void optionenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogProjectProperties dlg = null;
            try
            {
                dlg = new DialogProjectProperties();
                dlg.Service = this.ProjectSrv;
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while Adjusting Options of Project");

            }
            finally
            {
                if (dlg != null) dlg.Close();
                dlg = null;
            }
        }

        private void buttonOpenInterview_Click(object sender, EventArgs e)
        {
            try
            {

                Button btn = (Button)sender;
                Guid id = Guid.Parse(btn.Tag.ToString());

                Predicate<InterviewService> p = new Predicate<InterviewService>(x => x.CurrentInterview.Id.Equals(id));

                if (this.ProjectSrv.InterviewServices.Any(x => p(x)) == false)
                    throw new KeyNotFoundException("The requested Interview could not be found.");

                InterviewService IS = this.ProjectSrv.InterviewServices.Single(x => p(x));
                this.Hide();
                FormInterview frm = new FormInterview();
                frm.CurrentInterviewService = IS;

                frm.ShowDialog();
                frm = null;
                this.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while Opening an Interview");

            }
            finally
            {
                
            }
        }

        private void buttonDeleteInterview_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                Guid id = Guid.Parse(btn.Tag.ToString());

                Predicate<Interview> p = new Predicate<Interview>(x => x.Id.Equals(id)); 

                if (this.ProjectSrv.CurrentProject.Interviews.Any(x => p(x)) == false)
                    throw new KeyNotFoundException("The requested Interview could not be found.");
                
                Interview interview = this.ProjectSrv.CurrentProject.Interviews.Single(x => p(x));
                if (MessageBox.Show(string.Format("Do you really want to delete the Interview with Proband '{0}'?",
                    interview.Proband), "Confirm Delete of Interview", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                    throw new OperationCanceledException();
                this.ProjectSrv.RemoveInterview(interview);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while Deleting an Interview");

            }
            finally
            {
                
            }
        }

        #endregion

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Choose file to save Project";
                sfd.Filter = "XML-Files (*.xml)|*.xml)";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FileInfo f = new FileInfo(sfd.FileName);
                    this.projectService.Save(f);
                }
                else
                {
                    throw new Exception("Aborted by user");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Failure while saving");
            }
        }

    }
}
