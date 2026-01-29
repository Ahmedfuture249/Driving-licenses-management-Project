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
    public partial class ManageLocalDrivingLicensesApplicationfrm: Form
    {
        public ManageLocalDrivingLicensesApplicationfrm()
        {
            InitializeComponent();
        }

        private void dgvGetAllPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ManageLocalDrivingLicensesApplicationfrm_Load(object sender, EventArgs e)
        {
            dgvGetAllApplications.DataSource = clsLDLApplication.ListApplications();
        }
    }
}
