using LimeTree.Gui.Input;
namespace RepertoryGridGUI.ufos
{
    partial class ufoScoring
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ufoScoring));
            this.dataRepeaterConstructs = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.constructBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataRepeaterElements = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.elementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelRight = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.moveLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCurrentElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addConstructToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCurrentConstructToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotatedTextLabel1 = new RotatedTextLabel();
            this.ucScoring1 = new RepertoryGridGUI.UserControls.ucScoring();
            this.dataRepeaterConstructs.ItemTemplate.SuspendLayout();
            this.dataRepeaterConstructs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.constructBindingSource)).BeginInit();
            this.dataRepeaterElements.ItemTemplate.SuspendLayout();
            this.dataRepeaterElements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoresBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataRepeaterConstructs
            // 
            this.dataRepeaterConstructs.AllowUserToAddItems = false;
            this.dataRepeaterConstructs.AllowUserToDeleteItems = false;
            this.dataRepeaterConstructs.DataSource = this.constructBindingSource;
            this.dataRepeaterConstructs.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // dataRepeaterConstructs.ItemTemplate
            // 
            this.dataRepeaterConstructs.ItemTemplate.Controls.Add(this.ucScoring1);
            this.dataRepeaterConstructs.ItemTemplate.Size = new System.Drawing.Size(773, 67);
            this.dataRepeaterConstructs.Location = new System.Drawing.Point(0, 0);
            this.dataRepeaterConstructs.Name = "dataRepeaterConstructs";
            this.dataRepeaterConstructs.Size = new System.Drawing.Size(781, 223);
            this.dataRepeaterConstructs.TabIndex = 1;
            this.dataRepeaterConstructs.Text = "dataRepeater1";
            this.dataRepeaterConstructs.DrawItem += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventHandler(this.dataRepeater1_DrawItem);
            // 
            // constructBindingSource
            // 
            this.constructBindingSource.DataSource = typeof(RepertoryGrid.Model.Construct);
            // 
            // dataRepeaterElements
            // 
            this.dataRepeaterElements.AllowUserToAddItems = false;
            this.dataRepeaterElements.AllowUserToDeleteItems = false;
            this.dataRepeaterElements.DataSource = this.elementBindingSource;
            this.dataRepeaterElements.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // dataRepeaterElements.ItemTemplate
            // 
            this.dataRepeaterElements.ItemTemplate.Controls.Add(this.rotatedTextLabel1);
            this.dataRepeaterElements.ItemTemplate.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataRepeaterElements.ItemTemplate.Size = new System.Drawing.Size(46, 219);
            this.dataRepeaterElements.LayoutStyle = Microsoft.VisualBasic.PowerPacks.DataRepeaterLayoutStyles.Horizontal;
            this.dataRepeaterElements.Location = new System.Drawing.Point(251, 0);
            this.dataRepeaterElements.Name = "dataRepeaterElements";
            this.dataRepeaterElements.Size = new System.Drawing.Size(345, 227);
            this.dataRepeaterElements.TabIndex = 2;
            this.dataRepeaterElements.Text = "dataRepeater2";
            // 
            // elementBindingSource
            // 
            this.elementBindingSource.DataSource = typeof(RepertoryGrid.Model.Element);
            this.elementBindingSource.PositionChanged += new System.EventHandler(this.elementBindingSource_PositionChanged);
            // 
            // scoresBindingSource
            // 
            this.scoresBindingSource.DataMember = "Scores";
            this.scoresBindingSource.DataSource = this.elementBindingSource;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(596, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(185, 227);
            this.panelRight.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(447, 25);
            this.toolStrip1.TabIndex = 1;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(221, 22);
            this.toolStripLabel1.Text = "Provide Ratings for Current Interview;";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem,
            this.addConstructToolStripMenuItem,
            this.removeCurrentConstructToolStripMenuItem});
            this.toolStripButton1.Image = global::RepertoryGridGUI.Properties.Resources.LayoutSelectRow;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(96, 22);
            this.toolStripButton1.Text = "Constructs";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveLeftToolStripMenuItem,
            this.moveRightToolStripMenuItem,
            this.addElementToolStripMenuItem,
            this.removeCurrentElementToolStripMenuItem});
            this.toolStripButton2.Image = global::RepertoryGridGUI.Properties.Resources.LayoutSelectColumn;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(87, 22);
            this.toolStripButton2.Text = "Elements";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 227);
            this.panel1.TabIndex = 0;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(781, 454);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(781, 479);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataRepeaterElements);
            this.splitContainer1.Panel1.Controls.Add(this.panelRight);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataRepeaterConstructs);
            this.splitContainer1.Size = new System.Drawing.Size(781, 454);
            this.splitContainer1.SplitterDistance = 227;
            this.splitContainer1.TabIndex = 0;
            // 
            // moveLeftToolStripMenuItem
            // 
            this.moveLeftToolStripMenuItem.Image = global::RepertoryGridGUI.Properties.Resources.FillLeftHS;
            this.moveLeftToolStripMenuItem.Name = "moveLeftToolStripMenuItem";
            this.moveLeftToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.moveLeftToolStripMenuItem.Text = "Move Left";
            this.moveLeftToolStripMenuItem.Click += new System.EventHandler(this.moveLeftToolStripMenuItem_Click);
            // 
            // moveRightToolStripMenuItem
            // 
            this.moveRightToolStripMenuItem.Image = global::RepertoryGridGUI.Properties.Resources.FillRightHS;
            this.moveRightToolStripMenuItem.Name = "moveRightToolStripMenuItem";
            this.moveRightToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.moveRightToolStripMenuItem.Text = "Move Right";
            this.moveRightToolStripMenuItem.Click += new System.EventHandler(this.moveRightToolStripMenuItem_Click);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Image = global::RepertoryGridGUI.Properties.Resources.FillUpHS;
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.moveUpToolStripMenuItem.Text = "Move Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Image = global::RepertoryGridGUI.Properties.Resources.FillDownHS;
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.moveDownToolStripMenuItem.Text = "Move down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // addElementToolStripMenuItem
            // 
            this.addElementToolStripMenuItem.Image = global::RepertoryGridGUI.Properties.Resources.DataContainer_NewRecordHS;
            this.addElementToolStripMenuItem.Name = "addElementToolStripMenuItem";
            this.addElementToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.addElementToolStripMenuItem.Text = "Add Element";
            this.addElementToolStripMenuItem.Click += new System.EventHandler(this.addElementToolStripMenuItem_Click);
            // 
            // removeCurrentElementToolStripMenuItem
            // 
            this.removeCurrentElementToolStripMenuItem.Image = global::RepertoryGridGUI.Properties.Resources.DeleteHS;
            this.removeCurrentElementToolStripMenuItem.Name = "removeCurrentElementToolStripMenuItem";
            this.removeCurrentElementToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.removeCurrentElementToolStripMenuItem.Text = "Remove Current Element";
            this.removeCurrentElementToolStripMenuItem.Click += new System.EventHandler(this.removeCurrentElementToolStripMenuItem_Click);
            // 
            // addConstructToolStripMenuItem
            // 
            this.addConstructToolStripMenuItem.Image = global::RepertoryGridGUI.Properties.Resources.DataContainer_NewRecordHS;
            this.addConstructToolStripMenuItem.Name = "addConstructToolStripMenuItem";
            this.addConstructToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.addConstructToolStripMenuItem.Text = "Add Construct";
            this.addConstructToolStripMenuItem.Click += new System.EventHandler(this.addConstructToolStripMenuItem_Click);
            // 
            // removeCurrentConstructToolStripMenuItem
            // 
            this.removeCurrentConstructToolStripMenuItem.Image = global::RepertoryGridGUI.Properties.Resources.DeleteHS;
            this.removeCurrentConstructToolStripMenuItem.Name = "removeCurrentConstructToolStripMenuItem";
            this.removeCurrentConstructToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.removeCurrentConstructToolStripMenuItem.Text = "Remove Current Construct";
            this.removeCurrentConstructToolStripMenuItem.Click += new System.EventHandler(this.removeCurrentConstructToolStripMenuItem_Click);
            // 
            // rotatedTextLabel1
            // 
            this.rotatedTextLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.elementBindingSource, "Name", true));
            this.rotatedTextLabel1.Debugging = false;
            this.rotatedTextLabel1.DemoBoxSize = new System.Drawing.SizeF(300F, 200F);
            this.rotatedTextLabel1.DemoModus = false;
            this.rotatedTextLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rotatedTextLabel1.FitHeight = false;
            this.rotatedTextLabel1.FitWidth = false;
            this.rotatedTextLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rotatedTextLabel1.Location = new System.Drawing.Point(0, 0);
            this.rotatedTextLabel1.Name = "rotatedTextLabel1";
            this.rotatedTextLabel1.RotatedAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.rotatedTextLabel1.RotationAngle = 90.0000000001D;
            this.rotatedTextLabel1.Size = new System.Drawing.Size(45, 204);
            this.rotatedTextLabel1.TabIndex = 0;
            this.rotatedTextLabel1.Text = "break;";
            this.rotatedTextLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucScoring1
            // 
            this.ucScoring1.CurrentConstruct = null;
            this.ucScoring1.CurrentInterviewService = null;
            this.ucScoring1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucScoring1.Location = new System.Drawing.Point(0, 0);
            this.ucScoring1.Name = "ucScoring1";
            this.ucScoring1.Size = new System.Drawing.Size(758, 66);
            this.ucScoring1.TabIndex = 0;
            // 
            // ufoScoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 479);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ufoScoring";
            this.Text = "Provide Scoring";
            this.ResizeBegin += new System.EventHandler(this.ufoScoring_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.ufoScoring_ResizeEnd);
            this.dataRepeaterConstructs.ItemTemplate.ResumeLayout(false);
            this.dataRepeaterConstructs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.constructBindingSource)).EndInit();
            this.dataRepeaterElements.ItemTemplate.ResumeLayout(false);
            this.dataRepeaterElements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.elementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoresBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeaterConstructs;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeaterElements;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton1;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.BindingSource constructBindingSource;
        private System.Windows.Forms.BindingSource elementBindingSource;
        private System.Windows.Forms.BindingSource scoresBindingSource;
        private UserControls.ucScoring ucScoring1;
        private RotatedTextLabel rotatedTextLabel1;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addConstructToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCurrentConstructToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCurrentElementToolStripMenuItem;


    }
}