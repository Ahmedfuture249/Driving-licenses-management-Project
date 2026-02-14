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
    public partial class LicensHistoreyfrm: Form
    {
        private int _DriverID=-1;
        private int _PersonID=-1;
        clsDriver Driver;
        public LicensHistoreyfrm(int DriverID,int PersonID)
        {
            _DriverID = DriverID;
            _PersonID=PersonID;
           
            InitializeComponent();
            userControl21.FilterByEnabled = false;

        }
        public LicensHistoreyfrm()
        {

            InitializeComponent();
            userControl21.FilterByEnabled = true;

        }

        private void UserControl21_OnPersonSelected(int obj)
        {
            
            _PersonID= obj;
            if (_PersonID != -1)
            {
                Driver = clsDriver.FindByPersonID(_PersonID);
                if (Driver == null)
                {
                    MessageBox.Show("There Is No Driver With This PersonID !!");
                    return;
                }
                ctrlDriverLicenseHistorey1.LoadDriverLicenseHistorey(Driver.DriverID);
            }
            else
            {
             

                userControl21.FilterByEnabled = true;
            }


        }

        private void LicensHistoreyfrm_Load(object sender, EventArgs e)
        {
            userControl21.OnPersonSelected += UserControl21_OnPersonSelected;
           ctrlDriverLicenseHistorey1.LoadDriverLicenseHistorey(_DriverID);   
            userControl21.LoadPersonInfo(_PersonID);
            
            
        }
        

        private void ctrlDriverLicenseHistorey1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
