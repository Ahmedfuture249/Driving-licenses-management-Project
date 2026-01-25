using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DVLD
{
    public partial class AddEditPersonfrm: Form
    {
        enum enMode { AddNew=0,Update=1}
        enMode Mode;
        int _PersonID;
        clsPeople _Person;
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public AddEditPersonfrm(int PerosnID)
        {
            InitializeComponent();
            _PersonID = PerosnID;
            if (_PersonID == -1)
                Mode = enMode.AddNew;
            else
                Mode = enMode.Update;
        }
        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountries.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {

               CbCountries.Items.Add(row["CountryName"]);

            }

        }
        private void _ResetDefaultValues()
        {
            _FillCountriesInComoboBox();
            if (Mode == enMode.AddNew)
                lblMode.Text = "ADD NEW PERSON";
            else
                lblMode.Text = "UPDATE MODE";

            
            if (rbMale.Checked)
                pictureBox1.Image= Properties.Resources.Male_512;
            else
                pictureBox1.Image= Properties.Resources.Female_512;

            _Person = new clsPeople();
            lblPerosnID.Text = "";
            txtFirstName.Text =  "";
            txtSecondName.Text = "";
            txtThirdName.Text =  "";
            txtLastName.Text =   "";
            txtNationalNo.Text  = "";
            txtEmail.Text =      "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            dateTimePicker1.MinDate=DateTime.Now.AddYears(-100);
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            dateTimePicker1.Value = dateTimePicker1.MaxDate;
            rbMale.Checked = true;

        }
        public  void _LoadData()
        {
            _FillCountriesInComoboBox();
            CbCountries.SelectedIndex =164;
            if (Mode==enMode.AddNew)
            {
                _Person = new clsPeople();
                return;
            }
            lblMode.Text = "Edit Person ID = " + _PersonID.ToString();
            _Person = clsPeople.Find(_PersonID);
            
            if (_Person == null)
            {
                MessageBox.Show("Person is null ,the form will be closd ");
                this.Close();
                return;
            }
           
           lblPerosnID.Text =     _PersonID.ToString();
            txtFirstName.Text =    _Person.FirstName;
            txtSecondName.Text =   _Person.SecondName;
            txtThirdName.Text =    _Person.ThirdName;
            txtLastName.Text =     _Person.LastName;
            txtNationalNo.Text =   _Person.NationalNo;
             txtEmail.Text =       _Person.Email;
            if(_Person.Gendor==0)
            {
                rbMale.Checked=true;
               
            }
            if (_Person.Gendor ==1 )
            {
                rbFemale.Checked = true;
            }
            
            txtPhone.Text =   _Person.Phone;
            txtAddress.Text = _Person.Address;
            dateTimePicker1.Value = _Person.DateOfBirth;
            
            
            if (_Person.ImagePath != "")
            {
                pictureBox1.ImageLocation=_Person.ImagePath;
            }
           linklblRemoveImage.Visible = (_Person.ImagePath != "");
          CbCountries.SelectedIndex= CbCountries.FindString(clsCountries.Find(_Person.NationalityCountryID).CountryName);

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void AddEditPersonfrm_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if(Mode==enMode.Update)
            _LoadData();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int NationalityCountryID = clsCountries.Find(CbCountries.Text).ID;
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.NationalNo = txtNationalNo.Text;
            _Person.Email = txtEmail.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Address = txtAddress.Text;
            _Person.DateOfBirth = dateTimePicker1.Value;
            _Person.PersonID = _PersonID;
            _Person.NationalityCountryID = NationalityCountryID;
            //pictureBox1.ImageLocation = "kdjkldfj";
            if (pictureBox1.ImageLocation != null)
            {
                _Person.ImagePath = pictureBox1.ImageLocation;
            }
            else
            {
                _Person.ImagePath = "";
            }
            if (rbFemale.Checked==true)
            {
                _Person.Gendor = 1;
            }
            if (rbMale.Checked == true)
            {
                _Person.Gendor = 0;
            }
            _Person.Save();
        }
       
        

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
           
        }
        string _SelectedImagePath;
        private void linklblSelectImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _SelectedImagePath = ofd.FileName;
                pictureBox1.Image = Image.FromFile(_SelectedImagePath);
            }
        }
    }
}
