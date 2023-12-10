using DVLD_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsDrivers : clsPeoples
    {

        public enum enMode { Add, Update }
        public enMode Mode;
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        private clsDrivers(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;

            this.Mode = enMode.Update;
        }
        public clsDrivers()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;

            this.Mode = enMode.Add;
        }
        private bool _AddDrivers()
        {
            this.DriverID = clsDriversData.AddNewDrivers(this.PersonID, this.CreatedByUserID, this.CreatedDate);
            return (this.DriverID != -1);
        }
        private bool _UpdateDrivers()
        {
            return clsDriversData.UpdateDrivers(this.DriverID, this.PersonID, this.CreatedByUserID, this.CreatedDate);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Update:
                    {
                        return _UpdateDrivers();
                    }
                case enMode.Add:
                    {
                        if (_AddDrivers())
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
        public static bool DeleteDrivers(int DriverID)
        {
            return clsDriversData.DeleteDrivers(DriverID);
        }
        public static DataTable GitAllDrivers()
        {
            return clsDriversData.GitAllDrivers();
        }
        public static clsDrivers Find(int DriverID)
        {
            int Column2 = 0;
            int Column3 = 0;
            DateTime Column4 = DateTime.Now;

            if (clsDriversData.Find(DriverID, ref Column2, ref Column3, ref Column4))
                return new clsDrivers(DriverID, Column2, Column3, Column4);
            else
                return null;
        }



        public static int GitPersonID(int DrverID)
        {
            return clsDriversData.GitPersonID(DrverID);
        }
    }
}
