using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataLayer
{
    public class clsUsersData
    {
        public static int AddNewUsers(int PersonID, string UserName, string Password, int IsActive)
        {
            int UsersID = -1;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "insert into Users (PersonID,UserName,Password,IsActive) values (@Column2,@Column3,@Column4,@Column5);SELECT SCOPE_IDENTITY(); ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column2", PersonID);
            Command.Parameters.AddWithValue("@Column3", UserName);
            Command.Parameters.AddWithValue("@Column4", Password);
            Command.Parameters.AddWithValue("@Column5", IsActive);

            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int InsertedID))
                {
                    UsersID = InsertedID;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return UsersID;
        }
        public static bool UpdateUsers(int UserID, int PersonID, string UserName, string Password, int IsActive)
        {
            bool IsUpdate = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "update Users set  PersonID=@Column2,UserName=@Column3,Password=@Column4,IsActive=@Column5 where UserID=@Column1 ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", UserID);
            Command.Parameters.AddWithValue("@Column2", PersonID);
            Command.Parameters.AddWithValue("@Column3", UserName);
            Command.Parameters.AddWithValue("@Column4", Password);
            Command.Parameters.AddWithValue("@Column5", IsActive);

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
        public static bool Find(int UserID, ref int PersonID, ref string UserName, ref string Password, ref int IsActive)
        {
            bool IsFound = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "select * from Users where UserID=@Column1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", UserID);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    UserID = (int)Reader["UserID"];
                    PersonID = (int)Reader["PersonID"];
                    UserName = (string)Reader["UserName"];
                    Password = (string)Reader["Password"];
                    if ((bool)Reader["IsActive"] == true)
                    {
                        IsActive = 1;
                    }
                    else
                        IsActive = 0;
                 

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
        public static bool DeleteUsers(int ID)
        {
            bool IsDeleted = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "delete Users where ID=@Column1 ";
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
        public static bool IsUsersExist(int UsersID)
        {
            bool IsExist = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = " select Found=1 from Users  where UsersID = @Column1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", UsersID);
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
        public static DataTable GitAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Query = "SELECT * FROM UsersData";
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

        public static bool Find(ref int UserID, ref int PersonID, string UserName, ref string Password, ref int IsActive)
        {
            bool IsFound = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "select * from Users where Username=@Column1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", UserName);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    UserID = (int)Reader["UserID"];
                    PersonID = (int)Reader["PersonID"];
                    UserName = (string)Reader["UserName"];
                    Password = (string)Reader["Password"];
                    if ((bool)Reader["IsActive"] == true)
                    {
                        IsActive = 1;
                    }
                    else
                        IsActive = 0;


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

        public static bool IsUsersExist(string Username)
        {
            bool IsExist = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "select Found=1 from Users  where Username = @Column1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", Username);
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

        public static bool UpdatePasswordForUsers(int UserID, string Password)
        {
            bool IsUpdate = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "update Users set Password=@Column4 where UserID=@Column1 ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", UserID);
            Command.Parameters.AddWithValue("@Column4", Password);
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


    }
}
