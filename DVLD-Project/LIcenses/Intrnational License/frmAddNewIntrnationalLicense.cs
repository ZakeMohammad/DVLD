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
    public partial class frmAddNewIntrnationalLicense : Form
    {
        public frmAddNewIntrnationalLicense(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }
        int UserID;
        int LoclaLicenseID;

        int IntrnationalLicenseID;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clsLicenses License=clsLicenses.Find(Convert.ToInt32(TxtLicenseID.Text));

            if (License!=null)
            {
               if(License.LicenseClass!=3)
               {
                    MessageBox.Show($"Licnse With ID = {License.LicenseID} its not local license you cant create intrnational license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                    return;
               }
                LoclaLicenseID = License.LicenseID;
                ctrlDriverLicenseInformation1.FillDataToControl(LoclaLicenseID);
                ctrlIntrnationalApplicatoinInfo1.FillDataToControl(LoclaLicenseID);
            }
            else
                MessageBox.Show($"Licnse With ID = {TxtLicenseID.Text} Does Not Exist","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsLicenses LocalLicense = clsLicenses.Find(LoclaLicenseID);

            if (LocalLicense.IsActive!=1 )
            {
                MessageBox.Show("Your License Is Not Acive You cant issue new Intrnational License","Error",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                return;
            }
            if(LocalLicense.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show("You need to Renew Your License , You cant issue new Intrnational License", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            clsDrivers Driver = clsDrivers.Find(LocalLicense.DriverID);

            if(clsApplications.IsPersonhaveIntrnationalApplicationForIntrantionalLicense(Driver.PersonID))
            {
                MessageBox.Show("You Cant Issue New Intrnational license Because you have one already", "Licenses", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            clsApplications Applicatoin =new clsApplications();


            Applicatoin.ApplicantPersonID = Driver.PersonID;
            Applicatoin.ApplicationDate=DateTime.Now;
            Applicatoin.ApplicationTypeID = 6;
            Applicatoin.ApplicationStatus = 3;
            Applicatoin.LastStatusDate= DateTime.Now;
            Applicatoin.CreatedByUserID= UserID;
            Applicatoin.PaidFees = (int)ctrlIntrnationalApplicatoinInfo1.Fees;


            if(Applicatoin.Save())
            {
               
                clsInternationalLicenses IntrnationalLicense=new clsInternationalLicenses();    

                IntrnationalLicense.ApplicationID=Applicatoin.ApplicationID;
                IntrnationalLicense.DriverID=Driver.DriverID;
                IntrnationalLicense.IssuedUsingLocalLicenseID = ctrlIntrnationalApplicatoinInfo1.LocalLicenseID;
                IntrnationalLicense.IssueDate = ctrlIntrnationalApplicatoinInfo1.IssueDate;
                IntrnationalLicense.ExpirationDate = ctrlIntrnationalApplicatoinInfo1.ExpirationDate;
                IntrnationalLicense.IsActive = 1;    
                IntrnationalLicense.CreatedByUserID = ctrlIntrnationalApplicatoinInfo1.UserID;

                if(IntrnationalLicense.Save())
                {
                    IntrnationalLicenseID = IntrnationalLicense.InternationalLicenseID;
                    MessageBox.Show($"Intrnational License Added Succssfilly with ID={IntrnationalLicense.InternationalLicenseID}", "Intrnational License ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled= false;
                    linkLabel2.Enabled = true;

                    return;
                }
                else
                {
                    MessageBox.Show("Intrnational License Does Not Added", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                    linkLabel2.Enabled = false;
                    return;
                }

            }
            else
            {
                MessageBox.Show("Intrnational License Does Not Added", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                linkLabel2.Enabled = false;
                return;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(TxtLicenseID.Text==string.Empty)
            {
                MessageBox.Show("Please Enter License ID Before Show Person License Histroy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsLicenses License = clsLicenses.Find(Convert.ToInt32(TxtLicenseID.Text));
         
            if (License == null)
            {


                MessageBox.Show($"Licnse With ID = {TxtLicenseID.Text} Does Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int PersonID = clsDrivers.GitPersonID(License.DriverID);

            frmLicenseHistory New = new frmLicenseHistory(PersonID);
            New.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmIntrnationlLicenseInfo frm = new frmIntrnationlLicenseInfo(IntrnationalLicenseID);
            frm.ShowDialog();
        }

        private void TxtLicenseID_TextChanged(object sender, EventArgs e)
        {
            if(TxtLicenseID.Text==string.Empty)
            {
               btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}