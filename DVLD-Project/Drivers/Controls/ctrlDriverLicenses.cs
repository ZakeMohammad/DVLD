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
    public partial class ctrlDriverLicenses : UserControl
    {
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        public void FillDataToControl(int PersonID,int ApplicationID)
        {
            DataGridVewForLocal.DataSource=clsLicenses.GitAllLocalLicenseHistoryForPerson(PersonID);

            DataGridVewForIntrnatoinal.DataSource=clsLicenses.GitAllIntrnationalLicenseHistroyForPerson(ApplicationID);


            if (DataGridVewForLocal.RowCount == 0)
                lblNumberOfLocalLicense.Text = "0";
            else
            lblNumberOfLocalLicense.Text=(DataGridVewForLocal.RowCount-1).ToString();


            if (DataGridVewForIntrnatoinal.RowCount == 0)
                lblNumberOfInternationalLicense.Text = "0";
            else
                lblNumberOfInternationalLicense.Text = (DataGridVewForIntrnatoinal.RowCount - 1).ToString();

        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriverLicenseInformation frm=new frmDriverLicenseInformation((int)DataGridVewForLocal.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showLicenseInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmIntrnationlLicenseInfo frm = new frmIntrnationlLicenseInfo((int)DataGridVewForIntrnatoinal.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
