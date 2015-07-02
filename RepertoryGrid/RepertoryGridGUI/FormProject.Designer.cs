namespace RepertoryGridGUI
{
    partial class FormProject
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label remarkLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label probandLabel;
            System.Windows.Forms.Label dateLabel;
            System.Windows.Forms.Label remarkLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProject));
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.remarkTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interviewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addInterviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDemosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadRandomDemoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataRepeater1 = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.interviewsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonDeleteInterview = new System.Windows.Forms.Button();
            this.buttonOpenInterview = new System.Windows.Forms.Button();
            this.remarkTextBox1 = new System.Windows.Forms.TextBox();
            this.dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.probandTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripLabelCredits = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            nameLabel = new System.Windows.Forms.Label();
            remarkLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            probandLabel = new System.Windows.Forms.Label();
            dateLabel = new System.Windows.Forms.Label();
            remarkLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.dataRepeater1.ItemTemplate.SuspendLayout();
            this.dataRepeater1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interviewsBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(29, 35);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Name:";
            // 
            // remarkLabel
            // 
            remarkLabel.AutoSize = true;
            remarkLabel.Location = new System.Drawing.Point(20, 61);
            remarkLabel.Name = "remarkLabel";
            remarkLabel.Size = new System.Drawing.Size(47, 13);
            remarkLabel.TabIndex = 3;
            remarkLabel.Text = "Remark:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 128);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(58, 13);
            label1.TabIndex = 7;
            label1.Text = "Interviews:";
            // 
            // probandLabel
            // 
            probandLabel.AutoSize = true;
            probandLabel.Location = new System.Drawing.Point(17, 6);
            probandLabel.Name = "probandLabel";
            probandLabel.Size = new System.Drawing.Size(50, 13);
            probandLabel.TabIndex = 0;
            probandLabel.Text = "Proband:";
            // 
            // dateLabel
            // 
            dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            dateLabel.AutoSize = true;
            dateLabel.Location = new System.Drawing.Point(563, 6);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new System.Drawing.Size(33, 13);
            dateLabel.TabIndex = 2;
            dateLabel.Text = "Date:";
            // 
            // remarkLabel1
            // 
            remarkLabel1.AutoSize = true;
            remarkLabel1.Location = new System.Drawing.Point(17, 32);
            remarkLabel1.Name = "remarkLabel1";
            remarkLabel1.Size = new System.Drawing.Size(47, 13);
            remarkLabel1.TabIndex = 4;
            remarkLabel1.Text = "Remark:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(73, 32);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(825, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // projectBindingSource
            // 
//            this.projectBindingSource.DataSource = typeof(RepertoryGrid.Model.Project);
            // 
            // remarkTextBox
            // 
            this.remarkTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remarkTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectBindingSource, "Remark", true));
            this.remarkTextBox.Location = new System.Drawing.Point(73, 58);
            this.remarkTextBox.Multiline = true;
            this.remarkTextBox.Name = "remarkTextBox";
            this.remarkTextBox.Size = new System.Drawing.Size(825, 52);
            this.remarkTextBox.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.extrasToolStripMenuItem,
            this.interviewsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(913, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.öffnenToolStripMenuItem,
            this.toolStripSeparator,
            this.speichernToolStripMenuItem,
            this.toolStripSeparator2,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "&Datei";
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("neuToolStripMenuItem.Image")));
            this.neuToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.neuToolStripMenuItem.Text = "&New";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.neuToolStripMenuItem_Click);
            // 
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("öffnenToolStripMenuItem.Image")));
            this.öffnenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.öffnenToolStripMenuItem.Text = "Load";
            this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.öffnenToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(165, 6);
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("speichernToolStripMenuItem.Image")));
            this.speichernToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.speichernToolStripMenuItem.Text = "&Speichern";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.beendenToolStripMenuItem.Text = "&Beenden";
            // 
            // extrasToolStripMenuItem
            // 
            this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionenToolStripMenuItem});
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            this.extrasToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.extrasToolStripMenuItem.Text = "E&xtras";
            // 
            // optionenToolStripMenuItem
            // 
            this.optionenToolStripMenuItem.Name = "optionenToolStripMenuItem";
            this.optionenToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.optionenToolStripMenuItem.Text = "&Optionen";
            this.optionenToolStripMenuItem.Click += new System.EventHandler(this.optionenToolStripMenuItem_Click);
            // 
            // interviewsToolStripMenuItem
            // 
            this.interviewsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addInterviewToolStripMenuItem,
            this.loadDemosToolStripMenuItem,
            this.loadRandomDemoToolStripMenuItem});
            this.interviewsToolStripMenuItem.Name = "interviewsToolStripMenuItem";
            this.interviewsToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.interviewsToolStripMenuItem.Text = "Interviews";
            // 
            // addInterviewToolStripMenuItem
            // 
            this.addInterviewToolStripMenuItem.Image = global::RepertoryGridGUI.Properties.Resources.ShowGridlinesHS;
            this.addInterviewToolStripMenuItem.Name = "addInterviewToolStripMenuItem";
            this.addInterviewToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.addInterviewToolStripMenuItem.Text = "Add Interview";
            this.addInterviewToolStripMenuItem.Click += new System.EventHandler(this.addInterviewToolStripMenuItem_Click);
            // 
            // loadDemosToolStripMenuItem
            // 
            this.loadDemosToolStripMenuItem.Image = global::RepertoryGridGUI.Properties.Resources.Book_openHS;
            this.loadDemosToolStripMenuItem.Name = "loadDemosToolStripMenuItem";
            this.loadDemosToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.loadDemosToolStripMenuItem.Text = "Add Demos from Literature";
            this.loadDemosToolStripMenuItem.Click += new System.EventHandler(this.loadDemosToolStripMenuItem_Click);
            // 
            // loadRandomDemoToolStripMenuItem
            // 
            this.loadRandomDemoToolStripMenuItem.Image = global::RepertoryGridGUI.Properties.Resources.AppWindow;
            this.loadRandomDemoToolStripMenuItem.Name = "loadRandomDemoToolStripMenuItem";
            this.loadRandomDemoToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.loadRandomDemoToolStripMenuItem.Text = "Add Random Demo";
            this.loadRandomDemoToolStripMenuItem.Click += new System.EventHandler(this.loadRandomDemoToolStripMenuItem_Click);
            // 
            // dataRepeater1
            // 
            this.dataRepeater1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataRepeater1.DataSource = this.interviewsBindingSource;
            // 
            // dataRepeater1.ItemTemplate
            // 
            this.dataRepeater1.ItemTemplate.Controls.Add(this.buttonDeleteInterview);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.buttonOpenInterview);
            this.dataRepeater1.ItemTemplate.Controls.Add(remarkLabel1);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.remarkTextBox1);
            this.dataRepeater1.ItemTemplate.Controls.Add(dateLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.dateDateTimePicker);
            this.dataRepeater1.ItemTemplate.Controls.Add(probandLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.probandTextBox);
            this.dataRepeater1.ItemTemplate.Size = new System.Drawing.Size(881, 98);
            this.dataRepeater1.Location = new System.Drawing.Point(12, 144);
            this.dataRepeater1.Name = "dataRepeater1";
            this.dataRepeater1.Size = new System.Drawing.Size(889, 198);
            this.dataRepeater1.TabIndex = 6;
            this.dataRepeater1.Text = "dataRepeater1";
            // 
            // interviewsBindingSource
            // 
            this.interviewsBindingSource.DataMember = "Interviews";
            this.interviewsBindingSource.DataSource = this.projectBindingSource;
            // 
            // buttonDeleteInterview
            // 
            this.buttonDeleteInterview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteInterview.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.interviewsBindingSource, "Id", true));
            this.buttonDeleteInterview.Image = global::RepertoryGridGUI.Properties.Resources.DeleteHS;
            this.buttonDeleteInterview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeleteInterview.Location = new System.Drawing.Point(727, 63);
            this.buttonDeleteInterview.Name = "buttonDeleteInterview";
            this.buttonDeleteInterview.Size = new System.Drawing.Size(61, 23);
            this.buttonDeleteInterview.TabIndex = 7;
            this.buttonDeleteInterview.Text = "Delete";
            this.buttonDeleteInterview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDeleteInterview.UseVisualStyleBackColor = true;
            this.buttonDeleteInterview.Click += new System.EventHandler(this.buttonDeleteInterview_Click);
            // 
            // buttonOpenInterview
            // 
            this.buttonOpenInterview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenInterview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonOpenInterview.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.interviewsBindingSource, "Id", true));
            this.buttonOpenInterview.Image = global::RepertoryGridGUI.Properties.Resources.EditTableHS;
            this.buttonOpenInterview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOpenInterview.Location = new System.Drawing.Point(727, 32);
            this.buttonOpenInterview.Name = "buttonOpenInterview";
            this.buttonOpenInterview.Size = new System.Drawing.Size(61, 25);
            this.buttonOpenInterview.TabIndex = 6;
            this.buttonOpenInterview.Text = "Edit";
            this.buttonOpenInterview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOpenInterview.UseVisualStyleBackColor = true;
            this.buttonOpenInterview.Click += new System.EventHandler(this.buttonOpenInterview_Click);
            // 
            // remarkTextBox1
            // 
            this.remarkTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remarkTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.interviewsBindingSource, "Remark", true));
            this.remarkTextBox1.Location = new System.Drawing.Point(70, 29);
            this.remarkTextBox1.Multiline = true;
            this.remarkTextBox1.Name = "remarkTextBox1";
            this.remarkTextBox1.Size = new System.Drawing.Size(651, 57);
            this.remarkTextBox1.TabIndex = 5;
            // 
            // dateDateTimePicker
            // 
            this.dateDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.interviewsBindingSource, "Date", true));
            this.dateDateTimePicker.Location = new System.Drawing.Point(602, 3);
            this.dateDateTimePicker.Name = "dateDateTimePicker";
            this.dateDateTimePicker.Size = new System.Drawing.Size(186, 20);
            this.dateDateTimePicker.TabIndex = 3;
            // 
            // probandTextBox
            // 
            this.probandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.probandTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.interviewsBindingSource, "Proband", true));
            this.probandTextBox.Location = new System.Drawing.Point(70, 3);
            this.probandTextBox.Name = "probandTextBox";
            this.probandTextBox.Size = new System.Drawing.Size(487, 20);
            this.probandTextBox.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelCredits,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelStatus,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 351);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(913, 22);
            this.statusStrip1.TabIndex = 8;
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
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(328, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabelStatus.Text = "Status:";
            this.toolStripStatusLabelStatus.Visible = false;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FormProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 373);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(label1);
            this.Controls.Add(this.dataRepeater1);
            this.Controls.Add(remarkLabel);
            this.Controls.Add(this.remarkTextBox);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.menuStrip1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectBindingSource, "Name", true));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormProject";
            this.Text = "Project";
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.dataRepeater1.ItemTemplate.ResumeLayout(false);
            this.dataRepeater1.ItemTemplate.PerformLayout();
            this.dataRepeater1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.interviewsBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource projectBindingSource;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox remarkTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionenToolStripMenuItem;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater1;
        private System.Windows.Forms.Button buttonDeleteInterview;
        private System.Windows.Forms.Button buttonOpenInterview;
        private System.Windows.Forms.TextBox remarkTextBox1;
        private System.Windows.Forms.BindingSource interviewsBindingSource;
        private System.Windows.Forms.DateTimePicker dateDateTimePicker;
        private System.Windows.Forms.TextBox probandTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelCredits;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem interviewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addInterviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDemosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadRandomDemoToolStripMenuItem;
    }
}

