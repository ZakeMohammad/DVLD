using DVLD_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsApplications
    {

        public enum enMode { Add, Update }
        public enMode Mode;


        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public int ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public int PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

      
        private clsApplications(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate, int PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            this.Mode = enMode.Update;
        }
        public clsApplications()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = -1;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;

            this.Mode = enMode.Add;
        }
        private bool _AddApplications()
        {
            this.ApplicationID = clsApplicationsData.AddNewApplications(this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            return (this.ApplicationID != -1);
        }
        private bool _UpdateApplications()
        {
            return clsApplicationsData.UpdateApplications(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Update:
                    {
                        return _UpdateApplications();
                    }
                case enMode.Add:
                    {
                        if (_AddApplications())
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
        public static bool DeleteApplications(int ApplicationID)
        {
            return clsApplicationsData.DeleteApplications(ApplicationID);
        }
        public static DataTable GitAllApplications()
        {
            return clsApplicationsData.GitAllApplications();
        }
        public static clsApplications Find(int ApplicationID)
        {
            int Column2 = 0;
            DateTime Column3 = DateTime.Now;
            int Column4 = 0;
            int Column5 = 0;
            DateTime Column6 = DateTime.Now;
            int Column7 = 0;
            int Column8 = 0;

            if (clsApplicationsData.Find(ApplicationID, ref Column2, ref Column3, ref Column4, ref Column5, ref Column6, ref Column7, ref Column8))
                return new clsApplications(ApplicationID, Column2, Column3, Column4, Column5, Column6, Column7, Column8);
            else
                return null;
        }
        public static DataTable GitALlApplicationsClasses()
        {
            return clsApplicationsData.GitALlApplicationsClasses();
        }
        public static bool IsApplicationsExistWithSameStatusAndSamePerson(int PersonID, int ApplicationStatus)
        {
            return clsApplicationsData.IsApplicationsExistWithSameStatusAndSamePerson(PersonID, ApplicationStatus);
        }

        public static DataTable GitAllLocalLicenseApplications()
        {
            return clsApplicationsData.GitAllLocalLicenseApplications();
        }
        public static bool UpdateStatusForApplication(int ApplicatoinID,int Status)
        {
            return clsApplicationsData.UpdateStatusForApplication(ApplicatoinID, Status);
        }
        public static int GitFeesForApplicationUseApplicatoinName(string ApplicationName)
        {
            return clsApplicationsData.GitFeesForApplicationUseApplicatoinName(ApplicationName);
        }
        public static int GitFeesForApplicationUseLicenseClassName(string ClassName)
        {
            return clsApplicationsData.GitFeesForApplicationUseLicenseClassName(ClassName);
        }
        public static bool IsPersonhaveIntrnationalApplicationForIntrantionalLicense(int PersonId)
        {
           
            return clsApplicationsData.IsPersonhaveIntrnationalApplicationForIntrantionalLicense(PersonId);
        }

        public static bool IsPersonHaveThisLicenseWithThisLicenseClass(int PersonID, int licenseclassid)
        {
            return clsApplicationsData.IsPersonHaveThisLicenseWithThisLicenseClass(PersonID, licenseclassid);
        }

        public static bool IsApplicationsExistAndHisStatusIsCompletedAndSamePerson(int PersonID)
        {
            return clsApplicationsData.IsApplicationsExistAndHisStatusIsCompletedAndSamePerson(PersonID);
        }




        public static DataTable GitAllIntrnationalApplications()
        {
            return clsApplicationsData.GitAllIntrnationalApplications(); 
        }

        public static int GitApplicatoinIDusingPersonID(int PersonID)
        {
            return clsApplicationsData.GitApplicatoinIDusingPersonID(PersonID);
        }




    }
}
