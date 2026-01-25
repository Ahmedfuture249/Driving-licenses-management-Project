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
    public partial class ManagePeoplefrm: Form
    {
        private static DataTable _dtAllPeople = clsPeople.GetAllPeople();
        
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", 
            "LastName", "GendorCaption", "Phone", "Email", "DateOfBirth");
        public ManagePeoplefrm()
        {
            InitializeComponent();
        }
        private void _RefreshPeopleList()
        {
            dgvGetAllPeople.DataSource = _dtPeople;
        }
        private void ManagePeoplefrm_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddEditPersonfrm frm = new AddEditPersonfrm(-1);
            frm.ShowDialog();
            _RefreshPeopleList();
        }


        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddEditPersonfrm frm = new AddEditPersonfrm((int)dgvGetAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPeople.DeletePerson((int)dgvGetAllPeople.CurrentRow.Cells[0].Value);
            _RefreshPeopleList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm= new frmPersonDetails((int)dgvGetAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
         
        }

        private void txtFilterByValue_TextChanged(object sender, EventArgs e)
        {
            string selectedText = cbFilterBy.SelectedItem?.ToString().Trim();
            string FilterCoulmn = "";
            switch (selectedText)
            {
                case "Person ID":
                    FilterCoulmn = "PersonID";
                    break;
                case "National No":
                    FilterCoulmn = "NationalNo";
                    break;
                case "First Name":
                    FilterCoulmn = "FirstName";
                    break;
                case "Second Name":
                    FilterCoulmn = "SecondName";
                    break;
                case "Third Name":
                    FilterCoulmn = "ThirdName";
                    break;
                case "Last Name":
                    FilterCoulmn = "LastName";
                    break;
                case "Gendor":
                    FilterCoulmn = "GendorCaption";
                    break;
                case "Email":
                    FilterCoulmn = "Email";
                    break;
                case "Phone":
                    FilterCoulmn = "Phone";
                    break;
                default:
                    FilterCoulmn = "None";
                    break;
            }
            if(txtFilterByValue.Text.Trim()==""||FilterCoulmn=="None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvGetAllPeople.Rows.Count.ToString();
                return;
            }
            if(FilterCoulmn=="PersonID")
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}]={1}",FilterCoulmn,txtFilterByValue.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterCoulmn, txtFilterByValue.Text.Trim());


            lblRecordsCount.Text = dgvGetAllPeople.Rows.Count.ToString();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterByValue.Visible = (cbFilterBy.Text != "None");
            if(cbFilterBy.Visible==true)
            {
                txtFilterByValue.Text = "";
                txtFilterByValue.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
