using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataLayer;

namespace DVLD_BusinessLayer
{
    public class clsPeoples
    {
       public enum enMode { Add, Update }
        public enMode Mode;
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        private clsPeoples(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            this.Mode = enMode.Update;
        }
        public clsPeoples()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gendor = -1;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            this.Mode = enMode.Add;
        }
        private bool _AddPeople()
        {
            this.PersonID = clsPeoplesData.AddNewPeople(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
            return (this.PersonID != -1);
        }
        private bool _UpdatePeople()
        {
            return clsPeoplesData.UpdatePeople(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Update:
                    {
                        return _UpdatePeople();
                    }
                case enMode.Add:
                    {
                        if (_AddPeople())
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
        public static bool DeletePeople(int PersonID)
        {
            return clsPeoplesData.DeletePeople(PersonID);
        }
        public static DataTable GitAllPeople()
        {
            return clsPeoplesData.GitAllPeople();
        }
        public static clsPeoples Find(int PersonID)
        {
            string Column2 = "";
            string Column3 = "";
            string Column4 = "";
            string Column5 = "";
            string Column6 = "";
            DateTime Column7 = DateTime.Now;
            int Column8 = 0;
            string Column9 = "";
            string Column10 = "";
            string Column11 = "";
            int Column12 = 0;
            string Column13 = "";

            if (clsPeoplesData.Find(PersonID, ref Column2, ref Column3, ref Column4, ref Column5, ref Column6, ref Column7, ref Column8, ref Column9, ref Column10, ref Column11, ref Column12, ref Column13))
                return new clsPeoples(PersonID, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9, Column10, Column11, Column12, Column13);
            else
                return null;
        }

        public static clsPeoples Find(string NationalNo)
        {
            int Column1 = 0;    
         string Column3 = "";
            string Column4 = "";
            string Column5 = "";
            string Column6 = "";
            DateTime Column7 = DateTime.Now;
            int Column8 = 0;
            string Column9 = "";
            string Column10 = "";
            string Column11 = "";
            int Column12 = 0;
            string Column13 = "";

            if (clsPeoplesData.Find(ref Column1, NationalNo, ref Column3, ref Column4, ref Column5, ref Column6, ref Column7, ref Column8, ref Column9, ref Column10, ref Column11, ref Column12, ref Column13))
                return new clsPeoples(Column1, NationalNo, Column3, Column4, Column5, Column6, Column7, Column8, Column9, Column10, Column11, Column12, Column13);
            else
                return null;
        }



        public static string GitCountryName(int PersonID)
        {
            return clsPeoplesData.GitCountryName(PersonID);
        }

        public static bool IsPeopleExist(string NationalNo)
        {
           return clsPeoplesData.IsPeopleExist(NationalNo);
        }
        public static bool IsPeopleExist(int PersonID)
        {
            return clsPeoplesData.IsPeopleExist(PersonID);
        }

        public static DataTable GitAllCountry()
        {
            return clsPeoplesData.GitAllCountry();
        }


    }




}
