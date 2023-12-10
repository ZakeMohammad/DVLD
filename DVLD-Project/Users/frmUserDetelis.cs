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
    public partial class frmUserDetelis : Form
    {
        public frmUserDetelis(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }

        int UserID;



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserDetelis_Load(object sender, EventArgs e)
        {
            ctrlUserInformation1.FillDataToUserControl(UserID);
        }
    }
}
