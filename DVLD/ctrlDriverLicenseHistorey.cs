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
        public ctrlDriverLicenseHistorey()
        {
            InitializeComponent();
        }
        public  void LoadDriverLicenseHistorey(int DriverID)
        {
            DataTable dt = clsLicense.GetLocalLicensesForDriver(DriverID);
           dgvListLocalLicenses.DataSource = dt;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
