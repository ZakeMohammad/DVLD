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
    public partial class frmManegeDrivers : Form
    {
        public frmManegeDrivers()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
        }

        private void TxtSearchForFillter_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = clsDrivers.GitAllDrivers();

            DataView View1 = dt.DefaultView;


            dataGridView1.DataSource = View1;

            if (ComboBoxForFillter.SelectedIndex == 0 || TxtSearchForFillter.Text == string.Empty)
            {
                dataGridView1.DataSource = View1;
            }
            if (ComboBoxForFillter.SelectedIndex == 1)
            {

                if (TxtSearchForFillter.Text == "0" || TxtSearchForFillter.Text == string.Empty)
                {
                    dataGridView1.DataSource = View1;
                }
                else
                {
                    View1.RowFilter = $"PersonID ={TxtSearchForFillter.Text}";

                }

                dataGridView1.DataSource = View1;
            }

            if (ComboBoxForFillter.SelectedIndex == 2)
            {

                View1.RowFilter = $"NationalNo ='{TxtSearchForFillter.Text}'";
            }
        }

        private void frmManegeDrivers_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsDrivers.GitAllDrivers();
            lblNumberOfRows.Text=dataGridView1.RowCount.ToString();
            ComboBoxForFillter.SelectedIndex= 0;
        }

     
    }
}
