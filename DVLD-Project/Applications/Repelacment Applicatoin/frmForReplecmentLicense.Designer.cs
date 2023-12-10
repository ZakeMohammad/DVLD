namespace DVLD_Project
{
    partial class frmForReplecmentLicense
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.TxtLicenseID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RDForLost = new System.Windows.Forms.RadioButton();
            this.RDForDamaged = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.LinkFOrLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.linkForHistoryLicenses = new System.Windows.Forms.LinkLabel();
            this.ctrlApplicationForReplecment1 = new DVLD_Project.ctrlApplicationForReplecment();
            this.ctrlDriverLicenseInformation1 = new DVLD_Project.ctrlDriverLicenseInformation();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.TxtLicenseID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(539, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(820, 103);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fillter";
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::DVLD_Project.Properties.Resources.id__1_1;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(445, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(73, 43);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // TxtLicenseID
            // 
            this.TxtLicenseID.Location = new System.Drawing.Point(155, 45);
            this.TxtLicenseID.Name = "TxtLicenseID";
            this.TxtLicenseID.Size = new System.Drawing.Size(272, 27);
            this.TxtLicenseID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Licesne ID :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(721, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 38);
            this.label1.TabIndex = 52;
            this.label1.Text = "Replacement Licenses";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RDForLost);
            this.groupBox2.Controls.Add(this.RDForDamaged);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1410, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 124);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Replacement For:";
            // 
            // RDForLost
            // 
            this.RDForLost.AutoSize = true;
            this.RDForLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDForLost.Location = new System.Drawing.Point(33, 74);
            this.RDForLost.Name = "RDForLost";
            this.RDForLost.Size = new System.Drawing.Size(132, 26);
            this.RDForLost.TabIndex = 1;
            this.RDForLost.TabStop = true;
            this.RDForLost.Text = "Lost License";
            this.RDForLost.UseVisualStyleBackColor = true;
            this.RDForLost.CheckedChanged += new System.EventHandler(this.RDForLost_CheckedChanged);
            // 
            // RDForDamaged
            // 
            this.RDForDamaged.AutoSize = true;
            this.RDForDamaged.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDForDamaged.Location = new System.Drawing.Point(33, 37);
            this.RDForDamaged.Name = "RDForDamaged";
            this.RDForDamaged.Size = new System.Drawing.Size(175, 26);
            this.RDForDamaged.TabIndex = 0;
            this.RDForDamaged.TabStop = true;
            this.RDForDamaged.Text = "Damaged License";
            this.RDForDamaged.UseVisualStyleBackColor = true;
            this.RDForDamaged.CheckedChanged += new System.EventHandler(this.RDForDamaged_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_Project.Properties.Resources.cancel__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1195, 746);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 40);
            this.btnClose.TabIndex = 56;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_Project.Properties.Resources.floppy_disk__3_;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1352, 746);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 40);
            this.btnSave.TabIndex = 55;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // LinkFOrLicenseInfo
            // 
            this.LinkFOrLicenseInfo.AutoSize = true;
            this.LinkFOrLicenseInfo.Location = new System.Drawing.Point(725, 770);
            this.LinkFOrLicenseInfo.Name = "LinkFOrLicenseInfo";
            this.LinkFOrLicenseInfo.Size = new System.Drawing.Size(114, 16);
            this.LinkFOrLicenseInfo.TabIndex = 57;
            this.LinkFOrLicenseInfo.TabStop = true;
            this.LinkFOrLicenseInfo.Text = "Show License Info";
            this.LinkFOrLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkFOrLicenseInfo_LinkClicked);
            // 
            // linkForHistoryLicenses
            // 
            this.linkForHistoryLicenses.AutoSize = true;
            this.linkForHistoryLicenses.Location = new System.Drawing.Point(553, 770);
            this.linkForHistoryLicenses.Name = "linkForHistoryLicenses";
            this.linkForHistoryLicenses.Size = new System.Drawing.Size(135, 16);
            this.linkForHistoryLicenses.TabIndex = 58;
            this.linkForHistoryLicenses.TabStop = true;
            this.linkForHistoryLicenses.Text = "Show License History";
            this.linkForHistoryLicenses.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkForHistoryLicenses_LinkClicked);
            // 
            // ctrlApplicationForReplecment1
            // 
            this.ctrlApplicationForReplecment1.BackColor = System.Drawing.Color.White;
            this.ctrlApplicationForReplecment1.Location = new System.Drawing.Point(814, 224);
            this.ctrlApplicationForReplecment1.Name = "ctrlApplicationForReplecment1";
            this.ctrlApplicationForReplecment1.Size = new System.Drawing.Size(933, 226);
            this.ctrlApplicationForReplecment1.TabIndex = 59;
            // 
            // ctrlDriverLicenseInformation1
            // 
            this.ctrlDriverLicenseInformation1.BackColor = System.Drawing.Color.White;
            this.ctrlDriverLicenseInformation1.Location = new System.Drawing.Point(0, 224);
            this.ctrlDriverLicenseInformation1.Name = "ctrlDriverLicenseInformation1";
            this.ctrlDriverLicenseInformation1.Size = new System.Drawing.Size(786, 518);
            this.ctrlDriverLicenseInformation1.TabIndex = 54;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.logout__1_;
            this.pictureBox1.Location = new System.Drawing.Point(1752, 729);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmForReplecmentLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1834, 819);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ctrlApplicationForReplecment1);
            this.Controls.Add(this.linkForHistoryLicenses);
            this.Controls.Add(this.LinkFOrLicenseInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctrlDriverLicenseInformation1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmForReplecmentLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replecment License";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmForReplecmentLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox TxtLicenseID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RDForLost;
        private System.Windows.Forms.RadioButton RDForDamaged;
        private ctrlDriverLicenseInformation ctrlDriverLicenseInformation1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel LinkFOrLicenseInfo;
        private System.Windows.Forms.LinkLabel linkForHistoryLicenses;
        private ctrlApplicationForReplecment ctrlApplicationForReplecment1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}