namespace RepertoryGridGUI
{
    partial class ufoInterview
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
            System.Windows.Forms.Label probandLabel;
            System.Windows.Forms.Label remarkLabel;
            System.Windows.Forms.Label dateLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ufoInterview));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.probandTextBox = new System.Windows.Forms.TextBox();
            this.interviewsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.remarkTextBox = new System.Windows.Forms.TextBox();
            this.dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGrid = new System.Windows.Forms.TextBox();
            probandLabel = new System.Windows.Forms.Label();
            remarkLabel = new System.Windows.Forms.Label();
            dateLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interviewsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // probandLabel
            // 
            probandLabel.AutoSize = true;
            probandLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            probandLabel.Location = new System.Drawing.Point(3, 0);
            probandLabel.Name = "probandLabel";
            probandLabel.Size = new System.Drawing.Size(74, 25);
            probandLabel.TabIndex = 1;
            probandLabel.Text = "Proband:";
            probandLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // remarkLabel
            // 
            remarkLabel.AutoSize = true;
            remarkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            remarkLabel.Location = new System.Drawing.Point(3, 50);
            remarkLabel.Name = "remarkLabel";
            remarkLabel.Size = new System.Drawing.Size(74, 50);
            remarkLabel.TabIndex = 5;
            remarkLabel.Text = "Remark:";
            remarkLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            dateLabel.Location = new System.Drawing.Point(3, 25);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new System.Drawing.Size(74, 25);
            dateLabel.TabIndex = 3;
            dateLabel.Text = "Date:";
            dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(probandLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.probandTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.remarkTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(remarkLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(dateLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateDateTimePicker, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxGrid, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(590, 115);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // probandTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.probandTextBox, 3);
            this.probandTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.interviewsBindingSource, "Proband", true));
            this.probandTextBox.Location = new System.Drawing.Point(83, 3);
            this.probandTextBox.Name = "probandTextBox";
            this.probandTextBox.Size = new System.Drawing.Size(504, 20);
            this.probandTextBox.TabIndex = 2;
            // 
            // interviewsBindingSource
            // 
            this.interviewsBindingSource.DataSource = typeof(RepertoryGrid.Model.Interview);
            // 
            // remarkTextBox
            // 
            this.remarkTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.remarkTextBox, 3);
            this.remarkTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.interviewsBindingSource, "Remark", true));
            this.remarkTextBox.Location = new System.Drawing.Point(83, 53);
            this.remarkTextBox.Multiline = true;
            this.remarkTextBox.Name = "remarkTextBox";
            this.remarkTextBox.Size = new System.Drawing.Size(504, 44);
            this.remarkTextBox.TabIndex = 6;
            // 
            // dateDateTimePicker
            // 
            this.dateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.interviewsBindingSource, "Date", true));
            this.dateDateTimePicker.Location = new System.Drawing.Point(83, 28);
            this.dateDateTimePicker.Name = "dateDateTimePicker";
            this.dateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateDateTimePicker.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(298, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "R Grid name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxGrid
            // 
            this.textBoxGrid.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.interviewsBindingSource, "GridName", true));
            this.textBoxGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxGrid.Location = new System.Drawing.Point(378, 28);
            this.textBoxGrid.Name = "textBoxGrid";
            this.textBoxGrid.Size = new System.Drawing.Size(209, 20);
            this.textBoxGrid.TabIndex = 8;
            // 
            // ufoInterview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 115);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(606, 153);
            this.Name = "ufoInterview";
            this.Text = "Interview Details";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interviewsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox probandTextBox;
        private System.Windows.Forms.BindingSource interviewsBindingSource;
        private System.Windows.Forms.TextBox remarkTextBox;
        private System.Windows.Forms.DateTimePicker dateDateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGrid;
    }
}