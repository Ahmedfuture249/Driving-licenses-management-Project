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
        public ManagePeoplefrm()
        {
            InitializeComponent();
        }
        private void _RefreshPeopleList()
        {
            dgvGetAllPeople.DataSource = clsPeople.GetAllPeople();
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
    }
}
