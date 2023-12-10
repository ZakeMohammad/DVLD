using DVLD_BusinessLayer;
using DVLD_Project.Properties;
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
    public partial class ctrlIntrnationalLicenseInfo : UserControl
    {
        public ctrlIntrnationalLicenseInfo()
        {
            InitializeComponent();
        }

        public int LicenseID;

        public void FillDataToControl(int licenseid)
        {

            LicenseID = licenseid;

            clsInternationalLicenses licenses = clsInternationalLicenses.Find(licenseid);


            clsApplications Application = clsApplications.Find(licenses.ApplicationID);

            clsPeoples Person = clsPeoples.Find(Application.ApplicantPersonID);


           
            lblPersonName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
            lblLicenseID.Text = LicenseID.ToString();
          
            if (Person.Gendor == 1)
            {
                PictreGender.Image = Resources.administrator;
                lblGender.Text = "Male";
            }
            if (Person.Gendor == 2)
            {
                PictreGender.Image = Resources.patient_girl;
                lblGender.Text = "Female";
            }

            lblIssueDate.Text = licenses.IssueDate.ToShortDateString();
            lblExpirationDate.Text = licenses.IssueDate.AddYears(1).ToShortDateString();



            lblIssueReason.Text = "Intrnational License";
                lblNotes.Text = "No Notes";
            
            if (licenses.IsActive == 1)
            {
                lblIsActive.Text = "Yes";
                lblIsActive.ForeColor = System.Drawing.Color.Green;
            }
            if (licenses.IsActive == 0)
            {
                lblIsActive.Text = "No";
                lblIsActive.ForeColor = System.Drawing.Color.Red;
            }


        }


    }
}
