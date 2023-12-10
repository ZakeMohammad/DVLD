using DVLD_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsDetainedLicenses
    {

        public enum enMode { Add, Update }
        public enMode Mode;
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public int FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }

        private clsDetainedLicenses(int DetainID, int LicenseID, DateTime DetainDate, int FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

            this.Mode = enMode.Update;
        }
        public clsDetainedLicenses()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = -1;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.Now;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;

            this.Mode = enMode.Add;
        }
        private bool _AddDetainedLicenses()
        {
            this.DetainID = clsDetainedLicensesData.AddNewDetainedLicenses(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID, this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);
            return (this.DetainID != -1);
        }
        private bool _UpdateDetainedLicenses()
        {
            return clsDetainedLicensesData.UpdateDetainedLicenses(this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID, this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Update:
                    {
                        return _UpdateDetainedLicenses();
                    }
                case enMode.Add:
                    {
                        if (_AddDetainedLicenses())
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
        public static bool DeleteDetainedLicenses(int DetainID)
        {
            return clsDetainedLicensesData.DeleteDetainedLicenses(DetainID);
        }
        public static DataTable GitAllDetainedLicenses()
        {
            return clsDetainedLicensesData.GitAllDetainedLicenses();
        }
        public static clsDetainedLicenses Find(int DetainID)
        {
            int Column2 = 0;
            DateTime Column3 = DateTime.Now;
            int Column4 = 0;
            int Column5 = 0;
            bool Column6 = false;
            DateTime Column7 = DateTime.Now;
            int Column8 = 0;
            int Column9 = 0;

            if (clsDetainedLicensesData.Find(DetainID, ref Column2, ref Column3, ref Column4, ref Column5, ref Column6, ref Column7, ref Column8, ref Column9))
                return new clsDetainedLicenses(DetainID, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9);
            else
                return null;
        }
        public static clsDetainedLicenses FindForReleasedOnly(int LicenseID)
        {
            int Column1 = 0;
            DateTime Column3 = DateTime.Now;
            int Column4 = 0;
            int Column5 = 0;
            bool Column6 = false;
            DateTime Column7 = DateTime.Now;
            int Column8 = 0;
            int Column9 = 0;

            if (clsDetainedLicensesData.FindForReleasedOnly(ref Column1, LicenseID, ref Column3, ref Column4, ref Column5, ref Column6, ref Column7, ref Column8, ref Column9))
                return new clsDetainedLicenses(Column1, LicenseID, Column3, Column4, Column5, Column6, Column7, Column8, Column9);
            else
                return null;
        }
        public static clsDetainedLicenses Find(int LicneseID,bool ForOverlodingonly=true)
        {
            int Column1 = 0;
            DateTime Column3 = DateTime.Now;
            int Column4 = 0;
            int Column5 = 0;
            bool Column6 = false;
            DateTime Column7 = DateTime.Now;
            int Column8 = 0;
            int Column9 = 0;

            if (clsDetainedLicensesData.Find(ref Column1,  LicneseID, ref Column3, ref Column4, ref Column5, ref Column6, ref Column7, ref Column8, ref Column9))
                return new clsDetainedLicenses(Column1, LicneseID, Column3, Column4, Column5, Column6, Column7, Column8, Column9);
            else
                return null;
        }


        public static bool ReleaseLicense(int DetainID, DateTime ReleaseDate, int ReleaseApplicationID, int UserID)
        {
            return clsDetainedLicensesData.ReleaseLicense(DetainID,ReleaseDate, ReleaseApplicationID, UserID);
        }


    }
}
