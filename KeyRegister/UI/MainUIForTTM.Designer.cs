namespace KeyRegister.UI
{
    partial class MainUIForTTM
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
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.userManagementButton = new System.Windows.Forms.Button();
            this.buttonPropertyCreation = new System.Windows.Forms.Button();
            this.buttonKeyAllocation = new System.Windows.Forms.Button();
            this.buttonKeyCreation = new System.Windows.Forms.Button();
            this.buttonLockCreation = new System.Windows.Forms.Button();
            this.buttonLocationCreation = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(379, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Key Register System";
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonLogOut.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonLogOut.Location = new System.Drawing.Point(913, 2);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(97, 51);
            this.buttonLogOut.TabIndex = 3;
            this.buttonLogOut.Text = "Log Out";
            this.buttonLogOut.UseVisualStyleBackColor = false;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.groupBox1.Controls.Add(this.userManagementButton);
            this.groupBox1.Controls.Add(this.buttonPropertyCreation);
            this.groupBox1.Controls.Add(this.buttonKeyAllocation);
            this.groupBox1.Controls.Add(this.buttonKeyCreation);
            this.groupBox1.Controls.Add(this.buttonLockCreation);
            this.groupBox1.Controls.Add(this.buttonLocationCreation);
            this.groupBox1.Location = new System.Drawing.Point(18, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 518);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // userManagementButton
            // 
            this.userManagementButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.userManagementButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userManagementButton.ForeColor = System.Drawing.Color.Blue;
            this.userManagementButton.Location = new System.Drawing.Point(6, 403);
            this.userManagementButton.Name = "userManagementButton";
            this.userManagementButton.Size = new System.Drawing.Size(143, 59);
            this.userManagementButton.TabIndex = 10;
            this.userManagementButton.Text = "User Management ";
            this.userManagementButton.UseVisualStyleBackColor = false;
            // 
            // buttonPropertyCreation
            // 
            this.buttonPropertyCreation.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPropertyCreation.ForeColor = System.Drawing.Color.Blue;
            this.buttonPropertyCreation.Location = new System.Drawing.Point(8, 89);
            this.buttonPropertyCreation.Name = "buttonPropertyCreation";
            this.buttonPropertyCreation.Size = new System.Drawing.Size(141, 56);
            this.buttonPropertyCreation.TabIndex = 6;
            this.buttonPropertyCreation.Text = "Property Creation";
            this.buttonPropertyCreation.UseVisualStyleBackColor = true;
            this.buttonPropertyCreation.Click += new System.EventHandler(this.buttonPropertyCreation_Click);
            // 
            // buttonKeyAllocation
            // 
            this.buttonKeyAllocation.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeyAllocation.ForeColor = System.Drawing.Color.Blue;
            this.buttonKeyAllocation.Location = new System.Drawing.Point(11, 311);
            this.buttonKeyAllocation.Name = "buttonKeyAllocation";
            this.buttonKeyAllocation.Size = new System.Drawing.Size(143, 55);
            this.buttonKeyAllocation.TabIndex = 8;
            this.buttonKeyAllocation.Text = "Key Allocation";
            this.buttonKeyAllocation.UseVisualStyleBackColor = true;
            // 
            // buttonKeyCreation
            // 
            this.buttonKeyCreation.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeyCreation.ForeColor = System.Drawing.Color.Blue;
            this.buttonKeyCreation.Location = new System.Drawing.Point(6, 219);
            this.buttonKeyCreation.Name = "buttonKeyCreation";
            this.buttonKeyCreation.Size = new System.Drawing.Size(141, 46);
            this.buttonKeyCreation.TabIndex = 7;
            this.buttonKeyCreation.Text = "Key Creation";
            this.buttonKeyCreation.UseVisualStyleBackColor = true;
            this.buttonKeyCreation.Click += new System.EventHandler(this.buttonKeyCreation_Click);
            // 
            // buttonLockCreation
            // 
            this.buttonLockCreation.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLockCreation.ForeColor = System.Drawing.Color.Blue;
            this.buttonLockCreation.Location = new System.Drawing.Point(8, 155);
            this.buttonLockCreation.Name = "buttonLockCreation";
            this.buttonLockCreation.Size = new System.Drawing.Size(141, 52);
            this.buttonLockCreation.TabIndex = 5;
            this.buttonLockCreation.Text = "Lock Creation";
            this.buttonLockCreation.UseVisualStyleBackColor = true;
            this.buttonLockCreation.Click += new System.EventHandler(this.buttonLockCreation_Click);
            // 
            // buttonLocationCreation
            // 
            this.buttonLocationCreation.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLocationCreation.ForeColor = System.Drawing.Color.Blue;
            this.buttonLocationCreation.Location = new System.Drawing.Point(11, 17);
            this.buttonLocationCreation.Name = "buttonLocationCreation";
            this.buttonLocationCreation.Size = new System.Drawing.Size(138, 61);
            this.buttonLocationCreation.TabIndex = 3;
            this.buttonLocationCreation.Text = "Location Management";
            this.buttonLocationCreation.UseVisualStyleBackColor = true;
            this.buttonLocationCreation.Click += new System.EventHandler(this.buttonLocationCreation_Click);
            // 
            // MainUIForTTM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 620);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MainUIForTTM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainUIForTTM";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button userManagementButton;
        private System.Windows.Forms.Button buttonPropertyCreation;
        private System.Windows.Forms.Button buttonKeyAllocation;
        private System.Windows.Forms.Button buttonKeyCreation;
        private System.Windows.Forms.Button buttonLockCreation;
        private System.Windows.Forms.Button buttonLocationCreation;
    }
}