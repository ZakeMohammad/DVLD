using DVLD_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsApplicationTypes
    {


        public enum enMode { Add, Update }
        public enMode Mode;
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public double ApplicationFees { get; set; }

        private clsApplicationTypes(int ApplicationTypeID, string ApplicationTypeTitle, double ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;

            this.Mode = enMode.Update;
        }
        public clsApplicationTypes()
        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = "";
            this.ApplicationFees = -1;

            this.Mode = enMode.Add;
        }

        private bool _UpdateApplicationTypes()
        {
            return clsApplicationTypesData.UpdateApplicationTypes(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);
        }
        public bool Save()
        {
           
          return _UpdateApplicationTypes();
        }

        public static DataTable GitAllApplicationTypes()
        {
            return clsApplicationTypesData.GitAllApplicationTypes();
        }
        public static clsApplicationTypes Find(int ApplicationTypeID)
        {
            string Column2 = "";
            double Column3 = 0;

            if (clsApplicationTypesData.Find(ApplicationTypeID, ref Column2, ref Column3))
                return new clsApplicationTypes(ApplicationTypeID, Column2, Column3);
            else
                return null;
        }

    }
}
