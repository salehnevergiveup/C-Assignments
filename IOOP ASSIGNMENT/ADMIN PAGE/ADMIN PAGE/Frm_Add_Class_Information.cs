using System;
using System.Collections;
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
    public partial class Frm_Add_Class_Information : Form
    {
        //public static username; 
        string username, gender, name;
        public Frm_Add_Class_Information()
        {
            InitializeComponent();
        }

        public Frm_Add_Class_Information(string n, string un, string g)
        {
            InitializeComponent();
            username = un;
            gender = g;
            name = n;
        }

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

        // When user press the Update_and_Delete button, the system will bring the user to the interface of Update and Delete Class Information.
        private void btn_Update_and_Delete_Click(object sender, EventArgs e)
        {
            frm_Update_and_Delete frm_Update_And_Delete = new frm_Update_and_Delete(name, username, gender);
            this.Hide();
            frm_Update_And_Delete.ShowDialog();
            this.Close();
        }

        // When user press the View_Stud button, the system will bring the user to the interface of View Students Details.
        private void btn_View_Stud_Click(object sender, EventArgs e)
        {
            Frm_View_Students_Details frm_View_Students_Details = new Frm_View_Students_Details(name, username, gender);
            this.Hide();
            frm_View_Students_Details.ShowDialog();
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

        // When user press the View_My_Class_Schedule button, the system will bring the user to the interface of View My Class Schedule.
        private void btn_View_My_Class_Schedule_Click(object sender, EventArgs e)
        {
            frm_View_My_Class_Schedule frm_View_My_Class_Schedule = new frm_View_My_Class_Schedule(name, username, gender);
            this.Hide();
            frm_View_My_Class_Schedule.ShowDialog();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control i in panel11.Controls)
            {
                if (i is TextBox || i is ComboBox)
                {
                    i.Text = "";    // If there is a TextBox or ComboBox, the text will be clean up.
                }
            }
        }

        private void Frm_Add_Class_Information_Load(object sender, EventArgs e)
        {
            if (gender == "Male")
            {
                labGreeting.Text = $"Hello MR.{name}";
            }
            else
            {
                labGreeting.Text = $"Hello Miss.{name}";
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (!Validation.checkTextBoxes(txtDuration.Text, txtLocation.Text, txtSubject_Fee.Text, txt_Start_Time.Text, txt_End_Time.Text, cmbDay.Text, cmbLevel.Text, cmbSubject.Text))
            {
                MessageBox.Show("Havent complete yet! Make sure all the data is filled!");
                return;
            }
            if (!Validation.CheckTime(txt_End_Time.Text))   // check the time format
            {
                MessageBox.Show("Only time format is accepted");
                txt_End_Time.Focus();
                return;
            }

            if (!Validation.CheckTime(txt_Start_Time.Text))
            {
                MessageBox.Show("Only time format is accepted");
                txt_Start_Time.Focus();
                return;
            }
            if (!Validation.CheckSubject_Fee(txtSubject_Fee.Text))   // check the subject fee format
            {
                MessageBox.Show("Cannot insert text. Only numerical value is allowed!");
                txtSubject_Fee.Focus();
                return;
            }
            int test;
            if (int.TryParse(txtDuration.Text, out test) == false)
            {
                MessageBox.Show("Only number are allowed!");
                return;
            }

            Class_Information classInfo = new Class_Information();
            classInfo.Duration1 = txtDuration.Text;
            classInfo.Location1 = txtLocation.Text;
            classInfo.Subject_Fee1 = Convert.ToDouble(txtSubject_Fee.Text);
            classInfo.Start_Time1 = txt_Start_Time.Text;
            classInfo.End_Time1 = txt_End_Time.Text;
            classInfo.Day1 = cmbDay.Text;
            classInfo.Level1 = cmbLevel.Text;
            classInfo.Subject_Name_1 = cmbSubject.Text;
            classInfo.Add_Class_Information(username);

        }
    }
}
