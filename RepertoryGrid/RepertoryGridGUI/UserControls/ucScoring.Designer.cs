namespace RepertoryGridGUI.UserControls
{
    partial class ucScoring
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxConstrast = new System.Windows.Forms.TextBox();
            this.constructBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelRight = new System.Windows.Forms.Panel();
            this.textBoxConstructPole = new System.Windows.Forms.TextBox();
            this.dataRepeaterScoring = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.scoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonRating = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.constructBindingSource)).BeginInit();
            this.panelRight.SuspendLayout();
            this.dataRepeaterScoring.ItemTemplate.SuspendLayout();
            this.dataRepeaterScoring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scoreBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.textBoxName);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 0);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.textBoxConstrast);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(5, 25, 5, 0);
            this.splitContainer2.Size = new System.Drawing.Size(232, 67);
            this.splitContainer2.SplitterDistance = 77;
            this.splitContainer2.TabIndex = 5;
            // 
            // textBoxName
            // 
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxName.Location = new System.Drawing.Point(5, 25);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(67, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // textBoxConstrast
            // 
            this.textBoxConstrast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxConstrast.Location = new System.Drawing.Point(5, 25);
            this.textBoxConstrast.Name = "textBoxConstrast";
            this.textBoxConstrast.Size = new System.Drawing.Size(141, 20);
            this.textBoxConstrast.TabIndex = 1;
            // 
            // constructBindingSource
            // 
            this.constructBindingSource.DataSource = typeof(RepertoryGrid.Model.Construct);
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.textBoxConstructPole);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(470, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(5, 25, 5, 0);
            this.panelRight.Size = new System.Drawing.Size(157, 67);
            this.panelRight.TabIndex = 6;
            // 
            // textBoxConstructPole
            // 
            this.textBoxConstructPole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxConstructPole.Location = new System.Drawing.Point(5, 25);
            this.textBoxConstructPole.Name = "textBoxConstructPole";
            this.textBoxConstructPole.Size = new System.Drawing.Size(147, 20);
            this.textBoxConstructPole.TabIndex = 1;
            // 
            // dataRepeaterScoring
            // 
            this.dataRepeaterScoring.AllowUserToAddItems = false;
            this.dataRepeaterScoring.AllowUserToDeleteItems = false;
            this.dataRepeaterScoring.DataSource = this.scoreBindingSource;
            this.dataRepeaterScoring.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // dataRepeaterScoring.ItemTemplate
            // 
            this.dataRepeaterScoring.ItemTemplate.Controls.Add(this.buttonRating);
            this.dataRepeaterScoring.ItemTemplate.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dataRepeaterScoring.ItemTemplate.Size = new System.Drawing.Size(46, 59);
            this.dataRepeaterScoring.LayoutStyle = Microsoft.VisualBasic.PowerPacks.DataRepeaterLayoutStyles.Horizontal;
            this.dataRepeaterScoring.Location = new System.Drawing.Point(232, 0);
            this.dataRepeaterScoring.Name = "dataRepeaterScoring";
            this.dataRepeaterScoring.Size = new System.Drawing.Size(238, 67);
            this.dataRepeaterScoring.TabIndex = 7;
            this.dataRepeaterScoring.Text = "dataRepeater3";
            this.dataRepeaterScoring.DrawItem += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventHandler(this.dataRepeaterScoring_DrawItem);
            this.dataRepeaterScoring.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataRepeaterScoring_Scroll);
            // 
            // scoreBindingSource
            // 
            this.scoreBindingSource.DataSource = typeof(RepertoryGrid.Model.Score);
            this.scoreBindingSource.PositionChanged += new System.EventHandler(this.scoreBindingSource_PositionChanged);
            // 
            // buttonRating
            // 
            this.buttonRating.Location = new System.Drawing.Point(7, 3);
            this.buttonRating.Name = "buttonRating";
            this.buttonRating.Size = new System.Drawing.Size(31, 24);
            this.buttonRating.TabIndex = 0;
            this.buttonRating.Text = "3";
            this.buttonRating.UseVisualStyleBackColor = true;
            this.buttonRating.Click += new System.EventHandler(this.buttonRating_Click);
            // 
            // ucScoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataRepeaterScoring);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.splitContainer2);
            this.Name = "ucScoring";
            this.Size = new System.Drawing.Size(627, 67);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.constructBindingSource)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.dataRepeaterScoring.ItemTemplate.ResumeLayout(false);
            this.dataRepeaterScoring.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scoreBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxConstrast;
        private System.Windows.Forms.TextBox textBoxConstructPole;
        private System.Windows.Forms.BindingSource constructBindingSource;
        private System.Windows.Forms.Button buttonRating;
        public System.Windows.Forms.BindingSource scoreBindingSource;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Panel panelRight;
        public Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeaterScoring;
    }
}
