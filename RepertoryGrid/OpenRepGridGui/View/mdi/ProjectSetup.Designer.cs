namespace OpenRepGridGui
{
    partial class ProjectSetup
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
            System.Windows.Forms.Label gridNameLabel;
            System.Windows.Forms.Label probandLabel;
            System.Windows.Forms.Label remarkLabel1;
            System.Windows.Forms.Label dateLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label remarkLabel;
            this.dataRepeater1 = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.remarkTextBox1 = new System.Windows.Forms.TextBox();
            this.probandTextBox = new System.Windows.Forms.TextBox();
            this.gridNameTextBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.remarkTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.interviewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            gridNameLabel = new System.Windows.Forms.Label();
            probandLabel = new System.Windows.Forms.Label();
            remarkLabel1 = new System.Windows.Forms.Label();
            dateLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            remarkLabel = new System.Windows.Forms.Label();
            this.dataRepeater1.ItemTemplate.SuspendLayout();
            this.dataRepeater1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interviewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridNameLabel
            // 
            gridNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            gridNameLabel.AutoSize = true;
            gridNameLabel.Location = new System.Drawing.Point(560, 6);
            gridNameLabel.Name = "gridNameLabel";
            gridNameLabel.Size = new System.Drawing.Size(60, 13);
            gridNameLabel.TabIndex = 0;
            gridNameLabel.Text = "Grid Name:";
            // 
            // probandLabel
            // 
            probandLabel.AutoSize = true;
            probandLabel.Location = new System.Drawing.Point(-2, 6);
            probandLabel.Name = "probandLabel";
            probandLabel.Size = new System.Drawing.Size(50, 13);
            probandLabel.TabIndex = 2;
            probandLabel.Text = "Proband:";
            // 
            // remarkLabel1
            // 
            remarkLabel1.AutoSize = true;
            remarkLabel1.Location = new System.Drawing.Point(1, 32);
            remarkLabel1.Name = "remarkLabel1";
            remarkLabel1.Size = new System.Drawing.Size(47, 13);
            remarkLabel1.TabIndex = 4;
            remarkLabel1.Text = "Remark:";
            // 
            // dateLabel
            // 
            dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            dateLabel.AutoSize = true;
            dateLabel.Location = new System.Drawing.Point(315, 7);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new System.Drawing.Size(33, 13);
            dateLabel.TabIndex = 8;
            dateLabel.Text = "Date:";
            // 
            // nameLabel
            // 
            nameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            nameLabel.Location = new System.Drawing.Point(3, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(64, 30);
            nameLabel.TabIndex = 11;
            nameLabel.Text = "Name:";
            nameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // remarkLabel
            // 
            remarkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            remarkLabel.Location = new System.Drawing.Point(3, 30);
            remarkLabel.Name = "remarkLabel";
            remarkLabel.Size = new System.Drawing.Size(64, 70);
            remarkLabel.TabIndex = 10;
            remarkLabel.Text = "Remark:";
            remarkLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataRepeater1
            // 
            this.dataRepeater1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // dataRepeater1.ItemTemplate
            // 
            this.dataRepeater1.ItemTemplate.Controls.Add(dateLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.dateDateTimePicker);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.btnDelete);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.btnEdit);
            this.dataRepeater1.ItemTemplate.Controls.Add(remarkLabel1);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.remarkTextBox1);
            this.dataRepeater1.ItemTemplate.Controls.Add(probandLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.probandTextBox);
            this.dataRepeater1.ItemTemplate.Controls.Add(gridNameLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.gridNameTextBox);
            this.dataRepeater1.ItemTemplate.Size = new System.Drawing.Size(825, 117);
            this.dataRepeater1.Location = new System.Drawing.Point(12, 145);
            this.dataRepeater1.Name = "dataRepeater1";
            this.dataRepeater1.Size = new System.Drawing.Size(833, 297);
            this.dataRepeater1.TabIndex = 11;
            this.dataRepeater1.Text = "dataRepeater1";
            // 
            // dateDateTimePicker
            // 
            this.dateDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.interviewBindingSource, "Date", true));
            this.dateDateTimePicker.Location = new System.Drawing.Point(354, 3);
            this.dateDateTimePicker.Name = "dateDateTimePicker";
            this.dateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateDateTimePicker.TabIndex = 9;
            // 
            // remarkTextBox1
            // 
            this.remarkTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remarkTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.interviewBindingSource, "Remark", true));
            this.remarkTextBox1.Location = new System.Drawing.Point(54, 29);
            this.remarkTextBox1.Multiline = true;
            this.remarkTextBox1.Name = "remarkTextBox1";
            this.remarkTextBox1.Size = new System.Drawing.Size(500, 70);
            this.remarkTextBox1.TabIndex = 5;
            // 
            // probandTextBox
            // 
            this.probandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.probandTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.interviewBindingSource, "Proband", true));
            this.probandTextBox.Location = new System.Drawing.Point(54, 3);
            this.probandTextBox.Name = "probandTextBox";
            this.probandTextBox.Size = new System.Drawing.Size(246, 20);
            this.probandTextBox.TabIndex = 3;
            // 
            // gridNameTextBox
            // 
            this.gridNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gridNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.interviewBindingSource, "GridName", true));
            this.gridNameTextBox.Location = new System.Drawing.Point(626, 3);
            this.gridNameTextBox.Name = "gridNameTextBox";
            this.gridNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.gridNameTextBox.TabIndex = 1;
            this.toolTip1.SetToolTip(this.gridNameTextBox, "this is the variable-name used in R");
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectBindingSource, "Name", true));
            this.nameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameTextBox.Location = new System.Drawing.Point(73, 3);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(757, 20);
            this.nameTextBox.TabIndex = 12;
            // 
            // remarkTextBox
            // 
            this.remarkTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectBindingSource, "Remark", true));
            this.remarkTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remarkTextBox.Location = new System.Drawing.Point(73, 33);
            this.remarkTextBox.Multiline = true;
            this.remarkTextBox.Name = "remarkTextBox";
            this.remarkTextBox.Size = new System.Drawing.Size(757, 64);
            this.remarkTextBox.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.remarkTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(remarkLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(nameLabel, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(833, 100);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = global::OpenRepGridGui.Properties.Resources.DeleteHS;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(611, 76);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Image = global::OpenRepGridGui.Properties.Resources.CommentHS;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(682, 76);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(65, 23);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // interviewBindingSource
            // 
            this.interviewBindingSource.DataSource = typeof(OpenRepGridModel.Model.Interview);
            this.interviewBindingSource.PositionChanged += new System.EventHandler(this.interviewBindingSource_PositionChanged);
            // 
            // projectBindingSource
            // 
            this.projectBindingSource.DataSource = typeof(OpenRepGridModel.Model.Project);
            // 
            // ProjectSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 454);
            this.Controls.Add(this.dataRepeater1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectBindingSource, "Name", true));
            this.Name = "ProjectSetup";
            this.Text = "Project";
            this.Load += new System.EventHandler(this.ProjectSetup_Load);
            this.dataRepeater1.ItemTemplate.ResumeLayout(false);
            this.dataRepeater1.ItemTemplate.PerformLayout();
            this.dataRepeater1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interviewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource projectBindingSource;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox remarkTextBox1;
        private System.Windows.Forms.BindingSource interviewBindingSource;
        private System.Windows.Forms.TextBox probandTextBox;
        private System.Windows.Forms.TextBox gridNameTextBox;
        private System.Windows.Forms.DateTimePicker dateDateTimePicker;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox remarkTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

