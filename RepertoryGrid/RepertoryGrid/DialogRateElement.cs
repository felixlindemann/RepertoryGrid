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
    public partial class DialogRateElement : Form
    {
        private Rating rating;

        public Rating CurrentRating
        {
            get { return rating; }
            set
            {
                rating = value;

                if (value != null)
                {
                    this.ratingBindingSource.DataSource = this.CurrentRating;
                    foreach (ScaleItem s in rating.ParentConstruct.ParentInterview.Scales)
                    {
                        RadioButton r = new RadioButton();
                        r.Checked = (rating.ScaleItemId == s.Id);
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
                        r.CheckedChanged += new EventHandler(r_CheckedChanged);
                        this.flowLayoutPanel1.Controls.Add(r);
                    }

                }
            }
        }

        void r_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            if (r.Checked)
            {
                this.CurrentRating.ScaleItemId = (int)r.Tag;
            }
        }



        public DialogRateElement()
        {
            InitializeComponent();
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
    }
}
