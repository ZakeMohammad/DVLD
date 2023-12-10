using DVLD_BusinessLayer;
using DVLD_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class ctrlPersonInformation : UserControl
    {
        public ctrlPersonInformation()
        {
            InitializeComponent();
        }

        public int PersonID;
        public string NationalNO;


        public void FillDataToUserControlPersonInfoByPersonID(int Personid)
        {
            clsPeoples Person = clsPeoples.Find(Personid);
            NationalNO = Person.NationalNo;
            PersonID = Person.PersonID;
            lblPersonID.Text= Person.PersonID.ToString();
            lblName.Text=Person.FirstName+ " "+Person.SecondName+" "+Person.ThirdName+" "+Person.LastName;
            lblName.ForeColor= Color.Red;
            lblNationalNo.Text=Person.NationalNo.ToString();
            lblEmail.Text= Person.Email.ToString();
            lblPhone.Text= Person.Phone.ToString();
            if(Person.Gendor==1)
            {
                lblGender.Text = "Male";
                pictureBox4.Image = Resources.administrator;
            }
            if (Person.Gendor == 2)
            {
                lblGender.Text = "Female";
                pictureBox4.Image = Resources.patient_girl;
            }

            lblAddress.Text= Person.Address.ToString();

            if(Person.ImagePath=="" && Person.Gendor==1)
            {
                PictureForPerson.Image = Resources.person_boy__2_;
            }

            if (Person.ImagePath == "" && Person.Gendor == 2)
            {
                PictureForPerson.Image = Resources.person_girl;
            }
            if(Person.ImagePath!="")
            {
                PictureForPerson.Image=Image.FromFile(Person.ImagePath);
            }

            lblDate.Text = Person.DateOfBirth.ToShortDateString();

            lblCountry.Text = clsPeoples.GitCountryName(Person.PersonID);

        }

        public void FillDataToUserControlPersonInfoByPersonNationaNO(string NationalNo)
        {
            clsPeoples Person = clsPeoples.Find(NationalNo);
            NationalNO = Person.NationalNo;
            PersonID= Person.PersonID;
            lblPersonID.Text = Person.PersonID.ToString();
            lblName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
            lblName.ForeColor = Color.Red;
            lblNationalNo.Text = Person.NationalNo.ToString();
            lblEmail.Text = Person.Email.ToString();
            lblPhone.Text = Person.Phone.ToString();
            if (Person.Gendor == 1)
            {
                lblGender.Text = "Male";
                pictureBox4.Image = Resources.administrator;
            }
            if (Person.Gendor == 2)
            {
                lblGender.Text = "Female";
                pictureBox4.Image = Resources.patient_girl;
            }

            lblAddress.Text = Person.Address.ToString();

            if (Person.ImagePath == "" && Person.Gendor == 1)
            {
                PictureForPerson.Image = Resources.person_boy__2_;
            }

            if (Person.ImagePath == "" && Person.Gendor == 2)
            {
                PictureForPerson.Image = Resources.person_girl;
            }
            if (Person.ImagePath != "")
            {
                PictureForPerson.Image = Image.FromFile(Person.ImagePath);
            }

            lblDate.Text = Person.DateOfBirth.ToShortDateString();

            lblCountry.Text = clsPeoples.GitCountryName(Person.PersonID);

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAdd_Edit_Person New = new frmAdd_Edit_Person(PersonID);
            New.ShowDialog();
        }
    }
}
