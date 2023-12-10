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
    public partial class frmLicenseHistory : Form
    {
        public frmLicenseHistory(int personID)
        {
            InitializeComponent();
          _PersonID= personID;
        }
        int _PersonID;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {

           

            ctrlFindPerson1.FillDataToALlControlByPersonID(_PersonID);

         
            int ApplicationID=clsInternationalLicenses.GitIntrnationalApplicationIDUsingPersonID(_PersonID);

            ctrlDriverLicenses1.FillDataToControl(_PersonID,ApplicationID);

        }

    
    }
}
