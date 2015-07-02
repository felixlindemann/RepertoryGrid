namespace RepertoryGridGUI.UserControls
{
    partial class UcConstructLeftPole
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
            this.contrastPolTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.constructBindingSource = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.constructBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // contrastPolTextBox
            // 
            this.contrastPolTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contrastPolTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.constructBindingSource, "ContrastPol", true));
            this.contrastPolTextBox.Location = new System.Drawing.Point(129, 3);
            this.contrastPolTextBox.Name = "contrastPolTextBox";
            this.contrastPolTextBox.Size = new System.Drawing.Size(100, 20);
            this.contrastPolTextBox.TabIndex = 5;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.constructBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(3, 3);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(120, 20);
            this.nameTextBox.TabIndex = 4;
            // 
            // constructBindingSource
            // 
            this.constructBindingSource.DataSource = typeof(RepertoryGrid.Model.Construct);
            // 
            // UcConstructLeftPole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contrastPolTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Name = "UcConstructLeftPole";
            this.Size = new System.Drawing.Size(232, 30);
            ((System.ComponentModel.ISupportInitialize)(this.constructBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox contrastPolTextBox;
        private System.Windows.Forms.BindingSource constructBindingSource;
        private System.Windows.Forms.TextBox nameTextBox;
    }
}
