using DVLD_BusinessLayer;
using System;
using static System.Console;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DVLD_Project
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


        public string Username="";
        public string Password="";
        bool IsPasswordHide = true;
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int NumberOfTimes = 3;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (TxtUsername.Text == string.Empty || TxtPassword.Text == string.Empty)
            {
                MessageBox.Show("Plese Enter Username / Passwrod", "DVLD", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }

            clsUsers User = clsUsers.Find(TxtUsername.Text.ToString());

            if (User != null)
            {

                if (User.Password == TxtPassword.Text.ToString())
                {
                    Form1 MainFormforuser = new Form1(User.UserName);

                    if(User.IsActive!=1)
                    {
                        MessageBox.Show("Your Acount Desactive Plese Contact With Your Admin", "DVLD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    if(checkBox1.Checked)
                    {
                        string Path = "C:\\Users\\Progr\\OneDrive\\Desktop\\DVLD\\RemeberMe.txt";
                        string Contant = TxtUsername.Text + "#" + TxtPassword.Text;
                       File.WriteAllText(Path, Contant);
                        Username = User.UserName;
                        Password= User.Password;
                    }
                    else
                    {
                      
                        TxtUsername.Text = "";
                        TxtPassword.Text = "";
                    }


                    MainFormforuser.Show();
                    this.Hide();
                }
                else
                {
                    NumberOfTimes--;
                    if (NumberOfTimes == 0)
                    {
                        btnLogin.Enabled = false;

                        TxtPassword.Enabled = false;
                        TxtUsername.Enabled = false;

                        if (MessageBox.Show("❗ You Blocked From Systme, Are You whant to Sin Up Again?", "DVLD", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            btnLogin.Enabled = true;

                            TxtPassword.Enabled = true;
                            TxtUsername.Enabled = true;
                            NumberOfTimes = 3;
                        }
                        else
                        {
                            this.Close();
                            return;
                        }
                    }
                    lblWrongOrNot.Text = $"❗ Wrong Password You Have only {NumberOfTimes} Times";
                }
            }
            else
            {
                MessageBox.Show("User Does Not Exist", "DVLD", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            HidePassword();
            var fileName = "C:\\Users\\Progr\\OneDrive\\Desktop\\DVLD\\RemeberMe.txt";
            string []rawLines = File.ReadAllLines(fileName);

            foreach(string line in rawLines) 
            {
                var Data=line.Split('#');
                Username= Data[0];
                Password= Data[1];
            }
            TxtUsername.Text = Username;
            TxtPassword.Text = Password;
        }

        void ShowPassword()
        {
            IsPasswordHide= false;
            TxtPassword.UseSystemPasswordChar = false;
        }
        void HidePassword()
        {
            IsPasswordHide= true;
            TxtPassword.UseSystemPasswordChar = true;
        }
        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
          HidePassword();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (IsPasswordHide)
            {
                ShowPassword();
            }
            else
            {
                HidePassword();
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
