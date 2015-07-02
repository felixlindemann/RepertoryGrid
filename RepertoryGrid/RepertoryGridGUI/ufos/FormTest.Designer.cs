using LimeTree.Gui.Input;
namespace RepertoryGridGUI.ufos
{
    partial class FormTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxFitHeight = new System.Windows.Forms.CheckBox();
            this.checkBoxFitWidth = new System.Windows.Forms.CheckBox();
            this.checkBoxShowBorder = new System.Windows.Forms.CheckBox();
            this.checkBoxDemoModus = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.rotatedTextLabel1 = new RotatedTextLabel();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.checkBoxFitHeight);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxFitWidth);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxShowBorder);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxDemoModus);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 405);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(714, 52);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // checkBoxFitHeight
            // 
            this.checkBoxFitHeight.AutoSize = true;
            this.checkBoxFitHeight.Location = new System.Drawing.Point(3, 3);
            this.checkBoxFitHeight.Name = "checkBoxFitHeight";
            this.checkBoxFitHeight.Size = new System.Drawing.Size(68, 17);
            this.checkBoxFitHeight.TabIndex = 0;
            this.checkBoxFitHeight.Text = "FitHeight";
            this.checkBoxFitHeight.UseVisualStyleBackColor = true;
            // 
            // checkBoxFitWidth
            // 
            this.checkBoxFitWidth.AutoSize = true;
            this.checkBoxFitWidth.Location = new System.Drawing.Point(77, 3);
            this.checkBoxFitWidth.Name = "checkBoxFitWidth";
            this.checkBoxFitWidth.Size = new System.Drawing.Size(65, 17);
            this.checkBoxFitWidth.TabIndex = 1;
            this.checkBoxFitWidth.Text = "FitWidth";
            this.checkBoxFitWidth.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowBorder
            // 
            this.checkBoxShowBorder.AutoSize = true;
            this.checkBoxShowBorder.Checked = true;
            this.checkBoxShowBorder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowBorder.Location = new System.Drawing.Point(148, 3);
            this.checkBoxShowBorder.Name = "checkBoxShowBorder";
            this.checkBoxShowBorder.Size = new System.Drawing.Size(89, 17);
            this.checkBoxShowBorder.TabIndex = 2;
            this.checkBoxShowBorder.Text = "Debugmodus";
            this.checkBoxShowBorder.UseVisualStyleBackColor = true;
            // 
            // checkBoxDemoModus
            // 
            this.checkBoxDemoModus.AutoSize = true;
            this.checkBoxDemoModus.Checked = true;
            this.checkBoxDemoModus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDemoModus.Location = new System.Drawing.Point(243, 3);
            this.checkBoxDemoModus.Name = "checkBoxDemoModus";
            this.checkBoxDemoModus.Size = new System.Drawing.Size(86, 17);
            this.checkBoxDemoModus.TabIndex = 3;
            this.checkBoxDemoModus.Text = "DemoModus";
            this.checkBoxDemoModus.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBar1.Location = new System.Drawing.Point(0, 360);
            this.trackBar1.Maximum = 400;
            this.trackBar1.Minimum = -40;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(714, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.TickFrequency = 5;
            // 
            // rotatedTextLabel1
            // 
            this.rotatedTextLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rotatedTextLabel1.Debugging = true;
            this.rotatedTextLabel1.DemoBoxSize = new System.Drawing.SizeF(100F, 300F);
            this.rotatedTextLabel1.DemoModus = true;
            this.rotatedTextLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rotatedTextLabel1.FitHeight = false;
            this.rotatedTextLabel1.FitWidth = false;
            this.rotatedTextLabel1.Location = new System.Drawing.Point(0, 0);
            this.rotatedTextLabel1.Margin = new System.Windows.Forms.Padding(3);
            this.rotatedTextLabel1.Name = "rotatedTextLabel1";
            this.rotatedTextLabel1.Padding = new System.Windows.Forms.Padding(3);
            this.rotatedTextLabel1.RotatedAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rotatedTextLabel1.RotationAngle = 90D;
            this.rotatedTextLabel1.Size = new System.Drawing.Size(714, 360);
            this.rotatedTextLabel1.TabIndex = 5;
            this.rotatedTextLabel1.Text = resources.GetString("rotatedTextLabel1.Text");
            this.rotatedTextLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 457);
            this.Controls.Add(this.rotatedTextLabel1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FormTest";
            this.Text = "test";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxFitHeight;
        private System.Windows.Forms.CheckBox checkBoxFitWidth;
        private System.Windows.Forms.CheckBox checkBoxShowBorder;
        private System.Windows.Forms.TrackBar trackBar1;
        private RotatedTextLabel rotatedTextLabel1;
        private System.Windows.Forms.CheckBox checkBoxDemoModus;



    }
}