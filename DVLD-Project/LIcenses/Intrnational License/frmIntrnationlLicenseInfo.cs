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
    public partial class frmIntrnationlLicenseInfo : Form
    {
        public frmIntrnationlLicenseInfo(int licesneID)
        {
            InitializeComponent();
            LicesneID = licesneID;
        }

        int LicesneID;

        private void frmIntrnationlLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlIntrnationalLicenseInfo1.FillDataToControl(LicesneID);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
