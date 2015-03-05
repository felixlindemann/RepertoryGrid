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
    public partial class DialogConstructPCA : Form
    {
        public Boolean UseCutOff { get; set; }
        public Double CutOffLevel { get; set; }
        public Interview CurrentInterview { get; set; }
        public String Rcmd { get; set; }

        public DialogConstructPCA()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            generateRCommand();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        private void generateRCommand()
        {
            this.Rcmd = string.Format("constructPca({0}, rotate=\"{1}\", method=\"{2}\", nf={3})",
                this.CurrentInterview.GridName,
                this.flowLayoutPanelrotate.Controls.OfType<RadioButton>()
                           .FirstOrDefault(n => n.Checked)
                           .Text.ToLower(),
                this.flowLayoutPanelcorrmatrix.Controls.OfType<RadioButton>()
                           .FirstOrDefault(n => n.Checked)
                           .Text.ToLower(),
                this.numericUpDownNF
                .Value
                );
            this.UseCutOff = checkBoxCutOff.Checked;
            this.CutOffLevel = (double)numericUpDownCutoff.Value;
        }
    }
}
