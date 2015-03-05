using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text; 
using System.Windows.Forms;
using RepertoryGrid.classes;
using RDotNet;

namespace RepertoryGrid
{
    public partial class FormStatus : Form
    {
        private RHelper.RHelper rengine;
        private Project project;

        public Project CurrentProject
        {
            get { return project; }
            set { project = value; }
        }

        public RHelper.RHelper rEngine
        {
            get { return rengine; }
            set { rengine = value; }
        }
        public FormStatus()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = Math.Min(this.progressBar1.Maximum, Math.Max(this.progressBar1.Minimum, e.ProgressPercentage));
            this.labelProgress.Text = String.Format("{0} / {1} %", this.progressBar1.Value, this.progressBar1.Maximum);
            this.labelTask.Text = e.UserState.ToString();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.progressBar1.Value == 100)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                project = new Project();
                project.getDemo(this.rEngine, backgroundWorker1);
                this.CurrentProject = project;
            }
            catch (Exception ex)
            {

                this.backgroundWorker1.ReportProgress(0, ex.ToString());
            }
        }

        private void FormStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy && MessageBox.Show("Do you want to cancel the current process?", "Confirm Cancelling Process", MessageBoxButtons.YesNoCancel) == System.Windows.Forms.DialogResult.Yes)
            {

                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                backgroundWorker1.CancelAsync();
                e.Cancel = true;
                this.Visible = false;
            }


        }
    }
}
