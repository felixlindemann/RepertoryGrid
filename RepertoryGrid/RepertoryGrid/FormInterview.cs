using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RepertoryGrid.classes; 
using System.Diagnostics;
using Microsoft.VisualBasic.PowerPacks;
using RepertoryGrid.input;
using RDotNet;
using org.lime.tree.controls.helper;

namespace RepertoryGrid
{
    public partial class FormInterview : Form
    {

        #region variables

        private int digits = 2;
        private Boolean isRCodeInit = false;
        private Boolean isRefreshed = false;
        private Boolean isRefreshing = false;
        private RHelper.RHelper rengine;
        private Interview interview;
        private List<Construct> lc;
        private List<Element> le;
        private UserControlConstructLeftPole[] uclpA;
        private UserControlConstructRightPole[] ucrpA;
        private OrientedTextLabel[] lblElemA;
        private Button[,] btnA;

        #endregion

        #region Properties

        public Interview CurrentInterview
        {
            get { return interview; }
            set
            {
                interview = value;
                if (value == null)
                {
                    this.Close();
                    return;
                }
                this.interviewBindingSource.DataSource = this.CurrentInterview;

                this.constructsBindingSource.DataMember = "Constructs";
                this.constructsBindingSource.DataSource = this.interviewBindingSource;
                this.dataRepeaterConstructs.DataSource = this.constructsBindingSource;

                this.elementsBindingSource.DataMember = "Elements";
                this.elementsBindingSource.DataSource = this.interviewBindingSource;
                this.dataRepeaterELements.DataSource = this.elementsBindingSource;

                refreshBinding();
            }
        }

        public RHelper.RHelper rEngine
        {
            get { return rengine; }
            set
            {
                rengine = value;

                if (rengine != null)
                {
                    this.ucRConsole1.rEngine = this.rEngine;
                    rengine.rExec += new BaseClasses.RExececutedEventHandler(rengine_rExec);
                }
            }
        }

        void rengine_rExec(BaseClasses.RExececutedEventArgs e)
        {
            this.CurrentInterview.ExecuteR(e.RCmd);
        }

        #endregion

        #region Constructors

        public FormInterview()
        {
            InitializeComponent();

        }

        #endregion

        #region Form Methods
          
        private void refreshBinding()
        {
            try
            {

                if (isRefreshing) return;

                isRefreshing = true;
                this.tabPageRatings.SuspendLayout();
                panelLeftConstructs.Controls.Clear();
                panelRightConstructs.Controls.Clear();
                panelMiddleElements.Controls.Clear();
                panelMiddleTop.Controls.Clear();
                lc = CurrentInterview.Constructs.Where(x => x.UseForEvaluation).OrderBy(x => x.SortIndex).ThenBy(x => x.Name).ToList();
                le = CurrentInterview.Elements.Where(x => x.UseForEvaluation).OrderBy(x => x.SortIndex).ThenBy(x => x.Name).ToList();
                int intLeft = 5;
                int deltaX = 5;
                int deltaY = 5;
                int intWidth = 30;
                int intHeight = 30;
                int intTop = 5;
                int I = lc.Count;
                int J = le.Count;

                uclpA = new UserControlConstructLeftPole[I];
                ucrpA = new UserControlConstructRightPole[I];
                lblElemA = new OrientedTextLabel[J];
                btnA = new Button[I, J];
                for (int j = 0; j < J; j++)
                {
                    Element elem = le[j];
                    OrientedTextLabel lblElem = new OrientedTextLabel();
                    lblElem.RotationAngle = -90;
                    lblElem.Text = elem.Name;
                    lblElem.Tag = elem;
                    lblElem.AutoSize = false;
                    lblElem.Width = intWidth;
                    lblElem.Height = panelMiddleTop.Height - 10;
                    panelMiddleTop.Controls.Add(lblElem);
                    lblElem.TextOrientation = input.Orientation.Rotate;
                    lblElem.Top = intTop;
                    lblElem.Left = intLeft + j * (lblElem.Width + deltaX);
                    lblElem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
                    lblElemA[j] = lblElem;
                    lblElem.MouseEnter += new EventHandler(lblElem_MouseEnter);
                    lblElem.MouseLeave += new EventHandler(lblElem_MouseLeave);
                    for (int i = 0; i < I; i++)
                    {
                        Construct con = lc[i];
                        if (j == 0)
                        {
                            // id Label
                            UserControlConstructLeftPole ucl = new UserControlConstructLeftPole();
                            ucl.CurrentConstruct = con;

                            panelLeftConstructs.Controls.Add(ucl);
                            ucl.Height = intHeight;
                            ucl.Top = intTop + i * (ucl.Height + deltaY) + splitter3.Height;
                            ucl.Left = 5;
                            ucl.Width = panelLeftConstructs.Width - 10;
                            ucl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                            ucl.MouseEnter += new EventHandler(ucl_MouseEnter);
                            ucl.MouseLeave += new EventHandler(ucl_MouseLeave);
                            uclpA[i] = ucl;

                            UserControlConstructRightPole ucr = new UserControlConstructRightPole();
                            ucr.CurrentConstruct = con;
                            ucrpA[i] = ucr;
                            panelRightConstructs.Controls.Add(ucr);
                            ucr.Height = intHeight;
                            ucr.Top = intTop + i * (ucr.Height + deltaY) + splitter3.Height;
                            ucr.Left = 5;
                            ucr.Width = panelRightConstructs.Width - 10;
                            ucr.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                            ucr.MouseEnter += new EventHandler(ucr_MouseEnter);
                            ucr.MouseLeave += new EventHandler(ucr_MouseLeave);
                        }
                        Rating r = elem.Ratings.Single(x => x.ParentConstruct.Id.Equals(con.Id));
                        Button b = new Button();
                        b.Tag = r;
                        btnA[i, j] = b;
                        if (r.ScaleItemId == int.MinValue || r.ScaleItemId == int.MaxValue)
                        {
                            b.Text = "NA";
                        }
                        else
                        {
                            b.Text = "" + r.ScaleItemId;
                        }
                        toolTip1.SetToolTip(b, string.Format("Rating for Element \"{0}\" regarding Construct \"{1}\"", elem.Name, con.Name));
                        b.Height = 20;
                        b.Width = intWidth;
                        b.Top = intTop + i * (intHeight + deltaY) + 5;
                        b.Left = lblElem.Left;
                        panelMiddleElements.Controls.Add(b);
                        b.Click += new EventHandler(b_Click);
                        b.MouseEnter += new EventHandler(b_MouseEnter);
                        b.MouseLeave += new EventHandler(b_MouseLeave);
                        b.BackColor = SystemColors.Control;

                    }
                }


                this.tabPageRatings.ResumeLayout();
                isRefreshing = false;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                Debug.Print(ex.StackTrace);
            }
        }

        #region Rate Elements

        void lblElem_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                OrientedTextLabel lbl = (OrientedTextLabel)sender;
                Element elem = (Element)lbl.Tag;
                MyMouseLeave(null, elem);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }
        }

        void lblElem_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                OrientedTextLabel lbl = (OrientedTextLabel)sender;
                Element elem = (Element)lbl.Tag;
                MyMouseEnter(null, elem);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }
        }

        void b_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                Rating r = (Rating)btn.Tag;
                MyMouseLeave(r.ParentConstruct, r.ParentElement);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }
        }

        void b_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                Rating r = (Rating)btn.Tag;
                MyMouseEnter(r.ParentConstruct, r.ParentElement);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }
        }

        private void MyMouseHover(Construct c, Element elem, Boolean Entering)
        {
            int i = -1;
            int j = -1;
            bool ConstructHovered = (c != null);
            bool ElementHovered = (elem != null);
            if (ElementHovered) j = le.IndexOf(elem);
            Color col = Entering ? SystemColors.ControlDark : SystemColors.Control;

            if (ConstructHovered)
            {
                i = lc.IndexOf(c);
                if (ElementHovered)
                {
                    // Button Hovered
                    uclpA[i].BackColor = col;
                    ucrpA[i].BackColor = col;
                    btnA[i, j].BackColor = col;
                    lblElemA[j].BackColor = col;
                }
                else
                {
                    // Construct hovered
                    uclpA[i].BackColor = col;
                    ucrpA[i].BackColor = col;
                    for (int z = 0; z < le.Count; z++)
                    {
                        btnA[i, z].BackColor = col;
                    }
                }
            }
            else
            {
                if (ElementHovered)
                {
                    // Element Hovered
                    for (int z = 0; z < lc.Count; z++)
                    {
                        btnA[z, j].BackColor = col;
                    }
                }
                else
                {
                    // Should not be possible
                }
            }
        }

        private void MyMouseEnter(Construct c, Element elem = null)
        {
            MyMouseHover(c, elem, true);
        }

        private void MyMouseLeave(Construct c, Element elem = null)
        {
            MyMouseHover(c, elem, false);
        }

        void ucr_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                UserControlConstructRightPole ucr = (UserControlConstructRightPole)sender;
                MyMouseLeave(ucr.CurrentConstruct);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }
        }

        void ucl_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                UserControlConstructLeftPole ucl = (UserControlConstructLeftPole)sender;
                MyMouseLeave(ucl.CurrentConstruct);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }
        }

        void ucr_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                UserControlConstructRightPole ucr = (UserControlConstructRightPole)sender;
                MyMouseEnter(ucr.CurrentConstruct);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }
        }

        void ucl_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                UserControlConstructLeftPole ucl = (UserControlConstructLeftPole)sender;
                MyMouseEnter(ucl.CurrentConstruct);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }
        }

        void b_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                Rating r = (Rating)btn.Tag;
                DialogRateElement dlg = new DialogRateElement();
                dlg.CurrentRating = r;
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (r.ScaleItemId == int.MinValue || r.ScaleItemId == int.MaxValue)
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

                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        private void deleteInterview()
        {
            try
            {
                if (this.CurrentInterview == null)
                {
                    throw new NotSupportedException("You can delete existing Interviews only");
                }
                if (MessageBox.Show("Do you REALLY want to DELETE the current Interview?", "Confirmation needed") == System.Windows.Forms.DialogResult.OK)
                {

                    this.CurrentInterview.ParentProject.RemoveInterview(this.CurrentInterview);
                    this.Close();
                }
                else
                {
                    throw new Exception("Aborted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, String.Format("An Error Occured during Deleting Interview: {0}", ex.Message));
            }
        }

        #region Setup Grid

        private void AddConstruct()
        {
            try
            {
                if (this.CurrentInterview == null) this.Close();

                Construct c = new Construct(this.CurrentInterview);
                this.constructsBindingSource.MoveLast();
                this.tabControl1.SelectedIndex = 1;
                this.refreshBinding();

                this.ResetInitEvaluation();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.ToString(), "An Error Occured during AddConstruct");
            }
        }

        private void deleteConstruct(Guid id)
        {
            try
            {
                if (this.CurrentInterview == null)
                {
                    throw new NotSupportedException("You can delete Constructs from existing Interviews only");
                }
                if (this.CurrentInterview.Constructs.Any(x => x.Id.Equals(id)))
                {
                    if (MessageBox.Show("Do you REALLY want to DELETE the current Construct?", "Confirmation needed") == System.Windows.Forms.DialogResult.OK)
                    {
                        Construct construct = this.CurrentInterview.Constructs.Single(x => x.Id.Equals(id));

                        this.CurrentInterview.RemoveConstruct(construct);
                        this.constructsBindingSource.MoveFirst();
                        this.refreshBinding();

                        this.ResetInitEvaluation();
                    }
                    else
                    {
                        throw new Exception("Aborted");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.ToString(), "An Error Occured during deleting an Construct");
            }
        }

        private void AddElement()
        {
            try
            {
                if (this.CurrentInterview == null) this.Close();


                Element e = new Element(this.CurrentInterview);
                this.elementsBindingSource.MoveLast();
                this.tabControl1.SelectedIndex = 2;
                this.refreshBinding();
                this.ResetInitEvaluation();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.StackTrace, "An Error Occured during Adding an element.");
            }
        }

        private void deleteElement(Guid id)
        {
            try
            {
                if (this.CurrentInterview == null) this.Close();

                if (this.CurrentInterview.Elements.Any(x => x.Id.Equals(id)))
                {
                    if (MessageBox.Show("Do you REALLY want to DELETE the current Element?", "Confirmation needed") == System.Windows.Forms.DialogResult.OK)
                    {
                        Element elem = this.CurrentInterview.Elements.Single(x => x.Id.Equals(id));
                        this.CurrentInterview.RemoveElement(elem);
                        this.elementsBindingSource.MoveFirst();
                        this.refreshBinding();
                        this.ResetInitEvaluation();
                    }
                    else
                    {
                        throw new Exception("Aborted");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.ToString(), "An Error Occured during deleting an Element");
            }
        }

        #endregion

        #region Evaluation

        private void DescriptiveAnalysis(Boolean isConstruct)
        {
            try
            {
                if (isRCodeInit == false) this.ResetInitEvaluation();
                String cmd = string.Format("{0}({1})", isConstruct ? "statsConstructs" : "statsElements", this.CurrentInterview.GridName);
                addTabDatagridview(cmd, "DA", false);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(ex.Message, String.Format("Descriptive Analysis of {0}: An Error Occured.", isConstruct ? "Constructs" : "Elements"));
            }
        }

        private void CorrelationAnalysis(object sender)
        {

            try
            {
                if (isRCodeInit == false) this.ResetInitEvaluation();
                ToolStripMenuItem btn = (ToolStripMenuItem)sender;
                int t = int.Parse(btn.Tag.ToString());

                String cmd = string.Format("{0}Cor({1}, method=\"{2}\")",
                    t < 10 ? "construct" : "element",
                    this.CurrentInterview.GridName,
                   btn.Text.ToLower());
                addTabDatagridview(cmd, "CA", true);

            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(ex.Message, "Correlation Analysis. An Error occured.");
            }

        }

        private void addTabDatagridview(String cmd, string text, Boolean asMatrix = true)
        {
            SymbolicExpression s = this.rEngine.Evaluate(cmd)[0];

            UserControlRtoDatagridView u = new UserControlRtoDatagridView();
            TabPage p = new TabPage();
            p.Text = text;
            p.Controls.Add(u);
            u.Dock = DockStyle.Fill;

            u.textBox1.Text = cmd;
            if (asMatrix)
            {
                RHelper.RHelper.FillDataGridViewFromR(s.AsNumericMatrix(), u.dataGridView1, this.digits);
            }
            else
            {
                RHelper.RHelper.FillDataGridViewFromR(s.AsDataFrame(), u.dataGridView1, this.digits);
            }
            tabControlEvaluation.TabPages.Add(p);
            tabControlEvaluation.SelectedTab = p;
            u.dataGridView1.AutoResizeColumns();
        }

        private void ResetInitEvaluation()
        {
            try
            {
                this.ucRConsole1.ResetConsole();
                for (int i = tabControlEvaluation.TabPages.Count - 1; i > 0; i--)
                {
                    tabControlEvaluation.TabPages.RemoveAt(i);
                }
                this.CurrentInterview.initR(this.rEngine);
                isRCodeInit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error occured during Reset/Init Evaluation.");
            }
        }

        private void CalcDistances(object sender)
        {
            try
            {
                if (isRCodeInit == false) this.ResetInitEvaluation();
                ToolStripMenuItem btn = (ToolStripMenuItem)sender;
                string cmd = string.Format("distance({0}, along={1}, dmethod=\"{2}\")",
                    this.CurrentInterview.GridName,
                    btn.Tag.ToString(), btn.Text.ToLower());
                addTabDatagridview(cmd, "DIS", true);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(ex.Message, "An Error occured during CalcDistances");
            }
        }

        private void ConstructPCA()
        {
            try
            {
                DialogConstructPCA dlg = new DialogConstructPCA();
                dlg.CurrentInterview = this.CurrentInterview;
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SymbolicExpression s = null; 

                    s = this.rEngine.Evaluate(
                        string.Format("r<-{1}{2}print(r{0})",
                            dlg.UseCutOff ?
                            string.Format(", cut={0}",
                            dlg.CutOffLevel.ToString().Replace(",", "."))
                            : "", dlg.Rcmd, Environment.NewLine
                        ))[0];
                    
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(ex.Message, "An Error occured during Reset/Init Evaluation.");
            }
        }
        #endregion

        private void help()
        {
            try
            {
                throw new NotImplementedException("This function has not been implemented yet.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, String.Format("An Error Occured during Generate R-Scripts for an Interview: {0}", ex.Message));
            }
        }
          
        #endregion

        #region Button Events

        private void dataRepeaterConstructs_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            try
            {
                Control[] ca = e.DataRepeaterItem.Controls.Find("ucConstruct1", false);
                if (ca != null && ca.Length == 1)
                {
                    UcConstruct uc = (UcConstruct)ca[0];
                    uc.constructBindingSource.DataSource = this.CurrentInterview.Constructs[e.DataRepeaterItem.ItemIndex];
                    uc.deletingEventHandler += new DeletingEventHandler(uc_deletingEventHandler_Construct);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }
        }

        private void dataRepeaterELements_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            try
            {
                Control[] ca = e.DataRepeaterItem.Controls.Find("ucElement1", false);
                if (ca != null && ca.Length == 1)
                {
                    UcElement uc = (UcElement)ca[0];
                    uc.elementBindingSource.DataSource = this.CurrentInterview.Elements[e.DataRepeaterItem.ItemIndex];
                    uc.deletingEventHandler += new DeletingEventHandler(uc_deletingEventHandler_Element);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }
        }

        void uc_deletingEventHandler_Element(DeletingEventArgs e)
        {
            deleteElement(e.Id);
        }

        void uc_deletingEventHandler_Construct(DeletingEventArgs e)
        {
            deleteConstruct(e.Id);
        }

        private void FormInterview_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Validate();
        }

        private void toolStripButtonAddConstruct_Click_1(object sender, EventArgs e)
        {
            this.AddConstruct();
        }

        private void toolStripButtonAddElement_Click_1(object sender, EventArgs e)
        {
            this.AddElement();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Equals(tabPageRatings) && isRefreshed == false)
            {
                this.refreshBinding();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.refreshBinding();
        }

        #region Scrolling

        private void panelLeftConstructs_Scroll(object sender, ScrollEventArgs e)
        {
            panel_Scroll(sender, e);
        }

        private void panelMiddleElements_Scroll(object sender, ScrollEventArgs e)
        {
            panel_Scroll(sender, e);
        }

        private void panelRightConstructs_Scroll(object sender, ScrollEventArgs e)
        {
            panel_Scroll(sender, e);
        }

        Boolean scrolling = false;
        private void panel_Scroll(object sender, ScrollEventArgs e)
        {
            if (scrolling) return;
            scrolling = true;
            List<Panel> lp = new List<Panel>();
            lp.Add(panelLeftConstructs);
            lp.Add(panelMiddleElements);
            lp.Add(panelRightConstructs);
            Panel p = (Panel)sender;
            foreach (Panel o in lp)
            {
                o.VerticalScroll.Value = p.VerticalScroll.Value;
            }

            scrolling = false;
        }

        #endregion

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.refreshBinding();
        }

        private void panelMiddleTop_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                panelLeftTop.Height = panelMiddleTop.Height;
                panelRightTop.Height = panelMiddleTop.Height;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }
        }

        private void descriptiveAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DescriptiveAnalysis(true);
        }

        private void descriptiveAnalysisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DescriptiveAnalysis(false);
        }


        private void toolStripMenuItemPearsonConstruct_Click(object sender, EventArgs e)
        {
            CorrelationAnalysis(sender);
        }

        private void toolStripButtonResetEvaluation_Click(object sender, EventArgs e)
        {
            ResetInitEvaluation();
        }

        private void toolStripMenuItemDistances_Click(object sender, EventArgs e)
        {
            CalcDistances(sender);
        }


        private void pCAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConstructPCA();
        }
         

        #endregion
    }
}
