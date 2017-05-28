namespace KeyRegister.UI
{
    partial class LocationManagementUI
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
            this.buttonLocationAllocation = new System.Windows.Forms.Button();
            this.buttonLocationInChargeCreation = new System.Windows.Forms.Button();
            this.locationCreationButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonLocationAllocation);
            this.groupBox1.Controls.Add(this.buttonLocationInChargeCreation);
            this.groupBox1.Controls.Add(this.locationCreationButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 553);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // buttonLocationAllocation
            // 
            this.buttonLocationAllocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonLocationAllocation.ForeColor = System.Drawing.Color.Blue;
            this.buttonLocationAllocation.Location = new System.Drawing.Point(6, 181);
            this.buttonLocationAllocation.Name = "buttonLocationAllocation";
            this.buttonLocationAllocation.Size = new System.Drawing.Size(134, 68);
            this.buttonLocationAllocation.TabIndex = 2;
            this.buttonLocationAllocation.Text = "Location   Allocation";
            this.buttonLocationAllocation.UseVisualStyleBackColor = false;
            this.buttonLocationAllocation.Click += new System.EventHandler(this.buttonLocationAllocation_Click);
            // 
            // buttonLocationInChargeCreation
            // 
            this.buttonLocationInChargeCreation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonLocationInChargeCreation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLocationInChargeCreation.ForeColor = System.Drawing.Color.Blue;
            this.buttonLocationInChargeCreation.Location = new System.Drawing.Point(6, 82);
            this.buttonLocationInChargeCreation.Name = "buttonLocationInChargeCreation";
            this.buttonLocationInChargeCreation.Size = new System.Drawing.Size(134, 82);
            this.buttonLocationInChargeCreation.TabIndex = 1;
            this.buttonLocationInChargeCreation.Text = "Location InCharge  Creation";
            this.buttonLocationInChargeCreation.UseVisualStyleBackColor = false;
            this.buttonLocationInChargeCreation.Click += new System.EventHandler(this.buttonLocationInChargeCreation_Click);
            // 
            // locationCreationButton
            // 
            this.locationCreationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.locationCreationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationCreationButton.ForeColor = System.Drawing.Color.Blue;
            this.locationCreationButton.Location = new System.Drawing.Point(6, 18);
            this.locationCreationButton.Name = "locationCreationButton";
            this.locationCreationButton.Size = new System.Drawing.Size(133, 53);
            this.locationCreationButton.TabIndex = 0;
            this.locationCreationButton.Text = "Location Creation";
            this.locationCreationButton.UseVisualStyleBackColor = false;
            this.locationCreationButton.Click += new System.EventHandler(this.locationCreationButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(344, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Location Management UI";
            // 
            // LocationManagementUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "LocationManagementUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LocationManagementUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LocationManagementUI_FormClosed);
            this.Load += new System.EventHandler(this.LocationManagementUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonLocationAllocation;
        private System.Windows.Forms.Button buttonLocationInChargeCreation;
        private System.Windows.Forms.Button locationCreationButton;
        private System.Windows.Forms.Label label1;
    }
}