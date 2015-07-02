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
    public partial class ucOptionalValuesBoolean : UserControl, IucOptionalValues
    {
        public ucOptionalValuesBoolean()
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
                this.toolTip1.SetToolTip(this.checkBoxValue, this.RParameter.Description);
                  
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
            get { return  this.checkBoxValue.Checked; }
        }

        private void checkBoxUseParameter_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBoxValue.Enabled = checkBoxUseParameter.Checked;
        }
    }
}
