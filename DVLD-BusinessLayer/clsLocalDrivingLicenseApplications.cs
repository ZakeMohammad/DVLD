using DVLD_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLocalDrivingLicenseApplications
    {


        public enum enMode { Add, Update }
        public enMode Mode;
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        private clsLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;

            this.Mode = enMode.Update;
        }
        public clsLocalDrivingLicenseApplications()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;

            this.Mode = enMode.Add;
        }
        private bool _AddLocalDrivingLicenseApplications()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsData.AddNewLocalDrivingLicenseApplications(this.ApplicationID, this.LicenseClassID);
            return (this.LocalDrivingLicenseApplicationID != -1);
        }
        private bool _UpdateLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsData.UpdateLocalDrivingLicenseApplications(this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Update:
                    {
                        return _UpdateLocalDrivingLicenseApplications();
                    }
                case enMode.Add:
                    {
                        if (_AddLocalDrivingLicenseApplications())
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
        public static bool DeleteLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationsData.DeleteLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID);
        }
        public static DataTable GitAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsData.GitAllLocalDrivingLicenseApplications();
        }
        public static clsLocalDrivingLicenseApplications Find(int LocalDrivingLicenseApplicationID)
        {
            int Column2 = 0;
            int Column3 = 0;

            if (clsLocalDrivingLicenseApplicationsData.Find(LocalDrivingLicenseApplicationID, ref Column2, ref Column3))
                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, Column2, Column3);
            else
                return null;
        }


        public static string GitApplicationLicenseClassName(int LLApplicationID)
        {
            return clsLocalDrivingLicenseApplicationsData.GitApplicationLicenseClassName(LLApplicationID);
        }

      

    }
}
