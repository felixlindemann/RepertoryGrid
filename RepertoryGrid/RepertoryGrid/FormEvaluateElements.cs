using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;
using RepertoryGrid.classes;

namespace RepertoryGrid
{
    public partial class FormEvaluateElements : Form
    {

        private List<Construct> Constructs;
        private List<Element> Elements;
        private Interview interview;

        public Interview CurrentInterview
        {
            get { return interview; }
            set
            {
                interview = value;
                this.Name = "Interview: " + CurrentInterview.Proband;
                Constructs = CurrentInterview.Constructs.Where(x => x.UseForEvaluation).OrderBy(x => x.SortIndex).ThenBy(x => x.Name).ToList();
                Elements = CurrentInterview.Elements.Where(x => x.UseForEvaluation).OrderBy(x => x.SortIndex).ThenBy(x => x.Name).ToList();
                RatingconstructBindingSource.DataSource = Constructs;
                RatingelementBindingSource.DataSource = Elements;
            }
        }

        public FormEvaluateElements()
        {
            InitializeComponent();

            ldr.Add(dataRepeaterConstructLeft);
            ldr.Add(dataRepeaterConstructRight);
            lbs.Add(RatingconstructBindingSource);
        }

        private void Navigate()
        {
        }

        #region Scrolling

        private Boolean scrolling = false;
        List<DataRepeater> ldr = new List<DataRepeater>();
        private void dataRepeaterConstructLeft_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling(sender, e);
        }

        private void dataRepeaterConstructRight_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling(sender, e);
        }

        private void dataRepeaterConstructsElements_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling(sender, e);
        }
         
        private void Scrolling(object sender, ScrollEventArgs e)
        {
            try
            {
                /*
             * 0 : left
             * 1 : right
             * 2 : middle
             */
                if (scrolling) return;
                scrolling = true;

                DataRepeater dr = (DataRepeater)sender;
                int scrollposition = dr.VerticalScroll.Value;
                List<DataRepeater> ldr2 = new List<DataRepeater>();
                ldr2.AddRange(ldr.Where(x => x != null));
                ldr2.Remove(dr);
                foreach (DataRepeater drt in ldr)
                {
                    drt.VerticalScroll.Value = scrollposition;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                scrolling = false;
            }
        }

        #endregion

        #region SizeChanged

        private void FormEvaluateElements_SizeChanged(object sender, EventArgs e)
        {
            formsizechanged();
        }

        private void formsizechanged()
        {
            try
            {
                int h = dataRepeaterElements.HorizontalScroll.Visible ? 52 : 35;
                panel5.Size = new Size(0, h);
                panel7.Size = new Size(0, h);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void FormEvaluateElements_Paint(object sender, PaintEventArgs e)
        {

            formsizechanged();
        }

        private void FormEvaluateElements_Activated(object sender, EventArgs e)
        {

            formsizechanged();
        }

        #endregion

        #region Populate Elements

        private List<BindingSource> lbs = new List<BindingSource>(); 
       
        private void dataRepeaterElements_DrawItem(object sender, DataRepeaterItemEventArgs e)
        {
            try
            {
                Control[] ca = e.DataRepeaterItem.Controls.Find("ucElementConstruct1", false);
                if (ca != null && ca.Length == 1)
                {
                    UcElementConstruct uc = (UcElementConstruct)ca[0];
                    uc.CurrentInterview = this.CurrentInterview;
                    uc.CurrentElement = this.Elements[e.DataRepeaterItem.ItemIndex];
                    if (ldr.Any(x => x.Equals(uc.dataRepeaterConstructsElements)) == false)
                    {
                        ldr.Add(uc.dataRepeaterConstructsElements);
                    }
                    ldr.RemoveAll(x => x == null);
                    lbs.RemoveAll(x => x == null);
                    uc.dataRepeaterConstructsElements.Scroll += new ScrollEventHandler(Scrolling);
                    lbs.Add(uc.ratingsBindingSource);
                    uc.ratingsBindingSource.PositionChanged += new EventHandler(BindingSource_PositionChanged);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
  
        private void BindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            { 

                // constructBindingSource_PositionChanged
                BindingSource b = (BindingSource)sender;
                foreach (BindingSource bs in lbs.Where(x => !x.Equals(sender)))
                {
                    bs.Position = b.Position;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        #endregion 

        private void FormEvaluateElements_Load(object sender, EventArgs e)
        {

        }

        private void FormEvaluateElements_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                this.Validate(); 
                /*
                this.constructBindingSource.MoveFirst();
                this.constructBindingSource.MoveLast();*/
                 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void dataRepeaterElements_CurrentItemIndexChanged(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
         
    }
}
