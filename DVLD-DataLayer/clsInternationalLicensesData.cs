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
    public class clsInternationalLicensesData
    {

        public static int AddNewInternationalLicenses(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, int IsActive, int CreatedByUserID)
        {
            int InternationalLicensesID = -1;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "insert into InternationalLicenses (ApplicationID,DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive,CreatedByUserID) values (@Column2,@Column3,@Column4,@Column5,@Column6,@Column7,@Column8);SELECT SCOPE_IDENTITY(); ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column2", ApplicationID);
            Command.Parameters.AddWithValue("@Column3", DriverID);
            Command.Parameters.AddWithValue("@Column4", IssuedUsingLocalLicenseID);
            Command.Parameters.AddWithValue("@Column5", IssueDate);
            Command.Parameters.AddWithValue("@Column6", ExpirationDate);
            Command.Parameters.AddWithValue("@Column7", IsActive);
            Command.Parameters.AddWithValue("@Column8", CreatedByUserID);

            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int InsertedID))
                {
                    InternationalLicensesID = InsertedID;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return InternationalLicensesID;
        }
        public static bool UpdateInternationalLicenses(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, int IsActive, int CreatedByUserID)
        {
            bool IsUpdate = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "update InternationalLicenses set  ApplicationID=@Column2,DriverID=@Column3,IssuedUsingLocalLicenseID=@Column4,IssueDate=@Column5,ExpirationDate=@Column6,IsActive=@Column7,CreatedByUserID=@Column8 where InternationalLicenseID=@Column1 ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", InternationalLicenseID);
            Command.Parameters.AddWithValue("@Column2", ApplicationID);
            Command.Parameters.AddWithValue("@Column3", DriverID);
            Command.Parameters.AddWithValue("@Column4", IssuedUsingLocalLicenseID);
            Command.Parameters.AddWithValue("@Column5", IssueDate);
            Command.Parameters.AddWithValue("@Column6", ExpirationDate);
            Command.Parameters.AddWithValue("@Column7", IsActive);
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
        public static bool Find(int InternationalLicenseID, ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref int IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "select * from InternationalLicenses where InternationalLicenseID=@Column1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", InternationalLicenseID);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    InternationalLicenseID = (int)Reader["InternationalLicenseID"];
                    ApplicationID = (int)Reader["ApplicationID"];
                    DriverID = (int)Reader["DriverID"];
                    IssuedUsingLocalLicenseID = (int)Reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    if ((bool)Reader["IsActive"] == true)
                        IsActive = 1;
                    else
                        IsActive= 0;

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
        public static bool DeleteInternationalLicenses(int ID)
        {
            bool IsDeleted = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "delete InternationalLicenses where ID=@Column1 ";
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
        public static bool IsInternationalLicensesExist(int InternationalLicensesID)
        {
            bool IsExist = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = " select Found=1 from InternationalLicenses  where InternationalLicensesID = @Column1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", InternationalLicensesID);
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
        public static DataTable GitAllInternationalLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Query = "SELECT * FROM InternationalLicenses";
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



        public static int GitIntrnationalLicenseApplicatoinID(int LocalLicenseID)
        {
            int ApplicaintID = -1;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "select ApplicationID from InternationalLicenses where InternationalLicenses.IssuedUsingLocalLicenseID=@locallicense";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@locallicense", LocalLicenseID);
      

            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int applicaintID))
                {
                    ApplicaintID = applicaintID;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return ApplicaintID;

        }

    

        public static int GitIntrnationalApplicationIDUsingDriverID(int DriverID)
        {
            int ApplicaintID = -1;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "select ApplicationID from InternationalLicenses  where DriverID=@driver";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@driver", DriverID);


            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int applicaintID))
                {
                    ApplicaintID = applicaintID;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return ApplicaintID;

        }


    }
}
