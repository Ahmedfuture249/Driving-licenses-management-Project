using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlShowLicenseInfoWithFilter: UserControl
    {
        public event Action<int> OnLicenseSelected;
        protected virtual void LicenseSelected(int PersonID)
        {
            Action<int> Handler = OnLicenseSelected;
            if (Handler != null)
            {
                Handler(PersonID);
            }
        }
        public void FindNow(int LicenseID)
        {
            
                    ctrlShowLicenseInof1.LoadData(int.Parse(txtFindBy.Text));
                   
          
            if (OnLicenseSelected != null && FilterByEnabled != false)
                OnLicenseSelected(userControl11.personID);
        }
        public ctrlShowLicenseInfoWithFilter()
        {
            InitializeComponent();
        }
        private bool _FilterEnabled=false;
        public bool FilterEnabled
        {
            set { _FilterEnabled=Vl}
        }

        private void ctrlShowLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {

        }
    }
}
