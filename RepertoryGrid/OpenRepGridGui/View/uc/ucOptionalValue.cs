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
    public partial class ucOptionalValue : UserControl, IucOptionalValues
    {
        public ucOptionalValue()
        {
            InitializeComponent();
        }

        private Control ctl;
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

                this.buttonAdd.Visible = (this.RParameter.MinLength != this.RParameter.MaxLength);
                this.buttonRemove.Visible = (this.RParameter.MinLength != this.RParameter.MaxLength);

                this.toolTip1.SetToolTip(this.checkBoxUseParameter, this.RParameter.Description);
                this.toolTip1.SetToolTip(this.tableLayoutPanel1, this.RParameter.Description);
                this.toolTip1.SetToolTip(this.listBox1, this.RParameter.Description);

                if (this.RParameter.MaxLength == 1)
                {
                    this.buttonAdd.Visible = false;
                    this.buttonRemove.Visible = false;
                   // this.listBox1.Visible = false;
                    this.buttonReplace.Visible = false;
                }

                if (this.RParameter.VariableType == typeof(int))
                {
                    NumericUpDown n = new NumericUpDown();
                    n.Dock = DockStyle.Fill;
                    this.toolTip1.SetToolTip(n, this.RParameter.Description);
                    if (this.RParameter.PossibleValues != null &&
                        this.RParameter.PossibleValues.GetType() == (typeof(int[])))
                    {
                        int[] b = (int[])this.RParameter.PossibleValues;
                        if (b.Length == 2)
                        {
                            n.Minimum = b[0];
                            n.Maximum = b[1];
                        }
                    }
                    ctl = n;
                    if (this.buttonReplace.Visible == false)
                    {
                        n.ValueChanged += new EventHandler(n_ValueChanged);
                    }

                }
                else if (this.RParameter.VariableType == typeof(double))
                {
                    NumericUpDown n = new NumericUpDown();
                    n.Dock = DockStyle.Fill;
                    n.DecimalPlaces = 3;
                    this.toolTip1.SetToolTip(n, this.RParameter.Description);
                    if (this.RParameter.PossibleValues != null &&
                        this.RParameter.PossibleValues.GetType() == (typeof(double[])))
                    {
                        double[] b = (double[])this.RParameter.PossibleValues;
                        if (b.Length == 2)
                        {
                            n.Minimum = (decimal)b[0];
                            n.Maximum = (decimal)b[1];
                        }

                    }
                    ctl = n;
                    if (this.buttonReplace.Visible == false)
                    {
                        n.ValueChanged += new EventHandler(n_ValueChanged);
                    }

                }
                else if (this.RParameter.VariableType == typeof(bool))
                {
                    CheckBox n = new CheckBox();
                    n.Dock = DockStyle.Fill;
                    n.Text = "";
                    ctl = n;
                    if (this.buttonReplace.Visible == false)
                    {
                        n.CheckedChanged += new EventHandler(n_ValueChanged);
                    }
                }
                else if (this.RParameter.VariableType == typeof(string))
                {
                    TextBox n = new TextBox();
                    n.Dock = DockStyle.Fill;
                    n.Text = "";
                    ctl = n;
                    if (this.buttonReplace.Visible == false)
                    {
                        n.TextChanged += new EventHandler(n_ValueChanged);
                    }
                }
                else if (this.RParameter.VariableType == typeof(Color))
                {
                    Button n = new Button();
                    n.Dock = DockStyle.Fill;
                    n.Text = "Choose Color";
                    ctl = n;
                    n.Click += new EventHandler(n_Click);
                    buttonReplace.Visible = false;
                    label1.Visible = false;
                }


                if (ctl != null) this.panel1.Controls.Add(ctl);
                listBox1.Items.Clear();
                addToMax();



            }
        }

        void n_ValueChanged(object sender, EventArgs e)
        {
            replace();
        }

        void n_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Color c = dlg.Color;
                String s = string.Format("rgb({0}, {1}, {2}, {3}, maxColorValue = 255)",
                c.R, c.G, c.B, c.A);
                int index = Math.Max(0, listBox1.SelectedIndex);
                listBox1.Items[index] = s;
            }
        }

        public Boolean isUsed
        {
            get
            {
                return this.checkBoxUseParameter.Checked;
            }
        }

        public object[] ParamValue
        {
            get
            {

                List<object> l = new List<object>();
                foreach (object o in listBox1.Items)
                {
                    l.Add(o);
                }


                return l.ToArray();
            }
        }

        private void checkBoxUseParameter_CheckedChanged(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.Enabled = checkBoxUseParameter.Checked;
            if (this.checkBoxUseParameter.Checked && this.listBox1.SelectedItem == "NA")
            {
                replace();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            addToMax();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            removetoMin();
        }

        private void addToMax()
        {
            for (int i = listBox1.Items.Count; i < this.RParameter.MaxLength; i++)
            {
                this.listBox1.Items.Add("NA");
            }
            if (listBox1.Items.Count > 0) this.listBox1.SelectedIndex = 0;
        }

        private void removetoMin()
        {
            for (int i = listBox1.Items.Count; i >= this.RParameter.MinLength; i--)
            {
                this.listBox1.Items.RemoveAt(i);
            }
            if (listBox1.Items.Count > 0) this.listBox1.SelectedIndex = 0;
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            replace();
        }
        private void replace()
        {
            int index = Math.Max(0, listBox1.SelectedIndex);
            if (this.RParameter.VariableType == typeof(int) ||
                this.RParameter.VariableType == typeof(double))
            {
                NumericUpDown n = (NumericUpDown)ctl;
                listBox1.Items[index] = n.Value;

            }
            else if (this.RParameter.VariableType == typeof(bool))
            {
                CheckBox n = (CheckBox)ctl;
                listBox1.Items[index] = n.Checked;
            }
            else if (this.RParameter.VariableType == typeof(string))
            {
                TextBox n = (TextBox)ctl;
                listBox1.Items[index] = n.Text;
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {

            MessageBox.Show(this.RParameter.Description, string.Format("Info to Parameter: '{0}'", this.RParameter.VarName), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
