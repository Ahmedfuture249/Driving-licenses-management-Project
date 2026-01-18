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
                pictureBox1.Image = Image.FromFile(@"C:\Users\Lenovo\Desktop\Icons\Male 512.png");
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
                pictureBox1.Load(_Person.ImagePath);
            }
           linklblRemoveImage.Visible = (_Person.ImagePath != "");
          // CbCountries.SelectedIndex= CbCountries.FindString(clsCountries.Find(_Person.CountryID).CountryName);

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void AddEditPersonfrm_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

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
            _Person.NationalityCountryID = CbCountries.SelectedIndex;
            if (pictureBox1.Image == null)
            {
                _Person.ImagePath = "";
            }
            else
            {
                _Person.ImagePath = _SelectedImagePath;
            }
            if (rbFemale.Checked==true)
            {
                _Person.Gendor = 1;
            }
            else
            {
                _Person.Gendor = 1;
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
