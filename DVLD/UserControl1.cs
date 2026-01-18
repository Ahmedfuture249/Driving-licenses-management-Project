using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBusinessLayer;

namespace DVLD
{
    public partial class UserControl1: UserControl
    {
        clsPeople _person;
        int _PersonID;

        public int personID ()
        {
            return _PersonID;
        }
        public clsPeople person() 
        { 
            return _person;
        }
        public UserControl1(int personID)
        {
            
            InitializeComponent();
            _PersonID = personID;
            _person = clsPeople.Find(_PersonID);
        }
        public void LoadData()
        {
            lblName.Text = _person.FirstName + " " + _person.SecondName + " " + _person.ThirdName + " " + _person.LastName;
            lblEmail.Text = _person.Email;
            lblAddress.Text = _person.Address;
            lblNationalNo.Text = _person.NationalNo;
            lblPhone.Text = _person.Phone;
            lblPersonID.Text = _PersonID.ToString();
            lblDateOfBirth.Text = _person.DateOfBirth.ToString();
            if (_person.Gendor == 0)
                lblGendor.Text = "MALE";
            else
                lblGendor.Text = "FEMALE";
            lblCountry.Text = clsCountries.Find(_person.CountryID).CountryName;
            
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblDateOfBirth_Click(object sender, EventArgs e)
        {

        }
    }
}
