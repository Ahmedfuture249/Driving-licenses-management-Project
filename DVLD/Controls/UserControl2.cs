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
    public partial class UserControl2: UserControl
    {
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> Handler = OnPersonSelected;
            if(Handler!=null)
            {
                Handler(PersonID);  
            }
        }
        private bool _ShowAddPerson = true;
        public bool showAddPerson
        {
            get { return _ShowAddPerson; }
            set { _ShowAddPerson = value; btnAddPerson.Visible = _ShowAddPerson; }
        }
        private bool _FilterByEnabled= true;
        public bool FilterByEnabled
        {
            get { return _FilterByEnabled; }
            set { _FilterByEnabled = value; cbFilterBy.Visible = _FilterByEnabled; }
        }
        clsPeople _person;
        int _PersonID = -1;
        string _NationalNO = "";

        public int personID
        {
            get { return userControl11.personID; }
        }
        public string NationalNo
        {
            get { return userControl11.NationalNo; }
        }
        public clsPeople SelectedPersonInfo
        {
            get { return userControl11.SelectedPersonInfo; }
        }
        public void LoadPersonInfo(int id)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFindBy.Text = id.ToString();
            FindNow();
        }
        public void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    userControl11.LoadPersonInfo(int.Parse(txtFindBy.Text));
                    break;
                case "National No":
                    userControl11.LoadPersonInfo(txtFindBy.Text);
                    break;
                default:
                    break;
            }
            if (OnPersonSelected != null && FilterByEnabled != false)
                OnPersonSelected  (userControl11.personID);
        }
        public UserControl2()
        {
            InitializeComponent();
            //ErrorProvider errorProvider1 = new ErrorProvider();
            //errorProvider1.ContainerControl = this;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFindBy.Text = "";
            txtFindBy.Focus();
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddEditPersonfrm frm = new AddEditPersonfrm(-1);
            frm.DataBack += DataBackEvent;
            frm.ShowDialog();
        }
     private void   DataBackEvent(object sender, int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFindBy.Text = personID.ToString();
            userControl11.LoadPersonInfo(personID);
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("some fileds are not valid");
                return;
            }
            FindNow();
        }

        private void txtFindBy_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFindBy.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFindBy, "this filed is requierd");
            }
            else
            {
                errorProvider1.SetError(txtFindBy, null);
            }
        }

        private void txtFindBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==(char)13)
            {

                btnFindPerson.PerformClick();
            }

            if (cbFilterBy.Text == "Person ID") ;
        }
    }
}
