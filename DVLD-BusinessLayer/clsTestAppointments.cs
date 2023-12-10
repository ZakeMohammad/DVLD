using DVLD_DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTestAppointments
    {

        public enum enMode { Add, Update }
        public enMode Mode;
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }

        private clsTestAppointments(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, int PaidFees, int CreatedByUserID, bool IsLocked)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;

            this.Mode = enMode.Update;
        }
        public clsTestAppointments()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            this.IsLocked = false;

            this.Mode = enMode.Add;
        }
        private bool _AddTestAppointments()
        {
            this.TestAppointmentID = clsTestAppointmentsData.AddNewTestAppointments(this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked);
            return (this.TestAppointmentID != -1);
        }
        private bool _UpdateTestAppointments()
        {
            return clsTestAppointmentsData.UpdateTestAppointments(this.TestAppointmentID, this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Update:
                    {
                        return _UpdateTestAppointments();
                    }
                case enMode.Add:
                    {
                        if (_AddTestAppointments())
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
        public static bool DeleteTestAppointments(int TestAppointmentID)
        {
            return clsTestAppointmentsData.DeleteTestAppointments(TestAppointmentID);
        }
        public static DataTable GitAllTestAppointments(int TestTypeID,int LLApplicationID)
        {
            return clsTestAppointmentsData.GitAllTestAppointments(TestTypeID, LLApplicationID);
        }
        public static clsTestAppointments Find(int TestAppointmentID)
        {
            int Column2 = 0;
            int Column3 = 0;
            DateTime Column4 = DateTime.Now;
            int Column5 = 0;
            int Column6 = 0;
            bool Column7 = false;

            if (clsTestAppointmentsData.Find(TestAppointmentID, ref Column2, ref Column3, ref Column4, ref Column5, ref Column6, ref Column7))
                return new clsTestAppointments(TestAppointmentID, Column2, Column3, Column4, Column5, Column6, Column7);
            else
                return null;
        }
        public static bool IsTestAppointemntExistAndIsRusltIsFail(int TestAppointmentID)
        {
            return clsTestAppointmentsData.IsTestAppointemntExistAndIsRusltIsFail(TestAppointmentID);
        }
        public static bool IsThereAnyTestAppointmentActive(int LLApplicationID)
        {
            return clsTestAppointmentsData.IsThereAnyTestAppointmentActive(LLApplicationID);
        }
        public static bool UpdateTestAppointmentWhenTakeTest(int TestAppointmentID)
        {
            return clsTestAppointmentsData.UpdateTestAppointmentWhenTakeTest(TestAppointmentID);
        }

        public static bool IsTestAppointmentLocked(int TestAppointmentID)
        {
            return clsTestAppointmentsData.IsTestAppointmentLocked(TestAppointmentID);
        }


    }
}
