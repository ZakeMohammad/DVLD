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
    public partial class frmManegeDetainedLicenses : Form
    {
        public frmManegeDetainedLicenses(int userId)
        {
            InitializeComponent();
            UserId = userId;
        }

        int UserId;
        int _PersonID;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManegeDetainedLicenses_Load(object sender, EventArgs e)
        {
            DataGridViewForDetainedLicesns.DataSource = clsDetainedLicenses.GitAllDetainedLicenses();
            if (DataGridViewForDetainedLicesns.RowCount == 0)
                lblNumberOfRows.Text = "0";
            else
                lblNumberOfRows.Text= (DataGridViewForDetainedLicesns.RowCount-1).ToString();

            ComboBoxForFillter.SelectedIndex = 0;
        }

        private void btnDetainedLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm=new frmDetainLicense(UserId);

            frm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DataGridViewForDetainedLicesns.DataSource = clsDetainedLicenses.GitAllDetainedLicenses();
            if (DataGridViewForDetainedLicesns.RowCount == 0)
                lblNumberOfRows.Text = "0";
            else
                lblNumberOfRows.Text = (DataGridViewForDetainedLicesns.RowCount-1).ToString();

            ComboBoxForFillter.SelectedIndex= 0;
        }

        private void ComboBoxForFillter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxForFillter.SelectedIndex == 0)
            {
                TxtSearchForFillter.Visible = false;
                ComboForStatus.Visible = false;
                DataGridViewForDetainedLicesns.DataSource = clsDetainedLicenses.GitAllDetainedLicenses();
            }
            if (ComboBoxForFillter.SelectedIndex == 1)
            {
                TxtSearchForFillter.Visible = true;
                ComboForStatus.Visible = false;

            }
            if (ComboBoxForFillter.SelectedIndex == 2)
            {
                TxtSearchForFillter.Visible = true;
                ComboForStatus.Visible = false;
            }
            if (ComboBoxForFillter.SelectedIndex == 3)
            {
                TxtSearchForFillter.Visible = false;
                ComboForStatus.Visible = true;
            }
        }

        private void TxtSearchForFillter_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = clsDetainedLicenses.GitAllDetainedLicenses();
            DataView View1 = dt.DefaultView;


            if (ComboBoxForFillter.SelectedIndex == 0)
            {
                DataGridViewForDetainedLicesns.DataSource = View1;
            }
            if (ComboBoxForFillter.SelectedIndex == 1)
            {
                if (TxtSearchForFillter.Text == "0" || TxtSearchForFillter.Text == "")
                {
                    DataGridViewForDetainedLicesns.DataSource = View1;
                    return;
                }
                View1.RowFilter = $"DetainID={TxtSearchForFillter.Text}";
                DataGridViewForDetainedLicesns.DataSource = View1;
            }
            if (ComboBoxForFillter.SelectedIndex == 2)
            {
                if (TxtSearchForFillter.Text == "0" || TxtSearchForFillter.Text == "")
                {
                    DataGridViewForDetainedLicesns.DataSource = View1;
                    return;
                }

                View1.RowFilter = $"LicenseID={TxtSearchForFillter.Text}";
                DataGridViewForDetainedLicesns.DataSource = View1;
            }
        }

        private void ComboForStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = clsDetainedLicenses.GitAllDetainedLicenses();
            DataView View1 = dt.DefaultView;

          
            if (ComboForStatus.SelectedIndex == 0)
            {
                View1.RowFilter = "IsReleased=1";
                DataGridViewForDetainedLicesns.DataSource = View1;
            }
            if (ComboForStatus.SelectedIndex == 1)
            {
                View1.RowFilter = "IsReleased=0";
                DataGridViewForDetainedLicesns.DataSource = View1;
            }
           

        }

        private void showPersonDetalisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLicenses License = clsLicenses.Find((int)DataGridViewForDetainedLicesns.CurrentRow.Cells[1].Value);
            int PersonID = clsDrivers.GitPersonID(License.DriverID);
            _PersonID= PersonID;
            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog() ;
        }

        private void showLicenseDetalisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriverLicenseInformation frm = new frmDriverLicenseInformation((int)DataGridViewForDetainedLicesns.CurrentRow.Cells[1].Value);
            frm.ShowDialog() ;
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLicenses License = clsLicenses.Find((int)DataGridViewForDetainedLicesns.CurrentRow.Cells[1].Value);
            int PersonID = clsDrivers.GitPersonID(License.DriverID);
            _PersonID = PersonID;
            frmLicenseHistory frm = new frmLicenseHistory(_PersonID);
            frm.ShowDialog();
        }

        private void btnReleaseDetainedLicesse_Click(object sender, EventArgs e)
        {
          
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense(UserId);
            frm.ShowDialog();
        }



    }
}
