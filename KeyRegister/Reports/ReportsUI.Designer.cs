namespace KeyRegister.Reports
{
    partial class ReportsUI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TerritoriesListButton = new System.Windows.Forms.Button();
            this.LockerListButton = new System.Windows.Forms.Button();
            this.UserListButton = new System.Windows.Forms.Button();
            this.KeyListButton = new System.Windows.Forms.Button();
            this.ListCOOButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.KeyHolderListButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.KeyHolderListButton);
            this.groupBox1.Controls.Add(this.TerritoriesListButton);
            this.groupBox1.Controls.Add(this.LockerListButton);
            this.groupBox1.Controls.Add(this.UserListButton);
            this.groupBox1.Controls.Add(this.KeyListButton);
            this.groupBox1.Controls.Add(this.ListCOOButton);
            this.groupBox1.Location = new System.Drawing.Point(9, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 392);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // TerritoriesListButton
            // 
            this.TerritoriesListButton.Location = new System.Drawing.Point(417, 38);
            this.TerritoriesListButton.Name = "TerritoriesListButton";
            this.TerritoriesListButton.Size = new System.Drawing.Size(103, 52);
            this.TerritoriesListButton.TabIndex = 4;
            this.TerritoriesListButton.Text = "List of Territories";
            this.TerritoriesListButton.UseVisualStyleBackColor = true;
            this.TerritoriesListButton.Click += new System.EventHandler(this.TerritoriesListButton_Click);
            // 
            // LockerListButton
            // 
            this.LockerListButton.Location = new System.Drawing.Point(307, 37);
            this.LockerListButton.Name = "LockerListButton";
            this.LockerListButton.Size = new System.Drawing.Size(89, 53);
            this.LockerListButton.TabIndex = 3;
            this.LockerListButton.Text = "List of Lockers";
            this.LockerListButton.UseVisualStyleBackColor = true;
            this.LockerListButton.Click += new System.EventHandler(this.LockerListButton_Click);
            // 
            // UserListButton
            // 
            this.UserListButton.Location = new System.Drawing.Point(544, 38);
            this.UserListButton.Name = "UserListButton";
            this.UserListButton.Size = new System.Drawing.Size(98, 53);
            this.UserListButton.TabIndex = 2;
            this.UserListButton.Text = "List of Users";
            this.UserListButton.UseVisualStyleBackColor = true;
            this.UserListButton.Click += new System.EventHandler(this.UserListButton_Click);
            // 
            // KeyListButton
            // 
            this.KeyListButton.Location = new System.Drawing.Point(195, 38);
            this.KeyListButton.Name = "KeyListButton";
            this.KeyListButton.Size = new System.Drawing.Size(91, 53);
            this.KeyListButton.TabIndex = 1;
            this.KeyListButton.Text = "List of Keys";
            this.KeyListButton.UseVisualStyleBackColor = true;
            this.KeyListButton.Click += new System.EventHandler(this.KeyListButton_Click);
            // 
            // ListCOOButton
            // 
            this.ListCOOButton.Location = new System.Drawing.Point(48, 37);
            this.ListCOOButton.Name = "ListCOOButton";
            this.ListCOOButton.Size = new System.Drawing.Size(125, 54);
            this.ListCOOButton.TabIndex = 0;
            this.ListCOOButton.Text = "List of Chief Operating Officer (COO)";
            this.ListCOOButton.UseVisualStyleBackColor = true;
            this.ListCOOButton.Click += new System.EventHandler(this.ListCOOButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(345, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reports UI";
            // 
            // KeyHolderListButton
            // 
            this.KeyHolderListButton.Location = new System.Drawing.Point(662, 38);
            this.KeyHolderListButton.Name = "KeyHolderListButton";
            this.KeyHolderListButton.Size = new System.Drawing.Size(100, 52);
            this.KeyHolderListButton.TabIndex = 5;
            this.KeyHolderListButton.Text = "Key Holder List";
            this.KeyHolderListButton.UseVisualStyleBackColor = true;
            this.KeyHolderListButton.Click += new System.EventHandler(this.KeyHolderListButton_Click);
            // 
            // ReportsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 474);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReportsUI";
            this.Text = "ReportsUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportsUI_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TerritoriesListButton;
        private System.Windows.Forms.Button LockerListButton;
        private System.Windows.Forms.Button UserListButton;
        private System.Windows.Forms.Button KeyListButton;
        private System.Windows.Forms.Button ListCOOButton;
        private System.Windows.Forms.Button KeyHolderListButton;
    }
}