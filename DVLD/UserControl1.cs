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
using System.IO;

namespace DVLD
{
    public partial class UserControl1: UserControl
    {
        clsPeople _person;
        int _PersonID=-1;

        public int personID
        {
           get{ return _PersonID; }
        }
        public clsPeople SelectedPersonInfo
        {
            get { return _person; }
        }
        public void LoadPersonInfo(int ID)
        {
            _PersonID = ID;
            _person = clsPeople.Find(_PersonID);
            if(_person==null)
            {
                MessageBox.Show("ther is no person with ID " + ID);
                return;
            }
            _FillPersonInfo();
        }
        public UserControl1()
        {
            
            InitializeComponent();
           
        }
        private void _LoadPersonImage()
        {
            if (_person.Gendor == 0)
                pictureBox1.Image = Properties.Resources.Male_512;
            else
                pictureBox1.Image = Properties.Resources.Female_512;
            string ImagePath = _person.ImagePath;

            if (ImagePath != "" || ImagePath != null)
                if (File.Exists(ImagePath))
                    pictureBox1.ImageLocation = ImagePath;
                else
                    MessageBox.Show("could no find image : = " + ImagePath, "error", MessageBoxButtons.OK);


        }
        private void _FillPersonInfo()
        {
            linklblEditPerson.Enabled = true;
            lblName.Text = _person.FirstName + " " + _person.SecondName + " " + _person.ThirdName + " " + _person.LastName;
            lblEmail.Text = _person.Email;
            lblAddress.Text = _person.Address;
            lblNationalNo.Text = _person.NationalNo;
            lblPhone.Text = _person.Phone;
            lblPersonID.Text = _PersonID.ToString();
            lblDateOfBirth.Text = _person.DateOfBirth.ToShortDateString();
          
            lblGendor.Text = _person.Gendor == 0 ? "Male" : "Female";
            lblCountry.Text = clsCountries.Find(_person.NationalityCountryID).CountryName;
            _LoadPersonImage();


        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            _FillPersonInfo();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblDateOfBirth_Click(object sender, EventArgs e)
        {

        }

        private void linklblEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddEditPersonfrm frm = new AddEditPersonfrm(_PersonID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);
        }
    }
}
