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
    public partial class ListDriversfrm: Form
    {
        private static DataTable _dtDrivers = clsDriver.ListDrivers();
        public ListDriversfrm()
        {
            InitializeComponent();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {

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
                case "Full Name":
                    FilterCoulmn = "FullName";
                    break;
                case "Driver ID":
                    FilterCoulmn = "DriverID";
                    break;
             
            }
            if (txtFilterByValue.Text.Trim() == "" || FilterCoulmn == "None")
            {
                _dtDrivers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtDrivers.Rows.Count.ToString();
                return;
            }
            if (FilterCoulmn == "PersonID" || FilterCoulmn == "DriverID")
                _dtDrivers.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterCoulmn, txtFilterByValue.Text.Trim());
            else
                _dtDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterCoulmn, txtFilterByValue.Text.Trim());



            lblRecordsCount.Text = _dtDrivers.Rows.Count.ToString();
        }

        private void ListDriversfrm_Load(object sender, EventArgs e)
        {
            dgvGetAllPeople.DataSource = _dtDrivers;
        
        }

        private void showLicenesHistoreyToolStripMenuItem_Click(object sender, EventArgs e)
        {
           LicensHistoreyfrm licensHistoreyfrm = new LicensHistoreyfrm((int)dgvGetAllPeople.CurrentRow.Cells[0].Value, (int)dgvGetAllPeople.CurrentRow.Cells[1].Value);
            licensHistoreyfrm.ShowDialog();
        }

        private void showPerosnInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicensHistoreyfrm licensHistoreyfrm = new LicensHistoreyfrm();
            licensHistoreyfrm.ShowDialog();
        }
    }
}
