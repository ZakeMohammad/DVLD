using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Project
{
    public class clsSheardClassForManyThings
    {

        public static int NumberOfPassidTests(int LoclaDrivingLecinseApplicationID)
        {
            int PassidTests = 0;

            DataTable dt = clsApplications.GitAllLocalLicenseApplications();

            foreach (DataRow Row in dt.Rows)
            {
                if (LoclaDrivingLecinseApplicationID == (int)Row["LocalDrivingLicenseApplicationID"])
                {
                    if ((int)Row["PassedTestCount"] == 0)
                    {
                        PassidTests = 0;
                     
                    }
                    if ((int)Row["PassedTestCount"] == 1)
                    {
                       PassidTests= 1;
                      
                    }
                    if ((int)Row["PassedTestCount"] == 2)
                    {
                        PassidTests= 2;
                      
                    }
                    if ((int)Row["PassedTestCount"] == 3)
                    {
                        PassidTests= 3; 
                      
                    }
                }

            }

                return PassidTests;
              
        }

        public static string GitStatusForThisLocalDrivingLicenseApplicatoin(int LoclaDrivingLecinseApplicationID)
        {
            string Status="";

            DataTable dt = clsApplications.GitAllLocalLicenseApplications();

            foreach (DataRow Row in dt.Rows)
            {
                if ((int)Row["LocalDrivingLicenseApplicationID"]==LoclaDrivingLecinseApplicationID && (string)Row["Status"]=="New")
                {
                    Status = "New";
                }
                if ((int)Row["LocalDrivingLicenseApplicationID"] == LoclaDrivingLecinseApplicationID && (string)Row["Status"] == "Cancelled")
                {
                    Status = "Cancelled";
                }
                if ((int)Row["LocalDrivingLicenseApplicationID"] == LoclaDrivingLecinseApplicationID && (string)Row["Status"] == "Completed")
                {
                    Status = "Completed";
                }

            }
                return Status;
        }

        public static int GitFeesForApplicationUseApplicatoinName(string ApplicationName)
        {
            return clsApplications.GitFeesForApplicationUseApplicatoinName(ApplicationName);
        }

        public static int GitFeesForApplicationUseLicenseClassName(string ClassName)
        {
            return clsApplications.GitFeesForApplicationUseLicenseClassName(ClassName);
        }

    }
}
