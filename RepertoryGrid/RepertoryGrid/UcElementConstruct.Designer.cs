namespace RepertoryGrid
{
    partial class UcElementConstruct
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
            this.dataRepeaterConstructsElements = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.ratingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucEvaluateElements011 = new RepertoryGrid.ucEvaluateElements01();
            this.dataRepeaterConstructsElements.ItemTemplate.SuspendLayout();
            this.dataRepeaterConstructsElements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataRepeaterConstructsElements
            // 
            this.dataRepeaterConstructsElements.AllowUserToAddItems = false;
            this.dataRepeaterConstructsElements.AllowUserToDeleteItems = false;
            this.dataRepeaterConstructsElements.DataSource = this.ratingsBindingSource;
            this.dataRepeaterConstructsElements.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // dataRepeaterConstructsElements.ItemTemplate
            // 
            this.dataRepeaterConstructsElements.ItemTemplate.Controls.Add(this.ucEvaluateElements011);
            this.dataRepeaterConstructsElements.ItemTemplate.Size = new System.Drawing.Size(141, 39);
            this.dataRepeaterConstructsElements.Location = new System.Drawing.Point(0, 0);
            this.dataRepeaterConstructsElements.Name = "dataRepeaterConstructsElements";
            this.dataRepeaterConstructsElements.Size = new System.Drawing.Size(149, 203);
            this.dataRepeaterConstructsElements.TabIndex = 6;
            this.dataRepeaterConstructsElements.Text = "dataRepeaterConstructsElements";
            this.dataRepeaterConstructsElements.DrawItem += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventHandler(this.dataRepeaterConstructsElements_DrawItem);
            // 
            // ratingsBindingSource
            // 
            this.ratingsBindingSource.DataSource = typeof(RepertoryGrid.classes.Rating);
            // 
            // ucEvaluateElements011
            // 
            this.ucEvaluateElements011.CurrentRating = null;
            this.ucEvaluateElements011.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.ratingsBindingSource, "ParentElement", true));
            this.ucEvaluateElements011.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEvaluateElements011.Location = new System.Drawing.Point(0, 0);
            this.ucEvaluateElements011.Name = "ucEvaluateElements011";
            this.ucEvaluateElements011.Size = new System.Drawing.Size(126, 38);
            this.ucEvaluateElements011.TabIndex = 0;
            // 
            // UcElementConstruct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataRepeaterConstructsElements);
            this.Name = "UcElementConstruct";
            this.Size = new System.Drawing.Size(149, 203);
            this.dataRepeaterConstructsElements.ItemTemplate.ResumeLayout(false);
            this.dataRepeaterConstructsElements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ratingsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeaterConstructsElements;
        private ucEvaluateElements01 ucEvaluateElements011;
        public System.Windows.Forms.BindingSource ratingsBindingSource;
    }
}
