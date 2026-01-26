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
using static DVLDBusinessLayer.clsPeople;

namespace DVLD
{
    public partial class frmPersonDetails: Form
    {
        clsPeople _Person;
        int _PersonID=-1;
        public frmPersonDetails(int ID)
        {
            InitializeComponent();
            _PersonID = ID;

            userControl11.LoadPersonInfo(_PersonID);
        }
        public void _LoadData()
        {
         

        }
        private void frmPersonDetails_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_Load_1(object sender, EventArgs e)
        {

        }
    }
}
