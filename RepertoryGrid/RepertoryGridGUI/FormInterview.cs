using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RepertoryGrid.Service;
using RepertoryGridGUI.ufos;

namespace RepertoryGridGUI
{
    public partial class FormInterview : Form
    {
        #region Variables

        private InterviewService interviewService; 

        #endregion

        #region Properties

        public InterviewService CurrentInterviewService
        {
            get { return interviewService; }
            set
            {
                interviewService = value;
                if (value == null)
                {
                    this.Close();
                    return;
                }
                this.interviewsBindingSource.DataSource = this.CurrentInterviewService.CurrentInterview;
            }
        }

        #endregion

        #region Constructor

        public FormInterview()
        {
            InitializeComponent();
        }

        #endregion

        private void interviewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form frm in this.MdiChildren)
                {
                    if(typeof( ufoInterview) == frm.GetType()){
                        frm.Show();
                        frm.BringToFront();
                        return;
                    }
                }
                ufoInterview ufo = new ufoInterview();
                ufo.CurrentInterviewService = this.CurrentInterviewService;
                ufo.MdiParent = this;
                ufo.Show(); 
                 
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message, "Show Interview Details: An Error Occured.");
            }
        }
        #region Eventhandler
         

         
        private void scalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form frm in this.MdiChildren)
                {
                    if (typeof(ufoScales) == frm.GetType())
                    {
                        frm.Show();
                        frm.BringToFront();
                        return;
                    }
                }
                ufoScales ufo = new ufoScales();
                ufo.CurrentInterviewService = this.CurrentInterviewService;
                ufo.MdiParent = this;
                ufo.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Show Interview Details: An Error Occured.");
            } 
        }

        private void constructsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form frm in this.MdiChildren)
                {
                    if (typeof(ufoConstructs) == frm.GetType())
                    {
                        frm.Show();
                        frm.BringToFront();
                        return;
                    }
                }
                ufoConstructs ufo = new ufoConstructs();
                ufo.CurrentInterviewService = this.CurrentInterviewService;
                ufo.MdiParent = this;
                ufo.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Show Interview Details: An Error Occured.");
            }  
        }

        private void elementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form frm in this.MdiChildren)
                {
                    if (typeof(ufoElements) == frm.GetType())
                    {
                        frm.Show();
                        frm.BringToFront();
                        return;
                    }
                }
                ufoElements ufo = new ufoElements();
                ufo.CurrentInterviewService = this.CurrentInterviewService;
                ufo.MdiParent = this;
                ufo.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Show Interview Details: An Error Occured.");
            }   
        }

        #endregion

        private void scoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form frm in this.MdiChildren)
                {
                    if (typeof(ufoScoring) == frm.GetType())
                    {
                        frm.Show();
                        frm.BringToFront();
                        return;
                    }
                }
                ufoScoring ufo = new ufoScoring();
                ufo.CurrentInterviewService = this.CurrentInterviewService;
                ufo.MdiParent = this;
                ufo.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Show Interview Details: An Error Occured.");
            }    
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

         
    }
}
