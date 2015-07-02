using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics; 
using RepertoryGrid.Model;
using RepertoryGridGUI.UserControls;
using RepertoryGrid.Service;
using Microsoft.VisualBasic.PowerPacks;

namespace RepertoryGridGUI.ufos
{
    public partial class ufoScoring : Form
    {

        public ufoScoring()
        {
            InitializeComponent();
        }

        #region Variables

        private InterviewService interviewService;
        private List<ucScoring> UcScorings = new List<ucScoring>();
         Boolean RePositioning = false;

        #endregion

        #region Properties

        public InterviewService CurrentInterviewService
        {
            get { return interviewService; }
            set
            {
                this.interviewService = value;
                this.elementBindingSource.DataSource = this.CurrentInterviewService.CurrentInterview;
                this.elementBindingSource.DataMember = "Elements";
                this.constructBindingSource.DataSource = this.CurrentInterviewService.CurrentInterview;
                this.constructBindingSource.DataMember = "Constructs";
            }
        }

        #endregion


        #region EventHandler

        void b_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                Score r = (Score)btn.Tag;
                DialogRateElement dlg = new DialogRateElement();
                dlg.CurrentScore = r;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (r.ScaleItemId == int.MinValue ||
                        r.ScaleItemId == int.MaxValue)
                    {
                        btn.Text = "NA";
                    }
                    else
                    {
                        btn.Text = "" + r.ScaleItemId;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error during Scoring Element");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.CurrentInterviewService.AddConstruct();

            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            try
            {
                this.CurrentInterviewService.AddElement();

            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }

        private void dataRepeater1_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            try
            {

                Control[] ca = e.DataRepeaterItem.Controls.Find("ucScoring1", false);
                if (ca != null && ca.Length == 1)
                {

                    Construct c = this.CurrentInterviewService.CurrentInterview.Constructs[e.DataRepeaterItem.ItemIndex];
                    ucScoring d = (ucScoring)ca[0];
                    if (UcScorings.Contains(d) == false) UcScorings.Add(d);
                    d.panelRight.Width = this.panelRight.Width - (this.dataRepeaterConstructs.VerticalScroll.Visible ? System.Windows.Forms.SystemInformation.VerticalScrollBarWidth : 0);
                    d.CurrentInterviewService = this.CurrentInterviewService;
                    d.CurrentConstruct = c;
                    if (c.Name == null) c.Name = "";
                    d.scoringPositionChangedEventHandler += new EventHandler.ScoringPositionChangedEventHandler(d_scoringPositionChangedEventHandler);
                    //d.scoringScrollingPositionChangedEventHandler += new EventHandler.ScoringScrollingPositionChangedEventHandler(d_scoringScrollingPositionChangedEventHandler);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }

        #region Navigation

        private void bind()
        {

        }

        private void Reposition(int newIndex)
        {

            if (RePositioning) return;

            Debug.WriteLine("newIndex: {0}", newIndex);

            RePositioning = true;
            this.elementBindingSource.Position = newIndex;
            if(dataRepeaterElements.ItemCount > 0 && dataRepeaterElements.ItemCount <newIndex)
            this.dataRepeaterElements.ScrollItemIntoView(newIndex, true);
            foreach (ucScoring uc in UcScorings)
            {
                if (uc != null)
                {
                    uc.scoreBindingSource.Position = newIndex;
                }
            }


            RePositioning = false;
        }

        private void d_scoringPositionChangedEventHandler(EventHandler.ScoringPositionChangedEventArgs e)
        {
            Reposition(e.Index);
        }

        private void elementBindingSource_PositionChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("this.elementBindingSource.Position: {0}", this.elementBindingSource.Position);
            Reposition(this.elementBindingSource.Position);
        }

        #endregion
        /*
        #region Scrolling

        private void ReScroll(int newPosition)
        {
            if (Scrolling) return;
            Scrolling = true;
            //this.dataRepeaterElements.HorizontalScroll.Value = newPosition;

            this.dataRepeaterElements.HorizontalScroll.Value = newPosition; 
            //this.dataRepeaterElements.Invalidate();
            foreach (ucScoring uc in UcScorings)
            {
                if (uc != null)
                {
                    uc.dataRepeaterScoring.HorizontalScroll.Value = newPosition;
                    uc.dataRepeaterScoring.Update();
                    uc.dataRepeaterScoring.Refresh();
                }
            }


            Scrolling = false;
        }

        private void d_scoringScrollingPositionChangedEventHandler(EventHandler.ScoringScrollingPositionChangedEventArgs e)
        {
            ReScroll(e.Position);
        }

        private void dataRepeaterElements_Scroll(object sender, ScrollEventArgs e)
        {
            ReScroll(this.dataRepeaterElements.HorizontalScroll.Value);
        }

        #endregion
        */

        #endregion

        #region Resize

        private void ufoScoring_ResizeEnd(object sender, EventArgs e)
        {
            this.ResumeLayout();
        }

        private void ufoScoring_ResizeBegin(object sender, EventArgs e)
        {
            this.SuspendLayout();

        }

        #endregion

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                  this.CurrentInterviewService.MoveUp(this.constructBindingSource.Position);
                  this.constructBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during moving a Concept");
            }
        } 

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                this.CurrentInterviewService.MoveDown(this.constructBindingSource.Position);
                this.constructBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during moving a Concept");
            }

        }


        private void moveLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            { 
                this.CurrentInterviewService.MoveLeft(this.elementBindingSource.Position);

                navigateElements();
                this.Reposition(Math.Max(0, this.elementBindingSource.Position - 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during moving an element");
            }
        }

        private void moveRightToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                this.CurrentInterviewService.MoveRight(this.elementBindingSource.Position);
                navigateElements();
                this.Reposition(Math.Min(this.elementBindingSource.Count-1, this.elementBindingSource.Position + 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during moving an element");
            }
        }
        private void navigateElements()
        {
            this.elementBindingSource.ResetBindings(false);
            foreach (ucScoring uc in UcScorings)
            {
                if (uc != null)
                {
                    uc.Rebind();
                    uc.Invalidate();
                }
            }
        }
        private void addConstructToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                this.interviewService.AddConstruct();
                this.constructBindingSource.ResetBindings(false);
                this.constructBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during adding a construct");
            }
        }

        private void removeCurrentConstructToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Construct c = (Construct)this.constructBindingSource.Current;

                if (MessageBox.Show(String.Format("Do you really want to delete the construct '{2}' ({0}/{1})", c.ContrastPol, c.ConstructPol, c.Name), "Confirm Delete") != System.Windows.Forms.DialogResult.OK) throw new Exception("Aborted");
                
                this.interviewService.DeleteConstruct(c);
                this.constructBindingSource.ResetBindings(false);
                this.constructBindingSource.MoveFirst();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during adding a construct");
            }
        }

        private void addElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormNewElement frm = new FormNewElement();
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.interviewService.AddElement();
                    this.interviewService.CurrentInterview.Elements.Last().Name = frm.textBoxElementName.Text;
                    navigateElements();
                    this.elementBindingSource.MoveLast();
                }
                else
                {
                    throw new Exception("User aborted insert.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during adding a construct");
            }
        }

        private void removeCurrentElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Element el = (Element)this.elementBindingSource.Current;

                if (MessageBox.Show(String.Format("Do you really want to delete the Element '{0}'", el.Name), "Confirm Delete") != System.Windows.Forms.DialogResult.OK) throw new Exception("Aborted");

                this.interviewService.DeleteElement(el);
                navigateElements();
                this.elementBindingSource.MoveFirst();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during adding a construct");
            }
        }
    }
}
