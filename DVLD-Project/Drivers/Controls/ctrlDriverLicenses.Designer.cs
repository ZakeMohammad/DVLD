namespace DVLD_Project
{
    partial class ctrlDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblNumberOfLocalLicense = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DataGridVewForLocal = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumberOfRecordsForLocal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblNumberOfInternationalLicense = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DataGridVewForIntrnatoinal = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumberOfRecordsForIntrnational = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridVewForLocal)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridVewForIntrnatoinal)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1261, 282);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1242, 219);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblNumberOfLocalLicense);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.DataGridVewForLocal);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblNumberOfRecordsForLocal);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1234, 186);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblNumberOfLocalLicense
            // 
            this.lblNumberOfLocalLicense.AutoSize = true;
            this.lblNumberOfLocalLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfLocalLicense.Location = new System.Drawing.Point(147, 149);
            this.lblNumberOfLocalLicense.Name = "lblNumberOfLocalLicense";
            this.lblNumberOfLocalLicense.Size = new System.Drawing.Size(92, 22);
            this.lblNumberOfLocalLicense.TabIndex = 11;
            this.lblNumberOfLocalLicense.Tag = "";
            this.lblNumberOfLocalLicense.Text = "# Records";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 22);
            this.label6.TabIndex = 10;
            this.label6.Tag = "lblNumberOfRecordsForLocal";
            this.label6.Text = "# Records";
            // 
            // DataGridVewForLocal
            // 
            this.DataGridVewForLocal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DataGridVewForLocal.BackgroundColor = System.Drawing.Color.White;
            this.DataGridVewForLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridVewForLocal.ContextMenuStrip = this.contextMenuStrip1;
            this.DataGridVewForLocal.Location = new System.Drawing.Point(36, 39);
            this.DataGridVewForLocal.Name = "DataGridVewForLocal";
            this.DataGridVewForLocal.ReadOnly = true;
            this.DataGridVewForLocal.RowHeadersWidth = 51;
            this.DataGridVewForLocal.RowTemplate.Height = 24;
            this.DataGridVewForLocal.Size = new System.Drawing.Size(1192, 107);
            this.DataGridVewForLocal.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(201, 30);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.id__1_;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "# Records:";
            // 
            // lblNumberOfRecordsForLocal
            // 
            this.lblNumberOfRecordsForLocal.AutoSize = true;
            this.lblNumberOfRecordsForLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecordsForLocal.Location = new System.Drawing.Point(135, 224);
            this.lblNumberOfRecordsForLocal.Name = "lblNumberOfRecordsForLocal";
            this.lblNumberOfRecordsForLocal.Size = new System.Drawing.Size(20, 22);
            this.lblNumberOfRecordsForLocal.TabIndex = 4;
            this.lblNumberOfRecordsForLocal.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Local Licenses History:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblNumberOfInternationalLicense);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.DataGridVewForIntrnatoinal);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.lblNumberOfRecordsForIntrnational);
            this.tabPage2.Controls.Add(this.lbl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1234, 186);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Intrnational";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblNumberOfInternationalLicense
            // 
            this.lblNumberOfInternationalLicense.AutoSize = true;
            this.lblNumberOfInternationalLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfInternationalLicense.Location = new System.Drawing.Point(135, 150);
            this.lblNumberOfInternationalLicense.Name = "lblNumberOfInternationalLicense";
            this.lblNumberOfInternationalLicense.Size = new System.Drawing.Size(20, 22);
            this.lblNumberOfInternationalLicense.TabIndex = 9;
            this.lblNumberOfInternationalLicense.Tag = "";
            this.lblNumberOfInternationalLicense.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 22);
            this.label3.TabIndex = 8;
            this.label3.Tag = "lblNumberOfRecordsForLocal";
            this.label3.Text = "# Records";
            // 
            // DataGridVewForIntrnatoinal
            // 
            this.DataGridVewForIntrnatoinal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DataGridVewForIntrnatoinal.BackgroundColor = System.Drawing.Color.White;
            this.DataGridVewForIntrnatoinal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridVewForIntrnatoinal.ContextMenuStrip = this.contextMenuStrip2;
            this.DataGridVewForIntrnatoinal.Location = new System.Drawing.Point(29, 38);
            this.DataGridVewForIntrnatoinal.Name = "DataGridVewForIntrnatoinal";
            this.DataGridVewForIntrnatoinal.ReadOnly = true;
            this.DataGridVewForIntrnatoinal.RowHeadersWidth = 51;
            this.DataGridVewForIntrnatoinal.RowTemplate.Height = 24;
            this.DataGridVewForIntrnatoinal.Size = new System.Drawing.Size(1199, 109);
            this.DataGridVewForIntrnatoinal.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "# Records:";
            // 
            // lblNumberOfRecordsForIntrnational
            // 
            this.lblNumberOfRecordsForIntrnational.AutoSize = true;
            this.lblNumberOfRecordsForIntrnational.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecordsForIntrnational.Location = new System.Drawing.Point(137, 327);
            this.lblNumberOfRecordsForIntrnational.Name = "lblNumberOfRecordsForIntrnational";
            this.lblNumberOfRecordsForIntrnational.Size = new System.Drawing.Size(20, 22);
            this.lblNumberOfRecordsForIntrnational.TabIndex = 1;
            this.lblNumberOfRecordsForIntrnational.Text = "0";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(25, 13);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(240, 22);
            this.lbl2.TabIndex = 0;
            this.lbl2.Text = "Intrnational Licenses History:";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(201, 30);
            // 
            // showLicenseInfoToolStripMenuItem1
            // 
            this.showLicenseInfoToolStripMenuItem1.Image = global::DVLD_Project.Properties.Resources.world;
            this.showLicenseInfoToolStripMenuItem1.Name = "showLicenseInfoToolStripMenuItem1";
            this.showLicenseInfoToolStripMenuItem1.Size = new System.Drawing.Size(214, 26);
            this.showLicenseInfoToolStripMenuItem1.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem1.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem1_Click);
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(1261, 288);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridVewForLocal)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridVewForIntrnatoinal)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView DataGridVewForLocal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumberOfRecordsForLocal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumberOfRecordsForIntrnational;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.DataGridView DataGridVewForIntrnatoinal;
        private System.Windows.Forms.Label lblNumberOfLocalLicense;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNumberOfInternationalLicense;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem1;
    }
}
