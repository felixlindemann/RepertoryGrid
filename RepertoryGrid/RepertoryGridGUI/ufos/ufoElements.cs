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
using RepertoryGridGUI.UserControls;

namespace RepertoryGridGUI.ufos
{
    public partial class ufoElements : Form
    { 
        public ufoElements()
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
            this.elementBindingSource.SuspendBinding();
            this.elementBindingSource.DataSource =
                this.CurrentInterviewService.CurrentInterview;
            this.elementBindingSource.DataMember = "Elements";
            this.dataRepeater1.DataSource = this.elementBindingSource;
            this.elementBindingSource.ResumeBinding();
            this.elementBindingSource.ResetBindings(false);
            this.dataRepeater1.ResumeLayout();
            this.dataRepeater1.Refresh();
        }

        private void dataRepeater1_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            try
            {
                Control[] ca = e.DataRepeaterItem.Controls.Find("ucElement1", false);
                if (ca != null && ca.Length == 1)
                {
                    UcElement uc = (UcElement)ca[0];
                    uc.CurrentInterviewService = 
                        this.CurrentInterviewService;
                    uc.CurrentElement = 
                        this.CurrentInterviewService.CurrentInterview
                            .Elements[e.DataRepeaterItem.ItemIndex];
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }
        }

        private void ufoElements_ResizeBegin(object sender, EventArgs e)
        {
            this.dataRepeater1.SuspendLayout();
        }

        private void ufoElements_ResizeEnd(object sender, EventArgs e)
        {
            this.dataRepeater1.ResumeLayout();
            this.dataRepeater1.Refresh();
        }

        private void toolStripButtonAddElement_Click(object sender, EventArgs e)
        {

            try
            {
                this.CurrentInterviewService.AddElement();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during Adding an Element");
            }
        }
    }
}
