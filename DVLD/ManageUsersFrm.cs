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
    public partial class ManageUsersFrm: Form
    {
        private static DataTable _dtAllUsers = clsUsers.GetAllUsers();
        public ManageUsersFrm()
        {
            InitializeComponent();
        }
        
        private void _RefreshUsersList()
        {
            dgvGetAllUsers.DataSource = _dtAllUsers;
        }
        private void ManageUsersFrm_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();
        }

        private void dgvGetAllPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm = new frmAddNewUser();
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void txtFilterByValue_TextChanged(object sender, EventArgs e)
        {
            string selectedText = cbFilterBy.SelectedItem?.ToString().Trim();
            string FilterCoulmn = "";
            switch (selectedText)
            {
                case "User ID":
                    FilterCoulmn = "UserID";
                    break;
                case "User Name":
                    FilterCoulmn = "UserName";
                    break;
              
                default:
                    FilterCoulmn = "None";
                    break;
            }
            if (txtFilterByValue.Text.Trim() == "" || FilterCoulmn == "None")
            {
            _dtAllUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvGetAllUsers.Rows.Count.ToString();
                return;
            }
            if (FilterCoulmn == "UserID")
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterCoulmn, txtFilterByValue.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterCoulmn, txtFilterByValue.Text.Trim());


            lblRecordsCount.Text = dgvGetAllUsers.Rows.Count.ToString();

        

    }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  frmAddNewUser frm = new frmAddNewUser((int)dgvGetAllPeople.CurrentRow.Cells[0].Value);
            //frm.ShowDialog();
            //_RefreshUsersList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvGetAllUsers.CurrentRow.Cells[0].Value;
            UserDetailsfrm frm = new UserDetailsfrm(ID);
            frm.ShowDialog();
            _RefreshUsersList();
        }
    }
}
