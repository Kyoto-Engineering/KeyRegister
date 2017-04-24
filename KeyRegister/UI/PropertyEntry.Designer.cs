namespace KeyRegister.UI
{
    partial class PropertyEntry
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
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.propertyNameText = new System.Windows.Forms.TextBox();
            this.propertyTypeCombo = new System.Windows.Forms.ComboBox();
            this.locationNameCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Plum;
            this.saveButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.saveButton.Location = new System.Drawing.Point(341, 250);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(182, 71);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(295, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Property Creation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Property Name    :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Property Type     :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Location Name    :";
            // 
            // propertyNameText
            // 
            this.propertyNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertyNameText.Location = new System.Drawing.Point(176, 79);
            this.propertyNameText.Name = "propertyNameText";
            this.propertyNameText.Size = new System.Drawing.Size(393, 24);
            this.propertyNameText.TabIndex = 5;
            // 
            // propertyTypeCombo
            // 
            this.propertyTypeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertyTypeCombo.FormattingEnabled = true;
            this.propertyTypeCombo.Location = new System.Drawing.Point(177, 118);
            this.propertyTypeCombo.Name = "propertyTypeCombo";
            this.propertyTypeCombo.Size = new System.Drawing.Size(392, 26);
            this.propertyTypeCombo.TabIndex = 8;
            // 
            // locationNameCombo
            // 
            this.locationNameCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationNameCombo.FormattingEnabled = true;
            this.locationNameCombo.Location = new System.Drawing.Point(178, 161);
            this.locationNameCombo.Name = "locationNameCombo";
            this.locationNameCombo.Size = new System.Drawing.Size(391, 26);
            this.locationNameCombo.TabIndex = 9;
            // 
            // PropertyEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 412);
            this.Controls.Add(this.locationNameCombo);
            this.Controls.Add(this.propertyTypeCombo);
            this.Controls.Add(this.propertyNameText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Name = "PropertyEntry";
            this.Text = "Property Create";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox propertyNameText;
        private System.Windows.Forms.ComboBox propertyTypeCombo;
        private System.Windows.Forms.ComboBox locationNameCombo;
    }
}