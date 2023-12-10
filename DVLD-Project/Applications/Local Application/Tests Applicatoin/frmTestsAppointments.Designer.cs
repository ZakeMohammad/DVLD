namespace DVLD_Project
{
    partial class frmTestsAppointments
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
            this.lblForWhat = new System.Windows.Forms.Label();
            this.DataGridVeiwForALlAppointments = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.taleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumberOfRows = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlApplicationInfo1 = new DVLD_Project.ctrlApplicationInfo();
            this.btnAddNewAppintemnt = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.PictreForWhatTest = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridVeiwForALlAppointments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictreForWhatTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblForWhat
            // 
            this.lblForWhat.AutoSize = true;
            this.lblForWhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForWhat.ForeColor = System.Drawing.Color.Red;
            this.lblForWhat.Location = new System.Drawing.Point(315, 128);
            this.lblForWhat.Name = "lblForWhat";
            this.lblForWhat.Size = new System.Drawing.Size(387, 38);
            this.lblForWhat.TabIndex = 2;
            this.lblForWhat.Text = "Vision Test Appointments";
            // 
            // DataGridVeiwForALlAppointments
            // 
            this.DataGridVeiwForALlAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridVeiwForALlAppointments.BackgroundColor = System.Drawing.Color.White;
            this.DataGridVeiwForALlAppointments.ColumnHeadersHeight = 29;
            this.DataGridVeiwForALlAppointments.ContextMenuStrip = this.contextMenuStrip1;
            this.DataGridVeiwForALlAppointments.Location = new System.Drawing.Point(12, 716);
            this.DataGridVeiwForALlAppointments.Name = "DataGridVeiwForALlAppointments";
            this.DataGridVeiwForALlAppointments.ReadOnly = true;
            this.DataGridVeiwForALlAppointments.RowHeadersWidth = 51;
            this.DataGridVeiwForALlAppointments.RowTemplate.Height = 24;
            this.DataGridVeiwForALlAppointments.Size = new System.Drawing.Size(1052, 161);
            this.DataGridVeiwForALlAppointments.TabIndex = 49;
            this.DataGridVeiwForALlAppointments.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridVeiwForALlAppointments_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taleTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 30);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // taleTestToolStripMenuItem
            // 
            this.taleTestToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.admissions;
            this.taleTestToolStripMenuItem.Name = "taleTestToolStripMenuItem";
            this.taleTestToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.taleTestToolStripMenuItem.Text = "Take Test";
            this.taleTestToolStripMenuItem.Click += new System.EventHandler(this.taleTestToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 681);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 29);
            this.label2.TabIndex = 52;
            this.label2.Text = "Appointments";
            // 
            // lblNumberOfRows
            // 
            this.lblNumberOfRows.AutoSize = true;
            this.lblNumberOfRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRows.Location = new System.Drawing.Point(128, 889);
            this.lblNumberOfRows.Name = "lblNumberOfRows";
            this.lblNumberOfRows.Size = new System.Drawing.Size(21, 22);
            this.lblNumberOfRows.TabIndex = 57;
            this.lblNumberOfRows.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 889);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 22);
            this.label3.TabIndex = 56;
            this.label3.Text = "# Records";
            // 
            // ctrlApplicationInfo1
            // 
            this.ctrlApplicationInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlApplicationInfo1.Location = new System.Drawing.Point(12, 169);
            this.ctrlApplicationInfo1.Name = "ctrlApplicationInfo1";
            this.ctrlApplicationInfo1.Size = new System.Drawing.Size(1058, 494);
            this.ctrlApplicationInfo1.TabIndex = 59;
            // 
            // btnAddNewAppintemnt
            // 
            this.btnAddNewAppintemnt.BackgroundImage = global::DVLD_Project.Properties.Resources.essay;
            this.btnAddNewAppintemnt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewAppintemnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewAppintemnt.Location = new System.Drawing.Point(999, 669);
            this.btnAddNewAppintemnt.Name = "btnAddNewAppintemnt";
            this.btnAddNewAppintemnt.Size = new System.Drawing.Size(65, 44);
            this.btnAddNewAppintemnt.TabIndex = 51;
            this.btnAddNewAppintemnt.UseVisualStyleBackColor = true;
            this.btnAddNewAppintemnt.Click += new System.EventHandler(this.btnAddNewAppintemnt_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::DVLD_Project.Properties.Resources.cancel__2_;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(912, 883);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 36);
            this.button2.TabIndex = 58;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PictreForWhatTest
            // 
            this.PictreForWhatTest.Image = global::DVLD_Project.Properties.Resources.eye__1_;
            this.PictreForWhatTest.Location = new System.Drawing.Point(279, -10);
            this.PictreForWhatTest.Name = "PictreForWhatTest";
            this.PictreForWhatTest.Size = new System.Drawing.Size(516, 161);
            this.PictreForWhatTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictreForWhatTest.TabIndex = 3;
            this.PictreForWhatTest.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Project.Properties.Resources.refresh_button__1_;
            this.pictureBox2.Location = new System.Drawing.Point(999, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(65, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 74;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // frmTestsAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1077, 942);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnAddNewAppintemnt);
            this.Controls.Add(this.ctrlApplicationInfo1);
            this.Controls.Add(this.lblForWhat);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblNumberOfRows);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DataGridVeiwForALlAppointments);
            this.Controls.Add(this.PictreForWhatTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(2000, 2000);
            this.Name = "frmTestsAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vision Test Appointments";
            this.Load += new System.EventHandler(this.frmVisionTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridVeiwForALlAppointments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictreForWhatTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictreForWhatTest;
        private System.Windows.Forms.Label lblForWhat;
        private System.Windows.Forms.DataGridView DataGridVeiwForALlAppointments;
        private System.Windows.Forms.Button btnAddNewAppintemnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumberOfRows;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private ctrlApplicationInfo ctrlApplicationInfo1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem taleTestToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}