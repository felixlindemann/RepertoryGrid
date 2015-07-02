namespace RepertoryGridGUI.UserControls
{
    partial class UcConstruct
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
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label remarkLabel1;
            System.Windows.Forms.Label contrastPolLabel;
            System.Windows.Forms.Label constructPolLabel;
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.remarkTextBox1 = new System.Windows.Forms.TextBox();
            this.constructBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.contrastPolTextBox = new System.Windows.Forms.TextBox();
            this.constructPolTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDeleteConstruct = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            nameLabel = new System.Windows.Forms.Label();
            remarkLabel1 = new System.Windows.Forms.Label();
            contrastPolLabel = new System.Windows.Forms.Label();
            constructPolLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.constructBindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            nameLabel.Location = new System.Drawing.Point(3, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(74, 30);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Name:";
            nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // remarkLabel1
            // 
            remarkLabel1.AutoSize = true;
            remarkLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            remarkLabel1.Location = new System.Drawing.Point(3, 60);
            remarkLabel1.Name = "remarkLabel1";
            remarkLabel1.Size = new System.Drawing.Size(74, 52);
            remarkLabel1.TabIndex = 6;
            remarkLabel1.Text = "Remark:";
            remarkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contrastPolLabel
            // 
            contrastPolLabel.AutoSize = true;
            contrastPolLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            contrastPolLabel.Location = new System.Drawing.Point(3, 30);
            contrastPolLabel.Name = "contrastPolLabel";
            contrastPolLabel.Size = new System.Drawing.Size(74, 30);
            contrastPolLabel.TabIndex = 4;
            contrastPolLabel.Text = "Contrast Pol:";
            contrastPolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // constructPolLabel
            // 
            constructPolLabel.AutoSize = true;
            constructPolLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            constructPolLabel.Location = new System.Drawing.Point(237, 30);
            constructPolLabel.Name = "constructPolLabel";
            constructPolLabel.Size = new System.Drawing.Size(74, 30);
            constructPolLabel.TabIndex = 2;
            constructPolLabel.Text = "Construct Pol:";
            constructPolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(nameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.remarkTextBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(remarkLabel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(contrastPolLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.contrastPolTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(constructPolLabel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.constructPolTextBox, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonMoveUp, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonMoveDown, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(628, 112);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // remarkTextBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.remarkTextBox1, 3);
            this.remarkTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.constructBindingSource, "Remark", true));
            this.remarkTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remarkTextBox1.Location = new System.Drawing.Point(83, 63);
            this.remarkTextBox1.Multiline = true;
            this.remarkTextBox1.Name = "remarkTextBox1";
            this.remarkTextBox1.Size = new System.Drawing.Size(382, 46);
            this.remarkTextBox1.TabIndex = 3;
            // 
            // constructBindingSource
            // 
            this.constructBindingSource.DataSource = typeof(RepertoryGrid.Model.Construct);
            // 
            // nameTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.nameTextBox, 3);
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.constructBindingSource, "Name", true));
            this.nameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameTextBox.Location = new System.Drawing.Point(83, 3);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(382, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // contrastPolTextBox
            // 
            this.contrastPolTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.constructBindingSource, "ContrastPol", true));
            this.contrastPolTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contrastPolTextBox.Location = new System.Drawing.Point(83, 33);
            this.contrastPolTextBox.Name = "contrastPolTextBox";
            this.contrastPolTextBox.Size = new System.Drawing.Size(148, 20);
            this.contrastPolTextBox.TabIndex = 2;
            // 
            // constructPolTextBox
            // 
            this.constructPolTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.constructBindingSource, "ConstructPol", true));
            this.constructPolTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.constructPolTextBox.Location = new System.Drawing.Point(317, 33);
            this.constructPolTextBox.Name = "constructPolTextBox";
            this.constructPolTextBox.Size = new System.Drawing.Size(148, 20);
            this.constructPolTextBox.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.Controls.Add(this.buttonDeleteConstruct, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(471, 63);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(154, 46);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // buttonDeleteConstruct
            // 
            this.buttonDeleteConstruct.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.constructBindingSource, "Id", true));
            this.buttonDeleteConstruct.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDeleteConstruct.Image = global::RepertoryGridGUI.Properties.Resources.DeleteHS;
            this.buttonDeleteConstruct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeleteConstruct.Location = new System.Drawing.Point(37, 11);
            this.buttonDeleteConstruct.Name = "buttonDeleteConstruct";
            this.buttonDeleteConstruct.Size = new System.Drawing.Size(114, 24);
            this.buttonDeleteConstruct.TabIndex = 6;
            this.buttonDeleteConstruct.Text = "Delete Construct";
            this.buttonDeleteConstruct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDeleteConstruct.UseVisualStyleBackColor = true;
            this.buttonDeleteConstruct.Click += new System.EventHandler(this.buttonDeleteConstruct_Click);
            // 
            // buttonMoveUp
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonMoveUp, 2);
            this.buttonMoveUp.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.constructBindingSource, "Id", true));
            this.buttonMoveUp.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMoveUp.Image = global::RepertoryGridGUI.Properties.Resources.FillUpHS;
            this.buttonMoveUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMoveUp.Location = new System.Drawing.Point(508, 3);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(117, 24);
            this.buttonMoveUp.TabIndex = 10;
            this.buttonMoveUp.Text = "Move Up";
            this.buttonMoveUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // buttonMoveDown
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonMoveDown, 2);
            this.buttonMoveDown.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.constructBindingSource, "Id", true));
            this.buttonMoveDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMoveDown.Image = global::RepertoryGridGUI.Properties.Resources.FillDownHS;
            this.buttonMoveDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMoveDown.Location = new System.Drawing.Point(508, 33);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(117, 24);
            this.buttonMoveDown.TabIndex = 11;
            this.buttonMoveDown.Text = "Move Down";
            this.buttonMoveDown.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // UcConstruct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UcConstruct";
            this.Size = new System.Drawing.Size(628, 112);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.constructBindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox remarkTextBox1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox contrastPolTextBox;
        private System.Windows.Forms.TextBox constructPolTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonDeleteConstruct;
        public System.Windows.Forms.BindingSource constructBindingSource;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonMoveDown;
    }
}
