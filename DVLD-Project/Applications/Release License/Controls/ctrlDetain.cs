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
    public partial class ctrlDetain : UserControl
    {
        public ctrlDetain()
        {
            InitializeComponent();
        }


        public int Fees;

       public void FillDataToControl(int LicenseID,int UserID)
        {
           
            lblDetaindDate.Text=DateTime.Now.ToShortDateString();
            clsUsers User = clsUsers.Find(UserID);
            lblUsername.Text = User.UserName;



        }

        private void NumberOfFees_ValueChanged(object sender, EventArgs e)
        {
            Fees = Convert.ToInt32(NumberOfFees.Value);
        }


    }
}
