namespace RepertoryGridGUI.ufos
{
    partial class ufoElements
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ufoElements));
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonAddElement = new System.Windows.Forms.ToolStripButton();
            this.dataRepeater1 = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.ucElement1 = new RepertoryGridGUI.UserControls.UcElement();
            this.elementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip3.SuspendLayout();
            this.dataRepeater1.ItemTemplate.SuspendLayout();
            this.dataRepeater1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.toolStripButtonAddElement});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(528, 25);
            this.toolStrip3.TabIndex = 3;
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel3.Text = "Element:";
            // 
            // toolStripButtonAddElement
            // 
            this.toolStripButtonAddElement.Image = global::RepertoryGridGUI.Properties.Resources.LayoutSelectColumn;
            this.toolStripButtonAddElement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddElement.Name = "toolStripButtonAddElement";
            this.toolStripButtonAddElement.Size = new System.Drawing.Size(95, 22);
            this.toolStripButtonAddElement.Text = "Add Element";
            this.toolStripButtonAddElement.Click += new System.EventHandler(this.toolStripButtonAddElement_Click);
            // 
            // dataRepeater1
            // 
            this.dataRepeater1.AllowUserToAddItems = false;
            this.dataRepeater1.AllowUserToDeleteItems = false;
            this.dataRepeater1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // dataRepeater1.ItemTemplate
            // 
            this.dataRepeater1.ItemTemplate.Controls.Add(this.ucElement1);
            this.dataRepeater1.ItemTemplate.Size = new System.Drawing.Size(520, 108);
            this.dataRepeater1.Location = new System.Drawing.Point(0, 25);
            this.dataRepeater1.Name = "dataRepeater1";
            this.dataRepeater1.Size = new System.Drawing.Size(528, 237);
            this.dataRepeater1.TabIndex = 4;
            this.dataRepeater1.Text = "dataRepeater1";
            this.dataRepeater1.DrawItem += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventHandler(this.dataRepeater1_DrawItem);
            // 
            // ucElement1
            //  
            this.ucElement1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucElement1.Location = new System.Drawing.Point(0, 0);
            this.ucElement1.Name = "ucElement1";
            this.ucElement1.Size = new System.Drawing.Size(505, 107);
            this.ucElement1.TabIndex = 0;
            // 
            // elementBindingSource
            // 
            this.elementBindingSource.DataSource = typeof(RepertoryGrid.Model.Element);
            // 
            // ufoElements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 262);
            this.Controls.Add(this.dataRepeater1);
            this.Controls.Add(this.toolStrip3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ufoElements";
            this.Text = "Edit Elements";
            this.ResizeBegin += new System.EventHandler(this.ufoElements_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.ufoElements_ResizeEnd);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.dataRepeater1.ItemTemplate.ResumeLayout(false);
            this.dataRepeater1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.elementBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddElement;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater1;
        private UserControls.UcElement ucElement1;
        private System.Windows.Forms.BindingSource elementBindingSource;
    }
}