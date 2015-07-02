namespace RepertoryGridGUI.UserControls
{
    partial class UcElement
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.elementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDeleteElement = new System.Windows.Forms.Button();
            this.buttonMoveLeft = new System.Windows.Forms.Button();
            this.buttonMoveRight = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementBindingSource)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Location = new System.Drawing.Point(3, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(74, 30);
            label3.TabIndex = 1;
            label3.Text = "Name:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = System.Windows.Forms.DockStyle.Fill;
            label4.Location = new System.Drawing.Point(3, 60);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(74, 60);
            label4.TabIndex = 6;
            label4.Text = "Remark:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel3.Controls.Add(label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox2, 1, 2);
            this.tableLayoutPanel3.Controls.Add(label4, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.textBox3, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 4, 2);
            this.tableLayoutPanel3.Controls.Add(this.buttonMoveLeft, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonMoveRight, 4, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(579, 120);
            this.tableLayoutPanel3.TabIndex = 23;
            // 
            // textBox2
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.textBox2, 3);
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.elementBindingSource, "Remark", true));
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(83, 63);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(332, 54);
            this.textBox2.TabIndex = 3;
            // 
            // elementBindingSource
            // 
            this.elementBindingSource.DataSource = typeof(RepertoryGrid.Model.Element);
            // 
            // textBox3
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.textBox3, 3);
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.elementBindingSource, "Name", true));
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(83, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(332, 20);
            this.textBox3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel3.SetColumnSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.buttonDeleteElement, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(421, 63);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(155, 54);
            this.tableLayoutPanel4.TabIndex = 9;
            // 
            // buttonDeleteElement
            // 
            this.buttonDeleteElement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteElement.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.elementBindingSource, "Id", true));
            this.buttonDeleteElement.Image = global::RepertoryGridGUI.Properties.Resources.DeleteHS;
            this.buttonDeleteElement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeleteElement.Location = new System.Drawing.Point(38, 3);
            this.buttonDeleteElement.Name = "buttonDeleteElement";
            this.buttonDeleteElement.Size = new System.Drawing.Size(114, 24);
            this.buttonDeleteElement.TabIndex = 19;
            this.buttonDeleteElement.Text = "Delete Element";
            this.buttonDeleteElement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDeleteElement.UseVisualStyleBackColor = true;
            this.buttonDeleteElement.Click += new System.EventHandler(this.buttonDeleteElement_Click);
            // 
            // buttonMoveLeft
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.buttonMoveLeft, 2);
            this.buttonMoveLeft.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.elementBindingSource, "Id", true));
            this.buttonMoveLeft.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMoveLeft.Image = global::RepertoryGridGUI.Properties.Resources.FillLeftHS;
            this.buttonMoveLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMoveLeft.Location = new System.Drawing.Point(459, 3);
            this.buttonMoveLeft.Name = "buttonMoveLeft";
            this.buttonMoveLeft.Size = new System.Drawing.Size(117, 24);
            this.buttonMoveLeft.TabIndex = 10;
            this.buttonMoveLeft.Text = "Move Left";
            this.buttonMoveLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonMoveLeft.UseVisualStyleBackColor = true;
            this.buttonMoveLeft.Click += new System.EventHandler(this.buttonMoveLeft_Click);
            // 
            // buttonMoveRight
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.buttonMoveRight, 2);
            this.buttonMoveRight.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.elementBindingSource, "Id", true));
            this.buttonMoveRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMoveRight.Image = global::RepertoryGridGUI.Properties.Resources.FillRightHS;
            this.buttonMoveRight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMoveRight.Location = new System.Drawing.Point(459, 33);
            this.buttonMoveRight.Name = "buttonMoveRight";
            this.buttonMoveRight.Size = new System.Drawing.Size(117, 24);
            this.buttonMoveRight.TabIndex = 11;
            this.buttonMoveRight.Text = "MoveRight";
            this.buttonMoveRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonMoveRight.UseVisualStyleBackColor = true;
            this.buttonMoveRight.Click += new System.EventHandler(this.buttonMoveRight_Click);
            // 
            // UcElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "UcElement";
            this.Size = new System.Drawing.Size(579, 120);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementBindingSource)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button buttonDeleteElement;
        private System.Windows.Forms.Button buttonMoveLeft;
        private System.Windows.Forms.Button buttonMoveRight;
        private System.Windows.Forms.BindingSource elementBindingSource;
    }
}
