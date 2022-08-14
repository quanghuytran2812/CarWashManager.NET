namespace CarWashManagementSystem
{
    partial class Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddVT = new System.Windows.Forms.Button();
            this.txtSearchVT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dvgVehicleType = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddCostofGood = new System.Windows.Forms.Button();
            this.txtSearchCostG = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dvgCostofGoodSold = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditCofG = new System.Windows.Forms.DataGridViewImageColumn();
            this.DeleteCofG = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtComAddress = new System.Windows.Forms.TextBox();
            this.txtComName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgVehicleType)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCostofGoodSold)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 33);
            this.panel1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(945, 396);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.dvgVehicleType);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(937, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vehicle Type";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Controls.Add(this.btnAddVT);
            this.panel2.Controls.Add(this.txtSearchVT);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 260);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(931, 95);
            this.panel2.TabIndex = 4;
            // 
            // btnAddVT
            // 
            this.btnAddVT.FlatAppearance.BorderSize = 0;
            this.btnAddVT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVT.Image = ((System.Drawing.Image)(resources.GetObject("btnAddVT.Image")));
            this.btnAddVT.Location = new System.Drawing.Point(866, 21);
            this.btnAddVT.Name = "btnAddVT";
            this.btnAddVT.Size = new System.Drawing.Size(60, 60);
            this.btnAddVT.TabIndex = 2;
            this.btnAddVT.UseVisualStyleBackColor = true;
            this.btnAddVT.Click += new System.EventHandler(this.btnAddVT_Click);
            // 
            // txtSearchVT
            // 
            this.txtSearchVT.Location = new System.Drawing.Point(95, 36);
            this.txtSearchVT.Name = "txtSearchVT";
            this.txtSearchVT.Size = new System.Drawing.Size(193, 34);
            this.txtSearchVT.TabIndex = 1;
            this.txtSearchVT.TextChanged += new System.EventHandler(this.txtSearchVT_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // dvgVehicleType
            // 
            this.dvgVehicleType.AllowUserToAddRows = false;
            this.dvgVehicleType.AllowUserToDeleteRows = false;
            this.dvgVehicleType.AllowUserToResizeColumns = false;
            this.dvgVehicleType.AllowUserToResizeRows = false;
            this.dvgVehicleType.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dvgVehicleType.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgVehicleType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgVehicleType.ColumnHeadersHeight = 35;
            this.dvgVehicleType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dvgVehicleType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Edit,
            this.Delete});
            this.dvgVehicleType.Dock = System.Windows.Forms.DockStyle.Top;
            this.dvgVehicleType.EnableHeadersVisualStyles = false;
            this.dvgVehicleType.Location = new System.Drawing.Point(3, 3);
            this.dvgVehicleType.Name = "dvgVehicleType";
            this.dvgVehicleType.RowHeadersVisible = false;
            this.dvgVehicleType.RowTemplate.Height = 28;
            this.dvgVehicleType.Size = new System.Drawing.Size(931, 263);
            this.dvgVehicleType.TabIndex = 1;
            this.dvgVehicleType.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgVehicleType_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "No";
            this.Column1.Name = "Column1";
            this.Column1.Width = 76;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "Id";
            this.Column2.Name = "Column2";
            this.Column2.Width = 67;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Name";
            this.Column3.Name = "Column3";
            this.Column3.Width = 113;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Level";
            this.Column4.Name = "Column4";
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Edit.HeaderText = "";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.Name = "Edit";
            this.Edit.Width = 5;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Delete.HeaderText = "";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Name = "Delete";
            this.Delete.Width = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.dvgCostofGoodSold);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(937, 358);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cost of Good  Sold";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Controls.Add(this.btnAddCostofGood);
            this.panel3.Controls.Add(this.txtSearchCostG);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 263);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(931, 92);
            this.panel3.TabIndex = 7;
            // 
            // btnAddCostofGood
            // 
            this.btnAddCostofGood.FlatAppearance.BorderSize = 0;
            this.btnAddCostofGood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCostofGood.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCostofGood.Image")));
            this.btnAddCostofGood.Location = new System.Drawing.Point(866, 21);
            this.btnAddCostofGood.Name = "btnAddCostofGood";
            this.btnAddCostofGood.Size = new System.Drawing.Size(60, 60);
            this.btnAddCostofGood.TabIndex = 2;
            this.btnAddCostofGood.UseVisualStyleBackColor = true;
            this.btnAddCostofGood.Click += new System.EventHandler(this.btnAddCostofGood_Click_1);
            // 
            // txtSearchCostG
            // 
            this.txtSearchCostG.Location = new System.Drawing.Point(95, 36);
            this.txtSearchCostG.Name = "txtSearchCostG";
            this.txtSearchCostG.Size = new System.Drawing.Size(193, 34);
            this.txtSearchCostG.TabIndex = 1;
            this.txtSearchCostG.TextChanged += new System.EventHandler(this.txtSearchCostG_TextChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search";
            // 
            // dvgCostofGoodSold
            // 
            this.dvgCostofGoodSold.AllowUserToAddRows = false;
            this.dvgCostofGoodSold.AllowUserToDeleteRows = false;
            this.dvgCostofGoodSold.AllowUserToResizeColumns = false;
            this.dvgCostofGoodSold.AllowUserToResizeRows = false;
            this.dvgCostofGoodSold.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dvgCostofGoodSold.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgCostofGoodSold.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dvgCostofGoodSold.ColumnHeadersHeight = 35;
            this.dvgCostofGoodSold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dvgCostofGoodSold.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.Column5,
            this.EditCofG,
            this.DeleteCofG});
            this.dvgCostofGoodSold.Dock = System.Windows.Forms.DockStyle.Top;
            this.dvgCostofGoodSold.EnableHeadersVisualStyles = false;
            this.dvgCostofGoodSold.Location = new System.Drawing.Point(3, 3);
            this.dvgCostofGoodSold.Name = "dvgCostofGoodSold";
            this.dvgCostofGoodSold.RowHeadersVisible = false;
            this.dvgCostofGoodSold.RowTemplate.Height = 28;
            this.dvgCostofGoodSold.Size = new System.Drawing.Size(931, 352);
            this.dvgCostofGoodSold.TabIndex = 6;
            this.dvgCostofGoodSold.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgCostofGoodSold_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 76;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Id";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 67;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn4.HeaderText = "Cost";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 95;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "Date";
            this.Column5.Name = "Column5";
            this.Column5.Width = 99;
            // 
            // EditCofG
            // 
            this.EditCofG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EditCofG.HeaderText = "";
            this.EditCofG.Image = ((System.Drawing.Image)(resources.GetObject("EditCofG.Image")));
            this.EditCofG.Name = "EditCofG";
            this.EditCofG.Width = 5;
            // 
            // DeleteCofG
            // 
            this.DeleteCofG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DeleteCofG.HeaderText = "";
            this.DeleteCofG.Image = ((System.Drawing.Image)(resources.GetObject("DeleteCofG.Image")));
            this.DeleteCofG.Name = "DeleteCofG";
            this.DeleteCofG.Width = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnCancel);
            this.tabPage3.Controls.Add(this.btnSave);
            this.tabPage3.Controls.Add(this.txtComAddress);
            this.tabPage3.Controls.Add(this.txtComName);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(937, 363);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Company Name";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Location = new System.Drawing.Point(687, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(148, 45);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(506, 243);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 45);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtComAddress
            // 
            this.txtComAddress.Location = new System.Drawing.Point(348, 170);
            this.txtComAddress.Name = "txtComAddress";
            this.txtComAddress.Size = new System.Drawing.Size(504, 34);
            this.txtComAddress.TabIndex = 1;
            // 
            // txtComName
            // 
            this.txtComName.Location = new System.Drawing.Point(348, 111);
            this.txtComName.Name = "txtComName";
            this.txtComName.Size = new System.Drawing.Size(504, 34);
            this.txtComName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Company Address: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Company Name: ";
            // 
            // Setting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(945, 429);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Setting";
            this.Text = "Setting";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgVehicleType)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCostofGoodSold)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dvgVehicleType;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddVT;
        private System.Windows.Forms.TextBox txtSearchVT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridView dvgCostofGoodSold;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewImageColumn EditCofG;
        private System.Windows.Forms.DataGridViewImageColumn DeleteCofG;
        private System.Windows.Forms.TextBox txtComAddress;
        private System.Windows.Forms.TextBox txtComName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAddCostofGood;
        private System.Windows.Forms.TextBox txtSearchCostG;
        private System.Windows.Forms.Label label2;
    }
}