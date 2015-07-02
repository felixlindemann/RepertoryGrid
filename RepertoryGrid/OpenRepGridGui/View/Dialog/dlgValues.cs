using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RHelper.model;

namespace OpenRepGridGui.View.Dialog
{
    public partial class dlgValues : Form
    {
        public dlgValues()
        {
            InitializeComponent();
        }


        private List<rParameter> acceptedValues;
        public List<rParameter> AcceptedValues
        {
            get
            {
                return acceptedValues;
            }
            set
            {
                acceptedValues = value;

                this.ucOptionalValues1.AcceptedValues = this.AcceptedValues;
            }
        }

        public Dictionary<String, Object> OptionalValues
        {
            get
            {
                return ucOptionalValues1.OptionalValues();
            }
        }

        private void buttonok_Click(object sender, EventArgs e)
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
