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
    public partial class ctrlRenewLocalLicenseApplicatoin : UserControl
    {
        public ctrlRenewLocalLicenseApplicatoin()
        {
            InitializeComponent();
        }

        public int RenewdLicenseID;
        public int OldLicenseID;
        public DateTime ApplicationDate;
        public DateTime IssueDate;
        public int ApplicationFees;
        public int LicenseFees;
        public string Notes;
        public DateTime ExpirationDate;
        public int UserID;
        public int TotalFees;
        public int DriverID;
        public int LicenseClassID;
        public int OldApplicationID;
        public string IssueResons;
        public void FillDataToControl(int oldLicenseID,int userid)
        {

            OldLicenseID = oldLicenseID;

            clsLicenses OldLicense = clsLicenses.Find(OldLicenseID);

           DriverID= OldLicense.DriverID;
            LicenseClassID = OldLicense.LicenseClass;
            OldApplicationID= OldLicense.ApplicationID;

           lblApplicatoinDate.Text=DateTime.Now.ToShortDateString();

            ApplicationDate= DateTime.Now;

             lblIssueDate.Text=DateTime.Now.ToShortDateString();

           

            lblApplicationFees.Text=clsSheardClassForManyThings.GitFeesForApplicationUseApplicatoinName("Renew Driving License Service").ToString();

            ApplicationFees=Convert.ToInt32((lblApplicationFees.Text));

            string ClassName = clsLicenses.GitClassName(OldLicense.LicenseClass);

            lblLicenseFees.Text=clsSheardClassForManyThings.GitFeesForApplicationUseLicenseClassName(ClassName).ToString();

            LicenseFees = Convert.ToInt32((lblLicenseFees.Text));

            lblOldLicenseID.Text=OldLicenseID.ToString();

           lblUserID.Text=userid.ToString();
            UserID = userid;

            lblExpirationDate.Text=DateTime.Now.AddYears(10).ToShortDateString();
            ExpirationDate= DateTime.Now.AddYears(10);

            lblUserID.Text=UserID.ToString();
   
            lblTotalFees.Text=(ApplicationFees+LicenseFees).ToString();

            TotalFees=Convert.ToInt32((lblTotalFees.Text));

            if (TxtNotes.Text.Length < 0)
                Notes = null;
            else
                Notes=TxtNotes.Text;

        }




    }
}
