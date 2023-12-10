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
    public partial class frmFindPerson : Form
    {
        public frmFindPerson()
        {
            InitializeComponent();
        }
        public delegate void DataBackEventhandler(object sender, int personid);

        public event DataBackEventhandler BackData;


        int PersonID;
        private void btnBack_Click(object sender, EventArgs e)
        {
            PersonID = ctrlFindPerson1.PersonID;
            BackData.Invoke(this, PersonID);
            this.Close();
        }
    }
}
