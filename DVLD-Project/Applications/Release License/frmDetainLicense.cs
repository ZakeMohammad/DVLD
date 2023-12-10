using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmDetainLicense : Form
    {
        public frmDetainLicense(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int UserID;
        int LicenseID;
        clsLicenses _License;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            clsLicenses License = clsLicenses.Find(Convert.ToInt32(TxtLicenseID.Text));

            if (License != null)
            {
                clsDetainedLicenses DetaindLicense = clsDetainedLicenses.Find(License.LicenseID, true);
                _License = License;
                if (DetaindLicense!= null)
                {
                    if (DetaindLicense.IsReleased == false)
                    {
                        MessageBox.Show($"Licnse With ID = {DetaindLicense.LicenseID} its Already detaind please Release it ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnSave.Enabled = false;
                        return;
                    }
                  
                }
                LicenseID= License.LicenseID;   
                ctrlDetain1.FillDataToControl(LicenseID, UserID);
                ctrlDriverLicenseInformation1.FillDataToControl(LicenseID);
                btnSave.Enabled = true;
            }
            else
            {
                MessageBox.Show($"Licnse With ID = {TxtLicenseID.Text} Does Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            } 
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsDetainedLicenses DetaindLecinse=new clsDetainedLicenses();


            DetaindLecinse.LicenseID = LicenseID;
            DetaindLecinse.DetainDate= DateTime.Now;
            DetaindLecinse.FineFees = ctrlDetain1.Fees;
            DetaindLecinse.CreatedByUserID= UserID;
            DetaindLecinse.IsReleased= false;
            DetaindLecinse.CreatedByUserID = UserID;
            DetaindLecinse.ReleaseApplicationID = -1;
            DetaindLecinse.ReleaseDate= Convert.ToDateTime("2000-11-2");
            DetaindLecinse.ReleasedByUserID = -1;

            if (DetaindLecinse.Save())
            {  
                MessageBox.Show($"License Detaind Succssfilly with ID={DetaindLecinse.DetainID}", "Detaind Licenses ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                linkLabel2.Enabled = true;
                return;
            }
            else
            {
                MessageBox.Show("License Does Not Detaind ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                linkLabel2.Enabled = false;
                return;
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInformation frm = new frmDriverLicenseInformation(LicenseID);
            frm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           int PersonID = clsDrivers.GitPersonID(_License.DriverID);
            frmLicenseHistory frm= new frmLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
