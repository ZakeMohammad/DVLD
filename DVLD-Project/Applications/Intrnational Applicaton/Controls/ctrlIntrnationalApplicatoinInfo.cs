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
    public partial class ctrlIntrnationalApplicatoinInfo : UserControl
    {
        public ctrlIntrnationalApplicatoinInfo()
        {
            InitializeComponent();
        }

     public   int IntrnationalLicenseID;

        public int IntrnationalApplicationID;
        public int LocalLicenseID;
        public int UserID;
        public DateTime ApplicationDate;
        public DateTime IssueDate;
        public DateTime ExpirationDate;
        public double Fees;



       public void FillDataToControl(int loclaLicenseID)
        {
            clsLicenses License = clsLicenses.Find(loclaLicenseID);

          Fees=Convert.ToDouble( clsSheardClassForManyThings.GitFeesForApplicationUseApplicatoinName("New International License"));

            lblFees.Text = Fees.ToString();

            lblLocalLicenseID.Text = License.LicenseID.ToString();

            lblUserID.Text = License.CreatedByUserID.ToString();

            lblApplicatonDate.Text=DateTime.Now.ToShortDateString();

            lblIssueDate.Text = DateTime.Now.ToShortDateString();

            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();

            LocalLicenseID = License.LicenseID;
            UserID=License.CreatedByUserID;
            ApplicationDate=DateTime.Now;
            IssueDate=DateTime.Now;
            ExpirationDate=DateTime.Now.AddYears(1);
        }

    }
}
