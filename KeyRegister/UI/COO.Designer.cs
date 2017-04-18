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
            this.chiefOONameText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.companyNameText = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(277, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chief Operating Officer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chief Operating Officer Name :";
            // 
            // chiefOONameText
            // 
            this.chiefOONameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chiefOONameText.Location = new System.Drawing.Point(252, 80);
            this.chiefOONameText.Name = "chiefOONameText";
            this.chiefOONameText.Size = new System.Drawing.Size(415, 24);
            this.chiefOONameText.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Company Name                      :";
            // 
            // companyNameText
            // 
            this.companyNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyNameText.Location = new System.Drawing.Point(252, 126);
            this.companyNameText.Name = "companyNameText";
            this.companyNameText.Size = new System.Drawing.Size(415, 24);
            this.companyNameText.TabIndex = 4;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Plum;
            this.saveButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.saveButton.Location = new System.Drawing.Point(440, 327);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 44);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            // 
            // COO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 422);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.companyNameText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chiefOONameText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "COO";
            this.Text = "ChiefOperatingOfficerStation ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox chiefOONameText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox companyNameText;
        private System.Windows.Forms.Button saveButton;
    }
}