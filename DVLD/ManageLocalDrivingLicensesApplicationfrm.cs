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

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLoacalDrivingLicensesApplicationfrm frm = new AddLoacalDrivingLicensesApplicationfrm((int)dgvGetAllApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            dgvGetAllApplications.DataSource = clsLDLApplication.ListApplications();
        }

        private void deleteApplicatonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLDLApplication.DeleteApplication((int)dgvGetAllApplications.CurrentRow.Cells[0].Value);
            dgvGetAllApplications.DataSource = clsLDLApplication.ListApplications();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLDLApplication.Cancel((int)dgvGetAllApplications.CurrentRow.Cells[0].Value);
            dgvGetAllApplications.DataSource = clsLDLApplication.ListApplications();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddLoacalDrivingLicensesApplicationfrm frm = new AddLoacalDrivingLicensesApplicationfrm();
            frm.ShowDialog();
            
            dgvGetAllApplications.DataSource = clsLDLApplication.ListApplications();
        }
    }
}
