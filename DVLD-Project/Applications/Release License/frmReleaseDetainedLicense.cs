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
    public partial class frmReleaseDetainedLicense : Form
    {
        public frmReleaseDetainedLicense(int userid)
        {
            InitializeComponent();
           UserID= userid;
        }

        int UserID;
        int LicenseID;
        int _PersonID;
        int DetaindLicenseID;
        clsLicenses _License;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clsLicenses License = clsLicenses.Find(Convert.ToInt32(TxtLicenseID.Text));

            if (License != null)
            {
                int PersonID = clsDrivers.GitPersonID(License.DriverID);
                _PersonID = PersonID;
                clsDetainedLicenses DetaindLicense = clsDetainedLicenses.FindForReleasedOnly(License.LicenseID);
                _License = License;
                if (DetaindLicense != null)
                {
                    if(( DetaindLicense.IsReleased==false && DetaindLicense.CreatedByUserID==-1))
                    {
                        MessageBox.Show($"Licnse With ID = {DetaindLicense.LicenseID} its Released Already", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnSave.Enabled = false;
                        return;
                    }
                    DetaindLicenseID = DetaindLicense.DetainID;
                    LicenseID = License.LicenseID;
                    ctrlDriverLicenseInformation1.FillDataToControl(LicenseID);
                    btnSave.Enabled = true;
                    ctrlReleaseDetainLicense1.FillDataToControl(DetaindLicense.DetainID, UserID);

                }
                else
                {
                    MessageBox.Show($"Licnse With ID = {TxtLicenseID.Text} Its Not Detaind", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnSave.Enabled = false;
                    return;
                }
               
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
          
            clsApplications ReleaseApplication = new clsApplications();


            ReleaseApplication.ApplicantPersonID = _PersonID;
            ReleaseApplication.ApplicationDate= DateTime.Now;
            ReleaseApplication.ApplicationTypeID = 5;
            ReleaseApplication.ApplicationStatus = 3;
            ReleaseApplication.LastStatusDate= DateTime.Now;
            ReleaseApplication.PaidFees = ctrlReleaseDetainLicense1.ApplicatoinFees;
            ReleaseApplication.CreatedByUserID= UserID;


            if(ReleaseApplication.Save())
            {
               if(clsDetainedLicenses.ReleaseLicense(DetaindLicenseID,ReleaseApplication.ApplicationDate,ReleaseApplication.ApplicationID,ReleaseApplication.CreatedByUserID))
               {
                    MessageBox.Show($"License With ID {LicenseID} Succssfilly Released","Released Licenses",MessageBoxButtons.OK, MessageBoxIcon.Information);
                   linkLabel2.Enabled=true;
               }
                else
                {
                    MessageBox.Show($"License With ID {LicenseID} Does Not Released", "Released Licenses", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    linkLabel2.Enabled=false;
                }
               
            }

            btnSave.Enabled = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(_PersonID);
            frm.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInformation frm=new frmDriverLicenseInformation(LicenseID);
            frm.ShowDialog();
        }
    }
}
