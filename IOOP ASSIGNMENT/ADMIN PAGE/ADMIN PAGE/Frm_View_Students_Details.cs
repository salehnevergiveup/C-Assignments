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
    public partial class Frm_View_Students_Details : Form
    {
        public static string name, username, gender;

        public Frm_View_Students_Details()
        {
            InitializeComponent();
        }

        public Frm_View_Students_Details(string n, string un, string g)
        {
            InitializeComponent();
            username = un;
            gender = g;
            name = n;
        }

        // sidebar start

        bool sidebar;
        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebar)
            {
                panelSidebar.Width -= 10;
                if (panelSidebar.Width == panelSidebar.MinimumSize.Width)

                {
                    sidebar = false;
                    SidebarTimer.Stop();
                }
            }
            else
            {
                panelSidebar.Width += 10;
                if (panelSidebar.Width == panelSidebar.MaximumSize.Width)

                {
                    sidebar = true;
                    SidebarTimer.Stop();
                }
            }
        }
        private void Pic_Menu_Click(object sender, EventArgs e)
        {
            SidebarTimer.Start();
        }
        // sidebar end

        // To exit from the current page
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Successfully exit from the page

        // To minimize the page
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        // When the user press the minimize button on the top right of the page, the interface will be minimized.

        // To maximize the page
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximize.Visible = false;
            btnNormal.Visible = true;
            btnNormal.Location = btnMaximize.Location;
        }
        // When the user press the maximize button on the top right of the page, the interface will be maximized.

        // To return to the normal size interface
        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximize.Visible = true;
            btnNormal.Visible = false;
        }
        // When the user press the normalized button on the top right of the page, the interface will be return to the original size.

        // When user press the Add_Class button, the system will bring the user to the interface of Add Class Information.
        private void btn_Add_Class_Click(object sender, EventArgs e)
        {
            Frm_Add_Class_Information frm_Add_Class_Information = new Frm_Add_Class_Information();
            this.Hide();
            frm_Add_Class_Information.ShowDialog();
            this.Close();
        }

        // When user press the Update_and_Delete button, the system will bring the user to the interface of Update and Delete Class Information.
        private void btn_Update_and_Delete_Click(object sender, EventArgs e)
        {
            frm_Update_and_Delete frm_Update_And_Delete = new frm_Update_and_Delete(name, username, gender);
            this.Hide();
            frm_Update_And_Delete.ShowDialog();
            this.Close();
        }

        // When user press the Update_Profile button, the system will bring the user to the interface of Update Profile.
        private void btn_Update_Profile_Click(object sender, EventArgs e)
        {
            Frm_Update_Profile frm_Update_Profile = new Frm_Update_Profile(name, username, gender);
            this.Hide();
            frm_Update_Profile.ShowDialog();
            this.Close();
        }
        
        // When user press the Log Out button from the sidebar, the system will bring the user out of the interface.
        private void btn_Log_Out_Click(object sender, EventArgs e)
        {
            LoginForm loginform = new LoginForm();
            this.Hide();
            loginform.ShowDialog();
            this.Close();
        }
        
        private void btn_Search_Student_Click(object sender, EventArgs e)
        {
            Student.ViewStudentInfo(dataGridView1, cmb_Level.Text, cmb_Subject.Text);
        }

        private void Frm_View_Students_Details_Load(object sender, EventArgs e)
        {
            if (gender == "Male")
            {
                labGreating.Text = $"Hello MR.{name}";
            }
            else
            {
                labGreating.Text = $"Hello Miss.{name}";
            }
            Student.ViewStudentInfo(dataGridView1);

        }
    }
}
