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
    public partial class AdminViewProfile : Form
    {
        private static string name, gender, username;
        public AdminViewProfile()
        {
            InitializeComponent();
        }


        public AdminViewProfile(string Name, string Gender,string Username)
        {
            InitializeComponent();
            name = Name;
            gender = Gender;
            username = Username;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnnormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMax.Visible = true;
            btnnormal.Visible = false;
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMax.Visible = false;
            btnnormal.Visible = true;
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

        private void monthlyreport_Click(object sender, EventArgs e)
        {
            View_report viewreport = new View_report();
            this.Hide();
            viewreport.ShowDialog();
            this.Close();
        }

        private void btnUpdateprofile_Click(object sender, EventArgs e)
        {
            UpdatePrfile updateprofile = new UpdatePrfile(name, gender, username);
            this.Hide();
            updateprofile.ShowDialog();
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
        private void sidebartime_Tick(object sender, EventArgs e)
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

        private void lblcontact_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblAdmin_Click(object sender, EventArgs e)
        {

        }

        private void lblUsername1_Click(object sender, EventArgs e)
        {

        }

        private void ViewProfile_Load_1(object sender, EventArgs e)
        {
            if (gender == "Male")
            {
                lblIdentity.Text = $"Welcome,Mr.{name}";
            }
            else if (gender == "Female")
            {
                lblIdentity.Text = $"Welcome,Ms.{name}";
            }
            else
            {
                lblIdentity.Text = $"Welcome,{name}";
            }

            ClassAdmin showAdminDetails = new ClassAdmin(name,gender,username);
            ClassAdmin.viewdetails(showAdminDetails);
            lblUsername1.Text = showAdminDetails.Name;
            lblAdmin1.Text = showAdminDetails.Username;
            lblcontact1.Text = showAdminDetails.Contactnum;
            lblemail1.Text = showAdminDetails.Email;
            lblGender1.Text = showAdminDetails.Gender;
            lbladdress1.Text = showAdminDetails.Address;
            lblBirth1.Text = showAdminDetails.Dob.ToString();
            lblIIC.Text = showAdminDetails.Ic_passport;

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
