using DVLD_BusinessLayer;
using DVLD_Project.Properties;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DVLD_Project
{
    public partial class frmAdd_Edit_Person : Form
    {
        public frmAdd_Edit_Person(int personiD)
        {
            InitializeComponent();
            if (personiD !=0)
            {
                PersonID = personiD;
                _Person = clsPeoples.Find(PersonID);
            }

        }
        clsPeoples _Person;
        int PersonID;

        string _ImagePath = "";

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(PersonID==0)
            {
                clsPeoples Person = new clsPeoples();

                Person.FirstName = TxtFirstName.Text;
                Person.SecondName = TxtSecondName.Text;
                Person.ThirdName = TxtThirdName.Text;
                Person.LastName = TxtLastName.Text;
                Person.NationalNo = TxtNationalNo.Text;
                Person.NationalityCountryID = ComboForCountres.SelectedIndex + 1;


                
                Person.Email = TxtEmail.Text;
                Person.Phone = TxtPhone.Text;
                Person.Address = TxtAddress.Text;
                Person.DateOfBirth = DatePickerForPerson.Value;
                if (RDMale.Checked)
                {
                    Person.Gendor = 1;
                    PictureForPerson.Image = Resources.person_boy__2_;

                }
                if (RDFemale.Checked)
                {
                    Person.Gendor = 2;
                    PictureForPerson.Image = Resources.person_girl;
                }


                if (_ImagePath != "")
                    Person.ImagePath = _ImagePath;
                else
                    Person.ImagePath = "";

                if (Person.Save())
                    MessageBox.Show("Person Added Succssfilly", "Add People", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Person Does Not Added", "Add People", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UpdatePerosn();

                if (_Person.Save())
                    MessageBox.Show("Person Updated Succssfilly", "Updated People", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Person Does Not Updated", "Updated People", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         

            this.Close();
        }

        private void LinkLblForSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PictureForPerson.Image = new Bitmap(openFileDialog1.FileName);
                _ImagePath = openFileDialog1.FileName;
            }
            else
            {
                _ImagePath=_Person.ImagePath;
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (TxtFirstName.Text == string.Empty)
            {
                e.Cancel = true;
                TxtFirstName.Focus();
                errorProvider1.SetError(TxtFirstName, "Plese Enter First Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtFirstName, "");
            }
        }

        private void TxtSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (TxtSecondName.Text == string.Empty)
            {
                e.Cancel = true;
                TxtSecondName.Focus();
                errorProvider1.SetError(TxtSecondName, "Plese Enter Second Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtSecondName, "");
            }
        }

        private void TxtThirdName_Validating(object sender, CancelEventArgs e)
        {
            if (TxtThirdName.Text == string.Empty)
            {
                e.Cancel = true;
                TxtThirdName.Focus();
                errorProvider1.SetError(TxtThirdName, "Plese Enter Third Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtThirdName, "");
            }
        }

        private void TxtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (TxtLastName.Text == string.Empty)
            {
                e.Cancel = true;
                TxtLastName.Focus();
                errorProvider1.SetError(TxtLastName, "Plese Enter Last Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtLastName, "");
            }
        }

        private void TxtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (TxtNationalNo.Text == string.Empty)
            {
                e.Cancel = true;
                TxtNationalNo.Focus();
                errorProvider1.SetError(TxtNationalNo, "Plese Enter Natioal Number");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtNationalNo, "");
            }


            if (clsPeoples.IsPeopleExist(TxtNationalNo.Text))
            {
                e.Cancel = true;
                TxtNationalNo.Focus();
                errorProvider1.SetError(TxtNationalNo, "There Are Another Person With This National Number");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtNationalNo, "");
            }




        }

        private void TxtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (TxtEmail.Text == string.Empty)
            {
                e.Cancel = true;
                TxtEmail.Focus();
                errorProvider1.SetError(TxtEmail, "Plese Enter Email");
            }
        
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtEmail, "");
            }
        }

        private void TxtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (TxtPhone.Text == string.Empty)
            {
                e.Cancel = true;
                TxtPhone.Focus();
                errorProvider1.SetError(TxtPhone, "Plese Enter Phone Number");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtPhone, "");
            }
        }

        private void frmAdd_Edit_Person_Load(object sender, EventArgs e)
        {
            DataTable dt = clsPeoples.GitAllCountry();
            foreach (DataRow Row in dt.Rows)
            {
                ComboForCountres.Items.Add(Row[1].ToString());
            }
            
            DatePickerForPerson.MaxDate = DateTime.Now.AddYears(-18);

            if(PersonID==0)
            {              
                ComboForCountres.SelectedIndex = 89;
                return;
            }
            else
            {
                FillDataToForm();
            }



        }


        void FillDataToForm()
        {
            TxtFirstName.Text = _Person.FirstName;
            TxtLastName.Text = _Person.LastName;
            TxtEmail.Text = _Person.Email;
            TxtPhone.Text = _Person.Phone;
            TxtSecondName.Text = _Person.SecondName;
            TxtThirdName.Text = _Person.ThirdName;
            TxtNationalNo.Text = _Person.NationalNo;
            TxtAddress.Text = _Person.Address;

            DatePickerForPerson.Value = _Person.DateOfBirth;
            ComboForCountres.SelectedIndex = _Person.NationalityCountryID - 1;

            if (_Person.Gendor==1)
            {
                RDMale.Checked=true;
            }
            if(_Person.Gendor==2)
            {
                RDFemale.Checked=true;
            }

            if(_Person.ImagePath!="")
            {
                PictureForPerson.Image = Image.FromFile(_Person.ImagePath);
               _ImagePath=_Person.ImagePath;
            }
            if(_Person.ImagePath=="" && _Person.Gendor==1)
            {
                PictureForPerson.Image = Resources.person_boy__2_;
            }
            if (_Person.ImagePath == "" && _Person.Gendor == 2)
            {
                PictureForPerson.Image = Resources.person_girl;
            }
            this.Text = "Update Person";
            lblForWhatThisFrm.Text = "Update Person";
            lblPersonID.Text=PersonID.ToString();
        }



        void UpdatePerosn()
        {
            _Person.FirstName = TxtFirstName.Text;
            _Person.SecondName= TxtSecondName.Text;
            _Person.ThirdName= TxtThirdName.Text;
            _Person.LastName= TxtLastName.Text;
            _Person.NationalNo= TxtNationalNo.Text;
            _Person.Address= TxtAddress.Text;
            _Person.Phone= TxtPhone.Text;
            _Person.PersonID =PersonID;
            _Person.Email= TxtEmail.Text;

            if (_ImagePath != "")
            {
              _Person.ImagePath= _ImagePath;
            }                
            else
                _Person.ImagePath = "";

           

            if(RDMale.Checked)
                _Person.Gendor= 1;
            if(RDFemale.Checked)
                _Person.Gendor= 2;

            _Person.DateOfBirth = DatePickerForPerson.Value;
        }



    }
}
