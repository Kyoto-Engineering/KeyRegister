namespace KeyRegister.LoginUI
{
    partial class UserManagementUI
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
            this.buttonUserProfile = new System.Windows.Forms.Button();
            this.resetPasswordButton = new System.Windows.Forms.Button();
            this.createUserButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonUpdateUser = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonUpdateUser);
            this.groupBox1.Controls.Add(this.buttonUserProfile);
            this.groupBox1.Controls.Add(this.resetPasswordButton);
            this.groupBox1.Controls.Add(this.createUserButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 472);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // buttonUserProfile
            // 
            this.buttonUserProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonUserProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUserProfile.ForeColor = System.Drawing.Color.Blue;
            this.buttonUserProfile.Location = new System.Drawing.Point(12, 98);
            this.buttonUserProfile.Name = "buttonUserProfile";
            this.buttonUserProfile.Size = new System.Drawing.Size(107, 84);
            this.buttonUserProfile.TabIndex = 2;
            this.buttonUserProfile.Text = "Upload User Profile";
            this.buttonUserProfile.UseVisualStyleBackColor = false;
            this.buttonUserProfile.Click += new System.EventHandler(this.buttonUserProfile_Click);
            // 
            // resetPasswordButton
            // 
            this.resetPasswordButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.resetPasswordButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPasswordButton.ForeColor = System.Drawing.Color.Blue;
            this.resetPasswordButton.Location = new System.Drawing.Point(12, 281);
            this.resetPasswordButton.Name = "resetPasswordButton";
            this.resetPasswordButton.Size = new System.Drawing.Size(107, 72);
            this.resetPasswordButton.TabIndex = 1;
            this.resetPasswordButton.Text = "Reset Password";
            this.resetPasswordButton.UseVisualStyleBackColor = false;
            this.resetPasswordButton.Click += new System.EventHandler(this.resetPasswordButton_Click);
            // 
            // createUserButton
            // 
            this.createUserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.createUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createUserButton.ForeColor = System.Drawing.Color.Blue;
            this.createUserButton.Location = new System.Drawing.Point(12, 16);
            this.createUserButton.Name = "createUserButton";
            this.createUserButton.Size = new System.Drawing.Size(107, 76);
            this.createUserButton.TabIndex = 0;
            this.createUserButton.Text = "Create User";
            this.createUserButton.UseVisualStyleBackColor = false;
            this.createUserButton.Click += new System.EventHandler(this.createUserButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(371, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Management UI";
            // 
            // buttonUpdateUser
            // 
            this.buttonUpdateUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonUpdateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateUser.ForeColor = System.Drawing.Color.Blue;
            this.buttonUpdateUser.Location = new System.Drawing.Point(12, 188);
            this.buttonUpdateUser.Name = "buttonUpdateUser";
            this.buttonUpdateUser.Size = new System.Drawing.Size(107, 77);
            this.buttonUpdateUser.TabIndex = 2;
            this.buttonUpdateUser.Text = "Update  User";
            this.buttonUpdateUser.UseVisualStyleBackColor = false;
            this.buttonUpdateUser.Click += new System.EventHandler(this.buttonUpdateUser_Click);
            // 
            // UserManagementUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(931, 564);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserManagementUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserManagementUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserManagementUI_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button resetPasswordButton;
        private System.Windows.Forms.Button createUserButton;
        private System.Windows.Forms.Button buttonUserProfile;
        private System.Windows.Forms.Button buttonUpdateUser;
    }
}