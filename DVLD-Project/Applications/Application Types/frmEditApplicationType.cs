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
    public partial class frmEditApplicationType : Form
    {
        public frmEditApplicationType(int applicationTypeID)
        {
            InitializeComponent();
            ApplicationTypeID = applicationTypeID;
        }


        int ApplicationTypeID;

        clsApplicationTypes _ApplicationType;
    
        void FillDataToForm()
        {
            _ApplicationType = clsApplicationTypes.Find(ApplicationTypeID);

            lblApplicationID.Text = _ApplicationType.ApplicationTypeID.ToString();
            TxtTitel.Text = _ApplicationType.ApplicationTypeTitle;
            TxtFees.Text = Convert.ToString(_ApplicationType.ApplicationFees);


        }
    
        void UpdateApplicationType()
        {
            _ApplicationType.ApplicationTypeID = Convert.ToInt32(lblApplicationID.Text);
            _ApplicationType.ApplicationTypeTitle = TxtTitel.Text;
            _ApplicationType.ApplicationFees=Convert.ToInt32(TxtFees.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateApplicationType();

            if (_ApplicationType.Save())
                MessageBox.Show("Application Type Succssfilly Updated", "Application Types", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Application Type Does Not Updated", "Application Types", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            FillDataToForm();
        }
    }
}
