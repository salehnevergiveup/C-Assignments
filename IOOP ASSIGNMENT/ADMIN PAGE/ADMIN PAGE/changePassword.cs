using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADMIN_PAGE
{
    public partial class changePassword : Form
    {
        public changePassword()
        {
            InitializeComponent();
        }

        static string username, gender, name;

        public changePassword(string n, string un, string g)
        {
            InitializeComponent();
            username = un;
            gender = g;
            name = n;
        }
        private void btnUpdatePass_Click(object sender, EventArgs e)
        {
            if (!Recepvalidation.checkTextBoxes(txtNewPassword.Text, txtNewPassword.Text, txtConformNewPassword.Text))
            {
                string mrMiss = (gender == "Male") ? "Mr" : "Miss";
                MessageBox.Show($"kindly {mrMiss}.{name} Fill out all the  fields!!!!");
                return;

            }
            
            Receptionist receptionist = new Receptionist(username);
           string message =  receptionist.changePassword(txtOldPassword.Text, txtConformNewPassword.Text, txtNewPassword.Text);

            if(message == "1")
            {
                txtOldPassword.ForeColor = Color.Red;
                
            }
            if(message == "2")
            {
                txtOldPassword.ForeColor = Color.Red;
               txtNewPassword.ForeColor = Color.Red;
                
            }

            if (message == "3")
            {
                txtNewPassword.ForeColor = Color.Red;
                txtConformNewPassword.ForeColor = Color.Red;
            }
            if (message == "4")
            {
                txtNewPassword.ForeColor = Color.Black;
                txtConformNewPassword.ForeColor = Color.Black;
                txtOldPassword.ForeColor = Color.Black;
                txtNewPassword.Text = "";
                txtConformNewPassword.Text = "";
                txtOldPassword.Text = "";


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changePassword_Load_1(object sender, EventArgs e)
        {
            txtOldPassword.UseSystemPasswordChar = true;
            txtConformNewPassword.UseSystemPasswordChar = true;
            txtNewPassword.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtOldPassword.UseSystemPasswordChar = false;
            }
            else txtOldPassword.UseSystemPasswordChar = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                txtNewPassword.UseSystemPasswordChar = false;
            }
            else txtNewPassword.UseSystemPasswordChar = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                txtConformNewPassword.UseSystemPasswordChar = false;
            }
            else txtConformNewPassword.UseSystemPasswordChar = true;
        }
    }
}
