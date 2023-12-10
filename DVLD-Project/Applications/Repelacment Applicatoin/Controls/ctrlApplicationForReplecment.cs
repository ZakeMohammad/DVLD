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
    public partial class ctrlApplicationForReplecment : UserControl
    {
        public ctrlApplicationForReplecment()
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



        public void FillDataToControl(int oldLicenseID,int userID,int ForDamageOrLost)
        {
            clsLicenses OldLicense = clsLicenses.Find(oldLicenseID);

            OldLicenseID = oldLicenseID;
            DriverID = OldLicense.DriverID;
            LicenseClassID = OldLicense.LicenseClass;
            OldApplicationID = OldLicense.ApplicationID;
            IssueDate = OldLicense.IssueDate;
            ExpirationDate = OldLicense.ExpirationDate;
            Notes = OldLicense.Notes;
            LicenseFees = OldLicense.PaidFees;
            UserID = userID;
            ApplicationDate = DateTime.Now;


            lblApplicatoinDate.Text = DateTime.Now.ToShortDateString();
            lblOldLicenseID.Text=OldLicense.LicenseID.ToString();
            lblUserID.Text = UserID.ToString();

           

            if(ForDamageOrLost==1)
            {
                lblApplicationFees.Text = clsSheardClassForManyThings.GitFeesForApplicationUseApplicatoinName("Replacement for a Damaged Driving License").ToString();

                ApplicationFees = Convert.ToInt32((lblApplicationFees.Text));

            }
            if(ForDamageOrLost==2)
            {
                lblApplicationFees.Text = clsSheardClassForManyThings.GitFeesForApplicationUseApplicatoinName("Replacement for a Lost Driving License").ToString();

                ApplicationFees = Convert.ToInt32((lblApplicationFees.Text));
            }

        }

    }
}
