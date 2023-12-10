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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Project
{
    public partial class frmAddNewLoclaDrinvingLicense : Form
    {
        public frmAddNewLoclaDrinvingLicense(int lLApplicatoinID, int userID)
        {
            InitializeComponent();
            LLApplicatoinID = lLApplicatoinID;
            UserID = userID;
        }

        int LLApplicatoinID;
        int UserID;
        clsDrivers _Driver;
        clsApplications _Application;


        public delegate void DataBackEventhandler(object sender,  bool Ruslt, int ApplicationID,int LicenseID);

        public event DataBackEventhandler BackData;




        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddNewLoclaDrinvingLicense_Load(object sender, EventArgs e)
        {
            ctrlApplicationInfo1.FillDataToControls(LLApplicatoinID);
        }

        void CreateNewDriver()
        {
            clsDrivers Driver = new clsDrivers();
            clsLocalDrivingLicenseApplications LLApplication = clsLocalDrivingLicenseApplications.Find(LLApplicatoinID);

            clsApplications Application = clsApplications.Find(LLApplication.ApplicationID);
            _Application= Application;
            Driver.PersonID = Application.ApplicantPersonID;
            Driver.CreatedByUserID= UserID;
            Driver.CreatedDate = DateTime.Now;

            _Driver= Driver;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplications LLApplication = clsLocalDrivingLicenseApplications.Find(LLApplicatoinID);

            clsApplications Application = clsApplications.Find(LLApplication.ApplicationID);

            foreach (DataRow Row in clsDrivers.GitAllDrivers().Rows)
            {
                if ((int)Row["PersonID"]== Application.ApplicantPersonID)
                {
                    clsLicenses License = new clsLicenses();

                    License.ApplicationID = Application.ApplicationID;
                    License.DriverID = (int)Row["DriverID"];
                    License.LicenseClass = LLApplication.LicenseClassID;
                    License.IssueDate = DateTime.Now;
                    License.IsActive = 1;
                    if (License.LicenseClass == 1)
                    {
                        License.ExpirationDate = DateTime.Now.AddYears(5);
                        License.PaidFees = 15;
                    }
                    if (License.LicenseClass == 2)
                    {
                        License.ExpirationDate = DateTime.Now.AddYears(5);
                        License.PaidFees = 30;
                    }
                    if (License.LicenseClass == 3)
                    {
                        License.ExpirationDate = DateTime.Now.AddYears(10);
                        License.PaidFees = 20;
                    }
                    if (License.LicenseClass == 4)
                    {
                        License.ExpirationDate = DateTime.Now.AddYears(10);
                        License.PaidFees = 200;
                    }
                    if (License.LicenseClass == 5)
                    {
                        License.ExpirationDate = DateTime.Now.AddYears(10);
                        License.PaidFees = 50;
                    }
                    if (License.LicenseClass == 6)
                    {
                        License.ExpirationDate = DateTime.Now.AddYears(10);
                        License.PaidFees = 250;
                    }
                    if (License.LicenseClass == 7)
                    {
                        License.ExpirationDate = DateTime.Now.AddYears(10);
                        License.PaidFees = 300;
                    }
                    License.IssueReason = 1;
                    License.CreatedByUserID = UserID;


                    if (License.Save())
                    {
                        MessageBox.Show($"License Succssfilly Added With ID = {License.LicenseID}", "Licenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BackData?.Invoke(this, true, License.ApplicationID, License.LicenseID);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"License Does Not Added ", "Licenses", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        BackData?.Invoke(this, false, License.ApplicationID, License.LicenseID);
                        this.Close();
                    }
                    return;
                }
            }

            CreateNewDriver();

            if(_Driver.Save())
            {
                clsLicenses License= new clsLicenses();

                License.ApplicationID=_Application.ApplicationID;              
                License.DriverID= _Driver.DriverID;
                License.LicenseClass = _Application.ApplicationTypeID;
                License.IssueDate= DateTime.Now;
                License.IsActive = 1;
                if(License.LicenseClass==1 )
                {
                    License.ExpirationDate = DateTime.Now.AddYears(5);
                    License.PaidFees = 15;
                }
                if (License.LicenseClass == 2)
                {
                    License.ExpirationDate = DateTime.Now.AddYears(5);
                    License.PaidFees = 30;
                }
                if (License.LicenseClass == 3 )
                {
                    License.ExpirationDate = DateTime.Now.AddYears(10);
                    License.PaidFees = 20;
                }
                if (License.LicenseClass ==4)
                {
                    License.ExpirationDate = DateTime.Now.AddYears(10);
                    License.PaidFees = 200;
                }
                if (License.LicenseClass == 5)
                {
                    License.ExpirationDate = DateTime.Now.AddYears(10);
                    License.PaidFees = 50;
                }
                if (License.LicenseClass == 6)
                {
                    License.ExpirationDate = DateTime.Now.AddYears(10);
                    License.PaidFees = 250;
                }
                if (License.LicenseClass == 7)
                {
                    License.ExpirationDate = DateTime.Now.AddYears(10);
                    License.PaidFees = 300;
                }
                License.IssueReason = 1;
                License.CreatedByUserID = UserID;


                if(License.Save())
                {
                    MessageBox.Show($"License Succssfilly Added With ID = {License.LicenseID}","Licenses",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BackData?.Invoke(this, true,License.ApplicationID, License.LicenseID);
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"License Does Not Added ", "Licenses", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BackData?.Invoke(this, false, License.ApplicationID, License.LicenseID);
                    this.Close();
                }

            }
            return;
        }
    }
}
