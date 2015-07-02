namespace RepertoryGridGUI
{
    partial class ufoScales
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
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label nameLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ufoScales));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonSortAscending = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDescending = new System.Windows.Forms.ToolStripButton();
            this.dataRepeater2 = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.nameTextBox2 = new System.Windows.Forms.TextBox();
            this.scalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            idLabel = new System.Windows.Forms.Label();
            nameLabel1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.dataRepeater2.ItemTemplate.SuspendLayout();
            this.dataRepeater2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.toolStripButtonSortAscending,
            this.toolStripButtonDescending});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(657, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel4.Text = "Scales:";
            // 
            // toolStripButtonSortAscending
            // 
            this.toolStripButtonSortAscending.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSortAscending.Image = global::RepertoryGridGUI.Properties.Resources.SortHS;
            this.toolStripButtonSortAscending.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSortAscending.Name = "toolStripButtonSortAscending";
            this.toolStripButtonSortAscending.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSortAscending.Text = "Sort Ascending";
            this.toolStripButtonSortAscending.Click += new System.EventHandler(this.toolStripButtonSortAscending_Click);
            // 
            // toolStripButtonDescending
            // 
            this.toolStripButtonDescending.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDescending.Image = global::RepertoryGridGUI.Properties.Resources.SortUpHS;
            this.toolStripButtonDescending.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDescending.Name = "toolStripButtonDescending";
            this.toolStripButtonDescending.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDescending.Text = "Sort Descending";
            this.toolStripButtonDescending.Click += new System.EventHandler(this.toolStripButtonDescending_Click);
            // 
            // dataRepeater2
            // 
            this.dataRepeater2.AllowUserToAddItems = false;
            this.dataRepeater2.AllowUserToDeleteItems = false;
            this.dataRepeater2.DataSource = this.scalesBindingSource;
            this.dataRepeater2.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // dataRepeater2.ItemTemplate
            // 
            this.dataRepeater2.ItemTemplate.Controls.Add(this.numericUpDown1);
            this.dataRepeater2.ItemTemplate.Controls.Add(idLabel);
            this.dataRepeater2.ItemTemplate.Controls.Add(nameLabel1);
            this.dataRepeater2.ItemTemplate.Controls.Add(this.nameTextBox2);
            this.dataRepeater2.ItemTemplate.Size = new System.Drawing.Size(649, 52);
            this.dataRepeater2.Location = new System.Drawing.Point(0, 25);
            this.dataRepeater2.Name = "dataRepeater2";
            this.dataRepeater2.Size = new System.Drawing.Size(657, 237);
            this.dataRepeater2.TabIndex = 2;
            this.dataRepeater2.Text = "dataRepeater2";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.scalesBindingSource, "Id", true));
            this.numericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.scalesBindingSource, "IsDefault", true));
            this.numericUpDown1.Location = new System.Drawing.Point(6, 16);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(87, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(3, 0);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(41, 13);
            idLabel.TabIndex = 2;
            idLabel.Text = "Rating:";
            // 
            // nameLabel1
            // 
            nameLabel1.AutoSize = true;
            nameLabel1.Location = new System.Drawing.Point(110, 0);
            nameLabel1.Name = "nameLabel1";
            nameLabel1.Size = new System.Drawing.Size(38, 13);
            nameLabel1.TabIndex = 0;
            nameLabel1.Text = "Name:";
            // 
            // nameTextBox2
            // 
            this.nameTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scalesBindingSource, "Name", true));
            this.nameTextBox2.Location = new System.Drawing.Point(113, 15);
            this.nameTextBox2.Multiline = true;
            this.nameTextBox2.Name = "nameTextBox2";
            this.nameTextBox2.Size = new System.Drawing.Size(518, 21);
            this.nameTextBox2.TabIndex = 1;
            // 
            // scalesBindingSource
            // 
            this.scalesBindingSource.DataSource = typeof(RepertoryGrid.Model.ScaleItem);
            // 
            // ufoScales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 262);
            this.Controls.Add(this.dataRepeater2);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ufoScales";
            this.Text = "Scales";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.dataRepeater2.ItemTemplate.ResumeLayout(false);
            this.dataRepeater2.ItemTemplate.PerformLayout();
            this.dataRepeater2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton toolStripButtonSortAscending;
        private System.Windows.Forms.ToolStripButton toolStripButtonDescending;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater2;
        private System.Windows.Forms.BindingSource scalesBindingSource;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox nameTextBox2;

    }
}