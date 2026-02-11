using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBusinessLayer;

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
        
        public ctrlShowLicenseInfoWithFilter()
        {
            InitializeComponent();
        }
        private bool _FilterEnabled=false;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled; 
            }
            set
            {
                _FilterEnabled = value;
                groupBoxFilter.Enabled = _FilterEnabled;
            }
        }
        private int _LicenseID = -1;
        public int LicenseID { get { return ctrlShowLicenseInof1.LicenseID; } }

        public clsLicense SelectedLicenseInfo { get { return ctrlShowLicenseInof1.License; } }

        public void LoadLicensInfo(int LicenseID)
        {
            LicenseID = int.Parse(txtFindBy.Text);
           
            ctrlShowLicenseInof2.LoadDataByLicenseID(LicenseID);

            _LicenseID = ctrlShowLicenseInof2.LicenseID;
            if (OnLicenseSelected != null && FilterEnabled)
                OnLicenseSelected(_LicenseID);

        }

        private void ctrlShowLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("some Fildes are not valid!!");
                txtFindBy.Focus();
                return;
            }
           

            LoadLicensInfo(_LicenseID);
        }

        private void txtFindBy_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFindBy.Text))
            {
                errorProvider1.SetError(txtFindBy, "هذا الحقل مطلوب");
                e.Cancel = true;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFindBy, null);
            }
        }
    }
}
