namespace RepertoryGrid
{
    partial class FormEvaluateElements
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
            System.Windows.Forms.Label constructPolLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label nameLabel;
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.dataRepeaterElements = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.RatingelementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucElementConstruct1 = new RepertoryGrid.UcElementConstruct();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dataRepeaterConstructRight = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.RatingconstructBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contrastPolTextBox = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataRepeaterConstructLeft = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.nameTextBox1 = new System.Windows.Forms.TextBox();
            this.constructPolTextBox = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            constructPolLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.dataRepeaterElements.ItemTemplate.SuspendLayout();
            this.dataRepeaterElements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RatingelementBindingSource)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.dataRepeaterConstructRight.ItemTemplate.SuspendLayout();
            this.dataRepeaterConstructRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RatingconstructBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.dataRepeaterConstructLeft.ItemTemplate.SuspendLayout();
            this.dataRepeaterConstructLeft.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // constructPolLabel
            // 
            constructPolLabel.AutoSize = true;
            constructPolLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            constructPolLabel.Location = new System.Drawing.Point(137, 7);
            constructPolLabel.Name = "constructPolLabel";
            constructPolLabel.Size = new System.Drawing.Size(103, 16);
            constructPolLabel.TabIndex = 0;
            constructPolLabel.Text = "Construct Pol:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(16, 7);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(92, 16);
            label1.TabIndex = 1;
            label1.Text = "Contrast Pol";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            nameLabel.Location = new System.Drawing.Point(31, 7);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(53, 16);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Name:";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataRepeaterElements);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitter2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitter1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel8);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel4);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(760, 403);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(760, 428);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // dataRepeaterElements
            // 
            this.dataRepeaterElements.AllowUserToAddItems = false;
            this.dataRepeaterElements.AllowUserToDeleteItems = false;
            this.dataRepeaterElements.DataSource = this.RatingelementBindingSource;
            this.dataRepeaterElements.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // dataRepeaterElements.ItemTemplate
            // 
            this.dataRepeaterElements.ItemTemplate.Controls.Add(this.ucElementConstruct1);
            this.dataRepeaterElements.ItemTemplate.Controls.Add(this.panel6);
            this.dataRepeaterElements.ItemTemplate.Controls.Add(this.panel1);
            this.dataRepeaterElements.ItemTemplate.Size = new System.Drawing.Size(85, 395);
            this.dataRepeaterElements.LayoutStyle = Microsoft.VisualBasic.PowerPacks.DataRepeaterLayoutStyles.Horizontal;
            this.dataRepeaterElements.Location = new System.Drawing.Point(274, 0);
            this.dataRepeaterElements.Name = "dataRepeaterElements";
            this.dataRepeaterElements.Size = new System.Drawing.Size(283, 403);
            this.dataRepeaterElements.TabIndex = 8;
            this.dataRepeaterElements.Text = "Elements";
            this.dataRepeaterElements.CurrentItemIndexChanged += new System.EventHandler(this.dataRepeaterElements_CurrentItemIndexChanged);
            this.dataRepeaterElements.DrawItem += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventHandler(this.dataRepeaterElements_DrawItem);
            // 
            // RatingelementBindingSource
            // 
            this.RatingelementBindingSource.DataSource = typeof(RepertoryGrid.classes.Element);
            // 
            // ucElementConstruct1
            // 
            this.ucElementConstruct1.CurrentElement = null;
            this.ucElementConstruct1.CurrentInterview = null;
            this.ucElementConstruct1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucElementConstruct1.Location = new System.Drawing.Point(0, 32);
            this.ucElementConstruct1.Name = "ucElementConstruct1";
            this.ucElementConstruct1.Size = new System.Drawing.Size(84, 317);
            this.ucElementConstruct1.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.AutoScroll = true;
            this.panel6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel6.Controls.Add(this.textBox1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 349);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(84, 31);
            this.panel6.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.RatingelementBindingSource, "Name", true));
            this.textBox1.Location = new System.Drawing.Point(4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 20);
            this.textBox1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.nameTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(84, 32);
            this.panel1.TabIndex = 3;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.RatingelementBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(3, 6);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(76, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(557, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 403);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(271, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 403);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dataRepeaterConstructRight);
            this.panel8.Controls.Add(this.panel7);
            this.panel8.Controls.Add(this.panel3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(560, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(200, 403);
            this.panel8.TabIndex = 5;
            // 
            // dataRepeaterConstructRight
            // 
            this.dataRepeaterConstructRight.AllowUserToAddItems = false;
            this.dataRepeaterConstructRight.AllowUserToDeleteItems = false;
            this.dataRepeaterConstructRight.DataSource = this.RatingconstructBindingSource;
            this.dataRepeaterConstructRight.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // dataRepeaterConstructRight.ItemTemplate
            // 
            this.dataRepeaterConstructRight.ItemTemplate.Controls.Add(this.contrastPolTextBox);
            this.dataRepeaterConstructRight.ItemTemplate.Size = new System.Drawing.Size(192, 39);
            this.dataRepeaterConstructRight.Location = new System.Drawing.Point(0, 51);
            this.dataRepeaterConstructRight.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.dataRepeaterConstructRight.Name = "dataRepeaterConstructRight";
            this.dataRepeaterConstructRight.Size = new System.Drawing.Size(200, 300);
            this.dataRepeaterConstructRight.TabIndex = 5;
            this.dataRepeaterConstructRight.Text = "dataRepeater1";
            this.dataRepeaterConstructRight.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataRepeaterConstructRight_Scroll);
            // 
            // RatingconstructBindingSource
            // 
            this.RatingconstructBindingSource.DataSource = typeof(RepertoryGrid.classes.Construct);
            this.RatingconstructBindingSource.PositionChanged += new System.EventHandler(this.BindingSource_PositionChanged);
            // 
            // contrastPolTextBox
            // 
            this.contrastPolTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.RatingconstructBindingSource, "ContrastPol", true));
            this.contrastPolTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contrastPolTextBox.Location = new System.Drawing.Point(0, 0);
            this.contrastPolTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.contrastPolTextBox.Multiline = true;
            this.contrastPolTextBox.Name = "contrastPolTextBox";
            this.contrastPolTextBox.Size = new System.Drawing.Size(177, 38);
            this.contrastPolTextBox.TabIndex = 1;
            this.contrastPolTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel7
            // 
            this.panel7.AutoScroll = true;
            this.panel7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 351);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 52);
            this.panel7.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Controls.Add(label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 51);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataRepeaterConstructLeft);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(271, 403);
            this.panel4.TabIndex = 4;
            // 
            // dataRepeaterConstructLeft
            // 
            this.dataRepeaterConstructLeft.AllowUserToAddItems = false;
            this.dataRepeaterConstructLeft.AllowUserToDeleteItems = false;
            this.dataRepeaterConstructLeft.DataSource = this.RatingconstructBindingSource;
            this.dataRepeaterConstructLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // dataRepeaterConstructLeft.ItemTemplate
            // 
            this.dataRepeaterConstructLeft.ItemTemplate.Controls.Add(this.nameTextBox1);
            this.dataRepeaterConstructLeft.ItemTemplate.Controls.Add(this.constructPolTextBox);
            this.dataRepeaterConstructLeft.ItemTemplate.Size = new System.Drawing.Size(263, 39);
            this.dataRepeaterConstructLeft.Location = new System.Drawing.Point(0, 51);
            this.dataRepeaterConstructLeft.Name = "dataRepeaterConstructLeft";
            this.dataRepeaterConstructLeft.Size = new System.Drawing.Size(271, 317);
            this.dataRepeaterConstructLeft.TabIndex = 4;
            this.dataRepeaterConstructLeft.Text = "dataRepeater1";
            this.dataRepeaterConstructLeft.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataRepeaterConstructLeft_Scroll);
            // 
            // nameTextBox1
            // 
            this.nameTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.RatingconstructBindingSource, "Name", true));
            this.nameTextBox1.Location = new System.Drawing.Point(15, 0);
            this.nameTextBox1.Name = "nameTextBox1";
            this.nameTextBox1.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox1.TabIndex = 2;
            // 
            // constructPolTextBox
            // 
            this.constructPolTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.RatingconstructBindingSource, "ConstructPol", true));
            this.constructPolTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.RatingconstructBindingSource, "Id", true));
            this.constructPolTextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.constructPolTextBox.Location = new System.Drawing.Point(121, 0);
            this.constructPolTextBox.Multiline = true;
            this.constructPolTextBox.Name = "constructPolTextBox";
            this.constructPolTextBox.Size = new System.Drawing.Size(127, 38);
            this.constructPolTextBox.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 368);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(271, 35);
            this.panel5.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(nameLabel);
            this.panel2.Controls.Add(constructPolLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 51);
            this.panel2.TabIndex = 2;
            // 
            // FormEvaluateElements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 428);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "FormEvaluateElements";
            this.Text = "Interview";
            this.Activated += new System.EventHandler(this.FormEvaluateElements_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEvaluateElements_FormClosing);
            this.Load += new System.EventHandler(this.FormEvaluateElements_Load);
            this.SizeChanged += new System.EventHandler(this.FormEvaluateElements_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormEvaluateElements_Paint);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.dataRepeaterElements.ItemTemplate.ResumeLayout(false);
            this.dataRepeaterElements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RatingelementBindingSource)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.dataRepeaterConstructRight.ItemTemplate.ResumeLayout(false);
            this.dataRepeaterConstructRight.ItemTemplate.PerformLayout();
            this.dataRepeaterConstructRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RatingconstructBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.dataRepeaterConstructLeft.ItemTemplate.ResumeLayout(false);
            this.dataRepeaterConstructLeft.ItemTemplate.PerformLayout();
            this.dataRepeaterConstructLeft.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeaterElements;
        private System.Windows.Forms.BindingSource RatingelementBindingSource;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel8;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeaterConstructRight;
        private System.Windows.Forms.BindingSource RatingconstructBindingSource;
        private System.Windows.Forms.TextBox contrastPolTextBox;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeaterConstructLeft;
        private System.Windows.Forms.TextBox constructPolTextBox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox nameTextBox;
        private UcElementConstruct ucElementConstruct1;
        private System.Windows.Forms.TextBox nameTextBox1;

    }
}