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
    public partial class DialogProjectProperties : Form
    {

        private ProjectService projectService;

        public ProjectService Service
        {
            get { return projectService; }
            set { 
                projectService = value;
                this.propertyGrid1.SelectedObject = value;
            }
        } 

        public DialogProjectProperties()
        {
            InitializeComponent();
        }
    }
}
