namespace OpenRepGridGui.mdi
{
    partial class FormMain
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripLabelCredits = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucRConsole1 = new RHelper.ucRConsole();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interviewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addInterviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromOtherPackagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importGridStatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importGridCorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importGridSuiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importScivescoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.demoDataFromOpenRepGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getRandomGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDemosFromLiteratureincludedInOpenRepGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.rConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHideRConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.casadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelCredits,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 469);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(998, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripLabelCredits
            // 
            this.toolStripLabelCredits.Name = "toolStripLabelCredits";
            this.toolStripLabelCredits.Size = new System.Drawing.Size(570, 17);
            this.toolStripLabelCredits.Text = "This software uses the R-Library \"OpenRepGrid\" which was designed and programmed " +
    "by Mark Heckmann";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(413, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucRConsole1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 335);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 134);
            this.panel1.TabIndex = 12;
            // 
            // ucRConsole1
            // 
            this.ucRConsole1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRConsole1.Location = new System.Drawing.Point(0, 0);
            this.ucRConsole1.Name = "ucRConsole1";
            this.ucRConsole1.rEngine = null;
            this.ucRConsole1.Size = new System.Drawing.Size(998, 134);
            this.ucRConsole1.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 332);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(998, 3);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.interviewsToolStripMenuItem,
            this.rConsoleToolStripMenuItem,
            this.windowsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(998, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.editDataToolStripMenuItem,
            this.toolStripSeparator1,
            this.optionsToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.dateiToolStripMenuItem.Text = "Project";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::OpenRepGridGui.Properties.Resources.DocumentHS;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = global::OpenRepGridGui.Properties.Resources.openHS;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.Load_Demo_Button_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Image = global::OpenRepGridGui.Properties.Resources.saveHS;
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // editDataToolStripMenuItem
            // 
            this.editDataToolStripMenuItem.Image = global::OpenRepGridGui.Properties.Resources.CommentHS;
            this.editDataToolStripMenuItem.Name = "editDataToolStripMenuItem";
            this.editDataToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.editDataToolStripMenuItem.Text = "Edit Data";
            this.editDataToolStripMenuItem.Click += new System.EventHandler(this.editDataToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = global::OpenRepGridGui.Properties.Resources.Properties;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(135, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // interviewsToolStripMenuItem
            // 
            this.interviewsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addInterviewToolStripMenuItem,
            this.importToolStripMenuItem,
            this.toolStripSeparator4});
            this.interviewsToolStripMenuItem.Name = "interviewsToolStripMenuItem";
            this.interviewsToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.interviewsToolStripMenuItem.Text = "Interviews";
            // 
            // addInterviewToolStripMenuItem
            // 
            this.addInterviewToolStripMenuItem.Image = global::OpenRepGridGui.Properties.Resources.Microphone;
            this.addInterviewToolStripMenuItem.Name = "addInterviewToolStripMenuItem";
            this.addInterviewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addInterviewToolStripMenuItem.Text = "Add Interview";
            this.addInterviewToolStripMenuItem.Click += new System.EventHandler(this.addInterviewToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFromOtherPackagesToolStripMenuItem,
            this.importGridStatToolStripMenuItem,
            this.importGridCorToolStripMenuItem,
            this.importGridSuiteToolStripMenuItem,
            this.importScivescoToolStripMenuItem,
            this.toolStripSeparator3,
            this.demoDataFromOpenRepGridToolStripMenuItem,
            this.getRandomGridToolStripMenuItem,
            this.loadDemosFromLiteratureincludedInOpenRepGridToolStripMenuItem});
            this.importToolStripMenuItem.Image = global::OpenRepGridGui.Properties.Resources.RIconImg;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importToolStripMenuItem.Text = "Import using R";
            // 
            // importFromOtherPackagesToolStripMenuItem
            // 
            this.importFromOtherPackagesToolStripMenuItem.Enabled = false;
            this.importFromOtherPackagesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importFromOtherPackagesToolStripMenuItem.Name = "importFromOtherPackagesToolStripMenuItem";
            this.importFromOtherPackagesToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.importFromOtherPackagesToolStripMenuItem.Text = "Import from other Packages using R";
            // 
            // importGridStatToolStripMenuItem
            // 
            this.importGridStatToolStripMenuItem.Name = "importGridStatToolStripMenuItem";
            this.importGridStatToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.importGridStatToolStripMenuItem.Text = "Import Grid Stat";
            this.importGridStatToolStripMenuItem.Click += new System.EventHandler(this.importGridStatToolStripMenuItem_Click);
            // 
            // importGridCorToolStripMenuItem
            // 
            this.importGridCorToolStripMenuItem.Name = "importGridCorToolStripMenuItem";
            this.importGridCorToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.importGridCorToolStripMenuItem.Text = "Import Grid Cor";
            this.importGridCorToolStripMenuItem.Click += new System.EventHandler(this.importGridCorToolStripMenuItem_Click);
            // 
            // importGridSuiteToolStripMenuItem
            // 
            this.importGridSuiteToolStripMenuItem.Name = "importGridSuiteToolStripMenuItem";
            this.importGridSuiteToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.importGridSuiteToolStripMenuItem.Text = "Import Grid Suite";
            this.importGridSuiteToolStripMenuItem.Click += new System.EventHandler(this.importGridSuiteToolStripMenuItem_Click);
            // 
            // importScivescoToolStripMenuItem
            // 
            this.importScivescoToolStripMenuItem.Name = "importScivescoToolStripMenuItem";
            this.importScivescoToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.importScivescoToolStripMenuItem.Text = "Import Scivesco";
            this.importScivescoToolStripMenuItem.Click += new System.EventHandler(this.importScivescoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(363, 6);
            // 
            // demoDataFromOpenRepGridToolStripMenuItem
            // 
            this.demoDataFromOpenRepGridToolStripMenuItem.Enabled = false;
            this.demoDataFromOpenRepGridToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.demoDataFromOpenRepGridToolStripMenuItem.Name = "demoDataFromOpenRepGridToolStripMenuItem";
            this.demoDataFromOpenRepGridToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.demoDataFromOpenRepGridToolStripMenuItem.Text = "Demo Data From OpenRepGrid";
            // 
            // getRandomGridToolStripMenuItem
            // 
            this.getRandomGridToolStripMenuItem.Name = "getRandomGridToolStripMenuItem";
            this.getRandomGridToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.getRandomGridToolStripMenuItem.Text = "Load Random Grid";
            this.getRandomGridToolStripMenuItem.Click += new System.EventHandler(this.getRandomGridToolStripMenuItem_Click);
            // 
            // loadDemosFromLiteratureincludedInOpenRepGridToolStripMenuItem
            // 
            this.loadDemosFromLiteratureincludedInOpenRepGridToolStripMenuItem.Name = "loadDemosFromLiteratureincludedInOpenRepGridToolStripMenuItem";
            this.loadDemosFromLiteratureincludedInOpenRepGridToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.loadDemosFromLiteratureincludedInOpenRepGridToolStripMenuItem.Text = "Load Demos from Literature (included in OpenRepGrid)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // rConsoleToolStripMenuItem
            // 
            this.rConsoleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHideRConsoleToolStripMenuItem});
            this.rConsoleToolStripMenuItem.Name = "rConsoleToolStripMenuItem";
            this.rConsoleToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.rConsoleToolStripMenuItem.Text = "R Console";
            // 
            // showHideRConsoleToolStripMenuItem
            // 
            this.showHideRConsoleToolStripMenuItem.Checked = true;
            this.showHideRConsoleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showHideRConsoleToolStripMenuItem.Name = "showHideRConsoleToolStripMenuItem";
            this.showHideRConsoleToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.showHideRConsoleToolStripMenuItem.Text = "Show / Hide R-Console";
            this.showHideRConsoleToolStripMenuItem.Click += new System.EventHandler(this.showHideRConsoleToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.casadeToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.toolStripSeparator5,
            this.minimizeToolStripMenuItem,
            this.closeAllToolStripMenuItem});
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // casadeToolStripMenuItem
            // 
            this.casadeToolStripMenuItem.Name = "casadeToolStripMenuItem";
            this.casadeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.casadeToolStripMenuItem.Text = "Casade";
            this.casadeToolStripMenuItem.Click += new System.EventHandler(this.casadeToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.arrangeIconsToolStripMenuItem.Text = "Arrange Icons";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.arrangeIconsToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Tile Horizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.tileHorizontalToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileVerticalToolStripMenuItem.Text = "Tile Vertical";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.tileVerticalToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(148, 6);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.minimizeToolStripMenuItem.Text = "Minimize all";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.closeAllToolStripMenuItem.Text = "Close all";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // projectBindingSource
            // 
            this.projectBindingSource.DataSource = typeof(OpenRepGridModel.Model.Project);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 491);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectBindingSource, "Name", true));
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.Text = "ProjectDetails";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectDetails_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelCredits;
        private System.Windows.Forms.BindingSource projectBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private RHelper.ucRConsole ucRConsole1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interviewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addInterviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromOtherPackagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importGridStatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importGridCorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importGridSuiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importScivescoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem demoDataFromOpenRepGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getRandomGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDemosFromLiteratureincludedInOpenRepGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHideRConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem casadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;


    }
}