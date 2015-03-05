namespace RepertoryGrid
{
    partial class DialogConstructPCA
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelcorrmatrix = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelrotate = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownNF = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numericUpDownCutoff = new System.Windows.Forms.NumericUpDown();
            this.checkBoxCutOff = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanelcorrmatrix.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanelrotate.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNF)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCutoff)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanelcorrmatrix);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "method for CorrelationMatrix";
            // 
            // flowLayoutPanelcorrmatrix
            // 
            this.flowLayoutPanelcorrmatrix.Controls.Add(this.radioButton1);
            this.flowLayoutPanelcorrmatrix.Controls.Add(this.radioButton2);
            this.flowLayoutPanelcorrmatrix.Controls.Add(this.radioButton3);
            this.flowLayoutPanelcorrmatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelcorrmatrix.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanelcorrmatrix.Name = "flowLayoutPanelcorrmatrix";
            this.flowLayoutPanelcorrmatrix.Size = new System.Drawing.Size(277, 28);
            this.flowLayoutPanelcorrmatrix.TabIndex = 0;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(63, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "pearson";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(72, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "kendall";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(137, 3);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(71, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "spearman";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanelrotate);
            this.groupBox2.Location = new System.Drawing.Point(12, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 47);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "methods of rotation ";
            // 
            // flowLayoutPanelrotate
            // 
            this.flowLayoutPanelrotate.Controls.Add(this.radioButton5);
            this.flowLayoutPanelrotate.Controls.Add(this.radioButton6);
            this.flowLayoutPanelrotate.Controls.Add(this.radioButton7);
            this.flowLayoutPanelrotate.Controls.Add(this.radioButton8);
            this.flowLayoutPanelrotate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelrotate.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanelrotate.Name = "flowLayoutPanelrotate";
            this.flowLayoutPanelrotate.Size = new System.Drawing.Size(277, 28);
            this.flowLayoutPanelrotate.TabIndex = 0;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(3, 3);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(49, 17);
            this.radioButton5.TabIndex = 0;
            this.radioButton5.Text = "none";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Checked = true;
            this.radioButton6.Location = new System.Drawing.Point(58, 3);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(61, 17);
            this.radioButton6.TabIndex = 1;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "varimax";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(125, 3);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(59, 17);
            this.radioButton7.TabIndex = 2;
            this.radioButton7.Text = "promax";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(190, 3);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(51, 17);
            this.radioButton8.TabIndex = 3;
            this.radioButton8.Text = "cluter";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(9, 186);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(239, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://docu.openrepgrid.org/constructs_pca.html";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownNF);
            this.groupBox3.Location = new System.Drawing.Point(12, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 45);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "number of components to extract";
            // 
            // numericUpDownNF
            // 
            this.numericUpDownNF.Location = new System.Drawing.Point(11, 19);
            this.numericUpDownNF.Name = "numericUpDownNF";
            this.numericUpDownNF.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownNF.TabIndex = 0;
            this.numericUpDownNF.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxCutOff);
            this.groupBox4.Controls.Add(this.numericUpDownCutoff);
            this.groupBox4.Location = new System.Drawing.Point(218, 118);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(175, 45);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "cutoff level";
            // 
            // numericUpDownCutoff
            // 
            this.numericUpDownCutoff.DecimalPlaces = 2;
            this.numericUpDownCutoff.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownCutoff.Location = new System.Drawing.Point(110, 18);
            this.numericUpDownCutoff.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCutoff.Name = "numericUpDownCutoff";
            this.numericUpDownCutoff.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownCutoff.TabIndex = 0;
            this.numericUpDownCutoff.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            // 
            // checkBoxCutOff
            // 
            this.checkBoxCutOff.AutoSize = true;
            this.checkBoxCutOff.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxCutOff.Location = new System.Drawing.Point(6, 19);
            this.checkBoxCutOff.Name = "checkBoxCutOff";
            this.checkBoxCutOff.Size = new System.Drawing.Size(98, 17);
            this.checkBoxCutOff.TabIndex = 1;
            this.checkBoxCutOff.Text = "use cutoff level";
            this.checkBoxCutOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxCutOff.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(365, 173);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(284, 173);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // DialogConstructPCA
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(452, 208);
            this.ControlBox = false;
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DialogConstructPCA";
            this.Text = "PCA of constructs: Please Choose from the following Options";
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanelcorrmatrix.ResumeLayout(false);
            this.flowLayoutPanelcorrmatrix.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanelrotate.ResumeLayout(false);
            this.flowLayoutPanelrotate.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNF)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCutoff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelcorrmatrix;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelrotate;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownNF;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBoxCutOff;
        private System.Windows.Forms.NumericUpDown numericUpDownCutoff;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
    }
}