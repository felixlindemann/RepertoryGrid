namespace RepertoryGrid
{
    partial class UserControlConstructLeftPole
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
            this.constructBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.contrastPolTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.constructBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // constructBindingSource
            // 
            this.constructBindingSource.DataSource = typeof(RepertoryGrid.classes.Construct);
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.constructBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(3, 5);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(120, 20);
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.MouseEnter += new System.EventHandler(this.nameTextBox_MouseEnter);
            this.nameTextBox.MouseLeave += new System.EventHandler(this.nameTextBox_MouseLeave);
            // 
            // contrastPolTextBox
            // 
            this.contrastPolTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.contrastPolTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.constructBindingSource, "ContrastPol", true));
            this.contrastPolTextBox.Location = new System.Drawing.Point(129, 5);
            this.contrastPolTextBox.Name = "contrastPolTextBox";
            this.contrastPolTextBox.Size = new System.Drawing.Size(100, 20);
            this.contrastPolTextBox.TabIndex = 3;
            this.contrastPolTextBox.MouseEnter += new System.EventHandler(this.contrastPolTextBox_MouseEnter);
            this.contrastPolTextBox.MouseLeave += new System.EventHandler(this.contrastPolTextBox_MouseLeave);
            // 
            // UserControlConstructLeftPole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.contrastPolTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Name = "UserControlConstructLeftPole";
            this.Size = new System.Drawing.Size(233, 30);
            ((System.ComponentModel.ISupportInitialize)(this.constructBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource constructBindingSource;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox contrastPolTextBox;
    }
}
