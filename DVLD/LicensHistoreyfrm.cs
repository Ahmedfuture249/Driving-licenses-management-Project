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
    public partial class LicensHistoreyfrm: Form
    {
        private int _DriverID;
        public LicensHistoreyfrm(int DriverID)
        {
            _DriverID = DriverID;
            InitializeComponent();
        }

        private void LicensHistoreyfrm_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseHistorey1.LoadDriverLicenseHistorey(_DriverID);    
        }
        

        private void ctrlDriverLicenseHistorey1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
