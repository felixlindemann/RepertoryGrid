namespace RepertoryGrid
{
    partial class FormProject
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
            System.Windows.Forms.Label remarkLabel;
            System.Windows.Forms.Label nameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProject));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonDeleteInterview = new System.Windows.Forms.Button();
            this.interviewsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonAddInterview = new System.Windows.Forms.Button();
            this.buttonHide = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.neuToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.öffnenToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLoadDemos = new System.Windows.Forms.ToolStripButton();
            this.projectBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonChangeProjectDetails = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowSideBar = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelSideBar = new System.Windows.Forms.Panel();
            this.dataRepeater1 = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.buttonOpenInterview = new System.Windows.Forms.Button();
            this.remarkTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            remarkLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interviewsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panelSideBar.SuspendLayout();
            this.dataRepeater1.ItemTemplate.SuspendLayout();
            this.dataRepeater1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // remarkLabel
            // 
            remarkLabel.AutoSize = true;
            remarkLabel.Location = new System.Drawing.Point(7, 34);
            remarkLabel.Name = "remarkLabel";
            remarkLabel.Size = new System.Drawing.Size(47, 13);
            remarkLabel.TabIndex = 2;
            remarkLabel.Text = "Remark:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(16, 8);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Name:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 313);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(636, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(570, 17);
            this.toolStripStatusLabel1.Text = "This software uses the R-Library \"OpenRepGrid\" which was designed and programmed " +
                "by Mark Heckmann";
            this.toolStripStatusLabel1.DoubleClick += new System.EventHandler(this.toolStripStatusLabel1_DoubleClick);
            // 
            // buttonDeleteInterview
            // 
            this.buttonDeleteInterview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeleteInterview.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.interviewsBindingSource, "Id", true));
            this.buttonDeleteInterview.Image = global::RepertoryGrid.Properties.Resources.DeleteHS;
            this.buttonDeleteInterview.Location = new System.Drawing.Point(28, 50);
            this.buttonDeleteInterview.Name = "buttonDeleteInterview";
            this.buttonDeleteInterview.Size = new System.Drawing.Size(26, 26);
            this.buttonDeleteInterview.TabIndex = 5;
            this.toolTip1.SetToolTip(this.buttonDeleteInterview, "Delete Interview");
            this.buttonDeleteInterview.UseVisualStyleBackColor = true;
            this.buttonDeleteInterview.Click += new System.EventHandler(this.buttonDeleteInterview_Click);
            // 
            // interviewsBindingSource
            // 
            this.interviewsBindingSource.DataMember = "Interviews";
            this.interviewsBindingSource.DataSource = this.projectBindingSource;
            // 
            // projectBindingSource
            // 
            this.projectBindingSource.DataSource = typeof(RepertoryGrid.classes.Project);
            // 
            // buttonAddInterview
            // 
            this.buttonAddInterview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddInterview.Image = global::RepertoryGrid.Properties.Resources.AddTableHS;
            this.buttonAddInterview.Location = new System.Drawing.Point(147, 3);
            this.buttonAddInterview.Name = "buttonAddInterview";
            this.buttonAddInterview.Size = new System.Drawing.Size(26, 26);
            this.buttonAddInterview.TabIndex = 2;
            this.toolTip1.SetToolTip(this.buttonAddInterview, "Add Interview");
            this.buttonAddInterview.UseVisualStyleBackColor = true;
            this.buttonAddInterview.Click += new System.EventHandler(this.buttonAddInterview_Click);
            // 
            // buttonHide
            // 
            this.buttonHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHide.Image = global::RepertoryGrid.Properties.Resources.FillLeftHS;
            this.buttonHide.Location = new System.Drawing.Point(172, 3);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(26, 26);
            this.buttonHide.TabIndex = 1;
            this.toolTip1.SetToolTip(this.buttonHide, "Minimize Side bar");
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripButton,
            this.öffnenToolStripButton,
            this.toolStripButtonLoadDemos,
            this.projectBindingNavigatorSaveItem,
            this.toolStripSeparator1,
            this.toolStripButtonChangeProjectDetails,
            this.toolStripButtonShowSideBar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(636, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // neuToolStripButton
            // 
            this.neuToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.neuToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("neuToolStripButton.Image")));
            this.neuToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.neuToolStripButton.Name = "neuToolStripButton";
            this.neuToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.neuToolStripButton.Text = "&Neu";
            this.neuToolStripButton.Click += new System.EventHandler(this.neuToolStripButton_Click);
            // 
            // öffnenToolStripButton
            // 
            this.öffnenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.öffnenToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("öffnenToolStripButton.Image")));
            this.öffnenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.öffnenToolStripButton.Name = "öffnenToolStripButton";
            this.öffnenToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.öffnenToolStripButton.Text = "Ö&ffnen";
            this.öffnenToolStripButton.Click += new System.EventHandler(this.öffnenToolStripButton_Click);
            // 
            // toolStripButtonLoadDemos
            // 
            this.toolStripButtonLoadDemos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLoadDemos.Image = global::RepertoryGrid.Properties.Resources.LegendHS;
            this.toolStripButtonLoadDemos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadDemos.Name = "toolStripButtonLoadDemos";
            this.toolStripButtonLoadDemos.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonLoadDemos.Text = "Load Demos";
            this.toolStripButtonLoadDemos.Click += new System.EventHandler(this.toolStripButtonLoadDemos_Click);
            // 
            // projectBindingNavigatorSaveItem
            // 
            this.projectBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.projectBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("projectBindingNavigatorSaveItem.Image")));
            this.projectBindingNavigatorSaveItem.Name = "projectBindingNavigatorSaveItem";
            this.projectBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.projectBindingNavigatorSaveItem.Text = "Daten speichern";
            this.projectBindingNavigatorSaveItem.Click += new System.EventHandler(this.projectBindingNavigatorSaveItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonChangeProjectDetails
            // 
            this.toolStripButtonChangeProjectDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonChangeProjectDetails.Image = global::RepertoryGrid.Properties.Resources.NoteHS;
            this.toolStripButtonChangeProjectDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonChangeProjectDetails.Name = "toolStripButtonChangeProjectDetails";
            this.toolStripButtonChangeProjectDetails.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonChangeProjectDetails.Text = "Change Project Details";
            this.toolStripButtonChangeProjectDetails.Click += new System.EventHandler(this.toolStripButtonChangeProjectDetails_Click);
            // 
            // toolStripButtonShowSideBar
            // 
            this.toolStripButtonShowSideBar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowSideBar.Image = global::RepertoryGrid.Properties.Resources.FillRightHS;
            this.toolStripButtonShowSideBar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowSideBar.Name = "toolStripButtonShowSideBar";
            this.toolStripButtonShowSideBar.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShowSideBar.Text = "Show SideBar";
            this.toolStripButtonShowSideBar.Click += new System.EventHandler(this.toolStripButtonShowSideBar_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(200, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 288);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // panelSideBar
            // 
            this.panelSideBar.Controls.Add(this.dataRepeater1);
            this.panelSideBar.Controls.Add(this.panel1);
            this.panelSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideBar.Location = new System.Drawing.Point(0, 25);
            this.panelSideBar.Name = "panelSideBar";
            this.panelSideBar.Size = new System.Drawing.Size(200, 288);
            this.panelSideBar.TabIndex = 8;
            // 
            // dataRepeater1
            // 
            this.dataRepeater1.DataSource = this.interviewsBindingSource;
            this.dataRepeater1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // dataRepeater1.ItemTemplate
            // 
            this.dataRepeater1.ItemTemplate.Controls.Add(this.buttonDeleteInterview);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.buttonOpenInterview);
            this.dataRepeater1.ItemTemplate.Controls.Add(remarkLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.remarkTextBox);
            this.dataRepeater1.ItemTemplate.Controls.Add(nameLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.nameTextBox);
            this.dataRepeater1.ItemTemplate.MinimumSize = new System.Drawing.Size(192, 83);
            this.dataRepeater1.ItemTemplate.Size = new System.Drawing.Size(192, 83);
            this.dataRepeater1.Location = new System.Drawing.Point(0, 34);
            this.dataRepeater1.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.dataRepeater1.MinimumSize = new System.Drawing.Size(200, 254);
            this.dataRepeater1.Name = "dataRepeater1";
            this.dataRepeater1.Size = new System.Drawing.Size(200, 254);
            this.dataRepeater1.TabIndex = 5;
            this.dataRepeater1.Text = "dataRepeater1";
            // 
            // buttonOpenInterview
            // 
            this.buttonOpenInterview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpenInterview.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.interviewsBindingSource, "Id", true));
            this.buttonOpenInterview.Image = global::RepertoryGrid.Properties.Resources.ShowGridlinesHS;
            this.buttonOpenInterview.Location = new System.Drawing.Point(3, 50);
            this.buttonOpenInterview.Name = "buttonOpenInterview";
            this.buttonOpenInterview.Size = new System.Drawing.Size(26, 26);
            this.buttonOpenInterview.TabIndex = 4;
            this.buttonOpenInterview.UseVisualStyleBackColor = true;
            this.buttonOpenInterview.Click += new System.EventHandler(this.buttonOpenInterview_Click);
            // 
            // remarkTextBox
            // 
            this.remarkTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.remarkTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.interviewsBindingSource, "Remark", true));
            this.remarkTextBox.Location = new System.Drawing.Point(60, 31);
            this.remarkTextBox.Multiline = true;
            this.remarkTextBox.Name = "remarkTextBox";
            this.remarkTextBox.Size = new System.Drawing.Size(114, 42);
            this.remarkTextBox.TabIndex = 3;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.interviewsBindingSource, "Proband", true));
            this.nameTextBox.Location = new System.Drawing.Point(60, 5);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(116, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAddInterview);
            this.panel1.Controls.Add(this.buttonHide);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 34);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Interviews:";
            // 
            // FormProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 335);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelSideBar);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectBindingSource, "Name", true));
            this.IsMdiContainer = true;
            this.Name = "FormProject";
            this.Text = "OpenRepGrid GUI by Felix Lindemann";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProject_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormProject_FormClosed);
            this.Load += new System.EventHandler(this.FormProject_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interviewsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelSideBar.ResumeLayout(false);
            this.dataRepeater1.ItemTemplate.ResumeLayout(false);
            this.dataRepeater1.ItemTemplate.PerformLayout();
            this.dataRepeater1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton neuToolStripButton;
        private System.Windows.Forms.ToolStripButton öffnenToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadDemos;
        private System.Windows.Forms.ToolStripButton projectBindingNavigatorSaveItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonChangeProjectDetails;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowSideBar;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panelSideBar;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater1;
        private System.Windows.Forms.Button buttonDeleteInterview;
        private System.Windows.Forms.Button buttonOpenInterview;
        private System.Windows.Forms.TextBox remarkTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAddInterview;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource projectBindingSource;
        private System.Windows.Forms.BindingSource interviewsBindingSource;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}