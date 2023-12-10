using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class ctrlFindPerson : UserControl
    {
        public ctrlFindPerson()
        {
            InitializeComponent();
        }

        public int PersonID;
        public string NationalNO;

        

        public void FillDataToALlControlByPersonID(int personiD)
        {
          
            ctrlPersonInformation1.FillDataToUserControlPersonInfoByPersonID(personiD);
            PersonID= personiD;
            PersonID = ctrlPersonInformation1.PersonID;
        }

        public void FillDataToALlControlByPersonNationalNo(string NationalNo)
        {
           
            ctrlPersonInformation1.FillDataToUserControlPersonInfoByPersonNationaNO(NationalNo);
            NationalNO=ctrlPersonInformation1.NationalNO;
            PersonID= ctrlPersonInformation1.PersonID;
        }


        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text.Length <= 0)
            {
                MessageBox.Show("Plese Enter Person ID To Search","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            if(ComboForSearchBy.SelectedIndex==0)
            {
                if(!clsPeoples.IsPeopleExist(Convert.ToInt32(txtSearch.Text)))
                {
                    MessageBox.Show("The Person Does Not Exist ,, Plese Enter onther one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                FillDataToALlControlByPersonID(Convert.ToInt32(txtSearch.Text));
            }

            if(ComboForSearchBy.SelectedIndex==1)
            {
                if(!clsPeoples.IsPeopleExist(Convert.ToString(txtSearch.Text)))
                {
                    MessageBox.Show("The Person Does Not Exist ,, Plese Enter onther one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                FillDataToALlControlByPersonNationalNo(Convert.ToString(txtSearch.Text));
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_Person New = new frmAdd_Edit_Person(0);
            New.ShowDialog();
        }



    }
}
