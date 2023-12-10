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
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {

            DataTable dt = clsPeoples.GitAllPeople();

            DataView View1 = dt.DefaultView;


            DataGridViewForPeople.DataSource = View1;
          lblNumberOfRows.Text= View1.Count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_Person New = new frmAdd_Edit_Person(0);
            New.Show();
        }

        private void ComboBoxForFillter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxForFillter.SelectedIndex == 0)
            {
                TxtSearchForFillter.Visible = false;
            }

            if (ComboBoxForFillter.SelectedIndex == 1)
            {
                TxtSearchForFillter.Visible = true;                
            }
            if (ComboBoxForFillter.SelectedIndex == 2)
            {
                TxtSearchForFillter.Visible = true;
            }
            if (ComboBoxForFillter.SelectedIndex == 3)
            {
                TxtSearchForFillter.Visible = true;
            }
            if (ComboBoxForFillter.SelectedIndex == 4)
            {
                TxtSearchForFillter.Visible = true;
            }
            if (ComboBoxForFillter.SelectedIndex == 5)
            {
                TxtSearchForFillter.Visible = true;
            }
            if (ComboBoxForFillter.SelectedIndex == 6)
            {
                TxtSearchForFillter.Visible = true;
            }
            if (ComboBoxForFillter.SelectedIndex == 7)
            {
                TxtSearchForFillter.Visible = true;
            }
        }

        private void TxtSearchForFillter_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = clsPeoples.GitAllPeople();

            DataView View1 = dt.DefaultView;

            
            DataGridViewForPeople.DataSource = View1;

            if (ComboBoxForFillter.SelectedIndex == 0 || TxtSearchForFillter.Text==string.Empty)
            {
                DataGridViewForPeople.DataSource = View1;
            }
            if (ComboBoxForFillter.SelectedIndex == 1)
            {
               
                if (TxtSearchForFillter.Text == "0" || TxtSearchForFillter.Text == string.Empty)
                {
                    DataGridViewForPeople.DataSource = View1;
                }
                else
                {
                   
                    View1.RowFilter = $"PersonID ={TxtSearchForFillter.Text}";

                }

                DataGridViewForPeople.DataSource = View1;
            }

            if(ComboBoxForFillter.SelectedIndex == 2)
            {
              
                View1.RowFilter = $"NationalNo ='{TxtSearchForFillter.Text}'";
            }
            if (ComboBoxForFillter.SelectedIndex == 3)
            {
               
                View1.RowFilter = $"FirstName ='{TxtSearchForFillter.Text}'";
            }
            if (ComboBoxForFillter.SelectedIndex == 4)
            {
                View1.RowFilter = $"Gender ='{TxtSearchForFillter.Text}'";
            }
            if (ComboBoxForFillter.SelectedIndex == 5)
            {
                
                View1.RowFilter = $"Phone ='{TxtSearchForFillter.Text}'";
            }
            if (ComboBoxForFillter.SelectedIndex == 6)
            {
               
                View1.RowFilter = $"Email ='{TxtSearchForFillter.Text}'";
            }
            if (ComboBoxForFillter.SelectedIndex == 7)
            {
                View1.RowFilter = $"Address ='{TxtSearchForFillter.Text}'";
            }


        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo New = new frmShowPersonInfo((int)DataGridViewForPeople.CurrentRow.Cells[0].Value);
            New.ShowDialog();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_Person New = new frmAdd_Edit_Person((int)DataGridViewForPeople.CurrentRow.Cells[0].Value);
            New.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented Yet","Send Email",MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
        }

        private void phoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented Yet", "Phone Cal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if(clsPeoples.DeletePeople((int)DataGridViewForPeople.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("Person Succssdilly Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Person Does not deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
}
