namespace RepertoryGridGUI
{
    partial class DialogRateElement
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
            System.Windows.Forms.Label contrastPolLabel;
            System.Windows.Forms.Label constructPolLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogRateElement));
            this.scoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            contrastPolLabel = new System.Windows.Forms.Label();
            constructPolLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scoreBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contrastPolLabel
            // 
            contrastPolLabel.AutoSize = true;
            contrastPolLabel.Location = new System.Drawing.Point(109, 9);
            contrastPolLabel.Name = "contrastPolLabel";
            contrastPolLabel.Size = new System.Drawing.Size(67, 13);
            contrastPolLabel.TabIndex = 3;
            contrastPolLabel.Text = "Contrast Pol:";
            // 
            // constructPolLabel
            // 
            constructPolLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            constructPolLabel.AutoSize = true;
            constructPolLabel.Location = new System.Drawing.Point(467, 9);
            constructPolLabel.Name = "constructPolLabel";
            constructPolLabel.Size = new System.Drawing.Size(73, 13);
            constructPolLabel.TabIndex = 4;
            constructPolLabel.Text = "Construct Pol:";
            // 
            // scoreBindingSource
            // 
            this.scoreBindingSource.DataSource = typeof(RepertoryGrid.Model.Score);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scoreBindingSource, "ParentElement.Name", true));
            this.groupBox1.Location = new System.Drawing.Point(182, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 101);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(273, 82);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scoreBindingSource, "ParentConstruct.ContrastPol", true));
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 82);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scoreBindingSource, "ParentConstruct.ConstructPol", true));
            this.label2.Location = new System.Drawing.Point(467, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 82);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DialogRateElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 163);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(constructPolLabel);
            this.Controls.Add(contrastPolLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(685, 201);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(685, 201);
            this.Name = "DialogRateElement";
            this.Text = "Provide Scoring";
            ((System.ComponentModel.ISupportInitialize)(this.scoreBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource scoreBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}