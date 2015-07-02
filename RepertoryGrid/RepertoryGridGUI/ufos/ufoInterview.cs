using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RepertoryGrid.Service;

namespace RepertoryGridGUI
{
    public partial class ufoInterview : Form
    {

        private InterviewService interviewService;
        public InterviewService CurrentInterviewService
        {
            get { return interviewService; }
            set
            {
                interviewService = value;
                this.interviewsBindingSource.DataSource = this.CurrentInterviewService.CurrentInterview;
            }
        }
         
        public ufoInterview()
        {
            InitializeComponent();
        }
    }
}
