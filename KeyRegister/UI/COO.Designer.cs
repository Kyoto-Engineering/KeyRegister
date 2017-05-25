namespace KeyRegister.UI
{
    partial class COO
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cmbUserName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJoiningDate = new System.Windows.Forms.DateTimePicker();
            this.cmbCompanyName = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(276, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chief Operating Officer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(337, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chief Operating Officer Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(159, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Company Name :";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Plum;
            this.saveButton.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.Blue;
            this.saveButton.Location = new System.Drawing.Point(623, 307);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(132, 60);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cmbUserName
            // 
            this.cmbUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUserName.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUserName.FormattingEnabled = true;
            this.cmbUserName.Location = new System.Drawing.Point(355, 113);
            this.cmbUserName.Name = "cmbUserName";
            this.cmbUserName.Size = new System.Drawing.Size(342, 39);
            this.cmbUserName.TabIndex = 6;
            this.cmbUserName.SelectedIndexChanged += new System.EventHandler(this.cmbUserName_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(196, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Joining Date:";
            // 
            // txtJoiningDate
            // 
            this.txtJoiningDate.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJoiningDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtJoiningDate.Location = new System.Drawing.Point(355, 219);
            this.txtJoiningDate.Name = "txtJoiningDate";
            this.txtJoiningDate.Size = new System.Drawing.Size(342, 39);
            this.txtJoiningDate.TabIndex = 8;
            // 
            // cmbCompanyName
            // 
            this.cmbCompanyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCompanyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCompanyName.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompanyName.FormattingEnabled = true;
            this.cmbCompanyName.Location = new System.Drawing.Point(355, 167);
            this.cmbCompanyName.Name = "cmbCompanyName";
            this.cmbCompanyName.Size = new System.Drawing.Size(342, 39);
            this.cmbCompanyName.TabIndex = 9;
            this.cmbCompanyName.SelectedIndexChanged += new System.EventHandler(this.cmbCompanyName_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(717, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(537, 161);
            this.dataGridView1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(718, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(275, 37);
            this.label5.TabIndex = 11;
            this.label5.Text = "COO Information";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "COOId";
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "COOName";
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "CompanyName";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // COO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(1266, 451);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmbCompanyName);
            this.Controls.Add(this.txtJoiningDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbUserName);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "COO";
            this.Text = "ChiefOperatingOfficerStation ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.COO_FormClosed);
            this.Load += new System.EventHandler(this.COO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox cmbUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtJoiningDate;
        private System.Windows.Forms.ComboBox cmbCompanyName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label5;
    }
}