using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RepertoryGrid.Service;
using RepertoryGrid.Model;
using RepertoryGridGUI.EventHandler;
using System.Diagnostics;

namespace RepertoryGridGUI.UserControls
{
    public partial class ucScoring : UserControl
    {

        private InterviewService interviewService;
        private Construct construct;

        public Construct CurrentConstruct
        {
            get { return construct; }
            set
            {
                construct = value;
                try
                {
                    if (construct == null) return;
                    Rebind();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                    //throw;
                }
            }
        }

        public InterviewService CurrentInterviewService
        {
            get { return interviewService; }
            set { interviewService = value; }
        }


        public ucScoring()
        {
            InitializeComponent();
        }

        public void Rebind()
        {
            this.constructBindingSource.DataSource = this.CurrentConstruct;

            List<Score> scores = this.CurrentInterviewService.CurrentInterview.Elements
                    .SelectMany(x => x.Scores.Where(y => y.ParentConstruct.Id.Equals(this.CurrentConstruct.Id))).ToList();


            this.scoreBindingSource.DataSource = scores;
            this.textBoxName.DataBindings.Clear();
            this.textBoxConstrast.DataBindings.Clear();
            this.textBoxConstructPole.DataBindings.Clear();
            this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.constructBindingSource, "Name", true));
            this.textBoxConstrast.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.constructBindingSource, "ContrastPol", true));
            this.textBoxConstructPole.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.constructBindingSource, "ConstructPol", true));

            this.dataRepeaterScoring.DataSource = this.scoreBindingSource;
            this.scoreBindingSource.ResetBindings(false);
        }

        private void scoreBindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                if (FireEvent == false) return;
                if (scoreBindingSource.Current.GetType() == typeof(Score))
                { 
                    Score s = (Score)scoreBindingSource.Current;
                    ScoringPositionChanged(new ScoringPositionChangedEventArgs(s.ParentElement, s.ParentConstruct, scoreBindingSource.Position));

                    if (this.dataRepeaterScoring.ItemCount > 0 && this.dataRepeaterScoring.ItemCount < scoreBindingSource.Position)
                    this.dataRepeaterScoring.ScrollItemIntoView(scoreBindingSource.Position, true);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                //throw ex;
            }
        }
        Boolean FireEvent = true;
        public void setPosition(int index)
        {
            FireEvent = false;
            scoreBindingSource.Position = index;
            FireEvent = true;
        }

        public event ScoringPositionChangedEventHandler scoringPositionChangedEventHandler;
        protected virtual void ScoringPositionChanged(ScoringPositionChangedEventArgs e)
        {
            ScoringPositionChangedEventHandler handler = scoringPositionChangedEventHandler;
            if (handler != null)
            {
                handler(e);
            }
        }

        private void dataRepeaterScoring_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            try
            {

                Control[] ca = e.DataRepeaterItem.Controls.Find("buttonRating", false);
                if (ca != null && ca.Length == 1)
                {

                    Button d = (Button)ca[0];
                    Score s = (Score)scoreBindingSource[e.DataRepeaterItem.ItemIndex];
                    ScaleItem si = this.CurrentInterviewService.CurrentInterview.Scales.Single(x => x.Id == s.ScaleItemId);

                    d.Text = "" + si.Id;
                    if (si.IsDefault == false) d.Text = "NA";
                    d.Tag = s;
                    this.toolTip1.SetToolTip(d, si.Name);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRating_Click(object sender, EventArgs e)
        {
            try {
                Score s =(Score) ((Button)sender).Tag;
                DialogRateElement dlg = new DialogRateElement();
                dlg.CurrentScore = s;

                dlg.ShowDialog();
                ((Button)sender).Text = "" + s.ScaleItemId;

                ScaleItem si = this.CurrentInterviewService.CurrentInterview.Scales.Single(x => x.Id == s.ScaleItemId);

                this.toolTip1.SetToolTip((Button)sender, si.Name);
            
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }

        private void dataRepeaterScoring_Scroll(object sender, ScrollEventArgs e)
        {
            ScoringScrollPositionChanged(new ScoringScrollingPositionChangedEventArgs(this.dataRepeaterScoring.HorizontalScroll.Value));
        }


        public event ScoringScrollingPositionChangedEventHandler scoringScrollingPositionChangedEventHandler;
        protected virtual void ScoringScrollPositionChanged(ScoringScrollingPositionChangedEventArgs e)
        {
            ScoringScrollingPositionChangedEventHandler handler = scoringScrollingPositionChangedEventHandler;
            if (handler != null)
            {
                handler(e);
            }
        }

    }
}
