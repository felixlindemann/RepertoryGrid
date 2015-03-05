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
    public partial class UcElementConstruct : UserControl
    {
        private List<Rating> ratings;

        private Element currentElement;
        public Element CurrentElement
        {
            get
            {
                return currentElement;
            }
            set
            {
                currentElement = value;
                bind();
            }
        }

        private Interview currentInterview;
        public Interview CurrentInterview
        {
            get
            {
                return currentInterview;
            }
            set
            {
                currentInterview = value;
                bind();
            }
        }

        private void bind()
        {

            if (CurrentElement == null)
            {
                Console.WriteLine("CurrentElement == null");

                return;
            }
            try
            {
                ratings = currentElement.Ratings.Where(x => x.ParentConstruct.UseForEvaluation).OrderBy(x => x.ParentConstruct.SortIndex).ThenBy(x => x.ParentConstruct.Name).ToList();
                this.ratingsBindingSource.DataSource = ratings;
                  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }

        public UcElementConstruct()
        {
            InitializeComponent();
        }

        private void dataRepeaterConstructsElements_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            try
            {
                Control[] ca = e.DataRepeaterItem.Controls.Find("ucEvaluateElements011", false);
                if (ca != null && ca.Length == 1)
                {
                    ucEvaluateElements01 uc = (ucEvaluateElements01)ca[0]; 
                    uc.CurrentRating = this.ratings[e.DataRepeaterItem.ItemIndex]; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
         
    }
}
