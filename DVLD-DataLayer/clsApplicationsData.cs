using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataLayer
{
    public class clsApplicationsData
    {
        public static int AddNewApplications(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate, int PaidFees, int CreatedByUserID)
        {
            int ApplicationsID = -1;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "insert into Applications (ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID) values (@Column2,@Column3,@Column4,@Column5,@Column6,@Column7,@Column8);SELECT SCOPE_IDENTITY(); ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column2", ApplicantPersonID);
            Command.Parameters.AddWithValue("@Column3", ApplicationDate);
            Command.Parameters.AddWithValue("@Column4", ApplicationTypeID);
            Command.Parameters.AddWithValue("@Column5", ApplicationStatus);
            Command.Parameters.AddWithValue("@Column6", LastStatusDate);
            Command.Parameters.AddWithValue("@Column7", PaidFees);
            Command.Parameters.AddWithValue("@Column8", CreatedByUserID);

            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int InsertedID))
                {
                    ApplicationsID = InsertedID;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return ApplicationsID;
        }
        public static bool UpdateApplications(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate, int PaidFees, int CreatedByUserID)
        {
            bool IsUpdate = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "update Applications set  ApplicantPersonID=@Column2,ApplicationDate=@Column3,ApplicationTypeID=@Column4,ApplicationStatus=@Column5,LastStatusDate=@Column6,PaidFees=@Column7,CreatedByUserID=@Column8 where ApplicationID=@Column1 ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", ApplicationID);
            Command.Parameters.AddWithValue("@Column2", ApplicantPersonID);
            Command.Parameters.AddWithValue("@Column3", ApplicationDate);
            Command.Parameters.AddWithValue("@Column4", ApplicationTypeID);
            Command.Parameters.AddWithValue("@Column5", ApplicationStatus);
            Command.Parameters.AddWithValue("@Column6", LastStatusDate);
            Command.Parameters.AddWithValue("@Column7", PaidFees);
            Command.Parameters.AddWithValue("@Column8", CreatedByUserID);

            try
            {
                Conniction.Open();
                int RowEffected = Command.ExecuteNonQuery();
                if (RowEffected > 0)
                {
                    IsUpdate = true;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return IsUpdate;
        }
        public static bool Find(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID, ref int ApplicationStatus, ref DateTime LastStatusDate, ref int PaidFees, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "select * from Applications where ApplicationID=@Column1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", ApplicationID);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    ApplicationID = (int)Reader["ApplicationID"];
                    ApplicantPersonID = (int)Reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)Reader["ApplicationDate"];
                    ApplicationTypeID = (int)Reader["ApplicationTypeID"];
                    ApplicationStatus = (int)Reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)Reader["LastStatusDate"];
                    PaidFees = (int)Reader["PaidFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];

                }
                Reader.Close();
            }
            catch (Exception e)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return IsFound;
        }
        public static bool DeleteApplications(int ID)
        {
            bool IsDeleted = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "delete Applications where ApplicationID=@Column1 ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", ID);
            try
            {
                Conniction.Open();
                int RowEffected = Command.ExecuteNonQuery();
                if (RowEffected > 0)
                {
                    IsDeleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return IsDeleted;
        }
        public static bool IsApplicationsExistWithSameStatusAndSamePerson(int PersonID,int ApplicationStatus)
        {
            bool IsExist = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = " select Found=1 from Applications  where ApplicantPersonID = @personid and ApplicationStatus=@applicationstatues ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@personid", PersonID);
            Command.Parameters.AddWithValue("@applicationstatues", ApplicationStatus);
            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null)
                    IsExist = true;
                else
                    IsExist = false;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return IsExist;
        }
        public static DataTable GitAllApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Query = "SELECT * FROM Applications";
            SqlCommand Command = new SqlCommand(Query, Conniction);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                    dt.Load(Reader);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return dt;
        }


        public static DataTable GitAllLocalLicenseApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Query = "SELECT * FROM LocalDrivingLicenseApplications_View";
            SqlCommand Command = new SqlCommand(Query, Conniction);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                    dt.Load(Reader);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return dt;
        }

        public static DataTable GitAllIntrnationalApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Query = "select InternationalLicenses.InternationalLicenseID,InternationalLicenses.ApplicationID,InternationalLicenses.DriverID,InternationalLicenses.IssuedUsingLocalLicenseID,InternationalLicenses.IssueDate,InternationalLicenses.ExpirationDate,InternationalLicenses.IsActive from InternationalLicenses";
            SqlCommand Command = new SqlCommand(Query, Conniction);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                    dt.Load(Reader);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return dt;
        }

        public static DataTable GitALlApplicationsClasses()
        {
            DataTable dt = new DataTable();
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Query = "SELECT ClassName FROM LicenseClasses";
            SqlCommand Command = new SqlCommand(Query, Conniction);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                    dt.Load(Reader);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return dt;
        }



        public static bool UpdateStatusForApplication(int ApplicatoinID,int Status)
        {
            bool IsUpdate = false;

            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");

            string Querey = "update Applications set ApplicationStatus=@status  where ApplicationID=@Column1 ";

            SqlCommand Command = new SqlCommand(Querey, Conniction);

            Command.Parameters.AddWithValue("@Column1", ApplicatoinID);
            Command.Parameters.AddWithValue("@status", Status);

            try
            {
                Conniction.Open();
                int RowEffected = Command.ExecuteNonQuery();
                if (RowEffected > 0)
                {
                    IsUpdate = true;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return IsUpdate;
        }


        public static int GitFeesForApplicationUseApplicatoinName(string ApplicationName)
        {
            int Fees =0;

          
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");

            string Query = @"SELECT ApplicationFees FROM ApplicationTypes where ApplicationTypeTitle=@ApplicationName";
           
            SqlCommand Command = new SqlCommand(Query, Conniction);

            Command.Parameters.AddWithValue("@ApplicationName", ApplicationName);

            try
            {
                Conniction.Open();

                object Ruslt = Command.ExecuteScalar();

               Fees= (int)Ruslt;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }

            return Fees;
        }
        public static int GitFeesForApplicationUseLicenseClassName(string ClassName)
        {
            int Fees = 0;


            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");

            string Query = @"SELECT ClassFees FROM LicenseClasses where ClassName=@className";

            SqlCommand Command = new SqlCommand(Query, Conniction);

            Command.Parameters.AddWithValue("@className", ClassName);

            try
            {
                Conniction.Open();

                object Ruslt = Command.ExecuteScalar();

                Fees = (int)Ruslt;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }

            return Fees;
        }

        public static bool IsPersonhaveIntrnationalApplicationForIntrantionalLicense(int PersonID)
        {
            bool IsExist = false;

            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = " select Found=1 from Applications  where ApplicantPersonID = @personid and ApplicationTypeID=6";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@personid", PersonID);  
            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null)
                    IsExist = true;
                else
                    IsExist = false;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return IsExist;
        }


        public static bool IsApplicationsExistAndHisStatusIsCompletedAndSamePerson(int PersonID)
        {
            bool IsExist = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "select Found=1 from Applications  where ApplicantPersonID = @personid and ApplicationStatus=3";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@personid", PersonID);
    
            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null)
                    IsExist = true;
                else
                    IsExist = false;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return IsExist;
        }


        public static bool IsPersonHaveThisLicenseWithThisLicenseClass(int PersonID, int licenseclassid)
        {
            bool IsExist = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = " select Found=1 from IsPersonHaveThisLicenseinThisClass where ApplicantPersonID=@personid and LicenseClassID=@licenseclass";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@licenseclass", licenseclassid);
            Command.Parameters.AddWithValue("@personid", PersonID);
            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null)
                    IsExist = true;
                else
                    IsExist = false;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return IsExist;
        }

        public static int GitApplicatoinIDusingPersonID(int PersonID)
        {
            int ApplicationsID = -1;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "select ApplicationID from Applications  where ApplicantPersonID=@personid and ApplicationTypeID=3";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@personid", PersonID);
           
            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int applicationid))
                {
                    ApplicationsID = applicationid;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return ApplicationsID;
        }


    }
}
