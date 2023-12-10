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
    public partial class frmShowPersonInfo : Form
    {
        public frmShowPersonInfo(int personiD)
        {
            InitializeComponent();
            PersonID = personiD;
        }

        public int PersonID;

        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {
            ctrlPersonInformation1.FillDataToUserControlPersonInfoByPersonID(PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   
    }
}
