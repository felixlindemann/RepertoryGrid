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
    public partial class ucOptionalValuesDouble : UserControl, IucOptionalValues
    {
        public ucOptionalValuesDouble()
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
                checkBoxUseParameter.Checked = rparam.isOptional;
                checkBoxUseParameter.Checked = !rparam.isOptional;
                checkBoxUseParameter.Enabled = rparam.isOptional;

                this.toolTip1.SetToolTip(this.checkBoxUseParameter, this.RParameter.Description);
                this.toolTip1.SetToolTip(this.numericUpDownDouble, this.RParameter.Description);
                if (rparam.PossibleValues != null)
                {
                    if (typeof(double[]) == rparam.PossibleValues.GetType())
                    {
                        double[] p = (double[])rparam.PossibleValues;
                        if (p.Length == 2)
                        {
                            numericUpDownDouble.Minimum = (decimal)p[0];
                            numericUpDownDouble.Maximum = (decimal)p[1];
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
            get { return (double)this.numericUpDownDouble.Value; }
        }

        private void checkBoxUseParameter_CheckedChanged(object sender, EventArgs e)
        {
            this.numericUpDownDouble.Enabled = checkBoxUseParameter.Checked;
        }
    }

}