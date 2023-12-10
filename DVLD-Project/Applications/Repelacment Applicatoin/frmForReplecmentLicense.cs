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
    public partial class frmForReplecmentLicense : Form
    {
        public frmForReplecmentLicense(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }


        int UserID;


       
        int OldLicenseID;
        int ReplecmentLicenseID;
        int _PersonID;



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clsLicenses License = clsLicenses.Find(Convert.ToInt32(TxtLicenseID.Text));

            if (License != null)
            {
                _PersonID = clsDrivers.GitPersonID(License.DriverID);
                OldLicenseID = License.LicenseID;

                if (License.IsActive != 1)
                {
                    MessageBox.Show($"Selected License Is Not Active you cant Replecment it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                    ctrlDriverLicenseInformation1.FillDataToControl(OldLicenseID);
                    return;
                }
                else
                {
                    btnSave.Enabled = true;
                    ctrlDriverLicenseInformation1.FillDataToControl(OldLicenseID);
                }

            }
            else
            {
                MessageBox.Show($"Licnse With ID = {TxtLicenseID.Text} Does Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsApplications ReplecmentApplicatoin = new clsApplications();

            clsLicenses OldLicense = clsLicenses.Find(OldLicenseID);
            clsDrivers Driver = clsDrivers.Find(OldLicense.DriverID);


            ReplecmentApplicatoin.ApplicantPersonID = Driver.PersonID;
            ReplecmentApplicatoin.ApplicationDate = ctrlApplicationForReplecment1.ApplicationDate;

            if(RDForDamaged.Checked)
                ReplecmentApplicatoin.ApplicationTypeID = 4;
            if(RDForLost.Checked)
                ReplecmentApplicatoin.ApplicationTypeID = 3;

            ReplecmentApplicatoin.ApplicationStatus = 3;
            ReplecmentApplicatoin.LastStatusDate = DateTime.Now;
            ReplecmentApplicatoin.PaidFees = ctrlApplicationForReplecment1.ApplicationFees;
            ReplecmentApplicatoin.CreatedByUserID = UserID;


            if(ReplecmentApplicatoin.Save())
            {
                clsLicenses NewReplecmentLicese = new clsLicenses();

                NewReplecmentLicese.ApplicationID = ReplecmentApplicatoin.ApplicationID;
                NewReplecmentLicese.IssueDate = ctrlApplicationForReplecment1.IssueDate;
                NewReplecmentLicese.ExpirationDate = ctrlApplicationForReplecment1.ExpirationDate;
                NewReplecmentLicese.PaidFees = ctrlApplicationForReplecment1.LicenseFees;
                NewReplecmentLicese.Notes = ctrlApplicationForReplecment1.Notes;
                NewReplecmentLicese.IsActive = 1;
                NewReplecmentLicese.CreatedByUserID = UserID;
                NewReplecmentLicese.DriverID = OldLicense.DriverID;
                NewReplecmentLicese.LicenseClass = OldLicense.LicenseClass;

                if(RDForDamaged.Checked)
                     NewReplecmentLicese.IssueReason = 3;

                if(RDForLost.Checked)
                    NewReplecmentLicese.IssueReason = 4;

                if (NewReplecmentLicese.Save())
                {

                    if (!clsLicenses.DeActiveLicense(OldLicense.LicenseID))
                    {
                        return;
                    }
                    LinkFOrLicenseInfo.Enabled = true;
                    ReplecmentLicenseID = NewReplecmentLicese.LicenseID;
                    MessageBox.Show($"License Succssfilly Replecment with ID= {NewReplecmentLicese.LicenseID}", "Replecment", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    LinkFOrLicenseInfo.Enabled= false;
                    if (clsApplications.DeleteApplications(NewReplecmentLicese.ApplicationID))
                        MessageBox.Show("License  Does Not Replecment", "Replecment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }
            else
            {
                MessageBox.Show("Application For Replecment  Does Not Save", "Applications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void linkForHistoryLicenses_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(_PersonID);
            frm.ShowDialog();
        }

        private void LinkFOrLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInformation frm =new frmDriverLicenseInformation(ReplecmentLicenseID);
            frm.ShowDialog();
        }

        private void frmForReplecmentLicense_Load(object sender, EventArgs e)
        {
            LinkFOrLicenseInfo.Enabled = false;
        }

        private void RDForDamaged_CheckedChanged(object sender, EventArgs e)
        {
            if (RDForDamaged.Checked)
                ctrlApplicationForReplecment1.FillDataToControl(OldLicenseID, UserID, 1);
            if (RDForLost.Checked)
                ctrlApplicationForReplecment1.FillDataToControl(OldLicenseID, UserID, 2);

        }

        private void RDForLost_CheckedChanged(object sender, EventArgs e)
        {
            if (RDForDamaged.Checked)
                ctrlApplicationForReplecment1.FillDataToControl(OldLicenseID, UserID, 1);
            if (RDForLost.Checked)
                ctrlApplicationForReplecment1.FillDataToControl(OldLicenseID, UserID, 2);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
