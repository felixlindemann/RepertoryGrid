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
    public partial class ucOptionalValueString : UserControl, IucOptionalValues
    {
        public ucOptionalValueString()
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
                this.toolTip1.SetToolTip(this.textBoxValue, this.RParameter.Description);
                checkBoxUseParameter.Checked = rparam.isOptional;
                checkBoxUseParameter.Checked = !rparam.isOptional;
                checkBoxUseParameter.Enabled = rparam.isOptional; 
                
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
            get { return this.textBoxValue.Text; }
        }

        private void checkBoxUseParameter_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxValue.Enabled = checkBoxUseParameter.Checked;
        }

    }
}
