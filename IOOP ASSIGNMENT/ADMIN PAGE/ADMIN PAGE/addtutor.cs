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
    public partial class addtutor : Form
    {
        public addtutor()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnormalsize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnmax.Visible = true;
            btnormalsize.Visible = false;
        }

        private void btnmax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnmax.Visible = false;
            btnormalsize.Visible = true;
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnmainpage_Click(object sender, EventArgs e)
        {
            AdminViewProfile profile = new AdminViewProfile();
            this.Hide();
            profile.ShowDialog();
            this.Close();
        }

        private void btnreceptionistlist_Click(object sender, EventArgs e)
        {
            AdminReceptionist receptionist = new AdminReceptionist();
            this.Hide();
            receptionist.ShowDialog();
            this.Close();
        }

        private void btnmonthlyincome_Click(object sender, EventArgs e)
        {
            View_report viewreport = new View_report();
            this.Hide();
            viewreport.ShowDialog();
            this.Close();
        }

        private void btntutorlist_Click(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            TUTORLIST tutorlist = new TUTORLIST();
            this.Hide();
            tutorlist.ShowDialog();
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
        private void panelslidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTadd_Click(object sender, EventArgs e)
        {
            string passwordd = txtTpass.Text;
            string password_checked = txtTcomfirm.Text;
            string gender_Checked = "";
            if (rdFemale.Checked)
            {
                gender_Checked = "Female";


                if (password_checked != passwordd)
                {
                    MessageBox.Show("Password that you comfirm doesn't match with the password you enter\n Please reenter again");
                    txtTpass.Clear();
                    txtTcomfirm.Clear();
                    txtTpass.Focus();

                }
                else if (password_checked == passwordd)
                {
                    ClassTutor apptt = new ClassTutor(txtTname.Text, txtTICPASS.Text, dtpTDOB.Value, txtTcontact.Text, txtTemail.Text, gender_Checked, txtTaddress.Text, txtTuserusername.Text, passwordd);
                    string apptt1 = apptt.addtutor();
                    MessageBox.Show(apptt1);
                }



            }
            else if (rMale.Checked)
            {
                gender_Checked = "Male";

                if (password_checked != passwordd)
                {
                    MessageBox.Show("Password that you comfirm doesn't match with the password you enter\n Please reenter again");
                    txtTpass.Clear();
                    txtTcomfirm.Clear();
                    txtTpass.Focus();
                }
                else if (password_checked == passwordd)
                {
                    ClassTutor apptt = new ClassTutor(txtTname.Text, txtTICPASS.Text, dtpTDOB.Value, txtTcontact.Text, txtTemail.Text, gender_Checked, txtTaddress.Text, txtTuserusername.Text, passwordd);
                    string apptt1 = apptt.addtutor();
                    MessageBox.Show(apptt1);

                    /* string filename = System.IO.Path.GetFileName(openf.FileName);
                     if (filename == null)
                     {
                       MessageBox.Show("Please select a valid image.");
                     }
                     else
                     {
                         SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
                             //we already define our connection globaly. We are just calling the object of connection.
                             con.Open();
                             SqlCommand cmd = new SqlCommand("insert into Receptionist(Photo)values('\\Image\\" + filename + "')", con);
                             string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                             System.IO.File.Copy(openf.FileName, path + "\\Image\\" + filename);
                             cmd.ExecuteNonQuery();
                             con.Close();
                     }*/

                }


            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnTclearadd_Click(object sender, EventArgs e)
        {
            txtTuserusername.Clear();
            txtTaddress.Clear();
            txtTcomfirm.Clear();
            txtTcontact.Clear();
            txtTemail.Clear();
            txtTICPASS.Clear();
            txtTname.Clear();
            txtTpass.Clear();
        }
    }
}
