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
    public partial class ManageApplicationTypesfrm: Form
    {
        DataTable _dtListApplicationTypes;
        public ManageApplicationTypesfrm()
        {
            InitializeComponent();
        }
        //private void _RefreshList()
        //{
        //    dataGridView1.DataSource = clsManageApplications.ListApplicationTypes();
        //}

        private void ManageApplicationTypesfrm_Load(object sender, EventArgs e)
        {
            //  _RefreshList();
            _dtListApplicationTypes = clsManageApplications.ListApplicationTypes();
            dataGridView1.DataSource = _dtListApplicationTypes;
            lblRecordsCount.Text = dataGridView1.RowCount.ToString();

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 110;

            dataGridView1.Columns[1].HeaderText = "TITLE";
            dataGridView1.Columns[1].Width = 300;

            dataGridView1.Columns[2].HeaderText = "FEES";
            dataGridView1.Columns[2].Width = 110;
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditApplicationTypefrm frm = new EditApplicationTypefrm((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            ManageApplicationTypesfrm_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
