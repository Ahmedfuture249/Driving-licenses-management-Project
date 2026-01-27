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
        int _UserID;
        int _PersonID;
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode;
        public frmAddNewUser(int ID)
        {
            InitializeComponent();

            _UserID = ID;
            

            if (_UserID == -1)
            {
                Mode = enMode.AddNew;
                _User = new clsUsers();
                lblMode.Text = "Add New User";
                
            }
            else
            {
                Mode = enMode.Update;
                lblMode.Text = "Update User";
              
                   LoadUserInfo();
                
            }

        }
         public void LoadUserInfo()
        {
            _User = clsUsers.Find(_UserID);
            if (_User == null)
            {
                MessageBox.Show("USER NOT FOUNDED", "NOT FOUNDED", MessageBoxButtons.OK);
                return;
            }
           
            
                userControl22.LoadPersonInfo(_User.PersonID);
               userControl22.FilterByEnabled = false;

              
            
            txtPassword.Text = _User.UserPassword;
            txtConfirmPassword.Text = _User.UserPassword;
            txtUserName.Text = _User.UserName;
            if (_User.IsActive == true)
                checkBoxIsActive.Checked = true;
            else
                checkBoxIsActive.Checked = false;
            lblUserID.Text = _User.UserID.ToString();
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
                _User.IsActive = true;
            }
            else
            {
                _User.IsActive =false;
            }
            if(_person!=null)
            {
                _User.PersonID = _PersonID;
            }
           if( _User.Save())
            {
                MessageBox.Show("saved succussfuly");
            }
           else
            {
                MessageBox.Show("SOMTHING WRONG HAPPEND");
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "user name must have value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, "");
            }

        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password must have value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text!=txtConfirmPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "The password confirmation does not match");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }

        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
             
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //if (Mode == enMode.Update)
            //{
            //    tabPageLoginInfo.Enabled = true;
            //    tabControl1.SelectedTab = tabControl1.TabPages["tabPageLoginInfo"];
            //    return;
            //}
            //if (userControl22.personID != -1)
            //{
            //    if (clsUsers.IsUserExistForPersonID(userControl22.personID))
            //    {
            //        MessageBox.Show("selected person is already has user ,chose another One");
            //    }
            //    else
            //    {
            //        tabPageLoginInfo.Enabled = true;
            //        tabControl1.SelectedTab = tabControl1.TabPages["tabPagePersonInfo"];


            //    };
            //};

        }
    }
}
