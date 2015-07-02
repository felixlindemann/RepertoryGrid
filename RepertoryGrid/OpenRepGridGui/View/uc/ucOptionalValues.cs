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

        private List<rParameter> acceptedValues;

        public List<rParameter> AcceptedValues
        {
            get { return acceptedValues; }
            set
            {
                acceptedValues = value;

                if (value == null) return;
                foreach(rParameter p in this.AcceptedValues){  
                    if (p.VariableType == typeof(String))
                    {
                        ucOptionalValueString ucv = new ucOptionalValueString();
                        ucv.RParameter = p;
                        ucv.Dock = DockStyle.Top;
                        panel1.Controls.Add(ucv);
                    }
                    if (p.VariableType == typeof(int))
                    {
                        ucOptionalValuesInteger ucv = new ucOptionalValuesInteger();
                        ucv.RParameter = p;

                        ucv.Dock = DockStyle.Top;
                        panel1.Controls.Add(ucv);
                    }
                    if (p.VariableType == typeof(double))
                    {
                        ucOptionalValuesDouble ucv = new ucOptionalValuesDouble();
                        ucv.RParameter = p;

                        ucv.Dock = DockStyle.Top;
                        panel1.Controls.Add(ucv);
                    }
                    if (p.VariableType == typeof(bool))
                    {
                        ucOptionalValuesBoolean ucv = new ucOptionalValuesBoolean();
                        ucv.RParameter = p;

                        ucv.Dock = DockStyle.Top;
                        panel1.Controls.Add(ucv);
                    }
                    if (p.VariableType == typeof(Dictionary<String, Boolean>))
                    {
                        ucOptionalValueStringEnumDictionary ucv = new ucOptionalValueStringEnumDictionary();
                        ucv.RParameter = p;
                        ucv.Dock = DockStyle.Top;
                        panel1.Controls.Add(ucv);
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

            foreach (Control ctl in panel1.Controls)
            {
                if (ctl is IucOptionalValues)
                {
                    IucOptionalValues uc = (IucOptionalValues)ctl;
                    if (uc.isUsed)
                    {
                        o.Add(uc.RParameter.VarName, uc.ParamValue);
                    }
                }
                else
                {
                    Console.WriteLine("Expected was {0} -- Recieved: {1}",
                        typeof(IucOptionalValues).GetType().ToString(), ctl.GetType().ToString());
                }
            }

            return o;
        }


    }
}
