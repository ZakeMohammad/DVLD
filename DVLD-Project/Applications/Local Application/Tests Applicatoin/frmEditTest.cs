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
    public partial class frmEditTest : Form
    {
        public frmEditTest(int testID)
        {
            InitializeComponent();
            TestID = testID;
        }

        int TestID;
        clsTestTypes _Test;

        void FillDataToForm()
        {
            _Test = clsTestTypes.Find(TestID);

            lblTestID.Text = _Test.TestTypeID.ToString();
            TxtTitel.Text = _Test.TestTypeTitle;
            TxtDescription.Text = _Test.TestTypeDescription;
            TxtFees.Text=_Test.TestTypeFees.ToString();

        }

        void UpdateTest()
        {
            _Test.TestTypeID=Convert.ToInt32(lblTestID.Text);
            _Test.TestTypeTitle= TxtTitel.Text;
            _Test.TestTypeDescription= TxtDescription.Text;
            _Test.TestTypeFees=Convert.ToInt32(TxtFees.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditTest_Load(object sender, EventArgs e)
        {
           FillDataToForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateTest();

            if (_Test.Save())
                MessageBox.Show("Test Updated Succssfilly", "Tests", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Test Does Not Updated ", "Tests", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();
        }
    }
}
