using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DVLD_DataLayer
{
    public class clsDetainedLicensesData
    {
        public static int AddNewDetainedLicenses(int LicenseID, DateTime DetainDate, int FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int DetainedLicensesID = -1;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "insert into DetainedLicenses (LicenseID,DetainDate,FineFees,CreatedByUserID,IsReleased,ReleaseDate,ReleasedByUserID,ReleaseApplicationID) values (@Column2,@Column3,@Column4,@Column5,@Column6,@Column7,@Column8,@Column9);SELECT SCOPE_IDENTITY(); ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column2", LicenseID);
            Command.Parameters.AddWithValue("@Column3", DetainDate);
            Command.Parameters.AddWithValue("@Column4", FineFees);
            Command.Parameters.AddWithValue("@Column5", CreatedByUserID);
            Command.Parameters.AddWithValue("@Column6", IsReleased);


            if(ReleaseDate==Convert.ToDateTime( "2000-11-2"))
                Command.Parameters.AddWithValue("@Column7", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Column7", ReleaseDate);


            if (ReleasedByUserID == -1)
                Command.Parameters.AddWithValue("@Column8", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Column8", ReleasedByUserID);


            if (ReleaseApplicationID == -1)
                Command.Parameters.AddWithValue("@Column9", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Column9", ReleaseApplicationID);


            try
            {
                Conniction.Open();
                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int InsertedID))
                {
                    DetainedLicensesID = InsertedID;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }
            return DetainedLicensesID;
        }
        public static bool UpdateDetainedLicenses(int DetainID, int LicenseID, DateTime DetainDate, int FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            bool IsUpdate = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "update DetainedLicenses set  LicenseID=@Column2,DetainDate=@Column3,FineFees=@Column4,CreatedByUserID=@Column5,IsReleased=@Column6,ReleaseDate=@Column7,ReleasedByUserID=@Column8,ReleaseApplicationID=@Column9 where DetainID=@Column1 ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", DetainID);
            Command.Parameters.AddWithValue("@Column2", LicenseID);
            Command.Parameters.AddWithValue("@Column3", DetainDate);
            Command.Parameters.AddWithValue("@Column4", FineFees);
            Command.Parameters.AddWithValue("@Column5", CreatedByUserID);
            Command.Parameters.AddWithValue("@Column6", IsReleased);
            Command.Parameters.AddWithValue("@Column7", ReleaseDate);
            Command.Parameters.AddWithValue("@Column8", ReleasedByUserID);
            Command.Parameters.AddWithValue("@Column9", ReleaseApplicationID);

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
        public static bool Find(int DetainID, ref int LicenseID, ref DateTime DetainDate, ref int FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool IsFound = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "select * from DetainedLicenses where DetainID=@Column1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", DetainID);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    DetainID = (int)Reader["DetainID"];
                    LicenseID = (int)Reader["LicenseID"];
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = (int)Reader["FineFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsReleased = (bool)Reader["IsReleased"];
                    ReleaseDate = (DateTime)Reader["ReleaseDate"];
                    ReleasedByUserID = (int)Reader["ReleasedByUserID"];
                    ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];

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
        public static bool DeleteDetainedLicenses(int ID)
        {
            bool IsDeleted = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "delete DetainedLicenses where ID=@Column1 ";
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
        public static bool IsDetainedLicensesExist(int DetainedLicensesID)
        {
            bool IsExist = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = " select Found=1 from DetainedLicenses  where DetainedLicensesID = @Column1";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", DetainedLicensesID);
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
        public static DataTable GitAllDetainedLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Query = "SELECT * FROM DetaindList";
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


        public static bool Find(ref int DetainID,  int LicenseID, ref DateTime DetainDate, ref int FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool IsFound = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "select * from DetainedLicenses where LicenseID=@Column2";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column2", LicenseID);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    DetainID = (int)Reader["DetainID"];
                    LicenseID = (int)Reader["LicenseID"];
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = (int)Reader["FineFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsReleased = (bool)Reader["IsReleased"];

                    if (Reader["ReleaseDate"] == DBNull.Value)
                        ReleaseDate =Convert.ToDateTime("2000-11-2");
                    else
                        ReleaseDate = (DateTime)Reader["ReleaseDate"];


                    if (Reader["ReleasedByUserID"] == DBNull.Value)
                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)Reader["ReleasedByUserID"];

                    if (Reader["ReleaseApplicationID"] == DBNull.Value)
                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];

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
        public static bool FindForReleasedOnly(ref int DetainID, int LicenseID, ref DateTime DetainDate, ref int FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool IsFound = false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "select * from DetainedLicenses where LicenseID=@Column2 and IsReleased=0";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column2", LicenseID);
            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    DetainID = (int)Reader["DetainID"];
                    LicenseID = (int)Reader["LicenseID"];
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = (int)Reader["FineFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsReleased = (bool)Reader["IsReleased"];

                    if (Reader["ReleaseDate"] == DBNull.Value)
                        ReleaseDate = Convert.ToDateTime("2000-11-2");
                    else
                        ReleaseDate = (DateTime)Reader["ReleaseDate"];


                    if (Reader["ReleasedByUserID"] == DBNull.Value)
                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)Reader["ReleasedByUserID"];

                    if (Reader["ReleaseApplicationID"] == DBNull.Value)
                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];

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

        public static bool ReleaseLicense(int DetainID,System.DateTime ReleaseDate,int ReleaseApplicationID,int UserID)
        {
            bool IsReleased=false;
            SqlConnection Conniction = new SqlConnection("Server=.;Database=DVLD;User Id=sa;Password=123456");
            string Querey = "update DetainedLicenses set IsReleased=1  , ReleaseDate=@Column7 , ReleasedByUserID=@Column8 , ReleaseApplicationID=@Column9 where DetainID=@Column1 ";
            SqlCommand Command = new SqlCommand(Querey, Conniction);
            Command.Parameters.AddWithValue("@Column1", DetainID);
            Command.Parameters.AddWithValue("@Column7", ReleaseDate);
            Command.Parameters.AddWithValue("@Column8", UserID);
            Command.Parameters.AddWithValue("@Column9", ReleaseApplicationID);
            try
            {
                Conniction.Open();
                int RowEffected = Command.ExecuteNonQuery();
                if (RowEffected > 0)
                {
                    IsReleased = true;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conniction.Close();
            }

            return IsReleased;
        }

    }
}
