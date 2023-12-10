using DVLD_BusinessLayer;
using DVLD_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmTestsAppointments : Form
    {
        public frmTestsAppointments(int lLApplicationID,int forWhatThisAppointments,int userID)
        {
            InitializeComponent();
            LLApplicationID = lLApplicationID;
            ForWhatThisAppointments= forWhatThisAppointments;
            UserID = userID;
        }


        public int LLApplicationID;
        public int ForWhatThisAppointments;
        public int UserID;
        private void frmVisionTestAppointments_Load(object sender, EventArgs e)
        {
          
            ctrlApplicationInfo1.FillDataToControls(LLApplicationID);

            if(ForWhatThisAppointments==1)
            {
                lblForWhat.Text = "Vision Test Appointment";
                this.Text = "Vision Test Appointment";
                PictreForWhatTest.Image = Resources.eye__1_;
                btnAddNewAppintemnt.Tag = 1;
                DataGridVeiwForALlAppointments.DataSource = clsTestAppointments.GitAllTestAppointments(1, LLApplicationID);
                if (!(DataGridVeiwForALlAppointments.RowCount == 0))
                    lblNumberOfRows.Text = (DataGridVeiwForALlAppointments.RowCount - 1).ToString();
                else
                    lblNumberOfRows.Text = (DataGridVeiwForALlAppointments.RowCount).ToString();
            }
            if(ForWhatThisAppointments==2)
            {
                lblForWhat.Text = "Written Test Appointment";
                this.Text = "Written Test Appointment";
                PictreForWhatTest.Image = Resources.test__1_;
                btnAddNewAppintemnt.Tag = 2;
                DataGridVeiwForALlAppointments.DataSource = clsTestAppointments.GitAllTestAppointments(2, LLApplicationID);
                if (!(DataGridVeiwForALlAppointments.RowCount == 0))
                    lblNumberOfRows.Text = (DataGridVeiwForALlAppointments.RowCount - 1).ToString();
                else
                    lblNumberOfRows.Text = (DataGridVeiwForALlAppointments.RowCount).ToString();
                this.Text = "Written Test Appointment";
            }
            if (ForWhatThisAppointments == 3)
            {
                lblForWhat.Text = "Street Test Appointment";
                this.Text = "Street Test Appointment";
                PictreForWhatTest.Image = Resources.nascar_racing_car;
                btnAddNewAppintemnt.Tag = 3;
                DataGridVeiwForALlAppointments.DataSource = clsTestAppointments.GitAllTestAppointments(3, LLApplicationID);
                if(!(DataGridVeiwForALlAppointments.RowCount==0))
                lblNumberOfRows.Text = (DataGridVeiwForALlAppointments.RowCount - 1).ToString();
                else
                    lblNumberOfRows.Text = (DataGridVeiwForALlAppointments.RowCount).ToString();
                this.Text = "Street Test Appointment";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void taleTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmForALlTests New = new frmForALlTests(LLApplicationID, ForWhatThisAppointments, (int)DataGridVeiwForALlAppointments.CurrentRow.Cells[0].Value,UserID);
            New.ShowDialog();
        }

        private void btnAddNewAppintemnt_Click(object sender, EventArgs e)
        {

            if(clsTestAppointments.IsThereAnyTestAppointmentActive(LLApplicationID))
            {
                MessageBox.Show("You Cant Make New Appointment while you have already active appointment","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAddNewAppintemnt.Enabled= false;
                return;
            }    

            frmScheduleTest New = new frmScheduleTest(LLApplicationID,ForWhatThisAppointments,UserID);
            New.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(clsTestAppointments.IsTestAppointmentLocked((int)DataGridVeiwForALlAppointments.CurrentRow.Cells[0].Value))
            {
                taleTestToolStripMenuItem.Enabled = false;
             
                return;
            }
        }

        private void DataGridVeiwForALlAppointments_MouseClick(object sender, MouseEventArgs e)
        {
            if (clsTestAppointments.IsTestAppointmentLocked((int)DataGridVeiwForALlAppointments.CurrentRow.Cells[0].Value))
            {
                taleTestToolStripMenuItem.Enabled = false;
              
                return;
            }
            else
            {
                taleTestToolStripMenuItem.Enabled = true;
               
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ctrlApplicationInfo1.FillDataToControls(LLApplicationID);

            if (ForWhatThisAppointments == 1)
            {
                DataGridVeiwForALlAppointments.DataSource = clsTestAppointments.GitAllTestAppointments(1, LLApplicationID);
                if (!(DataGridVeiwForALlAppointments.RowCount == 0))
                    lblNumberOfRows.Text = (DataGridVeiwForALlAppointments.RowCount - 1).ToString();
                else
                    lblNumberOfRows.Text = (DataGridVeiwForALlAppointments.RowCount).ToString();
            }
            if (ForWhatThisAppointments == 2)
            {
                DataGridVeiwForALlAppointments.DataSource = clsTestAppointments.GitAllTestAppointments(2, LLApplicationID);
                if (!(DataGridVeiwForALlAppointments.RowCount == 0))
                    lblNumberOfRows.Text = (DataGridVeiwForALlAppointments.RowCount - 1).ToString();
                else
                    lblNumberOfRows.Text = (DataGridVeiwForALlAppointments.RowCount).ToString();
                this.Text = "Written Test Appointment";
            }
            if (ForWhatThisAppointments == 3)
            {
                DataGridVeiwForALlAppointments.DataSource = clsTestAppointments.GitAllTestAppointments(3, LLApplicationID);
                if (!(DataGridVeiwForALlAppointments.RowCount == 0))
                    lblNumberOfRows.Text = (DataGridVeiwForALlAppointments.RowCount - 1).ToString();
                else
                    lblNumberOfRows.Text = (DataGridVeiwForALlAppointments.RowCount).ToString();
                this.Text = "Street Test Appointment";
            }

        }
    }
}
