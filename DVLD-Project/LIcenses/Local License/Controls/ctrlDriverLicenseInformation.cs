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
    public partial class ctrlDriverLicenseInformation : UserControl
    {
        public ctrlDriverLicenseInformation()
        {
            InitializeComponent();
        }

       
        public int LicenseID;

       public void FillDataToControl(int licenseid)
        {

            LicenseID = licenseid;

            clsLicenses License = clsLicenses.Find(LicenseID);


            clsApplications Application = clsApplications.Find(License.ApplicationID);

            clsPeoples Person = clsPeoples.Find(Application.ApplicantPersonID);


            lblClassName.Text = clsLicenses.GitClassName(License.LicenseClass).ToString();
            lblPersonName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
            lblLicenseID.Text = LicenseID.ToString();
            lblNationalNo.Text = Person.NationalNo.ToString();
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
             
            lblIssueDate.Text = License.IssueDate.ToShortDateString();
          
            if(License.IssueReason==1)
            {
                lblIssueReason.Text = "First Time";
            }
            if (License.IssueReason == 2)
            {
                lblIssueReason.Text = "Renew";
            }
            if (License.IssueReason == 3)
            {
                lblIssueReason.Text = "Replacement for Damaged";
            }
            if (License.IssueReason == 4)
            {
                lblIssueReason.Text = "Replacement for Lost";
            }

            if(License.Notes=="" || License.Notes==DBNull.Value.ToString())
            {
                lblNotes.Text = "No Notes";
            }

            if(License.IsActive==1)
            {
                lblIsActive.Text = "Yes";
                lblIsActive.ForeColor= System.Drawing.Color.Green;
            }
            if (License.IsActive==0)
            {
                lblIsActive.Text = "No";
                lblIsActive.ForeColor = System.Drawing.Color.Red;
            }

            lblDateOfBirth.Text=Person.DateOfBirth.ToShortDateString();
            lblDriverID.Text=License.DriverID.ToString();
            lblExpirationDate.Text=License.ExpirationDate.ToShortDateString();


           if(clsLicenses.IsLicenseDetaind(LicenseID))
           {
                lblIsDetained.Text = "Yes";
                lblIsDetained.ForeColor= System.Drawing.Color.Red;
           }
           else
           {
                lblIsDetained.Text = "No";
                lblIsDetained.ForeColor = System.Drawing.Color.Green;
           }

            if (Person.ImagePath == "" || Person.ImagePath == DBNull.Value.ToString())
            {
                if (Person.Gendor == 'M')
                    PictreForPerson.Image = Resources.person_boy__1_;
                else
                    PictreForPerson.Image = Resources.person_girl;
            }
            else
            {
                PictreForPerson.Image = Image.FromFile(Person.ImagePath);
            }


        }


    }
}
