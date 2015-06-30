using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenRepGridGui.Service;

namespace OpenRepGridGui.View.mdi
{
    public partial class FormProperties : Form
    {
        public FormProperties()
        {
            InitializeComponent();
        }
        private ProjectService service;

        public ProjectService Service
        {
            get { return service; }
            set
            {
                service = value;
                this.propertyGrid1.SelectedObject = value;
            }
        }
        
        private void Properties_Load(object sender, EventArgs e)
        {

        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }
    }
}
