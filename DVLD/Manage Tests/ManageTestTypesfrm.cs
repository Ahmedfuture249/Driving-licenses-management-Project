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
    public partial class ManageTestTypesfrm: Form
    {
        public ManageTestTypesfrm()
        {
            InitializeComponent();
        }
        DataTable _dgvListTestTypes;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ManageTestTypesfrm_Load(object sender, EventArgs e)
        {
            _dgvListTestTypes = clsTestTypes.ListTestTypes();
            dataGridView1.DataSource = _dgvListTestTypes;
            lblRecordsCount.Text = dataGridView1.RowCount.ToString();

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 110;

            dataGridView1.Columns[1].HeaderText = "TITLE";
            dataGridView1.Columns[1].Width = 150;

            dataGridView1.Columns[2].HeaderText = "Discription";
            dataGridView1.Columns[2].Width = 250;

            dataGridView1.Columns[3].HeaderText = "FEES";
            dataGridView1.Columns[3].Width = 110;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditTestTypefrm frm = new EditTestTypefrm((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
