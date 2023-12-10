namespace DVLD_Project
{
    partial class ctrlApplicationInfo
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
            this.ctrlLLApplication1 = new DVLD_Project.ctrlLLApplication();
            this.ctrlBasicApplicationInfo1 = new DVLD_Project.ctrlBasicApplicationInfo();
            this.SuspendLayout();
            // 
            // ctrlLLApplication1
            // 
            this.ctrlLLApplication1.BackColor = System.Drawing.Color.White;
            this.ctrlLLApplication1.LLApplicationID = 0;
            this.ctrlLLApplication1.Location = new System.Drawing.Point(5, 3);
            this.ctrlLLApplication1.Name = "ctrlLLApplication1";
            this.ctrlLLApplication1.Size = new System.Drawing.Size(1031, 174);
            this.ctrlLLApplication1.TabIndex = 0;
            // 
            // ctrlBasicApplicationInfo1
            // 
            this.ctrlBasicApplicationInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlBasicApplicationInfo1.Location = new System.Drawing.Point(13, 181);
            this.ctrlBasicApplicationInfo1.Name = "ctrlBasicApplicationInfo1";
            this.ctrlBasicApplicationInfo1.Size = new System.Drawing.Size(1031, 313);
            this.ctrlBasicApplicationInfo1.TabIndex = 1;
            // 
            // ctrlApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctrlBasicApplicationInfo1);
            this.Controls.Add(this.ctrlLLApplication1);
            this.Name = "ctrlApplicationInfo";
            this.Size = new System.Drawing.Size(1044, 494);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlLLApplication ctrlLLApplication1;
        private ctrlBasicApplicationInfo ctrlBasicApplicationInfo1;
    }
}
