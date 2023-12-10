using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataLayer
{
    public class clsTestAppointmentsData
    {
        public static int AddNewTestAppointments(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, int PaidFees, int CreatedByUserID, bool IsLocked)
        {
            int TestAppointmentsID = -1;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "insert into TestAppointments (TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked) values (@Column2,@Column3,@Column4,@Column5,@Column6,@Column7);SELECT SCOPE_IDENTITY(); ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column2", TestTypeID);
            Command.Parameters.AddWithValue("@Column3", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@Column4", AppointmentDate);
            Command.Parameters.AddWithValue("@Column5", PaidFees);
            Command.Parameters.AddWithValue("@Column6", CreatedByUserID);
            Command.Parameters.AddWithValue("@Column7", IsLocked);

            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int InsertedID))
                {
                    TestAppointmentsID = InsertedID;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return TestAppointmentsID;
        }
        public static bool UpdateTestAppointments(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, int PaidFees, int CreatedByUserID, bool IsLocked)
        {
            bool IsUpdate = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "update TestAppointments set  TestTypeID=@Column2,LocalDrivingLicenseApplicationID=@Column3,AppointmentDate=@Column4,PaidFees=@Column5,CreatedByUserID=@Column6,IsLocked=@Column7 where TestAppointmentID=@Column1 ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", TestAppointmentID);
            Command.Parameters.AddWithValue("@Column2", TestTypeID);
            Command.Parameters.AddWithValue("@Column3", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@Column4", AppointmentDate);
            Command.Parameters.AddWithValue("@Column5", PaidFees);
            Command.Parameters.AddWithValue("@Column6", CreatedByUserID);
            Command.Parameters.AddWithValue("@Column7", IsLocked);

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
        public static bool Find(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref int PaidFees, ref int CreatedByUserID, ref bool IsLocked)
        {
            bool IsFound = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "select * from TestAppointments where TestAppointmentID=@Column1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", TestAppointmentID);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    TestAppointmentID = (int)Reader["TestAppointmentID"];
                    TestTypeID = (int)Reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)Reader["AppointmentDate"];
                    PaidFees = (int)Reader["PaidFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsLocked = (bool)Reader["IsLocked"];

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
        public static bool DeleteTestAppointments(int ID)
        {
            bool IsDeleted = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "delete TestAppointments where ID=@Column1 ";
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
        public static bool IsTestAppointmentsExist(int TestAppointmentsID)
        {
            bool IsExist = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = " select Found=1 from TestAppointments  where TestAppointmentsID = @Column1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", TestAppointmentsID);
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
        public static DataTable GitAllTestAppointments(int TestTypeID,int LLApplicationID)
        {
            DataTable dt = new DataTable();
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");




            string Query = "SELECT * FROM TestAppointments where TestTypeID=@testtype and LocalDrivingLicenseApplicationID=@llapplicationID";

            SqlCommand Command = new SqlCommand(Query, Conniction);

            Command.Parameters.AddWithValue("@testtype", TestTypeID);
            Command.Parameters.AddWithValue("@llapplicationID", LLApplicationID);

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


        public static bool IsTestAppointemntExistAndIsRusltIsFail(int TestAppointmentID)
        {
            bool IsExist = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = " select Found=1 from Tests  where TestAppointmentsID = @Column1 and TestResult=0";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", TestAppointmentID);
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

        public static bool IsThereAnyTestAppointmentActive(int LLApplicationID)
        {
            bool IsLocked = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = " select Found=1 from TestAppointments  where LocalDrivingLicenseApplicationID = @Column1 and IsLocked=0";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", LLApplicationID);
            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null)
                    IsLocked = true;
                else
                    IsLocked = false;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return IsLocked;
        }

        public static bool UpdateTestAppointmentWhenTakeTest(int TestAppointmentID)
        {
            bool IsUpdate = false;

          
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "update TestAppointments set IsLocked=1 where TestAppointmentID=@Column1 ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", TestAppointmentID);
         

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


        public static bool IsTestAppointmentLocked(int TestAppointmentID)
        {
            bool IsLocked = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = " select Found=1 from TestAppointments  where TestAppointmentID = @Column1 and IsLocked=1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", TestAppointmentID);
            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null)
                    IsLocked = true;
                else
                    IsLocked = false;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return IsLocked;
        }


    }
}
