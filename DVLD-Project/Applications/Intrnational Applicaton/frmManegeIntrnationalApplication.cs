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
    public partial class frmManegeIntrnationalApplication : Form
    {
        public frmManegeIntrnationalApplication(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }
        int UserID;
        public int LicenseID;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManegeIntrnationalApplication_Load(object sender, EventArgs e)
        {
            DataGridViewForIntrnationalApplications.DataSource = clsApplications.GitAllIntrnationalApplications();
            ComboBoxForFillter.SelectedIndex = 0;
            lblNumberOfRows.Text = (DataGridViewForIntrnationalApplications.RowCount - 1).ToString();

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddNewIntrnationalLicense New=new frmAddNewIntrnationalLicense(UserID);
            New.ShowDialog();
        }

        private void ComboBoxForFillter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxForFillter.SelectedIndex == 0)
            {
                TxtSearchForFillter.Visible = false;
                ComboForStatus.Visible = false;
                DataGridViewForIntrnationalApplications.DataSource = clsApplications.GitAllIntrnationalApplications();
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
                TxtSearchForFillter.Visible = true;
                ComboForStatus.Visible = false;
            }
            if (ComboBoxForFillter.SelectedIndex == 4)
            {
                TxtSearchForFillter.Visible = false;
                ComboForStatus.Visible = true;
            }
        }

        private void TxtSearchForFillter_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = clsApplications.GitAllIntrnationalApplications();
            DataView View1 = dt.DefaultView;


            if (ComboBoxForFillter.SelectedIndex == 0)
            {
                DataGridViewForIntrnationalApplications.DataSource = View1;
            }


            if (ComboBoxForFillter.SelectedIndex == 1)
            {
                if (TxtSearchForFillter.Text == "0" || TxtSearchForFillter.Text == "")
                {
                    DataGridViewForIntrnationalApplications.DataSource = View1;
                    return;
                }

                View1.RowFilter = $"InternationalLicenseID='{TxtSearchForFillter.Text}'";
                DataGridViewForIntrnationalApplications.DataSource = View1;
            }


            if (ComboBoxForFillter.SelectedIndex == 2)
            {
                if (TxtSearchForFillter.Text == "0" || TxtSearchForFillter.Text == "")
                {
                    DataGridViewForIntrnationalApplications.DataSource = View1;
                    return;
                }

                View1.RowFilter = $"IssuedUsingLocalLicenseID={TxtSearchForFillter.Text}";
                DataGridViewForIntrnationalApplications.DataSource = View1;
            }


            if (ComboBoxForFillter.SelectedIndex == 3)
            {
                if (TxtSearchForFillter.Text == "0" || TxtSearchForFillter.Text == "")
                {
                    DataGridViewForIntrnationalApplications.DataSource = View1;
                    return;
                }

                View1.RowFilter = $"ApplicationID={TxtSearchForFillter.Text}";
                DataGridViewForIntrnationalApplications.DataSource = View1;
            }
          
        }

        private void ComboForStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = clsApplications.GitAllIntrnationalApplications();
            DataView View1 = dt.DefaultView;
            if (ComboForStatus.SelectedIndex == 0)
            {
                DataGridViewForIntrnationalApplications.DataSource = View1;
            }
            if (ComboForStatus.SelectedIndex == 1)
            {
                View1.RowFilter = "IsActive=1";
                DataGridViewForIntrnationalApplications.DataSource = View1;
            }
            if (ComboForStatus.SelectedIndex == 2)
            {
                View1.RowFilter = "IsActive=0";
                DataGridViewForIntrnationalApplications.DataSource = View1;
            }
            
        }

        private void showPersonDetelisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsApplications Application = clsApplications.Find((int)DataGridViewForIntrnationalApplications.CurrentRow.Cells[1].Value);

            frmShowPersonInfo New = new frmShowPersonInfo(Application.ApplicantPersonID);
            New.ShowDialog();

        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIntrnationlLicenseInfo New = new frmIntrnationlLicenseInfo((int)DataGridViewForIntrnationalApplications.CurrentRow.Cells[0].Value);
            New.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)DataGridViewForIntrnationalApplications.CurrentRow.Cells[2].Value;

            int PersonId = clsDrivers.GitPersonID(DriverID);

            frmLicenseHistory New = new frmLicenseHistory(PersonId);
            New.ShowDialog();
        }



    }
}
