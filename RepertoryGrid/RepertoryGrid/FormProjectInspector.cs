using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RepertoryGrid.classes;

namespace RepertoryGrid
{
    public partial class FormProjectInspector : Form
    {

        #region variables
        
        private Project project;

        #endregion

        #region Properties

        public Project CurrentProject
        {
            get { return project; }
            set
            { 
                project = value;
                projectBindingSource.DataSource = CurrentProject;
            }
        }

        #endregion

        #region Constructor

        public FormProjectInspector()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void FormProjectInspector_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Validate();
        }

        #endregion

    }
}
