using DVLD_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsInternationalLicenses
    {

        public enum enMode { Add, Update }
        public enMode Mode;
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        private clsInternationalLicenses(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, int IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            this.Mode = enMode.Update;
        }
        public clsInternationalLicenses()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = -1;
            this.CreatedByUserID = -1;

            this.Mode = enMode.Add;
        }
        private bool _AddInternationalLicenses()
        {
            this.InternationalLicenseID = clsInternationalLicensesData.AddNewInternationalLicenses(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
            return (this.InternationalLicenseID != -1);
        }
        private bool _UpdateInternationalLicenses()
        {
            return clsInternationalLicensesData.UpdateInternationalLicenses(this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Update:
                    {
                        return _UpdateInternationalLicenses();
                    }
                case enMode.Add:
                    {
                        if (_AddInternationalLicenses())
                        {
                            this.Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
            }
            return false;
        }
        public static bool DeleteInternationalLicenses(int InternationalLicenseID)
        {
            return clsInternationalLicensesData.DeleteInternationalLicenses(InternationalLicenseID);
        }
        public static DataTable GitAllInternationalLicenses()
        {
            return clsInternationalLicensesData.GitAllInternationalLicenses();
        }
        public static clsInternationalLicenses Find(int InternationalLicenseID)
        {
            int Column2 = 0;
            int Column3 = 0;
            int Column4 = 0;
            DateTime Column5 = DateTime.Now;
            DateTime Column6 = DateTime.Now;
            int Column7 = 0;
            int Column8 = 0;

            if (clsInternationalLicensesData.Find(InternationalLicenseID, ref Column2, ref Column3, ref Column4, ref Column5, ref Column6, ref Column7, ref Column8))
                return new clsInternationalLicenses(InternationalLicenseID, Column2, Column3, Column4, Column5, Column6, Column7, Column8);
            else
                return null;
        }


        public static int GitIntrnationalLicenseApplicatoinID(int LocalLicenseID)
        {
            return clsInternationalLicensesData.GitIntrnationalLicenseApplicatoinID(LocalLicenseID);
        }

        public static int GitIntrnationalApplicationIDUsingPersonID(int PersonID)
        {

            int DriverID = 0;

            DataTable dt = clsDrivers.GitAllDrivers();

            foreach(DataRow Row in dt.Rows)
            {
                if ((int)Row["PersonID"] == PersonID)
                    DriverID = (int)Row["DriverID"];
            }

            return clsInternationalLicensesData.GitIntrnationalApplicationIDUsingDriverID(DriverID) ;
        }



    }
}
