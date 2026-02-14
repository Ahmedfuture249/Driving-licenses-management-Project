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
    public partial class ctrlDriverLicenseHistorey: UserControl
    {
        DataTable _dtDriverLocalLicensesHistory;
        public ctrlDriverLicenseHistorey()
        {
            InitializeComponent();
        }
        public  void LoadDriverLicenseHistorey(int DriverID)
        {
          
        
            _dtDriverLocalLicensesHistory = clsLicense.GetLocalLicensesForDriver(DriverID);


            dgvListLocalLicenses.DataSource = _dtDriverLocalLicensesHistory;
            //lblLocalLicensesRecords.Text = dgvLocalLicensesHistory.Rows.Count.ToString();

            if (dgvListLocalLicenses.Rows.Count > 0)
            {
                dgvListLocalLicenses.Columns[0].HeaderText = "Lic.ID";
                dgvListLocalLicenses.Columns[0].Width = 110;

                dgvListLocalLicenses.Columns[1].HeaderText = "App.ID";
                dgvListLocalLicenses.Columns[1].Width = 110;

                dgvListLocalLicenses.Columns[2].HeaderText = "Class Name";
                dgvListLocalLicenses.Columns[2].Width = 270;

                dgvListLocalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvListLocalLicenses.Columns[3].Width = 170;

                dgvListLocalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvListLocalLicenses.Columns[4].Width = 170;

                dgvListLocalLicenses.Columns[5].HeaderText = "Is Active";
                dgvListLocalLicenses.Columns[5].Width = 110;

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
