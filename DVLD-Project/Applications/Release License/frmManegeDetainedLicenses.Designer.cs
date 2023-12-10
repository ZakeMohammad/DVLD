namespace DVLD_Project
{
    partial class frmManegeDetainedLicenses
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboForStatus = new System.Windows.Forms.ComboBox();
            this.lblNumberOfRows = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtSearchForFillter = new System.Windows.Forms.TextBox();
            this.ComboBoxForFillter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DataGridViewForDetainedLicesns = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetalisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetalisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReleaseDetainedLicesse = new System.Windows.Forms.Button();
            this.btnDetainedLicense = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewForDetainedLicesns)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(596, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "List Detained Licenses";
            // 
            // ComboForStatus
            // 
            this.ComboForStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboForStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboForStatus.FormattingEnabled = true;
            this.ComboForStatus.ItemHeight = 20;
            this.ComboForStatus.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.ComboForStatus.Location = new System.Drawing.Point(291, 408);
            this.ComboForStatus.Name = "ComboForStatus";
            this.ComboForStatus.Size = new System.Drawing.Size(159, 28);
            this.ComboForStatus.TabIndex = 70;
            this.ComboForStatus.SelectedIndexChanged += new System.EventHandler(this.ComboForStatus_SelectedIndexChanged);
            // 
            // lblNumberOfRows
            // 
            this.lblNumberOfRows.AutoSize = true;
            this.lblNumberOfRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRows.Location = new System.Drawing.Point(128, 715);
            this.lblNumberOfRows.Name = "lblNumberOfRows";
            this.lblNumberOfRows.Size = new System.Drawing.Size(21, 22);
            this.lblNumberOfRows.TabIndex = 69;
            this.lblNumberOfRows.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 715);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 22);
            this.label3.TabIndex = 68;
            this.label3.Text = "# Records";
            // 
            // TxtSearchForFillter
            // 
            this.TxtSearchForFillter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSearchForFillter.Location = new System.Drawing.Point(291, 408);
            this.TxtSearchForFillter.Name = "TxtSearchForFillter";
            this.TxtSearchForFillter.Size = new System.Drawing.Size(235, 27);
            this.TxtSearchForFillter.TabIndex = 67;
            this.TxtSearchForFillter.TextChanged += new System.EventHandler(this.TxtSearchForFillter_TextChanged);
            // 
            // ComboBoxForFillter
            // 
            this.ComboBoxForFillter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxForFillter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ComboBoxForFillter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxForFillter.FormattingEnabled = true;
            this.ComboBoxForFillter.ItemHeight = 20;
            this.ComboBoxForFillter.Items.AddRange(new object[] {
            "None",
            "Detaind ID",
            "License ID",
            "Is Released"});
            this.ComboBoxForFillter.Location = new System.Drawing.Point(119, 408);
            this.ComboBoxForFillter.Name = "ComboBoxForFillter";
            this.ComboBoxForFillter.Size = new System.Drawing.Size(166, 28);
            this.ComboBoxForFillter.TabIndex = 66;
            this.ComboBoxForFillter.SelectedIndexChanged += new System.EventHandler(this.ComboBoxForFillter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 403);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 29);
            this.label2.TabIndex = 65;
            this.label2.Text = "Filter By";
            // 
            // DataGridViewForDetainedLicesns
            // 
            this.DataGridViewForDetainedLicesns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewForDetainedLicesns.BackgroundColor = System.Drawing.Color.White;
            this.DataGridViewForDetainedLicesns.ColumnHeadersHeight = 29;
            this.DataGridViewForDetainedLicesns.ContextMenuStrip = this.contextMenuStrip1;
            this.DataGridViewForDetainedLicesns.Location = new System.Drawing.Point(12, 444);
            this.DataGridViewForDetainedLicesns.Name = "DataGridViewForDetainedLicesns";
            this.DataGridViewForDetainedLicesns.ReadOnly = true;
            this.DataGridViewForDetainedLicesns.RowHeadersWidth = 51;
            this.DataGridViewForDetainedLicesns.RowTemplate.Height = 24;
            this.DataGridViewForDetainedLicesns.Size = new System.Drawing.Size(1497, 257);
            this.DataGridViewForDetainedLicesns.TabIndex = 62;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetalisToolStripMenuItem,
            this.showLicenseDetalisToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(269, 82);
            // 
            // showPersonDetalisToolStripMenuItem
            // 
            this.showPersonDetalisToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.list__4_;
            this.showPersonDetalisToolStripMenuItem.Name = "showPersonDetalisToolStripMenuItem";
            this.showPersonDetalisToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.showPersonDetalisToolStripMenuItem.Text = "Show Person Detalis";
            this.showPersonDetalisToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetalisToolStripMenuItem_Click);
            // 
            // showLicenseDetalisToolStripMenuItem
            // 
            this.showLicenseDetalisToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.id__1_;
            this.showLicenseDetalisToolStripMenuItem.Name = "showLicenseDetalisToolStripMenuItem";
            this.showLicenseDetalisToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.showLicenseDetalisToolStripMenuItem.Text = "Show License Detalis";
            this.showLicenseDetalisToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetalisToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.activate_profile_config;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // btnReleaseDetainedLicesse
            // 
            this.btnReleaseDetainedLicesse.BackgroundImage = global::DVLD_Project.Properties.Resources.hand__2_;
            this.btnReleaseDetainedLicesse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReleaseDetainedLicesse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReleaseDetainedLicesse.Location = new System.Drawing.Point(1357, 381);
            this.btnReleaseDetainedLicesse.Name = "btnReleaseDetainedLicesse";
            this.btnReleaseDetainedLicesse.Size = new System.Drawing.Size(65, 57);
            this.btnReleaseDetainedLicesse.TabIndex = 71;
            this.btnReleaseDetainedLicesse.UseVisualStyleBackColor = true;
            this.btnReleaseDetainedLicesse.Click += new System.EventHandler(this.btnReleaseDetainedLicesse_Click);
            // 
            // btnDetainedLicense
            // 
            this.btnDetainedLicense.BackgroundImage = global::DVLD_Project.Properties.Resources.hand;
            this.btnDetainedLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDetainedLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetainedLicense.Location = new System.Drawing.Point(1444, 381);
            this.btnDetainedLicense.Name = "btnDetainedLicense";
            this.btnDetainedLicense.Size = new System.Drawing.Size(65, 57);
            this.btnDetainedLicense.TabIndex = 64;
            this.btnDetainedLicense.UseVisualStyleBackColor = true;
            this.btnDetainedLicense.Click += new System.EventHandler(this.btnDetainedLicense_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::DVLD_Project.Properties.Resources.cancel__2_;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(1357, 707);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 40);
            this.button2.TabIndex = 63;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.hand;
            this.pictureBox1.Location = new System.Drawing.Point(516, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(487, 196);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Project.Properties.Resources.refresh_button__1_;
            this.pictureBox2.Location = new System.Drawing.Point(1444, 44);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(65, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 72;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // frmManegeDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1841, 752);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnReleaseDetainedLicesse);
            this.Controls.Add(this.ComboForStatus);
            this.Controls.Add(this.lblNumberOfRows);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtSearchForFillter);
            this.Controls.Add(this.ComboBoxForFillter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDetainedLicense);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DataGridViewForDetainedLicesns);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmManegeDetainedLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Detained Licenses";
            this.Load += new System.EventHandler(this.frmManegeDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewForDetainedLicesns)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnReleaseDetainedLicesse;
        private System.Windows.Forms.ComboBox ComboForStatus;
        private System.Windows.Forms.Label lblNumberOfRows;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtSearchForFillter;
        private System.Windows.Forms.ComboBox ComboBoxForFillter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDetainedLicense;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView DataGridViewForDetainedLicesns;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetalisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetalisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}