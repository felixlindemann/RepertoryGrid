using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RepertoryGrid.Model;

namespace RepertoryGridGUI
{
    public partial class DialogRateElement : Form
    {

        #region Variables

        private Score score;

        #endregion

        #region Properties

        public Score CurrentScore
        {
            get { return score; }
            set
            {
                score = value;

                if (value != null)
                {
                    this.scoreBindingSource.DataSource = this.CurrentScore;
                    foreach (ScaleItem s in this.CurrentScore.ParentConstruct.ParentInterview.Scales)
                    {
                        RadioButton r = new RadioButton();
                        r.Checked = (score.ScaleItemId == s.Id);
                        r.AutoSize = true;
                        r.CheckAlign = ContentAlignment.TopCenter;

                        if (s.Id == int.MinValue)
                        {
                            r.Text = "No rating prefered";
                        }
                        else if (s.Id == int.MaxValue)
                        {
                            r.Text = "NAN";
                        }
                        else
                        {
                            r.Text = "" + s.Id;
                        }
                        this.toolTip1.SetToolTip(r, s.DisplayName);
                        r.Tag = s.Id;
                        r.CheckedChanged+=new System.EventHandler(r_CheckedChanged);
                        this.flowLayoutPanel1.Controls.Add(r);
                    }

                }
            }
        }

        #endregion

        public DialogRateElement()
        {
            InitializeComponent();
        }
        
        #region Event Handler
        
        void r_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            if (r.Checked)
            {
                this.CurrentScore.ScaleItemId = (int)r.Tag;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        #endregion

    }
}
