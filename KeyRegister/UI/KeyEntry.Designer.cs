namespace KeyRegister.UI
{
    partial class KeyEntry
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
            this.createButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.propertyNameText = new System.Windows.Forms.TextBox();
            this.keyTypeCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.BackColor = System.Drawing.Color.Plum;
            this.createButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.ForeColor = System.Drawing.Color.Blue;
            this.createButton.Location = new System.Drawing.Point(377, 242);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(209, 78);
            this.createButton.TabIndex = 0;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(254, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Key Creation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Property Name ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(109, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "Key Type ";
            // 
            // propertyNameText
            // 
            this.propertyNameText.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertyNameText.Location = new System.Drawing.Point(250, 90);
            this.propertyNameText.Name = "propertyNameText";
            this.propertyNameText.Size = new System.Drawing.Size(423, 41);
            this.propertyNameText.TabIndex = 4;
            // 
            // keyTypeCombo
            // 
            this.keyTypeCombo.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyTypeCombo.FormattingEnabled = true;
            this.keyTypeCombo.Location = new System.Drawing.Point(250, 163);
            this.keyTypeCombo.Name = "keyTypeCombo";
            this.keyTypeCombo.Size = new System.Drawing.Size(423, 40);
            this.keyTypeCombo.TabIndex = 5;
            // 
            // KeyEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 395);
            this.Controls.Add(this.keyTypeCombo);
            this.Controls.Add(this.propertyNameText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createButton);
            this.MaximizeBox = false;
            this.Name = "KeyEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Key Create";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox propertyNameText;
        private System.Windows.Forms.ComboBox keyTypeCombo;
    }
}