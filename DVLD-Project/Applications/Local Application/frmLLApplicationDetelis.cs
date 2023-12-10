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
    public partial class frmLLApplicationDetelis : Form
    {
        public frmLLApplicationDetelis(int llapplicationid)
        {
            InitializeComponent();
            LLApplicationID= llapplicationid;
        }

        int LLApplicationID;





        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLLApplicationDetelis_Load(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplications LocalApplication = clsLocalDrivingLicenseApplications.Find(LLApplicationID);

            ctrlApplicationInfo1.FillDataToControls(LLApplicationID);


        }
    }
}
