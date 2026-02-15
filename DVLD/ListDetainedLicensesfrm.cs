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
    public partial class ListDetainedLicensesfrm : Form
    {

        private DataTable _dtDetainedLicenses;
        public ListDetainedLicensesfrm()
        {
            InitializeComponent();
        }

        private void ListDetainedLicensesfrm_Load(object sender, EventArgs e)
        {
            //cbFilterBy.SelectedIndex = 0;

            _dtDetainedLicenses = clsDetainedLicenses.ListDetainedLicenses();

            dgvDetainedLicenses.DataSource = _dtDetainedLicenses;
            lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

            if (dgvDetainedLicenses.Rows.Count > 0)
            {
                dgvDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicenses.Columns[0].Width = 90;

                dgvDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvDetainedLicenses.Columns[1].Width = 90;

                dgvDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvDetainedLicenses.Columns[2].Width = 160;

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 110;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 110;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 160;

                dgvDetainedLicenses.Columns[6].HeaderText = "N.No.";
                dgvDetainedLicenses.Columns[6].Width = 90;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 330;

                dgvDetainedLicenses.Columns[8].HeaderText = "Rlease App.ID";
                dgvDetainedLicenses.Columns[8].Width = 150;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicensefrm frm = new ReleaseDetainedLicensefrm();
            frm.ShowDialog();
            ListDetainedLicensesfrm_Load(null, null);
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            DetainLicenseFrm frm = new DetainLicenseFrm(-1);
            frm.ShowDialog();
            ListDetainedLicensesfrm_Load(null, null);
        }
    }
}
