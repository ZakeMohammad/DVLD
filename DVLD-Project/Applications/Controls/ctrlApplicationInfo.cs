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
    public partial class ctrlApplicationInfo : UserControl
    {
        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }

       public void FillDataToControls(int LLApplicationID)
       {
            ctrlLLApplication1.FillDataToControl(LLApplicationID);
            clsLocalDrivingLicenseApplications LLApplication = clsLocalDrivingLicenseApplications.Find(LLApplicationID);
            ctrlBasicApplicationInfo1.FillDataToControl(LLApplication.ApplicationID);
       }



    }
}
