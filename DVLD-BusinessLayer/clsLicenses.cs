using DVLD_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLicenses
    {
        public enum enMode { Add, Update }
        public enMode Mode;
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public int PaidFees { get; set; }
        public int IsActive { get; set; }
        public int IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        private clsLicenses(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, int PaidFees, int IsActive, int IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this.Mode = enMode.Update;
        }
        public clsLicenses()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = -1;
            this.IsActive = 0;
            this.IssueReason = -1;
            this.CreatedByUserID = -1;

            this.Mode = enMode.Add;
        }
        private bool _AddLicenses()
        {
            this.LicenseID = clsLicensesData.AddNewLicenses(this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);
            return (this.LicenseID != -1);
        }
        private bool _UpdateLicenses()
        {
            return clsLicensesData.UpdateLicenses(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Update:
                    {
                        return _UpdateLicenses();
                    }
                case enMode.Add:
                    {
                        if (_AddLicenses())
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
        public static bool DeleteLicenses(int LicenseID)
        {
            return clsLicensesData.DeleteLicenses(LicenseID);
        }
        public static DataTable GitAllLicenses()
        {
            return clsLicensesData.GitAllLicenses();
        }
        public static clsLicenses Find(int LicenseID)
        {
            int Column2 = 0;
            int Column3 = 0;
            int Column4 = 0;
            DateTime Column5 = DateTime.Now;
            DateTime Column6 = DateTime.Now;
            string Column7 = "";
            int Column8 = 0;
            int Column9 = 0;
            int Column10 = 0;
            int Column11 = 0;

            if (clsLicensesData.Find(LicenseID, ref Column2, ref Column3, ref Column4, ref Column5, ref Column6, ref Column7, ref Column8, ref Column9, ref Column10, ref Column11))
                return new clsLicenses(LicenseID, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9, Column10, Column11);
            else
                return null;
        }



        public static string GitClassName(int LicenseID)
        {
            return clsLicensesData.GitClassName(LicenseID);
        }

        public static int GitLicenseID(int ApplicationID)
        {
            return clsLicensesData.GitLicenseID(ApplicationID);
        }


        public static DataTable GitAllLocalLicenseHistoryForPerson(int PersonID)
        {
            return clsLicensesData.GitAllLocalLicenseHistoryForPerson(PersonID);
        }

        public static bool DeActiveLicense(int LicenseID)
        {
            return clsLicensesData.DeActiveLicense(LicenseID);
        }

        public static DataTable GitAllIntrnationalLicenseHistroyForPerson(int ApplicationID)
        {
            return clsLicensesData.GitAllIntrnationalLicenseHistroyForPerson(ApplicationID);
        }
        public static bool IsLicenseDetaind(int LicenseID)
        {
            return clsLicensesData.IsLicenseDetaind(LicenseID);
        }
    }
}
