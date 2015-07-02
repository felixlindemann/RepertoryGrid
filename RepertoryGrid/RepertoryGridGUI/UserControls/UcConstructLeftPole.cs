using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RepertoryGrid.Model;

namespace RepertoryGridGUI.UserControls
{
    public partial class UcConstructLeftPole : UserControl
    {
        private Construct construct;

        public Construct CurrentConstruct
        {
            get { return construct; }
            set { construct = value; }
        }
        public UcConstructLeftPole()
        {
            InitializeComponent();
        }
    }
}
