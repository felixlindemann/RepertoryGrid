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
    public partial class UserControlConstructLeftPole : UserControl
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

        public UserControlConstructLeftPole()
        {
            InitializeComponent();
        }

        private void nameTextBox_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter( e);
        }

        private void nameTextBox_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);

        }

        private void contrastPolTextBox_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void contrastPolTextBox_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }
    }
}
