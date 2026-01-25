using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddNewUser: Form
    {
        clsUsers _User;
        clsPeople _person;
        int _PersonID;
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode;
        public frmAddNewUser()
        {
            InitializeComponent();
          
            Mode = enMode.AddNew;
            if (Mode == enMode.AddNew)
            {
                _User = new clsUsers();
            }
            _PersonID = userControl22.personID;
            _person = clsPeople.Find(_PersonID);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _PersonID = userControl22.personID;
            _person = clsPeople.Find(_PersonID);

            _User.UserName = txtUserName.Text;
            _User.UserPassword = txtPassword.Text;
            if(checkBoxIsActive.Checked==true)
            {
                _User.IsActive = 1;
            }
            else
            {
                _User.IsActive = 0;
            }
            if(_person!=null)
            {
                _User.PersonID = _PersonID;
            }
           if( _User.Save())
            {
                MessageBox.Show("new user with ID = " + _User.UserID + "Added");
            }
           else
            {
                MessageBox.Show("SOMTHING WRONG HAPPEND");
            }
        }
    }
}
