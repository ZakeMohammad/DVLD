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
    public partial class frmAdd_Edit_User : Form
    {
        public frmAdd_Edit_User(int useriD)
        {
            InitializeComponent();
            UserID = useriD;
        }

        int UserID;

        public int PersonID;
        clsUsers _User;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            DataTable dt=clsUsers.GitAllUsers();

            foreach(DataRow Row in dt.Rows)
            {
                if ((int)Row["PersonID"]==PersonID)
                {
                    MessageBox.Show("This Person Is Alredy Admin. Plese Chose another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnNext.Enabled = false;
                    btnSave.Enabled = false;
                 
                    return;
                }
                else
                {
                    btnNext.Enabled = true;
                    btnSave.Enabled = true;
                   
                    tabControl1.SelectTab(1);
                }
            }


           
        }

        private void btnSelectPerson_Click(object sender, EventArgs e)
        {
            frmFindPerson New=new frmFindPerson();
            New.BackData += FillDataSheWasDelegeted;
            New.ShowDialog();
        }

        void FillDataSheWasDelegeted(object sender,int Personid)
        {
            PersonID= Personid;
            ctrlPersonInformation1.FillDataToUserControlPersonInfoByPersonID(Personid);
        }

        private void TxtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(clsUsers.IsUsersExist(TxtUserName.Text))
            {
                e.Cancel = true;
                TxtUserName.Focus();
                errorProvider1.SetError(TxtUserName, "There Are another username like this username");
            }
            else 
            { 
                e.Cancel = false;
                errorProvider1.SetError(TxtUserName, "");
            }
        }

        private void TxtPassword_Validating(object sender, CancelEventArgs e)
        {
            if(TxtPassword.Text==string.Empty || TxtPassword.Text.Length<=5)
            {

                e.Cancel = true;
                TxtPassword.Focus();
                errorProvider1.SetError(TxtPassword, "Plese Enter Password wiht mininum 6 latter");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtPassword, "");
            }
        }

        private void TxtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (TxtConfirmPassword.Text !=TxtPassword.Text)
            {

                e.Cancel = true;
                TxtConfirmPassword.Focus();
                errorProvider1.SetError(TxtConfirmPassword, "Plese Write Same Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtConfirmPassword, "");
            }
        }

        
        void FillDataToFormForUpdate()
        {
            clsUsers User = clsUsers.Find(UserID);
            ctrlPersonInformation1.FillDataToUserControlPersonInfoByPersonID(User.PersonID);
            TxtUserName.Text=User.UserName; 
            TxtPassword.Text=User.Password;
            TxtConfirmPassword.Text = User.Password;
            lblUserID.Text=User.UserID.ToString();
            if(User.IsActive==1)
            {
                CHIsActive.Checked=true;
            }
            else
            { 
                CHIsActive.Checked=false;
            }

        }

        void UpdateUser()
        {
            clsUsers User = clsUsers.Find(UserID);
            User.PersonID = User.PersonID;
            User.UserID = Convert.ToInt32(lblUserID.Text);
            User.UserName=TxtUserName.Text;
            User.Password=TxtPassword.Text;

            if (CHIsActive.Checked)
            {
                User.IsActive = 1;
            }
            else
                User.IsActive = 0;
            _User = User;
        }
        void FillNewUserWihtPerosnID(int personid)
        {
            clsUsers User= new clsUsers();
            clsPeoples Person=clsPeoples.Find(personid);

            User.PersonID= Person.PersonID;
            User.UserName=TxtUserName.Text;
            User.Password=TxtPassword.Text;
            if(CHIsActive.Checked)
            {
                User.IsActive = 1;
            }
            if(!CHIsActive.Checked)
            {
                User.IsActive = 0;
            }
          _User= User;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(UserID!=0)
            {
                UpdateUser();
                if (_User.Save())
                {
                    MessageBox.Show("User Added Succssdilly", "Users", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblUserID.Text = _User.UserID.ToString();
                }
                else
                    MessageBox.Show("User Does Not Added ", "Users", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
                return;
            }


            FillNewUserWihtPerosnID(PersonID);
            if (_User.Save())
            {
                MessageBox.Show("User Added Succssdilly", "Users", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblUserID.Text=_User.UserID.ToString();
            }               
            else
                MessageBox.Show("User Does Not Added ", "Users", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
           
        }

        private void frmAdd_Edit_User_Load(object sender, EventArgs e)
        {
            if(UserID!=0)
            {
                FillDataToFormForUpdate();
                this.Text = "Update User";
                lblForWhat.Text = "Update User";
                btnSelectPerson.Enabled= false;
                tabPage2.Enabled = false;
            }
        }
    }
}
