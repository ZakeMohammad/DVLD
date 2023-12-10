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
    public partial class Form1 : Form
    {
        public Form1(string username)
        {
            InitializeComponent();
            Username = username;
            
        }


        string Username;
       public clsUsers CurrentUser;

        private void newDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi from deeeeep");
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople New = new frmManagePeople();
            New.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers New=new frmManageUsers();    
            New.ShowDialog();
        }

        private void fygjuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetelis New = new frmUserDetelis(CurrentUser.UserID);
            New.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CurrentUser = clsUsers.Find(Username);

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword New = new frmChangePassword(CurrentUser.UserID);
            New.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmLogin Login=new frmLogin();
            Login.Show();
            CurrentUser = null;
            this.Close();
        }

        private void dfghdhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManegeApplictaionTypes New=new frmManegeApplictaionTypes();
            New.ShowDialog();
        }

        private void dfhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes New=new frmManageTestTypes();
            New.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalLicenseApplication New =new frmNewLocalLicenseApplication(CurrentUser.UserID); 
            New.ShowDialog();
        }

        private void qwdqdToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmManageLLApplications New=new frmManageLLApplications(CurrentUser.UserID);  
            New.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManegeDrivers New = new frmManegeDrivers();
            New.ShowDialog();
        }

        private void intrnationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewIntrnationalLicense New= new frmAddNewIntrnationalLicense(CurrentUser.UserID);
            New.ShowDialog();
        }

        private void qwdffffffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManegeIntrnationalApplication New = new frmManegeIntrnationalApplication(CurrentUser.UserID);
            New.ShowDialog();
        }

        private void qwdqqdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicense New=new frmRenewLicense(CurrentUser.UserID);
            New.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmForReplecmentLicense frm = new frmForReplecmentLicense(CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLLApplications frm = new frmManageLLApplications(CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManegeDetainedLicenses frm = new frmManegeDetainedLicenses(CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense(CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void relaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense(CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense(CurrentUser.UserID);
            frm.ShowDialog();
        }
    }
}
