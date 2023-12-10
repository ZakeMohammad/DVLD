using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataLayer
{
    public class clsTestTypesData
    {
        public static int AddNewTestTypes(string TestTypeTitle, string TestTypeDescription, int TestTypeFees)
        {
            int TestTypesID = -1;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "insert into TestTypes (TestTypeTitle,TestTypeDescription,TestTypeFees,,,,,,,,,,,,) values (@Column2,@Column3,@Column4);SELECT SCOPE_IDENTITY(); ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column2", TestTypeTitle);
            Command.Parameters.AddWithValue("@Column3", TestTypeDescription);
            Command.Parameters.AddWithValue("@Column4", TestTypeFees);

            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int InsertedID))
                {
                    TestTypesID = InsertedID;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return TestTypesID;
        }
        public static bool UpdateTestTypes(int TestTypeID, string TestTypeTitle, string TestTypeDescription, int TestTypeFees)
        {
            bool IsUpdate = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "update TestTypes set  TestTypeTitle=@Column2,TestTypeDescription=@Column3,TestTypeFees=@Column4 where TestTypeID=@Column1 ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", TestTypeID);
            Command.Parameters.AddWithValue("@Column2", TestTypeTitle);
            Command.Parameters.AddWithValue("@Column3", TestTypeDescription);
            Command.Parameters.AddWithValue("@Column4", TestTypeFees);

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
        public static bool Find(int TestTypeID, ref string TestTypeTitle, ref string TestTypeDescription, ref int TestTypeFees)
        {
            bool IsFound = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "select * from TestTypes where TestTypeID=@Column1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", TestTypeID);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    TestTypeID = (int)Reader["TestTypeID"];
                    TestTypeTitle = (string)Reader["TestTypeTitle"];
                    TestTypeDescription = (string)Reader["TestTypeDescription"];
                    TestTypeFees = (int)Reader["TestTypeFees"];

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
        public static bool DeleteTestTypes(int ID)
        {
            bool IsDeleted = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "delete TestTypes where ID=@Column1 ";
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
        public static bool IsTestTypesExist(int TestTypesID)
        {
            bool IsExist = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = " select Found=1 from TestTypes  where TestTypesID = @Column1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", TestTypesID);
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
        public static DataTable GitAllTestTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Query = "SELECT * FROM TestTypes";
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

    }
}
