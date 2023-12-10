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
    public class clsLocalDrivingLicenseApplicationsData
    {

        public static int AddNewLocalDrivingLicenseApplications(int ApplicationID, int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationsID = -1;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "insert into LocalDrivingLicenseApplications (ApplicationID,LicenseClassID) values (@Column2,@Column3);SELECT SCOPE_IDENTITY(); ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column2", ApplicationID);
            Command.Parameters.AddWithValue("@Column3", LicenseClassID);

            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int InsertedID))
                {
                    LocalDrivingLicenseApplicationsID = InsertedID;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return LocalDrivingLicenseApplicationsID;
        }
        public static bool UpdateLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            bool IsUpdate = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "update LocalDrivingLicenseApplications set  ApplicationID=@Column2,LicenseClassID=@Column3 where LocalDrivingLicenseApplicationID=@Column1 ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@Column2", ApplicationID);
            Command.Parameters.AddWithValue("@Column3", LicenseClassID);

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
        public static bool Find(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool IsFound = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "select * from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID=@Column1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", LocalDrivingLicenseApplicationID);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    ApplicationID = (int)Reader["ApplicationID"];
                    LicenseClassID = (int)Reader["LicenseClassID"];

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
        public static bool DeleteLocalDrivingLicenseApplications(int ID)
        {
            bool IsDeleted = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "delete LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID=@Column1 ";
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
        public static bool IsLocalDrivingLicenseApplicationsExist(int LocalDrivingLicenseApplicationsID)
        {
            bool IsExist = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = " select Found=1 from LocalDrivingLicenseApplications  where LocalDrivingLicenseApplicationsID = @Column1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", LocalDrivingLicenseApplicationsID);
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
        public static DataTable GitAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Query = "SELECT * FROM LocalDrivingLicenseApplications";
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

        public static string GitApplicationLicenseClassName(int LLApplicationID)
        {
            string ClassName = "";

            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Query = "select ClassName from LicenseClasses inner join LocalDrivingLicenseApplications on LocalDrivingLicenseApplications.LicenseClassID=LicenseClasses.LicenseClassID where LocalDrivingLicenseApplicationID=@llapplicatoinid";
            SqlCommand Command = new SqlCommand(Query, Conniction);
            Command.Parameters.AddWithValue("@llapplicatoinid", LLApplicationID);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                    ClassName = (string)Reader[0];
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }


            return ClassName;

        }

       


    }
}
