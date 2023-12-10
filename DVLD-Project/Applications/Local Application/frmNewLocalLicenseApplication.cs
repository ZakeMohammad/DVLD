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
    public partial class frmNewLocalLicenseApplication : Form
    {
        public frmNewLocalLicenseApplication(int userID)
        {
            InitializeComponent();
            UserID = userID;
            CurrentUser = clsUsers.Find(UserID);
        }
        int UserID;
        clsUsers CurrentUser;

        clsApplications _Application;

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewLocalLicenseApplication_Load(object sender, EventArgs e)
        {
            DataTable dt = clsApplications.GitALlApplicationsClasses();
            
            foreach(DataRow dr in dt.Rows)
            {
                ComboForClasses.Items.Add(dr["ClassName"]);
            }

            ComboForClasses.SelectedIndex= 0;
            lblUsername.Text = CurrentUser.UserName;
            lblFees.Text = "15";
            LLApplicatoinDate.Text=DateTime.Now.ToShortDateString();
        }


        void FillApplicationWithData()
        {
            clsApplications Application=new clsApplications();
            Application.ApplicationStatus = 1;
            Application.ApplicationDate = DateTime.Now;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = 15;
            Application.CreatedByUserID= UserID;
            Application.ApplicationTypeID = 1;
            Application.ApplicantPersonID = ctrlFindPerson1.PersonID;

            _Application = Application;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FillApplicationWithData();

            if(clsApplications.IsApplicationsExistWithSameStatusAndSamePerson(_Application.ApplicantPersonID,_Application.ApplicationStatus))
            {
                MessageBox.Show($"Choose another license Class, the selected Person Already have an active applicatoin for the selected calss", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
                return;
            }

  



            if (_Application.Save())
            {
                clsLocalDrivingLicenseApplications LocalApplicatoin = new clsLocalDrivingLicenseApplications();

                LocalApplicatoin.ApplicationID = _Application.ApplicationID;

                LocalApplicatoin.LicenseClassID = Convert.ToInt32(ComboForClasses.SelectedIndex + 1);


                if (clsApplications.IsPersonHaveThisLicenseWithThisLicenseClass(_Application.ApplicantPersonID, LocalApplicatoin.LicenseClassID))
                {
                    if (clsApplications.DeleteApplications(_Application.ApplicationID))
                    {
                        MessageBox.Show($"Choose another license Class, the selected Person Already have License For This Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }


                if (LocalApplicatoin.Save())
                {

                    MessageBox.Show($"Applicatoin Added Succssfilly With ID ={LocalApplicatoin.LocalDrivingLicenseApplicationID}", "Local license", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblLLApplicationID.Text = _Application.ApplicationID.ToString();
                }
              
            }             
            else
                MessageBox.Show($"Applicatoin Does Not Added", "Local license", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }
    }
}
