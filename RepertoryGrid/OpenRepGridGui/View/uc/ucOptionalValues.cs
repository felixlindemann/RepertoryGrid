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
    public partial class ucOptionalValues : UserControl
    {
        private List<IucOptionalValues> ctls = new List<IucOptionalValues>();
        private List<rParameter> acceptedValues;

        public List<rParameter> AcceptedValues
        {
            get { return acceptedValues; }
            set
            {
                acceptedValues = value;
                if (value == null) return;
                ctls = new List<IucOptionalValues>();
                foreach (rParameter p in this.AcceptedValues)
                {
                    TabPage t = new TabPage(p.VarName);
                    tabControl1.TabPages.Add(t);

                    if (p.VariableType == typeof(Dictionary<String, Boolean>))
                    {
                        ucOptionalValueStringEnumDictionary ucv = new ucOptionalValueStringEnumDictionary();
                        ucv.RParameter = p;
                        ucv.Dock = DockStyle.Fill;
                        t.Controls.Add(ucv);
                        ctls.Add(ucv);
                    }
                    else
                    {
                        ucOptionalValue ucv = new ucOptionalValue();
                        ucv.RParameter = p;
                        ucv.Dock = DockStyle.Fill;
                        t.Controls.Add(ucv);
                        ctls.Add(ucv);
                    }
                }
            }
        }


        public ucOptionalValues()
        {
            InitializeComponent();
        }


        public Dictionary<String, object> OptionalValues()
        {
            Dictionary<String, object> o = new Dictionary<string, object>();

            foreach (IucOptionalValues uc in ctls)
            {
                if (uc.isUsed)
                {
                    o.Add(uc.RParameter.VarName, uc.ParamValue);
                }
            }

            return o;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
