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
           
           lblPerosnID.Text = _PersonID.ToString();
            txtFirstName.Text = "kkkk";
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
             txtEmail.Text = _Person.Email;
            if(_Person.Gendor==0)
            {
                rbMale.Checked=true;
            }
            if (_Person.Gendor ==1 )
            {
                rbFemale.Checked = true;
            }
            txtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;
            dateTimePicker1.Value = _Person.DateOfBirth;
            //if(_Contact.ImagePath!="")
            //{
            //    pictureBox1.Load(_Contact.ImagePath);
            //}
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

        }
    }
}
