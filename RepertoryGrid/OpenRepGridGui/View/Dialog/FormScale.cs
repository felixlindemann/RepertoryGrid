using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenRepGridGui.Service;
using OpenRepGridModel.Model;

namespace OpenRepGridGui.View.Dialog
{
    public partial class FormScale : Form
    {
        private InterviewService interviewService;

        public InterviewService Service
        {
            get { return interviewService; }
            set { interviewService = value; }
        }

        public FormScale()
        {
            InitializeComponent();
        }

        private void scaleItemDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
        
        }

        private void FormScale_Load(object sender, EventArgs e)
        {

        }
    }
}
