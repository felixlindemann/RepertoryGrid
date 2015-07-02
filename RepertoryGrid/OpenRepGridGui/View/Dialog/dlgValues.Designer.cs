namespace OpenRepGridGui.View.Dialog
{
    partial class dlgValues
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonok = new System.Windows.Forms.Button();
            this.ucOptionalValues1 = new OpenRepGridGui.View.uc.ucOptionalValues();
            this.checkBoxCustomOptions = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(207, 297);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonok
            // 
            this.buttonok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonok.Location = new System.Drawing.Point(288, 297);
            this.buttonok.Name = "buttonok";
            this.buttonok.Size = new System.Drawing.Size(75, 23);
            this.buttonok.TabIndex = 7;
            this.buttonok.Text = "Ok";
            this.buttonok.UseVisualStyleBackColor = true;
            this.buttonok.Click += new System.EventHandler(this.buttonok_Click);
            // 
            // ucOptionalValues1
            // 
            this.ucOptionalValues1.AcceptedValues = null;
            this.ucOptionalValues1.Location = new System.Drawing.Point(12, 12);
            this.ucOptionalValues1.Name = "ucOptionalValues1";
            this.ucOptionalValues1.Size = new System.Drawing.Size(352, 205);
            this.ucOptionalValues1.TabIndex = 9;
            // 
            // checkBoxCustomOptions
            // 
            this.checkBoxCustomOptions.AutoSize = true;
            this.checkBoxCustomOptions.Location = new System.Drawing.Point(12, 223);
            this.checkBoxCustomOptions.Name = "checkBoxCustomOptions";
            this.checkBoxCustomOptions.Size = new System.Drawing.Size(320, 17);
            this.checkBoxCustomOptions.TabIndex = 10;
            this.checkBoxCustomOptions.Text = "Custom Options (use if GUI doesn\'t provide the desired Option)";
            this.checkBoxCustomOptions.UseVisualStyleBackColor = true;
            this.checkBoxCustomOptions.CheckedChanged += new System.EventHandler(this.checkBoxCustomOptions_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Lime;
            this.textBox1.Location = new System.Drawing.Point(12, 246);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(351, 45);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "# room for your code";
            // 
            // dlgValues
            // 
            this.AcceptButton = this.buttonok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(375, 332);
            this.ControlBox = false;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBoxCustomOptions);
            this.Controls.Add(this.ucOptionalValues1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "dlgValues";
            this.Text = "FormDialogValues";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonok;
        private uc.ucOptionalValues ucOptionalValues1;
        private System.Windows.Forms.CheckBox checkBoxCustomOptions;
        private System.Windows.Forms.TextBox textBox1;
    }
}