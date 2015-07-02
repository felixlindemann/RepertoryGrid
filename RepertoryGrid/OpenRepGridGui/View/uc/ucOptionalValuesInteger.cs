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
    public partial class ucOptionalValuesInteger : UserControl, IucOptionalValues
    {
        public ucOptionalValuesInteger()
        {
            InitializeComponent();
        }


        private rParameter rparam;

        public rParameter RParameter
        {
            get { return rparam; }
            set
            {
                rparam = value;

                this.groupBoxParameter.Text = this.RParameter.VarName;
                this.toolTip1.SetToolTip(this.checkBoxUseParameter, this.RParameter.Description);
                checkBoxUseParameter.Checked = rparam.isOptional;
                checkBoxUseParameter.Checked = !rparam.isOptional;
                checkBoxUseParameter.Enabled = rparam.isOptional; 
                
                this.toolTip1.SetToolTip(this.numericUpDownInteger, this.RParameter.Description);
                if (rparam.PossibleValues != null)
                {
                    if (typeof(int[]) == rparam.PossibleValues.GetType())
                    {
                        int[] p = (int[])rparam.PossibleValues;
                        if (p.Length == 2)
                        {
                            numericUpDownInteger.Minimum = p[0];
                            numericUpDownInteger.Maximum = p[1];
                        }
                    }
                }


            }
        }

        public Boolean isUsed
        {
            get
            {
                return this.checkBoxUseParameter.Checked;
            }
        }

        public object ParamValue
        {
            get { return (int)this.numericUpDownInteger.Value; }
        }

        private void checkBoxUseParameter_CheckedChanged(object sender, EventArgs e)
        {
            this.numericUpDownInteger.Enabled = checkBoxUseParameter.Checked;
        }
         

    }
}
