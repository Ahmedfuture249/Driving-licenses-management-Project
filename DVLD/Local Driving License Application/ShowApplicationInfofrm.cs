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
    public partial class ShowApplicationInfofrm: Form
    {
        int _id;
        public ShowApplicationInfofrm(int ID)
        {
            InitializeComponent();
            _id = ID;
        }

        private void ShowApplicationInfofrm_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfocs1._LoadApplicationInfo(_id);
        }
    }
}
