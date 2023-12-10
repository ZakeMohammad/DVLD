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
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

   

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            DataGridViewForUsers.DataSource = clsUsers.GitAllUsers();
            ComboBoxForFillter.SelectedIndex= 0;
            lblNumberOfRows.Text=( DataGridViewForUsers.Rows.Count -1).ToString();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboBoxForFillter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ComboBoxForFillter.SelectedIndex==0)
            {
                TxtSearchForFillter.Enabled = false;
                ComboForActiveStatus.Enabled = false;
            }
            if (ComboBoxForFillter.SelectedIndex == 1)
            {
                TxtSearchForFillter.Enabled = true;
                ComboForActiveStatus.Enabled = false;

            }
            if (ComboBoxForFillter.SelectedIndex == 2)
            {
                TxtSearchForFillter.Enabled = true;
                ComboForActiveStatus.Enabled = false;
            }
            if (ComboBoxForFillter.SelectedIndex == 3)
            {
                TxtSearchForFillter.Enabled = false;
                ComboForActiveStatus.Enabled = true;
            }


        }

        private void TxtSearchForFillter_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = clsUsers.GitAllUsers();
            DataView View1 = dt.DefaultView;


            if (ComboBoxForFillter.SelectedIndex == 0)
            {
                TxtSearchForFillter.Text=string.Empty;
                ComboForActiveStatus.SelectedIndex= 0;
               
                DataGridViewForUsers.DataSource = View1;
            }
            if (ComboBoxForFillter.SelectedIndex == 1)
            {
                if (TxtSearchForFillter.Text == "0" || TxtSearchForFillter.Text==string.Empty)
                    DataGridViewForUsers.DataSource = View1;
                else
                    View1.RowFilter = $"UserID={TxtSearchForFillter.Text}";

                DataGridViewForUsers.DataSource = View1;
            }
            if (ComboBoxForFillter.SelectedIndex == 2)
            {
                if (TxtSearchForFillter.Text =="0" || TxtSearchForFillter.Text == string.Empty)
                    DataGridViewForUsers.DataSource = View1;
                else
                View1.RowFilter = $"PersonID={TxtSearchForFillter.Text}";

                DataGridViewForUsers.DataSource = View1;
            }
           
        }

        private void ComboForActiveStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = clsUsers.GitAllUsers();
            DataView View1 = dt.DefaultView;
            if (ComboForActiveStatus.SelectedIndex == 0)
            {
                DataGridViewForUsers.DataSource = View1;
            }
            if (ComboForActiveStatus.SelectedIndex == 1)
            {
                View1.RowFilter = "IsActive=1";
                DataGridViewForUsers.DataSource = View1;
            }
            if (ComboForActiveStatus.SelectedIndex == 2)
            {
                View1.RowFilter = "IsActive=0";
                DataGridViewForUsers.DataSource = View1;
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_User New=new frmAdd_Edit_User(0);
            New.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void showDetalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetelis New = new frmUserDetelis((int)DataGridViewForUsers.CurrentRow.Cells[0].Value);
            New.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_User New = new frmAdd_Edit_User((int)DataGridViewForUsers.CurrentRow.Cells[0].Value);
            New.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented Yet", "Send Email", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void phoneCalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented Yet", "Phone Cal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword New= new frmChangePassword((int)DataGridViewForUsers.CurrentRow.Cells[0].Value);
            New.ShowDialog();
        }
    }
}
