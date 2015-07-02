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
    public partial class ufoScales : Form
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
                Bind(true);
            }
        }

        #endregion

        #region Constructor

        public ufoScales()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void Bind(Boolean asc)
        {
            try
            {
                if (asc)
                {

                    this.scalesBindingSource.DataSource =
                      this.CurrentInterviewService.CurrentInterview
                          .Scales.OrderBy(x=> x.IsDefault)
                          .ThenBy(x=> x.Name);
                }
                else
                {
                    this.scalesBindingSource.DataSource =
                      this.CurrentInterviewService.CurrentInterview
                          .Scales.OrderBy(x => x.IsDefault)
                          .ThenByDescending(x => x.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during Bind / Sort of Scales");
            }
        }

        #endregion

        #region EventHandler

        private void toolStripButtonSortAscending_Click(object sender, EventArgs e)
        {
            Bind(true);
        }

        private void toolStripButtonDescending_Click(object sender, EventArgs e)
        {
            Bind(false);
        }

        #endregion

    }
}
