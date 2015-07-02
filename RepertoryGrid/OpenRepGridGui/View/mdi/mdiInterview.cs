﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenRepGridGui.Service;
using OpenRepGridModel.Model;
using LimeTree.Extensions;
using LimeTree.Gui.Input;
using OpenRepGridGui.View.Dialog;

namespace OpenRepGridGui.View.mdi
{
    public partial class mdiInterview : Form
    {
        public mdiInterview()
        {
            InitializeComponent();
            this.panelScoringLeft.AutoScroll = true;
            this.panelScoringRight.AutoScroll = true;
            this.panelScoringTop.AutoScroll = true;
            this.panelScoringMain.AutoScroll = true;
            this.panelScoringLeft.HorizontalScroll.Enabled = false;
            this.panelScoringLeft.HorizontalScroll.Visible = false;
            this.panelScoringRight.HorizontalScroll.Enabled = false;
            this.panelScoringRight.HorizontalScroll.Visible = false;
            this.panelScoringTop.VerticalScroll.Enabled = false;
            this.panelScoringTop.HorizontalScroll.Visible = false;
            this.panelScoringLeft.Scroll += new ScrollEventHandler(panelScoringLeft_Scroll);
            this.panelScoringRight.Scroll += new ScrollEventHandler(panelScoringLeft_Scroll);
            this.panelScoringTop.Scroll += new ScrollEventHandler(panelScoringLeft_Scroll);
            this.panelScoringMain.Scroll += new ScrollEventHandler(panelScoringLeft_Scroll);
            ClearScoring();
        }

        #region Properties

        private InterviewService interviewService;

        public InterviewService Service
        {
            get { return interviewService; }
            set
            {
                interviewService = value;
                this.interviewBindingSource.DataSource = interviewService.CurrentInterview;

            }
        }

        public Interview CurrentInterview
        {
            get
            {
                try
                {
                    return (Interview)this.interviewBindingSource.Current;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public Element CurrentElement
        {
            get
            {
                try
                {
                    return (Element)this.elementsBindingSource.Current;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public Construct CurrentConstruct
        {
            get
            {
                try
                {
                    return (Construct)this.constructsBindingSource.Current;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        #endregion

        #region Eventhandler

        #region Elements

        #region Buttons

        private void toolStripButtonMoveLeft_Click(object sender, EventArgs e)
        {
            try
            {
                this.elementsBindingSource.EndEdit();
                this.interviewBindingSource.EndEdit();
                this.CurrentInterview.Elements.MoveUp(this.elementsBindingSource.Position);
                this.CurrentInterview.FirePropertyChanged("Elements");
                this.Service.FirePropertyChanged("CurrentInterview");
                this.ClearScoring();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while moving an element to the left");
            }
        }

        private void toolStripButtonMoveRight_Click(object sender, EventArgs e)
        {
            try
            {
                this.elementsBindingSource.EndEdit();
                this.interviewBindingSource.EndEdit();
                this.CurrentInterview.Elements.MoveDown(this.elementsBindingSource.Position);
                this.CurrentInterview.FirePropertyChanged("Elements");
                this.Service.FirePropertyChanged("CurrentInterview");
                this.ClearScoring();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while moving an element to the right");
            }

        }

        private void toolStripButtonAddElement_Click(object sender, EventArgs e)
        {

            try
            {
                this.elementsBindingSource.EndEdit();
                this.interviewBindingSource.EndEdit();
                this.elementsBindingSource.SuspendBinding();
                this.Service.AddElement();
                this.elementsBindingSource.ResumeBinding();
                this.ClearScoring();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while adding an element");
            }
        }

        private void toolStripButtonRemoveElement_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Should the current Element really be deleted?", "Confirm Delete", MessageBoxButtons.YesNoCancel) == System.Windows.Forms.DialogResult.OK)
                {

                    this.elementsBindingSource.EndEdit();
                    this.interviewBindingSource.EndEdit();
                    this.elementsBindingSource.SuspendBinding();
                    this.Service.DeleteElement(elementsBindingSource.Position);
                    this.elementsBindingSource.ResumeBinding();
                    this.ClearScoring();
                }
                else
                {
                    throw new Exception("Aborted by user");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while removing an element");
            }
        }

        #endregion

        #region Evaluation

        #endregion

        #endregion

        #region Constructs

        #region Buttons

        private void toolStripButtonMoveUp_Click(object sender, EventArgs e)
        {


            try
            {

                this.CurrentInterview.Constructs.MoveUp(this.constructsBindingSource.Position);
                this.CurrentInterview.FirePropertyChanged("Constructs");
                this.Service.FirePropertyChanged("CurrentInterview");
                this.ClearScoring();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while moving a construct up");
            }
        }

        private void toolStripButtonMoveDown_Click(object sender, EventArgs e)
        {


            try
            {
                this.CurrentInterview.Constructs.MoveDown(this.constructsBindingSource.Position);
                this.CurrentInterview.FirePropertyChanged("Constructs");
                this.Service.FirePropertyChanged("CurrentInterview");
                this.ClearScoring();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while moving a construct down");
            }
        }

        private void toolStripButtonAddConstructs_Click(object sender, EventArgs e)
        {

            try
            {
                this.Service.AddConstruct();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while adding a construct");
            }
        }

        private void toolStripButtonRemoveConstruct_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Should the current Construct really be deleted?", "Confirm Delete", MessageBoxButtons.YesNoCancel) == System.Windows.Forms.DialogResult.OK)
                {

                    this.constructsBindingSource.EndEdit();
                    this.interviewBindingSource.EndEdit();
                    this.constructsBindingSource.SuspendBinding();
                    this.Service.DeleteConstruct(constructsBindingSource.Position);
                    this.constructsBindingSource.ResumeBinding();
                    this.ClearScoring();
                }
                else
                {
                    throw new Exception("Aborted by user");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while removing a construct");
            }
        }

        #endregion

        #region Evaluation

        #endregion

        #endregion

        #region R

        private void setToRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.elementsBindingSource.EndEdit();
                this.constructsBindingSource.EndEdit();
                this.interviewBindingSource.EndEdit();
                this.Service.SetToR(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while moving a construct up");
            }
        }

        private void updateFromRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.elementsBindingSource.EndEdit();
                this.constructsBindingSource.EndEdit();
                this.interviewBindingSource.EndEdit();

                this.elementsBindingSource.SuspendBinding();
                this.constructsBindingSource.SuspendBinding();
                this.interviewBindingSource.SuspendBinding();

                this.Service.GetFromR(false);


                this.interviewBindingSource.ResumeBinding();
                this.elementsBindingSource.ResumeBinding();
                this.constructsBindingSource.ResumeBinding();
                this.ClearScoring();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while moving a construct up");
            }
        }

        #endregion

        private void toolStripButtonAutosizeConstructs_Click(object sender, EventArgs e)
        {
            try
            {
                this.constructsDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
            catch (Exception)
            {

            }
        }


        private void toolStripButtonAutosizeElements_Click(object sender, EventArgs e)
        {
            try
            {
                this.elementsDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
            catch (Exception)
            {

            }

        }
        #endregion

        #region helper

        private DataGridView getDGV(TabPage p)
        {
            DataGridView dgv = new DataGridView();
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToAddRows = false;

            dgv.Dock = DockStyle.Fill;
            p.Controls.Add(dgv);
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            return dgv;
        }

        private TabPage getNewTabpage(string name)
        {
            TabPage p = new TabPage();
            p.Text = name;
            tabControl1.TabPages.Add(p);
            tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
            return p;
        }

        #endregion

        #region Scoring

        #region Scrolling

        Boolean scrolling = false;
        private void panelScoringLeft_Scroll(object sender, ScrollEventArgs e)
        {
            if (this.scrolling) return;
            try
            {
                scrolling = true;
                if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                {

                    this.panelScoringTop.HorizontalScroll.Value = e.NewValue;
                    this.panelScoringMain.HorizontalScroll.Value = e.NewValue;
                }
                else if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
                {
                    this.panelScoringLeft.VerticalScroll.Value = e.NewValue;
                    this.panelScoringRight.VerticalScroll.Value = e.NewValue;
                    this.panelScoringMain.VerticalScroll.Value = e.NewValue;
                }
                scrolling = false;
            }
            catch (Exception ex)
            {
                scrolling = false;
                Console.WriteLine(ex.ToString());
            }
        }

        #endregion

        private void ClearScoring()
        {
            try
            {
                this.panelScoringLeft.Controls.Clear();
                this.panelScoringTop.Controls.Clear();
                this.panelScoringRight.Controls.Clear();
                this.panelScoringMain.Controls.Clear();
                LabelsConstructsLeft = new Label[0];
                LabelsConstructsRight = new Label[0];
                LabelsElement = new RotatedTextLabel[0];
                cboScoring = new ComboBox[0, 0];

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        Label[] LabelsConstructsLeft = new Label[0];
        Label[] LabelsConstructsRight = new Label[0];
        RotatedTextLabel[] LabelsElement = new RotatedTextLabel[0];
        ComboBox[,] cboScoring = new ComboBox[0, 0];
        List<BindingSource> BindingSources = new List<BindingSource>();

        private void ReDrawScoring()
        {
            int width = 45;
            this.SuspendLayout();
            try
            {
                ClearScoring();
                BindingSources = new List<BindingSource>();
                LabelsConstructsLeft = new Label[this.CurrentInterview.Constructs.Count];
                LabelsConstructsRight = new Label[this.CurrentInterview.Constructs.Count];
                LabelsElement = new RotatedTextLabel[this.CurrentInterview.Elements.Count];
                cboScoring = new ComboBox[this.CurrentInterview.Constructs.Count, this.CurrentInterview.Elements.Count];
                this.toolStripComboBoxFromElements.Items.Clear();
                this.toolStripComboBoxFromElements.Items.AddRange(this.CurrentInterview.Elements.Select(x => x.Name).ToArray());
                this.toolStripComboBoxToElements.Items.Clear();
                this.toolStripComboBoxToElements.Items.AddRange(this.CurrentInterview.Elements.Select(x => x.Name).ToArray());

                for (int j = 0; j < this.CurrentInterview.Elements.Count; j++)
                {
                    Element element = this.CurrentInterview.Elements[j];
                    LabelsElement[j] = new RotatedTextLabel();
                    LabelsElement[j].Size = new Size(width, this.panelScoringTop.Height);
                    LabelsElement[j].Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
                    LabelsElement[j].Debugging = false;
                    LabelsElement[j].DemoModus = false;
                    LabelsElement[j].FitHeight = false;
                    LabelsElement[j].FitWidth = false;
                    LabelsElement[j].Margin = new System.Windows.Forms.Padding(3);
                    LabelsElement[j].Name = "rotatedTextLabel_" + j;
                    LabelsElement[j].RotatedAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    LabelsElement[j].RotationAngle = 90D;
                    LabelsElement[j].Text = element.Name;
                    LabelsElement[j].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    LabelsElement[j].Location = new System.Drawing.Point(3 + j * (width + 3), 3);
                    this.panelScoringTop.Controls.Add(LabelsElement[j]);

                    for (int i = 0; i < this.CurrentInterview.Constructs.Count; i++)
                    {
                        Construct construct = this.CurrentInterview.Constructs[i];
                        Score score = element.Scores.Single(x => x.ParentConstruct.Id.Equals(construct.Id));
                        BindingSource c = new BindingSource();
                        c.DataSource = score;

                        BindingSource b = new BindingSource();
                        BindingList<ScaleItem> bl = new BindingList<ScaleItem>(this.CurrentInterview.Scales);
                        b.DataSource = bl;


                        cboScoring[i, j] = new ComboBox();
                        cboScoring[i, j].DropDownWidth = 400;
                        cboScoring[i, j].DataSource = b;
                        cboScoring[i, j].DisplayMember = "DisplayName";
                        cboScoring[i, j].ValueMember = "Id";
                        cboScoring[i, j].Size = new System.Drawing.Size(width, 21);
                        cboScoring[i, j].Location = new System.Drawing.Point(3 + j * (width + 3), 3 + i * 24);
                        cboScoring[i, j].Tag = score;
                        cboScoring[i, j].LostFocus += new EventHandler(mdiInterview_LostFocus);
                        cboScoring[i, j].DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", c, "ScaleItemId", true));
                        this.panelScoringMain.Controls.Add(cboScoring[i, j]);

                        this.toolTip1.SetToolTip(cboScoring[i, j],
                            string.Format("Element: {0} -- Construct: {1}/{2}",
                            element.Name, construct.ContrastPol,
                            construct.ContrastPol));
                        BindingSources.Add(c);
                        BindingSources.Add(b);

                        if (j == 0)
                        {
                            Label lbl = new Label();
                            lbl.Text = construct.ContrastPol;
                            this.toolTip1.SetToolTip(lbl, construct.Name);
                            lbl.Size = new Size(this.panelScoringLeft.Width, 21);
                            lbl.Location = new Point(0, 3 + i * (21 + 3));
                            lbl.TextAlign = ContentAlignment.MiddleRight;
                            this.panelScoringLeft.Controls.Add(lbl);

                            lbl = new Label();
                            lbl.Text = construct.ConstructPol;
                            this.toolTip1.SetToolTip(lbl, construct.Name);
                            lbl.Size = new Size(this.panelScoringRight.Width, 21);
                            lbl.Location = new Point(0, 3 + i * (21 + 3));
                            lbl.TextAlign = ContentAlignment.MiddleLeft;
                            this.panelScoringRight.Controls.Add(lbl);

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            this.ResumeLayout();
        }

        void mdiInterview_LostFocus(object sender, EventArgs e)
        {
            ComboBox s = (ComboBox)sender;
            this.Validate();
        }


        private void toolStripButtonReloadScoring_Click(object sender, EventArgs e)
        {
            this.ReDrawScoring();
        }

        private void toolStripButtonCopyRating_Click(object sender, EventArgs e)
        {
            try
            {
                Element source = this.CurrentInterview.Elements.First(x => x.Name == toolStripComboBoxFromElements.SelectedItem.ToString());
                Element destination = this.CurrentInterview.Elements.First(x => x.Name == toolStripComboBoxToElements.SelectedItem.ToString());
                if (source.Id.Equals(destination.Id)) throw new Exception("Copying requires different source and target.");

                foreach (Score score in source.Scores)
                {
                    foreach (Score tscore in destination.Scores)
                    {
                        if (tscore.ParentConstruct.Id.Equals(score.ParentConstruct.Id))
                        {
                            this.interviewService.GiveRating(destination, score.ParentConstruct, score.ScaleItemId);

                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while copying scores");
            }
        }

        #endregion

        #region evaluate

        private void removeAllEvaluationTabsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = tabControl1.TabPages.Count - 1; i > 3; i--)
                {
                    tabControl1.TabPages.RemoveAt(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while Removing Tabpages.");
            }
        }

        #region Elements

        private void statsElementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dlgValues dlg = new dlgValues();
                dlg.Text = "Please provide custom parameters for the statsElements function";
                dlg.AcceptedValues = InterviewService.StatsGridAcceptedValues();
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    throw new Exception("Aborted by User");
                }

                RDotNet.DataFrame df = this.interviewService.StatsGrid(true, dlg.OptionalValues); 
                RHelper.RHelper.FillDataGridViewFromR(df, getDGV(getNewTabpage("statsElements")), 3);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while Calculating statistics for elements");
            }
        }
       
        #region Correlation

        private void correlationsForElementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dlgValues dlg = new dlgValues();
                dlg.Text = "Please provide custom parameters for the elementCor function";
                dlg.AcceptedValues = InterviewService.CorrelationAcceptedValues();
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    throw new Exception("Aborted by User");
                }

                RDotNet.NumericMatrix df = this.interviewService.Correlation(true, dlg.OptionalValues);
                RHelper.RHelper.FillDataGridViewFromR(df, getDGV(getNewTabpage("elementCor")), 3);
          
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Error while Calculating Correlations for Elements");
            }
        }

        private void rootMeanSquareCorrelationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dlgValues dlg = new dlgValues();
                dlg.Text = "Please provide custom parameters for the elementRmsCor function";
                dlg.AcceptedValues = InterviewService.CorrelationRMSAcceptedValues();
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    throw new Exception("Aborted by User");
                }
                 
                RDotNet.DataFrame df = this.interviewService.CorrelationRMS(true, dlg.OptionalValues);
                RHelper.RHelper.FillDataGridViewFromR(df, getDGV(getNewTabpage("elementRmsCor")), 3);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Error while Calculating Root mean square correlation for Elements");
            }
        }

        #endregion

        #region Distances

        private void distancesBetweenElementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dlgValues dlg = new dlgValues();
                dlg.Text = "Please provide custom parameters for the distance function";
                dlg.AcceptedValues = InterviewService.DistanceAcceptedValues();
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    throw new Exception("Aborted by User");
                }

                RDotNet.NumericMatrix df = this.interviewService.Distance(true, dlg.OptionalValues);
                RHelper.RHelper.FillDataGridViewFromR(df, getDGV(getNewTabpage("ElementsDistance")), 3);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Error while Calculating Distances between Elements");
            } 
        }

        private void slaterDistances1977ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dlgValues dlg = new dlgValues();
                dlg.Text = "Please provide custom parameters for the Slater-distance function";
                dlg.AcceptedValues = InterviewService.DistanceSlaterAcceptedValues();
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    throw new Exception("Aborted by User");
                }

                RDotNet.NumericMatrix nm = this.Service.DistanceSlater(dlg.OptionalValues);

                DataGridView dgv = getDGV(getNewTabpage("distanceSlater"));
                RHelper.RHelper.FillDataGridViewFromR(nm, dgv, 3);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while Calculating Slater-1977-Distances between Elements");
            }
        }

        private void hartmannDistances1992ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

                try
                {
                    dlgValues dlg = new dlgValues();
                    dlg.Text = "Please provide custom parameters for the Hartmann-distance function";
                    dlg.AcceptedValues = InterviewService.DistanceHartmannAcceptedValues();
                    if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        throw new Exception("Aborted by User");
                    }

                    RDotNet.NumericMatrix df = this.interviewService.DistanceHartmann( dlg.OptionalValues);
                    RHelper.RHelper.FillDataGridViewFromR(df, getDGV(getNewTabpage("distanceHartmann")), 3);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine(ex.StackTrace);
                    MessageBox.Show(ex.Message, "Error while Calculating Hartmann1992-Distances between Elements");
                }  
        }

        private void heckmannsApproach2012ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dlgValues dlg = new dlgValues();
                dlg.Text = "Please provide custom parameters for the Heckmann-distance function (prob, progress, distribution not implemented here)";
                dlg.AcceptedValues = InterviewService.DistanceNormalizedAcceptedValues();
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    throw new Exception("Aborted by User");
                }


                RDotNet.NumericMatrix df = this.interviewService.DistanceHartmann(dlg.OptionalValues);
                RHelper.RHelper.FillDataGridViewFromR(df, getDGV(getNewTabpage("distanceNormalized")), 3);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Error while Calculating Heckmann-Distances between Elements");
            }  
        }

        #endregion

        private void clusterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dlgValues dlg = new dlgValues();
                dlg.Text = "Please provide custom parameters for the Cluster function";
                dlg.AcceptedValues = InterviewService.ClusterAcceptedValues();
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    throw new Exception("Aborted by User");
                }
                this.interviewService.cluster(dlg.OptionalValues);
                this.ClearScoring();
                this.constructsBindingSource.ResetBindings(false);
                this.elementsBindingSource.ResetBindings(false);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Error while Clustering");
            }
        }

        #endregion

        #region Constructs

        private void toolStripMenuItemStatsElementsConstructs_Click(object sender, EventArgs e)
        {
            try
            {
                dlgValues dlg = new dlgValues();
                dlg.Text = "Please provide custom parameters for the statsConstructs function";
                dlg.AcceptedValues = InterviewService.StatsGridAcceptedValues();
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    throw new Exception("Aborted by User");
                }

                RDotNet.DataFrame df = this.interviewService.StatsGrid(false, dlg.OptionalValues);
                RHelper.RHelper.FillDataGridViewFromR(df, getDGV(getNewTabpage("statsConstructs")), 3);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while Calculating statistics for Constructs");
            } 
        }

        #region Correlation

        private void constructCorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dlgValues dlg = new dlgValues();
                dlg.Text = "Please provide custom parameters for the constructCor function";
                dlg.AcceptedValues = InterviewService.CorrelationAcceptedValues();
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    throw new Exception("Aborted by User");
                }

                RDotNet.NumericMatrix df = this.interviewService.Correlation(false, dlg.OptionalValues);
                RHelper.RHelper.FillDataGridViewFromR(df, getDGV(getNewTabpage("constructCor")), 3);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Error while Calculating Correlations for Constructs");
            }
        }

        private void rootMeanSquareCorrelationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                dlgValues dlg = new dlgValues();
                dlg.Text = "Please provide custom parameters for the constructRmsCor function";
                dlg.AcceptedValues = InterviewService.CorrelationRMSAcceptedValues();
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    throw new Exception("Aborted by User");
                }

                RDotNet.DataFrame df = this.interviewService.CorrelationRMS(false, dlg.OptionalValues);
                RHelper.RHelper.FillDataGridViewFromR(df, getDGV(getNewTabpage("constructRmsCor")), 3);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Error while Calculating Root mean square correlation for Constructs");
            }
        }

        private void somersDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dlgValues dlg = new dlgValues();
                dlg.Text = "Please provide custom parameters for the constructD function";
                dlg.AcceptedValues = InterviewService.SomerDAcceptedValues();
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    throw new Exception("Aborted by User");
                }

                RDotNet.NumericMatrix df = this.interviewService.ConstructD( dlg.OptionalValues);
                RHelper.RHelper.FillDataGridViewFromR(df, getDGV(getNewTabpage("constructD")), 3);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Error while Calculating Root mean square correlation for Constructs");
            }
        }

        #endregion // Correlation

        private void distanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dlgValues dlg = new dlgValues();
                dlg.Text = "Please provide custom parameters for the distance function";
                dlg.AcceptedValues = InterviewService.DistanceAcceptedValues();
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    throw new Exception("Aborted by User");
                }

                RDotNet.NumericMatrix df = this.interviewService.Distance(true, dlg.OptionalValues);
                RHelper.RHelper.FillDataGridViewFromR(df, getDGV(getNewTabpage("ConstructsDistance")), 3);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Error while Calculating Distances between Construct");
            } 
        }

        #endregion

        private void principalComponentAnalysisPCAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dlgValues dlg = new dlgValues();
                dlg.Text = "Please provide custom parameters for the constructPca function";
                dlg.AcceptedValues = InterviewService.PCAAcceptedValues();
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    throw new Exception("Aborted by User");
                }
                  this.interviewService.ConstructPCA( dlg.OptionalValues);
                  MessageBox.Show("Please Check the R-Output in the Console for the results!", "Principal component analysis (PCA) of inter-construct correlations");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Error during the Principal component analysis (PCA)");
            } 
        }


        #endregion
         



    }
}