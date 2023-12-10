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
    public partial class frmScheduleTest : Form
    {
        public frmScheduleTest(int llapplicationid, int testTypeID,int userid)
        {
            InitializeComponent();
            LLApplicationID = llapplicationid;
            TestTypeID = testTypeID;
            UserID = userid;
        }

        int LLApplicationID;
        int TestTypeID;
        int UserID;
        clsTestAppointments _Appointment;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            if(TestTypeID==1)
            {
                PictreForWhatTest.Image = Resources.eye__1_;
                lblFees.Text = "10";
            }
            if(TestTypeID==2)
            {
                PictreForWhatTest.Image = Resources.test__1_;
                lblFees.Text = "20";
            }
            if(TestTypeID==3)
            {
                PictreForWhatTest.Image = Resources.nascar_racing_car;
                lblFees.Text = "30";
            }

            clsLocalDrivingLicenseApplications LLApplicaatino = clsLocalDrivingLicenseApplications.Find(LLApplicationID);

            clsApplications APPlication = clsApplications.Find(LLApplicaatino.ApplicationID);

            lblLLApplicationID.Text = LLApplicaatino.LocalDrivingLicenseApplicationID.ToString();

            lblCalssName.Text = clsLocalDrivingLicenseApplications.GitApplicationLicenseClassName(LLApplicationID);

            clsPeoples Person = clsPeoples.Find(APPlication.ApplicantPersonID);
            lblPersonName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;

            int NumberOfTrial = clsTests.GitNumberOfTrials(LLApplicationID, 1);
            lblTrials.Text = NumberOfTrial.ToString();
            AppointmentDate.Value= DateTime.Now;
            AppointmentDate.MaxDate=DateTime.Now.AddDays(5);
        }

        void CreateNewAppointment()
        {
            clsTestAppointments appointments= new clsTestAppointments();
            appointments.LocalDrivingLicenseApplicationID = LLApplicationID;
            appointments.CreatedByUserID= UserID;
            appointments.PaidFees = Convert.ToInt32(lblFees.Text);
            appointments.AppointmentDate = AppointmentDate.Value;
            appointments.TestTypeID= TestTypeID;
            appointments.IsLocked = false;
            _Appointment = appointments;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CreateNewAppointment();

            if(_Appointment.Save())
            {
                MessageBox.Show("Schedule Test Added Succssfilly","Test",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Schedule Test Does Not Added", "Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }
    }
}
