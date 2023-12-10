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
    public partial class frmRenewLicense : Form
    {
        public frmRenewLicense(int userId)
        {
            InitializeComponent();
            UserId = userId;
        }

        int UserId;
        int OldLicenseID;
        int RennewLicenseID;
        int _PersonID;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            clsLicenses License = clsLicenses.Find(Convert.ToInt32(TxtLicenseID.Text));

            if (License != null)
            {
                _PersonID = clsDrivers.GitPersonID(License.DriverID);
               OldLicenseID= License.LicenseID;
                
                if (License.IsActive != 1)
                {
                    MessageBox.Show($"Selected License Is Not Active you cant renew it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                    ctrlDriverLicenseInformation1.FillDataToControl(OldLicenseID);
                    return;
                }
                else 
                btnSave.Enabled = true;

                if (License.ExpirationDate>DateTime.Now)
                {
                    MessageBox.Show($"Selected License is not yet ecpiared, it will expire on: {License.ExpirationDate.ToShortDateString()}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    btnSave.Enabled= false;
                    ctrlDriverLicenseInformation1.FillDataToControl(OldLicenseID);
                    return;
                }
                else
                {
                    btnSave.Enabled = true;
                    ctrlDriverLicenseInformation1.FillDataToControl(OldLicenseID);
                    ctrlRenewLocalLicenseApplicatoin1.FillDataToControl(OldLicenseID, UserId);
                }

            }
            else
            {
                MessageBox.Show($"Licnse With ID = {TxtLicenseID.Text} Does Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
            }
               
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           clsApplications RenewApplication= new clsApplications();

            clsLicenses OldLicense = clsLicenses.Find(OldLicenseID);
            clsDrivers Driver = clsDrivers.Find(OldLicense.DriverID);

            RenewApplication.ApplicantPersonID = Driver.PersonID;
            RenewApplication.ApplicationDate = ctrlRenewLocalLicenseApplicatoin1.ApplicationDate;
            RenewApplication.ApplicationTypeID = 2;
            RenewApplication.ApplicationStatus = 3;
            RenewApplication.LastStatusDate=DateTime.Now;
            RenewApplication.PaidFees = ctrlRenewLocalLicenseApplicatoin1.ApplicationFees;
            RenewApplication.CreatedByUserID= UserId;
          

            if(RenewApplication.Save())
            {
              
                clsLicenses NewRenewLicense = new clsLicenses();

                    NewRenewLicense.ApplicationID=RenewApplication.ApplicationID;
                    NewRenewLicense.IssueDate= DateTime.Now;
                    NewRenewLicense.ExpirationDate= ctrlRenewLocalLicenseApplicatoin1.ExpirationDate;
                    NewRenewLicense.PaidFees = ctrlRenewLocalLicenseApplicatoin1.LicenseFees;
                    NewRenewLicense.Notes= ctrlRenewLocalLicenseApplicatoin1.Notes;
                    NewRenewLicense.IsActive = 1;
                    NewRenewLicense.CreatedByUserID= UserId;
                    NewRenewLicense.DriverID = OldLicense.DriverID;
                    NewRenewLicense.LicenseClass=OldLicense.LicenseClass;
                    NewRenewLicense.IssueReason = 2;


                    if(NewRenewLicense.Save())
                    {

                       if (!clsLicenses.DeActiveLicense(OldLicense.LicenseID))
                       {
                        return;
                       }


                        MessageBox.Show($"License Succssfilly Renewd with ID= {NewRenewLicense.LicenseID}","Renwed",MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                    else
                    {
                      if( clsApplications.DeleteApplications(NewRenewLicense.ApplicationID))
                        MessageBox.Show("License  Does Not Renewed", "Renwed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
            }
            else
            {
                MessageBox.Show("Application For Renewd  Does Not Save", "Applications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory New = new frmLicenseHistory(_PersonID);
            New.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
