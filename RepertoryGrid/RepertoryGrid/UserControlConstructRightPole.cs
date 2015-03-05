using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RepertoryGrid.classes;

namespace RepertoryGrid
{
    public partial class UserControlConstructRightPole : UserControl
    {

        private Construct construct;

        public Construct CurrentConstruct
        {
            get { return construct; }
            set
            {
                construct = value;
                if (value != null)
                {
                    this.constructBindingSource.DataSource = construct;
                }
            }
        }

        public UserControlConstructRightPole()
        {
            InitializeComponent();
        }

        private void constructPolTextBox_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void constructPolTextBox_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }
    }
}
