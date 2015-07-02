namespace OpenRepGridGui.View.uc
{
    partial class ucOptionalValuesBoolean
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
            this.checkBoxUseParameter = new System.Windows.Forms.CheckBox();
            this.checkBoxValue = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxParameter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxParameter
            // 
            this.groupBoxParameter.Controls.Add(this.checkBoxValue);
            this.groupBoxParameter.Controls.Add(this.checkBoxUseParameter);
            this.groupBoxParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxParameter.Location = new System.Drawing.Point(0, 0);
            this.groupBoxParameter.Name = "groupBoxParameter";
            this.groupBoxParameter.Size = new System.Drawing.Size(280, 70);
            this.groupBoxParameter.TabIndex = 3;
            this.groupBoxParameter.TabStop = false;
            this.groupBoxParameter.Text = "groupBox1";
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
            // checkBoxValue
            // 
            this.checkBoxValue.AutoSize = true;
            this.checkBoxValue.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxValue.Enabled = false;
            this.checkBoxValue.Location = new System.Drawing.Point(41, 44);
            this.checkBoxValue.Name = "checkBoxValue";
            this.checkBoxValue.Size = new System.Drawing.Size(53, 17);
            this.checkBoxValue.TabIndex = 2;
            this.checkBoxValue.Text = "Value";
            this.checkBoxValue.UseVisualStyleBackColor = true;
            // 
            // ucOptionalValuesBoolean
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxParameter);
            this.Name = "ucOptionalValuesBoolean";
            this.Size = new System.Drawing.Size(280, 70);
            this.groupBoxParameter.ResumeLayout(false);
            this.groupBoxParameter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxParameter;
        private System.Windows.Forms.CheckBox checkBoxValue;
        private System.Windows.Forms.CheckBox checkBoxUseParameter;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
