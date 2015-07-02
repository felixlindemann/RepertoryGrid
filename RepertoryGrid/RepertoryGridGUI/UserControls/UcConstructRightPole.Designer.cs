namespace RepertoryGridGUI.UserControls
{
    partial class UcConstructRightPole
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
            this.constructPolTextBox = new System.Windows.Forms.TextBox();
            this.constructBindingSource = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.constructBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // constructPolTextBox
            // 
            this.constructPolTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.constructPolTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.constructBindingSource, "ConstructPol", true));
            this.constructPolTextBox.Location = new System.Drawing.Point(3, 5);
            this.constructPolTextBox.Name = "constructPolTextBox";
            this.constructPolTextBox.Size = new System.Drawing.Size(103, 20);
            this.constructPolTextBox.TabIndex = 3;
            // 
            // constructBindingSource
            // 
            this.constructBindingSource.DataSource = typeof(RepertoryGrid.Model.Construct);
            // 
            // UcConstructRightPole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.constructPolTextBox);
            this.Name = "UcConstructRightPole";
            this.Size = new System.Drawing.Size(109, 30);
            ((System.ComponentModel.ISupportInitialize)(this.constructBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox constructPolTextBox;
        private System.Windows.Forms.BindingSource constructBindingSource;
    }
}
