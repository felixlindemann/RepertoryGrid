namespace RepertoryGridGUI.ufos
{
    partial class ufoConstructs
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ufoConstructs));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonAddConstruct = new System.Windows.Forms.ToolStripButton();
            this.dataRepeater1 = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.constructBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucConstruct1 = new RepertoryGridGUI.UserControls.UcConstruct();
            this.toolStrip2.SuspendLayout();
            this.dataRepeater1.ItemTemplate.SuspendLayout();
            this.dataRepeater1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.constructBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripButtonAddConstruct});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(599, 25);
            this.toolStrip2.TabIndex = 2;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(64, 22);
            this.toolStripLabel2.Text = "Construct:";
            // 
            // toolStripButtonAddConstruct
            // 
            this.toolStripButtonAddConstruct.Image = global::RepertoryGridGUI.Properties.Resources.LayoutSelectRow;
            this.toolStripButtonAddConstruct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddConstruct.Name = "toolStripButtonAddConstruct";
            this.toolStripButtonAddConstruct.Size = new System.Drawing.Size(104, 22);
            this.toolStripButtonAddConstruct.Text = "Add Construct";
            this.toolStripButtonAddConstruct.Click += new System.EventHandler(this.toolStripButtonAddConstruct_Click);
            // 
            // dataRepeater1
            // 
            this.dataRepeater1.AllowUserToAddItems = false;
            this.dataRepeater1.AllowUserToDeleteItems = false;
            this.dataRepeater1.DataSource = this.constructBindingSource;
            this.dataRepeater1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // dataRepeater1.ItemTemplate
            // 
            this.dataRepeater1.ItemTemplate.Controls.Add(this.ucConstruct1);
            this.dataRepeater1.ItemTemplate.Size = new System.Drawing.Size(591, 98);
            this.dataRepeater1.Location = new System.Drawing.Point(0, 25);
            this.dataRepeater1.Name = "dataRepeater1";
            this.dataRepeater1.Size = new System.Drawing.Size(599, 237);
            this.dataRepeater1.TabIndex = 3;
            this.dataRepeater1.Text = "dataRepeater1";
            this.dataRepeater1.DrawItem += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventHandler(this.dataRepeater1_DrawItem);
            // 
            // constructBindingSource
            // 
            this.constructBindingSource.DataSource = typeof(RepertoryGrid.Model.Construct);
            // 
            // ucConstruct1
            // 
            this.ucConstruct1.CurrentConstruct = null;
            this.ucConstruct1.CurrentInterviewService = null;
            this.ucConstruct1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucConstruct1.Location = new System.Drawing.Point(0, 0);
            this.ucConstruct1.Name = "ucConstruct1";
            this.ucConstruct1.Size = new System.Drawing.Size(576, 97);
            this.ucConstruct1.TabIndex = 0; 
            // 
            // ufoConstructs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 262);
            this.Controls.Add(this.dataRepeater1);
            this.Controls.Add(this.toolStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ufoConstructs";
            this.Text = "Edit Constructs"; 
            this.ResizeBegin += new System.EventHandler(this.ufoConstructs_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.ufoConstructs_ResizeEnd);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.dataRepeater1.ItemTemplate.ResumeLayout(false);
            this.dataRepeater1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.constructBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddConstruct;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater1;
        private UserControls.UcConstruct ucConstruct1;
        private System.Windows.Forms.BindingSource constructBindingSource;
    }
}