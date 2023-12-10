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
    public partial class frmForALlTests : Form
    {
        public frmForALlTests(int llapplicationid,int testForAnyTest, int testappointmentid, int userID)
        {
            InitializeComponent();
            TestForAnyTest = testForAnyTest;
            LLApplicationID = llapplicationid;
            TestAppointmentID = testappointmentid;
            UserID = userID;
        }
        public int LLApplicationID;
        int TestForAnyTest;
        int TestAppointmentID;
        int UserID;
        clsTests _Test;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmForALlTests_Load(object sender, EventArgs e)
        {
            if(TestForAnyTest == 1)
            {
                ctrlVisionTest1.Visible = true;
               
                ctrlWrittenTest1.Visible = false;
                ctrlStreetTest1.Visible = false;

                ctrlVisionTest1.FillDataToControl(LLApplicationID,TestAppointmentID);
                return;
            }
            if (TestForAnyTest == 2)
            {
                ctrlVisionTest1.Visible = false;
               
                ctrlWrittenTest1.Visible = true;
                ctrlStreetTest1.Visible = false;

                ctrlWrittenTest1.FillDataToControl(LLApplicationID, TestAppointmentID);
                return;
            }
            if (TestForAnyTest == 3)
            {
                ctrlVisionTest1.Visible = false;
                ctrlWrittenTest1.Visible = false;
                
                ctrlStreetTest1.Visible = true;
                ctrlStreetTest1.FillDataToControl(LLApplicationID, TestAppointmentID);
                return;
            }
        }


        void FillNewTestObject()
        {
            clsTests Test=new clsTests();
            Test.TestAppointmentID= TestAppointmentID;

            if(RDPass.Checked)
            {
                Test.TestResult = true;
            }
            if(RDFail.Checked)
            {
                Test.TestResult = false;
            }
            Test.CreatedByUserID= UserID;
            Test.Notes = TxtNotes.Text;
            _Test = Test;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            FillNewTestObject();


            if (_Test.Save())           
                MessageBox.Show("Test Added Succssdilly", "Tests", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Test Does Not Added ", "Tests", MessageBoxButtons.OK, MessageBoxIcon.Error);


            clsTestAppointments.UpdateTestAppointmentWhenTakeTest(TestAppointmentID);

            this.Close();
        }
    }
}
