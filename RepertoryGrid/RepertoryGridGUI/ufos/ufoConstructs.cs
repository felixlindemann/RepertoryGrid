using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RepertoryGridGUI.UserControls;
using RepertoryGrid.Service;
using System.Diagnostics;

namespace RepertoryGridGUI.ufos
{
    public partial class ufoConstructs : Form
    {

        public ufoConstructs()
        {
            InitializeComponent();
        }

        private InterviewService interviewService;

        public InterviewService CurrentInterviewService
        {
            get { return interviewService; }
            set
            {
                interviewService = value;
                this.CurrentInterviewService.PropertyChanged += new PropertyChangedEventHandler(CurrentInterviewService_PropertyChanged);
                Bind();

            }
        }

        void CurrentInterviewService_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            this.dataRepeater1.SuspendLayout();
            this.constructBindingSource.SuspendBinding();
            this.constructBindingSource.DataSource =
                this.CurrentInterviewService.CurrentInterview;
            this.constructBindingSource.DataMember = "Constructs";
            this.dataRepeater1.DataSource = this.constructBindingSource;
            this.constructBindingSource.ResumeBinding();
            this.constructBindingSource.ResetBindings(false);
            this.dataRepeater1.ResumeLayout();
            this.dataRepeater1.Refresh();
        }

        #region Eventhandler

        private void dataRepeater1_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            try
            {
                Control[] ca = e.DataRepeaterItem.Controls.Find("ucConstruct1", false);
                if (ca != null && ca.Length == 1)
                {
                    UcConstruct uc = (UcConstruct)ca[0];

                    uc.CurrentInterviewService =
                        this.CurrentInterviewService;
                    uc.CurrentConstruct =
                        this.CurrentInterviewService.CurrentInterview
                            .Constructs[e.DataRepeaterItem.ItemIndex];
                 //   uc.reOrderedConstructEventHandler += new EventHandler.ReOrderedConstructEventHandler(uc_reOrderedConstructEventHandler);
                 //   uc.constructDeleteEventHandler += new EventHandler.ConstructDeleteEventHandler(uc_constructDeleteEventHandler);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }
        }

        void uc_constructDeleteEventHandler(EventHandler.ConstructDeletedEventArgs e)
        {
            Bind(); // throw new NotImplementedException();
        }

        void uc_reOrderedConstructEventHandler(EventHandler.ReOrderedConstructEventArgs e)
        {
           Bind(); // throw new NotImplementedException(); 
        }

        private void toolStripButtonAddConstruct_Click(object sender, EventArgs e)
        {
            try
            {
                this.CurrentInterviewService.AddConstruct();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during Adding a Construct");
            }
        }

        #endregion
         

        private void ufoConstructs_ResizeBegin(object sender, EventArgs e)
        {
            this.dataRepeater1.SuspendLayout();
        }

        private void ufoConstructs_ResizeEnd(object sender, EventArgs e)
        {

            this.dataRepeater1.ResumeLayout();
            this.dataRepeater1.Refresh();
        }
         

    }
}
