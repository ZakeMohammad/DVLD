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
    public partial class frmChangePassword : Form
    {
        public frmChangePassword(int userID)
        {
            InitializeComponent();
            UserID = userID;
           
        }

        int UserID;
        clsUsers _User;


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlUserInformation1.FillDataToUserControl(UserID);
            _User = clsUsers.Find(UserID);
        }

        private void TxtPassword_Validating(object sender, CancelEventArgs e)
        {
            if(TxtPassword.Text!=_User.Password)
            {
                e.Cancel = true;
                TxtPassword.Focus();
                errorProvider1.SetError(TxtPassword, "This Password Does Not Same Orignal one");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtPassword, "");
            }
        }

        private void TxtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (TxtNewPassword.Text.Length<=5)
            {
                e.Cancel = true;
                TxtNewPassword.Focus();
                errorProvider1.SetError(TxtNewPassword, "Plese Enter Password More than 5 latter");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtNewPassword, "");
            }
        }

        private void TxtConfirmNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (TxtConfirmNewPassword.Text != TxtNewPassword.Text)
            {
                e.Cancel = true;
                TxtConfirmNewPassword.Focus();
                errorProvider1.SetError(TxtConfirmNewPassword, "Plese Enter same password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtConfirmNewPassword, "");
            }
        }

        void UpdatePassword()
        {
            _User.Password=TxtNewPassword.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdatePassword();

            if(clsUsers.UpdatePasswordForUsers(UserID,_User.Password))
            {
                MessageBox.Show("Password Change Succssfilly", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password Change Succssfilly", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }
    }
}
