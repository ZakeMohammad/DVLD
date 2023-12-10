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
    public partial class ctrlWrittenTest : UserControl
    {
        public ctrlWrittenTest()
        {
            InitializeComponent();
        }

        public void FillDataToControl( int LLApplicationID, int TestAppointmentID)
        {
            clsLocalDrivingLicenseApplications LLApplicaatino = clsLocalDrivingLicenseApplications.Find(LLApplicationID);

            clsApplications APPlication = clsApplications.Find(LLApplicaatino.ApplicationID);

            lblLLApplicationID.Text = LLApplicaatino.LocalDrivingLicenseApplicationID.ToString();

            lblCalssName.Text = clsLocalDrivingLicenseApplications.GitApplicationLicenseClassName(LLApplicationID);

            clsPeoples Person = clsPeoples.Find(APPlication.ApplicantPersonID);
            lblPersonName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;

            int NumberOfTrial = clsTests.GitNumberOfTrials(LLApplicationID, 1);
            lblTrials.Text = NumberOfTrial.ToString();
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = "20";
            int TestID = clsTests.GitTestID(TestAppointmentID);
            if (TestID == 0)
            {
                lblTestID.Text = "Not Taken Yet";
            }
            else
            {
               
                lblTestID.Text = TestID.ToString();
            }

        }



    }
}
