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
    public partial class FindPersonfrm: Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public FindPersonfrm()
        {
            InitializeComponent();
        }

        private void FindPersonfrm_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, userControl21.personID);
        }

        private void userControl21_Load(object sender, EventArgs e)
        {

        }
    }
}
