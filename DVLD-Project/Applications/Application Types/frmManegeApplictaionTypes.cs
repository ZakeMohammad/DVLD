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
    public partial class frmManegeApplictaionTypes : Form
    {
        public frmManegeApplictaionTypes()
        {
            InitializeComponent();
        }

        private void frmManegeApplictaionTypes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsApplicationTypes.GitAllApplicationTypes();
            lblNumberOfRows.Text=(dataGridView1.RowCount-1).ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType New = new frmEditApplicationType((int)dataGridView1.CurrentRow.Cells[0].Value);
            New.ShowDialog();
        }
    }
}
