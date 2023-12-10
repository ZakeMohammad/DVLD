namespace DVLD_Project
{
    partial class frmIntrnationlLicenseInfo
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
            this.ctrlIntrnationalLicenseInfo1 = new DVLD_Project.ctrlIntrnationalLicenseInfo();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlIntrnationalLicenseInfo1
            // 
            this.ctrlIntrnationalLicenseInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlIntrnationalLicenseInfo1.Location = new System.Drawing.Point(18, 37);
            this.ctrlIntrnationalLicenseInfo1.Name = "ctrlIntrnationalLicenseInfo1";
            this.ctrlIntrnationalLicenseInfo1.Size = new System.Drawing.Size(959, 408);
            this.ctrlIntrnationalLicenseInfo1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_Project.Properties.Resources.cancel__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(410, 479);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 40);
            this.btnClose.TabIndex = 41;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmIntrnationlLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(989, 544);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlIntrnationalLicenseInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmIntrnationlLicenseInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Intrnationl License Info";
            this.Load += new System.EventHandler(this.frmIntrnationlLicenseInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlIntrnationalLicenseInfo ctrlIntrnationalLicenseInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}