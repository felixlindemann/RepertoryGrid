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
    public partial class ucEvaluateElements01 : UserControl
    {

        private List<ScaleItem> scaleItems;
        private Rating currentRating;
        public Rating CurrentRating
        {
            get
            {
                return currentRating;
            }
            set
            {
                currentRating = value;
                bind();
            }
        }
         

        private void bind()
        {

            if (CurrentRating == null)
            { 
                return;
            }
            try
            {
                scaleItems = CurrentRating.ParentConstruct.ParentInterview.Scales.ToList();
                this.scaleItemBindingSource.DataSource = scaleItems;
                this.ratingBindingSource.DataSource = CurrentRating;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }
    
        public ucEvaluateElements01()
        {
            InitializeComponent();
        }
         
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
         
    }
}
