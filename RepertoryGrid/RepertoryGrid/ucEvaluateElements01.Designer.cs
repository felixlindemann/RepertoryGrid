namespace RepertoryGrid
{
    partial class ucEvaluateElements01
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ratingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scaleItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ratingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ratingBindingSource, "ScaleItemId", true));
            this.comboBox1.DataSource = this.scaleItemBindingSource;
            this.comboBox1.DisplayMember = "DisplayName";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.DropDownWidth = 400;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(123, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ratingBindingSource
            // 
            this.ratingBindingSource.DataSource = typeof(RepertoryGrid.classes.Rating);
            // 
            // scaleItemBindingSource
            // 
            this.scaleItemBindingSource.DataSource = typeof(RepertoryGrid.classes.ScaleItem);
            // 
            // ucEvaluateElements01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox1);
            this.Name = "ucEvaluateElements01";
            this.Size = new System.Drawing.Size(129, 28);
            ((System.ComponentModel.ISupportInitialize)(this.ratingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource scaleItemBindingSource;
        private System.Windows.Forms.BindingSource ratingBindingSource;
    }
}
