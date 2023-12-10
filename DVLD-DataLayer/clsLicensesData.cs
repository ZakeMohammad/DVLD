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
    public class clsLicensesData
    {
        public static int AddNewLicenses(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, int PaidFees, int IsActive, int IssueReason, int CreatedByUserID)
        {
            int LicensesID = -1;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "insert into Licenses (ApplicationID,DriverID,LicenseClass,IssueDate,ExpirationDate,Notes,PaidFees,IsActive,IssueReason,CreatedByUserID) values (@Column2,@Column3,@Column4,@Column5,@Column6,@Column7,@Column8,@Column9,@Column10,@Column11);SELECT SCOPE_IDENTITY(); ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column2", ApplicationID);
            Command.Parameters.AddWithValue("@Column3", DriverID);
            Command.Parameters.AddWithValue("@Column4", LicenseClass);
            Command.Parameters.AddWithValue("@Column5", IssueDate);
            Command.Parameters.AddWithValue("@Column6", ExpirationDate);

            if(Notes!= null)
            Command.Parameters.AddWithValue("@Column7", Notes);
            else
                Command.Parameters.AddWithValue("@Column7", DBNull.Value);
            Command.Parameters.AddWithValue("@Column8", PaidFees);
            Command.Parameters.AddWithValue("@Column9", IsActive);
            Command.Parameters.AddWithValue("@Column10", IssueReason);
            Command.Parameters.AddWithValue("@Column11", CreatedByUserID);

            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int InsertedID))
                {
                    LicensesID = InsertedID;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return LicensesID;
        }
        public static bool UpdateLicenses(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, int PaidFees, int IsActive, int IssueReason, int CreatedByUserID)
        {
            bool IsUpdate = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "update Licenses set  ApplicationID=@Column2,DriverID=@Column3,LicenseClass=@Column4,IssueDate=@Column5,ExpirationDate=@Column6,Notes=@Column7,PaidFees=@Column8,IsActive=@Column9,IssueReason=@Column10,CreatedByUserID=@Column11 where LicenseID=@Column1 ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", LicenseID);
            Command.Parameters.AddWithValue("@Column2", ApplicationID);
            Command.Parameters.AddWithValue("@Column3", DriverID);
            Command.Parameters.AddWithValue("@Column4", LicenseClass);
            Command.Parameters.AddWithValue("@Column5", IssueDate);
            Command.Parameters.AddWithValue("@Column6", ExpirationDate);
            Command.Parameters.AddWithValue("@Column7", Notes);
            Command.Parameters.AddWithValue("@Column8", PaidFees);
            Command.Parameters.AddWithValue("@Column9", IsActive);
            Command.Parameters.AddWithValue("@Column10", IssueReason);
            Command.Parameters.AddWithValue("@Column11", CreatedByUserID);

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
        public static bool Find(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref int PaidFees, ref int IsActive, ref int IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "select * from Licenses where LicenseID=@Column1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", LicenseID);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    LicenseID = (int)Reader["LicenseID"];
                    ApplicationID = (int)Reader["ApplicationID"];
                    DriverID = (int)Reader["DriverID"];
                    LicenseClass = (int)Reader["LicenseClass"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    Notes = (string)Reader["Notes"];
                    PaidFees = (int)Reader["PaidFees"];
                    if ((bool)Reader["IsActive"] == true)
                        IsActive = 1;
                    else
                        IsActive= 0;
                  
                    IssueReason = (int)Reader["IssueReason"];
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
        public static bool DeleteLicenses(int ID)
        {
            bool IsDeleted = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "delete Licenses where ID=@Column1 ";
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
        public static bool IsLicensesExist(int LicensesID)
        {
            bool IsExist = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = " select Found=1 from Licenses  where LicensesID = @Column1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", LicensesID);
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
        public static DataTable GitAllLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Query = "SELECT * FROM Licenses";
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

        public static string GitClassName(int LicenseID)
        {
            string ClassName = "";

           
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Query = "SELECT ClassName FROM LicenseClasses where LicenseClassID=@LicenseID";
            SqlCommand Command = new SqlCommand(Query, Conniction);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    ClassName = Reader[0].ToString();
                }
                   
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

        public static int GitLicenseID(int ApplicationID)
        {
            int LicenseID = 0;


            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "select LicenseID from Licenses where  ApplicationID =@Column2 ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column2", ApplicationID);         
            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int InsertedID))
                {
                    LicenseID = InsertedID;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }


            return LicenseID;
        }

        public static DataTable GitAllLocalLicenseHistoryForPerson(int PersonID)
        {
            DataTable dataTable= new DataTable();

            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");

            string Query = "SELECT Licenses.LicenseID, Applications.ApplicationID, LicenseClasses.ClassName, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive FROM  " +
                " Applications INNER JOIN " +
                " Licenses ON Applications.ApplicationID = Licenses.ApplicationID INNER JOIN " +
                " LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID INNER JOIN     " +
                " ApplicationTypes ON Applications.ApplicationTypeID = ApplicationTypes.ApplicationTypeID INNER JOIN " +
                " Drivers ON Licenses.DriverID = Drivers.DriverID INNER JOIN            " +
                " People ON Applications.ApplicantPersonID = People.PersonID AND Drivers.PersonID = People.PersonID INNER JOIN " +
                " Users ON Applications.CreatedByUserID = Users.UserID AND Licenses.CreatedByUserID = Users.UserID " +
                "where Applications.ApplicantPersonID=@PersonID order by Licenses.LicenseID desc";

            SqlCommand Command = new SqlCommand(Query, Conniction);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                    dataTable.Load(Reader);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return dataTable;
        }

        public static DataTable GitAllIntrnationalLicenseHistroyForPerson(int ApplicationID)
        {
            DataTable dataTable = new DataTable();

            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");

            string Querey = "select InternationalLicenses.InternationalLicenseID,InternationalLicenses.ApplicationID,InternationalLicenses.IssuedUsingLocalLicenseID,InternationalLicenses.IssueDate,InternationalLicenses.ExpirationDate,\r\nInternationalLicenses.IsActive from InternationalLicenses where ApplicationID=@applicationid";

            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@applicationid", ApplicationID);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                    dataTable.Load(Reader);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return dataTable;
        }

        public static bool DeActiveLicense(int LicenseID)
        {
            bool IsUpdate = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "update Licenses set IsActive=0 where LicenseID=@Column1 ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", LicenseID);
           

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

        public static bool IsLicenseDetaind(int LicenseID)
        {
            bool IsDetaind = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = " select Found=1 from DetainedLicenses  where LicenseID = @Column1 and IsReleased=0 ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", LicenseID);
            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null)
                    IsDetaind = true;
                else
                    IsDetaind = false;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }


            return IsDetaind;
        }



    }
}
