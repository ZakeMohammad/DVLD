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
    public partial class frmDriverLicenseInformation : Form
    {
        public frmDriverLicenseInformation(int licenseID,bool IsDetaind=false)
        {
            InitializeComponent();
            LicenseID = licenseID;
            isDetaind= IsDetaind;
        }

        int LicenseID;
        bool isDetaind;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDriverLicenseInformation_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInformation1.FillDataToControl(LicenseID);
        }
    }
}
