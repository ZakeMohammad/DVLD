using DVLD_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTestTypes
    {
        public enum enMode { Add, Update }
        public enMode Mode;
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public int TestTypeFees { get; set; }

        private clsTestTypes(int TestTypeID, string TestTypeTitle, string TestTypeDescription, int TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;

            this.Mode = enMode.Update;
        }
        public clsTestTypes()
        {
            this.TestTypeID = -1;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = -1;
            ;
            this.Mode = enMode.Add;
        }
        private bool _AddTestTypes()
        {
            this.TestTypeID = clsTestTypesData.AddNewTestTypes(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
            return (this.TestTypeID != -1);
        }
        private bool _UpdateTestTypes()
        {
            return clsTestTypesData.UpdateTestTypes(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Update:
                    {
                        return _UpdateTestTypes();
                    }
                case enMode.Add:
                    {
                        if (_AddTestTypes())
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
        public static bool DeleteTestTypes(int TestTypeID)
        {
            return clsTestTypesData.DeleteTestTypes(TestTypeID);
        }
        public static DataTable GitAllTestTypes()
        {
            return clsTestTypesData.GitAllTestTypes();
        }
        public static clsTestTypes Find(int TestTypeID)
        {
            string Column2 = "";
            string Column3 = "";
            int Column4 = 0;

            if (clsTestTypesData.Find(TestTypeID, ref Column2, ref Column3, ref Column4))
                return new clsTestTypes(TestTypeID, Column2, Column3, Column4);
            else
                return null;
        }



    }
}
