using DVLD_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsUsers : clsPeoples
    {

        public enum enMode { Add, Update }
        public enMode Mode;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IsActive { get; set; }

        private clsUsers(int UserID, int PersonID, string UserName, string Password, int IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            this.Mode = enMode.Update;
        }
        public clsUsers()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = -1;

            this.Mode = enMode.Add;
        }
        private bool _AddUsers()
        {
            this.UserID = clsUsersData.AddNewUsers(this.PersonID, this.UserName, this.Password, this.IsActive);
            return (this.UserID != -1);
        }
        private bool _UpdateUsers()
        {
            return clsUsersData.UpdateUsers(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);
        }
        public bool Save()
        {

            switch (Mode)
            {
                case enMode.Update:
                    {
                        return _UpdateUsers();
                    }
                case enMode.Add:
                    {
                        if (_AddUsers())
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
        public static bool DeleteUsers(int UserID)
        {
            return clsUsersData.DeleteUsers(UserID);
        }
        public static DataTable GitAllUsers()
        {
            return clsUsersData.GitAllUsers();
        }
        public static clsUsers Find(int UserID)
        {
            int Column2 = 0;
            string Column3 = "";
            string Column4 = "";
            int Column5 = 0;

            if (clsUsersData.Find(UserID, ref Column2, ref Column3, ref Column4, ref Column5))
                return new clsUsers(UserID, Column2, Column3, Column4, Column5);
            else
                return null;
        }

        public static clsUsers Find( string UserName)
        {
            int Column1 = 0;
            int Column2 = 0;
           
            string Column4 = "";
            int Column5 = 0;

            if (clsUsersData.Find(ref Column1, ref Column2, UserName, ref Column4, ref Column5))
                return new clsUsers(Column1, Column2, UserName, Column4, Column5);
            else
                return null;
        }




        public static bool IsUsersExist(string Username)
        {
            return clsUsersData.IsUsersExist(Username);
        }


        public static bool UpdatePasswordForUsers(int UserID, string Password)
        {
            return clsUsersData.UpdatePasswordForUsers(UserID, Password);
        }


    }
}
