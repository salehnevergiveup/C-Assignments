using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ADMIN_PAGE
{
    public partial class UpdatePrfile : Form
    {
        private  string username;
        private string name, gender;

        System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["ViewProfile"];

        public UpdatePrfile()
        {
            InitializeComponent();
        }
        public UpdatePrfile(string Name, string Gender, string Username)
        {
            InitializeComponent();
            name = Name;
            gender = Gender;
            username = Username;
        }
        private void UpdatePrfile_Load(object sender, EventArgs e)
        {
            if (gender == "Male")
            {
                label5.Text = $"What personal information you want to update?Mr.{name}";
            }
            else if (gender == "Female")
            {
                label5.Text = $"What personal information you want to update?Ms.{name}";
            }
            else
            {
                label5.Text = $"What personal information you want to update?{name}";
            }
            ClassAdmin showAdminDetails = new ClassAdmin(name, gender, username);
            ClassAdmin.viewdetails(showAdminDetails);
            txtAdminName.Text = showAdminDetails.Name;
            txtUsername.Text = showAdminDetails.Username;
            txtContact.Text = showAdminDetails.Contactnum;
            txtEmail.Text = showAdminDetails.Email;
            lblGender1.Text = showAdminDetails.Gender;
            txtAddress.Text = showAdminDetails.Address;
            dateTimePicker1.Value = showAdminDetails.Dob;
            txtICPassport.Text = showAdminDetails.Ic_passport;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text != TxtComfirmPass.Text)
            {
                MessageBox.Show("Password that you comfirm is not match with the new password!");
                txtNewPassword.Clear();
                TxtComfirmPass.Clear();
                txtNewPassword.Focus();
            }
            else if (txtNewPassword.Text == null || txtNewPassword.Text == "")
            {
                MessageBox.Show("Password that you change cannot be empty");
                txtNewPassword.Focus();
            }
            else if (txtNewPassword.Text == TxtComfirmPass.Text) ;
            {
                ClassAdmin pp = new ClassAdmin(username);
                string pp1 = pp.updatePassword(txtNewPassword.Text);
                MessageBox.Show(pp1);
            }
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnmax.Visible = true;
            btnNormal.Visible = false;
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnmax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnmax.Visible = false;
            btnNormal.Visible = true;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntutorlist_Click(object sender, EventArgs e)
        {
            TUTORLIST tutorlist = new TUTORLIST();
            this.Hide();
            tutorlist.ShowDialog();
            this.Close();
        }

        private void btnreceplist_Click(object sender, EventArgs e)
        {
            AdminReceptionist receptionist = new AdminReceptionist();
            this.Hide();
            receptionist.ShowDialog();
            this.Close();
        }

        private void btnmonthlyreport_Click(object sender, EventArgs e)
        {
            View_report viewreport = new View_report();
            this.Hide();
            viewreport.ShowDialog();
            this.Close();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            AdminViewProfile profile = new AdminViewProfile();
            this.Hide();
            profile.ShowDialog();
            this.Close();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            LoginForm loginform = new LoginForm();
            this.Hide();
            loginform.ShowDialog();
            this.Close();
        }
        bool sidebar;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sidebar)
            {
                panelslidebar.Width -= 10;
                if (panelslidebar.Width == panelslidebar.MinimumSize.Width)
                {
                    sidebar = false;
                    sidebartime.Stop();
                }



            }
            else
            {
                panelslidebar.Width += 10;
                if (panelslidebar.Width == panelslidebar.MaximumSize.Width)
                {
                    sidebar = true;
                    sidebartime.Stop();
                }
            }

        }

        private void Menu_Click(object sender, EventArgs e)
        {
            sidebartime.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_2(object sender, EventArgs e)
        {

        }

        private void lblAdminID_Click(object sender, EventArgs e)
        {

        }

        private void btnupdateprofilepage_Click(object sender, EventArgs e)
        {
            List<int> txtbxindext = new List<int>();
            txtbxindext = ClassValidation.checkAllTextBox(panel12);
            if (txtbxindext.Count == 0)
            {
                foreach (Control txtbox in panel12.Controls)
                {
                    if (txtbox is TextBox)
                    {
                        txtbox.BringToFront();
                    }
                }
                if (ClassValidation.CheckEmail(txtEmail.Text))
                {
                    txtEmail.BringToFront();
                    if (ClassValidation.checkName(txtAdminName.Text))
                    {
                        ClassAdmin upadmin = new ClassAdmin(username);
                        string message = upadmin.updateProfile(txtAdminName.Text, dateTimePicker1.Value ,txtUsername.Text, txtContact.Text, txtEmail.Text, txtAddress.Text,txtICPassport.Text);
                        MessageBox.Show(message);
                        username = txtUsername.Text;

                    }
                    else
                    {
                        MessageBox.Show("Invalid name!!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid email address");
                    txtEmail.Focus();
                    txtEmail.SendToBack();
                }
            }
            else
            {
                //red stars will shown if the user left some fields empty
                foreach (int i in txtbxindext)
                {
                    panel12.Controls[i].SendToBack();
                    MessageBox.Show(panel12.Controls[i].ToString());
                    MessageBox.Show("Fill down the empty field");
                }


            }
        }

        private void txtAdminName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtComfirmPass_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
