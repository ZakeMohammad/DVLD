namespace DVLD_Project
{
    partial class ctrlUserInformation
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
            this.ctrlPersonInformation1 = new DVLD_Project.ctrlPersonInformation();
            this.ctrlLoginInformation1 = new DVLD_Project.ctrlLoginInformation();
            this.SuspendLayout();
            // 
            // ctrlPersonInformation1
            // 
            this.ctrlPersonInformation1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonInformation1.Location = new System.Drawing.Point(0, 3);
            this.ctrlPersonInformation1.Name = "ctrlPersonInformation1";
            this.ctrlPersonInformation1.Size = new System.Drawing.Size(937, 343);
            this.ctrlPersonInformation1.TabIndex = 0;
            // 
            // ctrlLoginInformation1
            // 
            this.ctrlLoginInformation1.BackColor = System.Drawing.Color.White;
            this.ctrlLoginInformation1.Location = new System.Drawing.Point(3, 341);
            this.ctrlLoginInformation1.Name = "ctrlLoginInformation1";
            this.ctrlLoginInformation1.Size = new System.Drawing.Size(925, 121);
            this.ctrlLoginInformation1.TabIndex = 1;
            // 
            // ctrlUserInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctrlLoginInformation1);
            this.Controls.Add(this.ctrlPersonInformation1);
            this.Name = "ctrlUserInformation";
            this.Size = new System.Drawing.Size(943, 489);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonInformation ctrlPersonInformation1;
        private ctrlLoginInformation ctrlLoginInformation1;
    }
}
