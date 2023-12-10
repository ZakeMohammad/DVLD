 using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmManageLLApplications : Form
    {
        public frmManageLLApplications(int userID)
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

        private void frmManageLLApplications_Load(object sender, EventArgs e)
        {
            DataGridViewForLLApplications.DataSource = clsApplications.GitAllLocalLicenseApplications();
            ComboBoxForFillter.SelectedIndex= 0;
            lblNumberOfRows.Text= (DataGridViewForLLApplications.RowCount-1).ToString();
          
        }


        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmNewLocalLicenseApplication New=new frmNewLocalLicenseApplication(UserID);
            New.ShowDialog();
        }

        private void ComboBoxForFillter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxForFillter.SelectedIndex == 0)
            {
                TxtSearchForFillter.Visible = false;
                ComboForStatus.Visible = false;
                DataGridViewForLLApplications.DataSource = clsApplications.GitAllLocalLicenseApplications();
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
            DataTable dt = clsApplications.GitAllLocalLicenseApplications();
            DataView View1 = dt.DefaultView;


            if (ComboBoxForFillter.SelectedIndex == 0)
            {                             
                DataGridViewForLLApplications.DataSource = View1;
            }
            if (ComboBoxForFillter.SelectedIndex == 1)
            {             

                View1.RowFilter = $"NationalNo='{TxtSearchForFillter.Text}'";
                DataGridViewForLLApplications.DataSource = View1;
            }
            if (ComboBoxForFillter.SelectedIndex == 2)
            {
                if (TxtSearchForFillter.Text =="0" || TxtSearchForFillter.Text=="")
                {
                    DataGridViewForLLApplications.DataSource = View1;
                    return;
                }

                View1.RowFilter = $"LocalDrivingLicenseApplicationID={TxtSearchForFillter.Text}";
                DataGridViewForLLApplications.DataSource = View1;
            }

        }

        private void ComboForStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = clsApplications.GitAllLocalLicenseApplications();
            DataView View1 = dt.DefaultView;
            if (ComboForStatus.SelectedIndex == 0)
            {
                DataGridViewForLLApplications.DataSource = View1;
            }
            if (ComboForStatus.SelectedIndex == 1)
            {
                View1.RowFilter = "Status='New'";
                DataGridViewForLLApplications.DataSource = View1;
            }
            if (ComboForStatus.SelectedIndex == 2)
            {
                View1.RowFilter = "Status='Cancelled'";
                DataGridViewForLLApplications.DataSource = View1;
            }
            if (ComboForStatus.SelectedIndex == 3)
            {
                View1.RowFilter = "Status='Completed'";
                DataGridViewForLLApplications.DataSource = View1;
            }
        }

        private void showApplicationDetelisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLLApplicationDetelis New = new frmLLApplicationDetelis((int)DataGridViewForLLApplications.CurrentRow.Cells[0].Value);
            New.ShowDialog();
        }

        private void schduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestsAppointments New = new frmTestsAppointments((int)DataGridViewForLLApplications.CurrentRow.Cells[0].Value,1,UserID);
            New.Show();
        }

        private void schduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestsAppointments New = new frmTestsAppointments((int)DataGridViewForLLApplications.CurrentRow.Cells[0].Value, 2,UserID);
            New.Show();
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestsAppointments New = new frmTestsAppointments((int)DataGridViewForLLApplications.CurrentRow.Cells[0].Value, 3, UserID);
            New.Show();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (clsSheardClassForManyThings.GitStatusForThisLocalDrivingLicenseApplicatoin((int)DataGridViewForLLApplications.CurrentRow.Cells[0].Value) == "Cancelled")
            {
                sechduleTestToolStripMenuItem.Enabled = false;
                cancelApplicatoinToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = true;
                editApplicationToolStripMenuItem.Enabled = false;
                sechduleTestToolStripMenuItem.Enabled = false;
                schduleVisionTestToolStripMenuItem.Enabled = false;
                schduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
                return;
            }
            if (clsSheardClassForManyThings.NumberOfPassidTests((int)DataGridViewForLLApplications.CurrentRow.Cells[0].Value)==0)
            {
                sechduleTestToolStripMenuItem.Enabled = true;
                cancelApplicatoinToolStripMenuItem.Enabled = true;
                deleteApplicationToolStripMenuItem.Enabled = true;
                editApplicationToolStripMenuItem.Enabled = true;
                sechduleTestToolStripMenuItem.Enabled = true;
                schduleVisionTestToolStripMenuItem.Enabled = true;
                schduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
                return;
            }
            if(clsSheardClassForManyThings.NumberOfPassidTests((int)DataGridViewForLLApplications.CurrentRow.Cells[0].Value) == 1)
            {
                sechduleTestToolStripMenuItem.Enabled = true;
                cancelApplicatoinToolStripMenuItem.Enabled = true;
                deleteApplicationToolStripMenuItem.Enabled = true;
                editApplicationToolStripMenuItem.Enabled = true;
                sechduleTestToolStripMenuItem.Enabled = true;
                schduleVisionTestToolStripMenuItem.Enabled = false;
                schduleWrittenTestToolStripMenuItem.Enabled = true;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
                return;
            }
            if (clsSheardClassForManyThings.NumberOfPassidTests((int)DataGridViewForLLApplications.CurrentRow.Cells[0].Value) == 2)
            {
                sechduleTestToolStripMenuItem.Enabled = true;
                cancelApplicatoinToolStripMenuItem.Enabled = true;
                deleteApplicationToolStripMenuItem.Enabled = true;
                editApplicationToolStripMenuItem.Enabled = true;
                sechduleTestToolStripMenuItem.Enabled = true;
                schduleVisionTestToolStripMenuItem.Enabled = false;
                schduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = true;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
                return;
            }
            if (clsSheardClassForManyThings.NumberOfPassidTests((int)DataGridViewForLLApplications.CurrentRow.Cells[0].Value) == 3)
            {
                
                sechduleTestToolStripMenuItem.Enabled = false;
                cancelApplicatoinToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = false;
                if(clsSheardClassForManyThings.GitStatusForThisLocalDrivingLicenseApplicatoin((int)DataGridViewForLLApplications.CurrentRow.Cells[0].Value)=="New")
                {
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                    showLicenseToolStripMenuItem.Enabled = false;
                    return;
                }
                if (clsSheardClassForManyThings.GitStatusForThisLocalDrivingLicenseApplicatoin((int)DataGridViewForLLApplications.CurrentRow.Cells[0].Value) == "Cancelled")
                {
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = false;
                    return;
                }
                else
                {
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = true;
                    return;
                }
               
            }
        }


        void GitRusltIfLicenseAddedOrNot(object sender, bool Ruslt, int ApplicationID, int licenseID)
        {
            //This Only Work When i Create New License , Because This reasons i make another way to git licenseid;
            //LicenseID=licenseID;
           if(Ruslt)
           {
                clsApplications.UpdateStatusForApplication(ApplicationID,3);
           }
        }

   

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewLoclaDrinvingLicense New = new frmAddNewLoclaDrinvingLicense((int)DataGridViewForLLApplications.CurrentRow.Cells[0].Value, UserID);
            New.BackData += GitRusltIfLicenseAddedOrNot;
            New.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            clsLocalDrivingLicenseApplications LLApplication = clsLocalDrivingLicenseApplications.Find((int)DataGridViewForLLApplications.CurrentRow.Cells[0].Value);

            int LicenseID = clsLicenses.GitLicenseID(LLApplication.ApplicationID);


            frmDriverLicenseInformation New = new frmDriverLicenseInformation(LicenseID);
            New.ShowDialog();
        }

        private void cancelApplicatoinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you Sure you whant to cancle this application?","Cancle",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                clsLocalDrivingLicenseApplications LLApplication = clsLocalDrivingLicenseApplications.Find((int)DataGridViewForLLApplications.CurrentRow.Cells[0].Value);
                clsApplications.UpdateStatusForApplication(LLApplication.ApplicationID, 2);
            }


        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure you whant to Delete this application?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsLocalDrivingLicenseApplications LLApplication = clsLocalDrivingLicenseApplications.Find((int)DataGridViewForLLApplications.CurrentRow.Cells[0].Value);


                if (!clsLocalDrivingLicenseApplications.DeleteLocalDrivingLicenseApplications(LLApplication.LocalDrivingLicenseApplicationID))
                {
                    MessageBox.Show("Application Does Not Delete because data inegrety in system ", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                    if (clsApplications.DeleteApplications(LLApplication.ApplicationID))
                    {
                        MessageBox.Show("Application Succssfilly deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Application Does Not Delete because data inegrety in system ", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                
              
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            clsPeoples Person = clsPeoples.Find((string)DataGridViewForLLApplications.CurrentRow.Cells[2].Value);

            frmLicenseHistory New = new frmLicenseHistory(Person.PersonID);
           New.ShowDialog();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DataGridViewForLLApplications.DataSource = clsApplications.GitAllLocalLicenseApplications();
            lblNumberOfRows.Text = (DataGridViewForLLApplications.RowCount - 1).ToString();
        }



    }
}
