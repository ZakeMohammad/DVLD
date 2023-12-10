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
    public partial class ctrlLLApplication : UserControl
    {
        public ctrlLLApplication()
        {
            InitializeComponent();
        }


        public int LLApplicationID { get; set; }



        public void FillDataToControl(int llAPplicationID)
        {
            clsLocalDrivingLicenseApplications LLApplicaiton=clsLocalDrivingLicenseApplications.Find(llAPplicationID);

           DataTable dt = clsApplications.GitAllLocalLicenseApplications();
            string ClassName = "";
            int NumberOfPassdTest = 0;
            foreach(DataRow Row in dt.Rows)
            {
                if (llAPplicationID == (int)Row["LocalDrivingLicenseApplicationID"])
                {
                    ClassName = (string)Row["ClassName"];
                    NumberOfPassdTest = (int)Row["PassedTestCount"];
                }
            }

            lblClassName.Text = ClassName;
            lblLLApplicationID.Text=llAPplicationID.ToString();
            lblHowManyPassdTest.Text=NumberOfPassdTest.ToString();

        }


    }
}
