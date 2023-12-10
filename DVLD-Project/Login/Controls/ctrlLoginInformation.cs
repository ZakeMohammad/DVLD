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
    public partial class ctrlLoginInformation : UserControl
    {
        public ctrlLoginInformation()
        {
            InitializeComponent();
        }


        int UserID;
   
      public  void FillDataToLoginControl(int Userid)
        {
            clsUsers User = clsUsers.Find(Userid);

            lblUserID.Text=User.UserID.ToString();
            lblUsername.Text=User.UserName.ToString();
            UserID = Userid;
            if (User.IsActive==1)
            {
                lblIsActive.Text = "Yes";
                lblIsActive.ForeColor= Color.Green;
                return;
            }
            if (User.IsActive ==0)
            {
                lblIsActive.Text = "No";
                lblIsActive.ForeColor = Color.Red;
            }
           
        }


    }
}
