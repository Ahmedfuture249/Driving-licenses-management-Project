using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class LoginForm: Form
    {
        clsUsers CurrentUser;
        string _UserName;
        string filePath = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
    "MyApp",
    "loginInfo.txt"
);

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length >= 2)
                {
                    txtUserName.Text = lines[0];
                    txtPassword.Text = lines[1];
                    checkBoxRememberMe.Checked = true;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void SaveLogin()
        {
            string dir = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(txtUserName.Text);
                sw.WriteLine(txtPassword.Text);
            }
        }
        private void DeleteSavedLogin()
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            CurrentUser = clsUsers.Find(username);
            if(CurrentUser==null)
            {
                MessageBox.Show("User Was Not Founded !!");
                return;
            }
            if(password!=CurrentUser.UserPassword)
            {
                MessageBox.Show("Wrong Password!!!");
                return;
            }
            if (checkBoxRememberMe.Checked == true)
            {

                SaveLogin();
            }
            else
            {
                DeleteSavedLogin();
        
             }
            Form1 frm = new Form1();
            frm.ShowDialog();
        }
    
    }
}
