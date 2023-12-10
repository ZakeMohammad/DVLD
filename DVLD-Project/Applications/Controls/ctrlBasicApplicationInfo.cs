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
    public partial class ctrlBasicApplicationInfo : UserControl
    {
        public ctrlBasicApplicationInfo()
        {
            InitializeComponent();
        }


        public int ApplicationID;
        public int PersonID;

        public void FillDataToControl(int applicationID)
        {
            clsApplications Application = clsApplications.Find(applicationID);

            lblApplicatoinID.Text = applicationID.ToString();
            lblFees.Text = Application.PaidFees.ToString();
            if (Application.ApplicationStatus == 1)
            {
                lblType.Text = "New Local Driving license Service";
                lblStatus.Text = "New";
                lblStatus.ForeColor= Color.Blue;
            }
            if (Application.ApplicationStatus == 2)
            {
                lblType.Text = "Cancelled";
                lblStatus.Text = "Cancelled";
                lblStatus.ForeColor= Color.Red;
            }
            if (Application.ApplicationStatus == 3)
            {
                lblType.Text = "Completed Local Driving license Service";
                lblStatus.Text = "Completed";
                lblStatus.ForeColor= Color.Green;
            }

            clsPeoples Person = clsPeoples.Find(Application.ApplicantPersonID);
            PersonID = Person.PersonID;
            lblPersonName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
            lblDate.Text = Application.ApplicationDate.ToShortDateString();
            lblStatusDate.Text = Application.LastStatusDate.ToShortDateString();

            clsUsers User = clsUsers.Find(Application.CreatedByUserID);
            lblUsername.Text = User.UserName;
            ApplicationID = Application.ApplicationID;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo New=new frmShowPersonInfo(PersonID);
            New.ShowDialog();
        }
    }
}
