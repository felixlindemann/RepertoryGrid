namespace OpenRepGridGui.View.uc
{
    partial class ucOptionalValuesInteger
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxParameter = new System.Windows.Forms.GroupBox();
            this.numericUpDownInteger = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxUseParameter = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInteger)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxParameter
            // 
            this.groupBoxParameter.Controls.Add(this.numericUpDownInteger);
            this.groupBoxParameter.Controls.Add(this.label1);
            this.groupBoxParameter.Controls.Add(this.checkBoxUseParameter);
            this.groupBoxParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxParameter.Location = new System.Drawing.Point(0, 0);
            this.groupBoxParameter.Name = "groupBoxParameter";
            this.groupBoxParameter.Size = new System.Drawing.Size(280, 70);
            this.groupBoxParameter.TabIndex = 1;
            this.groupBoxParameter.TabStop = false;
            this.groupBoxParameter.Text = "groupBox1";
            // 
            // numericUpDownInteger
            // 
            this.numericUpDownInteger.Enabled = false;
            this.numericUpDownInteger.Location = new System.Drawing.Point(84, 44);
            this.numericUpDownInteger.Name = "numericUpDownInteger";
            this.numericUpDownInteger.Size = new System.Drawing.Size(181, 20);
            this.numericUpDownInteger.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Value: ";
            // 
            // checkBoxUseParameter
            // 
            this.checkBoxUseParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxUseParameter.AutoSize = true;
            this.checkBoxUseParameter.Location = new System.Drawing.Point(178, 19);
            this.checkBoxUseParameter.Name = "checkBoxUseParameter";
            this.checkBoxUseParameter.Size = new System.Drawing.Size(96, 17);
            this.checkBoxUseParameter.TabIndex = 0;
            this.checkBoxUseParameter.Text = "Use Parameter";
            this.checkBoxUseParameter.UseVisualStyleBackColor = true;
            this.checkBoxUseParameter.CheckedChanged += new System.EventHandler(this.checkBoxUseParameter_CheckedChanged);
            // 
            // ucOptionalValuesInteger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxParameter);
            this.Name = "ucOptionalValuesInteger";
            this.Size = new System.Drawing.Size(280, 70);
            this.groupBoxParameter.ResumeLayout(false);
            this.groupBoxParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInteger)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxParameter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxUseParameter;
        private System.Windows.Forms.NumericUpDown numericUpDownInteger;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
