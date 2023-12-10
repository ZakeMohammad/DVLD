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
    public partial class ctrlReleaseDetainLicense : UserControl
    {
        public ctrlReleaseDetainLicense()
        {
            InitializeComponent();
        }


        public int ApplicatoinFees;
        public int ApplicationID;



        public void FillDataToControl(int DetaindLicenseID,int UserID)
        {
            clsDetainedLicenses DetaindLicnse = clsDetainedLicenses.Find(DetaindLicenseID);


            lblDetainID.Text = DetaindLicnse.DetainID.ToString();
            lblDetaindDate.Text=DetaindLicnse.DetainDate.ToShortDateString();

            ApplicatoinFees = clsSheardClassForManyThings.GitFeesForApplicationUseApplicatoinName("Release Detained Driving Licsense");
            lblApplicationFees.Text=ApplicatoinFees.ToString();

            lblFineFees.Text = DetaindLicnse.FineFees.ToString();

            lblTotalFees.Text=(DetaindLicnse.FineFees + ApplicatoinFees).ToString();
            lblLicenseID.Text=DetaindLicnse.LicenseID.ToString();
            clsUsers User = clsUsers.Find(UserID);

            lblUsername.Text=User.UserName.ToString();


        }


    }
}
