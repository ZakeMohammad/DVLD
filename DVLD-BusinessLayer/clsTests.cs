using DVLD_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTests
    {
        public enum enMode { Add, Update }
        public enMode Mode;
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        private clsTests(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            this.Mode = enMode.Update;
        }
        public clsTests()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;

            this.Mode = enMode.Add;
        }
        private bool _AddTests()
        {
            this.TestID = clsTestsData.AddNewTests(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
            return (this.TestID != -1);
        }
        private bool _UpdateTests()
        {
            return clsTestsData.UpdateTests(this.TestID, this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Update:
                    {
                        return _UpdateTests();
                    }
                case enMode.Add:
                    {
                        if (_AddTests())
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
        public static bool DeleteTests(int TestID)
        {
            return clsTestsData.DeleteTests(TestID);
        }
        public static DataTable GitAllTests()
        {
            return clsTestsData.GitAllTests();
        }
        public static clsTests Find(int TestID)
        {
            int Column2 = 0;
            bool Column3 = false;
            string Column4 = "";
            int Column5 = 0;

            if (clsTestsData.Find(TestID, ref Column2, ref Column3, ref Column4, ref Column5))
                return new clsTests(TestID, Column2, Column3, Column4, Column5);
            else
                return null;
        }



        public static int GitTestID(int TestAppointmentID)
        {
            return clsTestsData.GitTestID(TestAppointmentID);
        }

        public static int GitNumberOfTrials(int LLApplicationID, int TestTypeID)
        {
            return clsTestsData.GitNumberOfTrials(LLApplicationID, TestTypeID);
        }

    }
}
