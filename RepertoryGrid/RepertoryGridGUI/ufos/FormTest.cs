using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RepertoryGridGUI.ufos
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent(); 
            this.rotatedTextLabel1.DataBindings.Add(new System.Windows.Forms.Binding("RotationAngle", this.trackBar1, "Value", true));
            this.rotatedTextLabel1.DataBindings.Add(new System.Windows.Forms.Binding("FitHeight", this.checkBoxFitHeight, "Checked", true));
            this.rotatedTextLabel1.DataBindings.Add(new System.Windows.Forms.Binding("FitWidth", this.checkBoxFitWidth, "Checked", true));
            this.rotatedTextLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Debugging", this.checkBoxShowBorder, "Checked", true));
            this.rotatedTextLabel1.DataBindings.Add(new System.Windows.Forms.Binding("DemoModus", this.checkBoxDemoModus, "Checked", true));
           
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}
