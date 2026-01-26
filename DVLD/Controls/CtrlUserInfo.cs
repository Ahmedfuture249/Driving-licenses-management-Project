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
    public partial class CtrlUserInfo: UserControl
    {
        clsUsers _User;
        int _UserID;
        public clsUsers User
        { 
            get { return _User; }
        }
        public int UserID
        {
            get { return _UserID; }
        }

        public CtrlUserInfo()
        {
            InitializeComponent();
        }
        public  void  _LoadUserInof(int UserID)
        {
            _UserID = UserID;
            _User = clsUsers.Find(_UserID);
            if(_User==null)
            {
                MessageBox.Show("user not founded");
                return;
            }
            _FilLUserInfo();

        }
        private void _FilLUserInfo()
        {
            userControl11.LoadPersonInfo(_User.PersonID);
            lblUserName.Text = _User.UserName;
            if (_User.IsActive == false)
                lblIsActive.Text = " NO ";
            else
                lblIsActive.Text = " yes ";
            lblUserID.Text = _User.UserID.ToString();
        }
        private void CtrlUserInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
