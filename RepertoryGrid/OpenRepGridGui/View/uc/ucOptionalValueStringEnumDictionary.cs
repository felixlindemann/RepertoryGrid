using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RHelper.model;

namespace OpenRepGridGui.View.uc
{
    public partial class ucOptionalValueStringEnumDictionary : UserControl, IucOptionalValues
    {
        private rParameter rparam;
        public ucOptionalValueStringEnumDictionary()
        {
            InitializeComponent();
        }

        public Boolean isUsed
        {
            get
            {
                return this.checkBoxUseParameter.Checked;
            }
        }



        public rParameter RParameter
        {
            get { return rparam; }
            set
            {
                rparam = value;

                this.groupBoxParameter.Text = this.RParameter.VarName;
                checkBoxUseParameter.Checked = rparam.isOptional;
                checkBoxUseParameter.Checked = !rparam.isOptional;
                checkBoxUseParameter.Enabled = rparam.isOptional;

                this.toolTip1.SetToolTip(this.checkBoxUseParameter, this.RParameter.Description);
                this.toolTip1.SetToolTip(this.flowLayoutPanel1, this.RParameter.Description);
                if (rparam.PossibleValues != null)
                {
                    if (typeof(Dictionary<String, Boolean>) == rparam.PossibleValues.GetType())
                    {
                        Dictionary<String, Boolean> p = (Dictionary<String, Boolean>)rparam.PossibleValues;
                        this.flowLayoutPanel1.Controls.Clear();
                        foreach (string key in p.Keys)
                        {
                            RadioButton rb = new RadioButton();
                            rb.Text = key;
                            rb.Checked = p[key];
                            this.flowLayoutPanel1.Controls.Add(rb);
                        }
                    }
                }


            }
        }

        public object[] ParamValue
        {
            get
            {
                if (this.flowLayoutPanel1.Controls.OfType<RadioButton>().Any(x => x.Checked))
                {
                    return new string[] { this.flowLayoutPanel1.Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked).Text };
                }
                else
                {
                    return new string[] { "NAN" };
                }
            }
        }


        private void checkBoxUseParameter_CheckedChanged(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Enabled = checkBoxUseParameter.Checked;
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
                  MessageBox.Show(this.RParameter.Description, string.Format("Info to Parameter: '{0}'", this.RParameter.VarName), MessageBoxButtons.OK, MessageBoxIcon.Information);
     
        }

    }
}
