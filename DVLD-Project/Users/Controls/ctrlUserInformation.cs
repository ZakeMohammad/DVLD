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
    public partial class ctrlUserInformation : UserControl
    {
        public ctrlUserInformation()
        {
            InitializeComponent();
        }



        public void FillDataToUserControl(int userid)
        {
            clsUsers User=clsUsers.Find(userid);
            ctrlPersonInformation1.FillDataToUserControlPersonInfoByPersonID(User.PersonID);
            ctrlLoginInformation1.FillDataToLoginControl(User.UserID);
        }







    }
}
