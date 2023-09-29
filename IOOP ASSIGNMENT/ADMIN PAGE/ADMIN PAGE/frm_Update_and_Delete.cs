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
    public partial class frm_Update_and_Delete : Form
    {
        string name, username, gender;
        public frm_Update_and_Delete()
        {
            InitializeComponent();
        }

        public frm_Update_and_Delete(string n, string un, string g)
        {
            InitializeComponent();
            username = un;
            name = n;
            gender = g;
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
            Frm_Add_Class_Information frm_Add_Class_Information = new Frm_Add_Class_Information(name, username, gender);
            this.Hide();
            frm_Add_Class_Information.ShowDialog();
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

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (!Validation.checkSelected(dataGridView1)) { MessageBox.Show("Select one of the row before you go for the next step!"); return; }
            int Schedule_ID = Convert.ToInt32(Validation.getCellFromGridView(dataGridView1, 0));
            Frm_Update_Class_Information update_Class_Information = new Frm_Update_Class_Information(Schedule_ID, username);
            update_Class_Information.ShowDialog();
        }

        private void btn_Search_Click(object sender, EventArgs e)

        {
            Class_Information.ViewClassInfo(dataGridView1, cmb_Level.Text, cmb_Subject.Text);

        }

        // When user press the Log Out button from the sidebar, the system will bring the user out of the interface.
        private void btn_Log_Out_Click(object sender, EventArgs e)
        {
            LoginForm loginform = new LoginForm();
            this.Hide();
            loginform.ShowDialog();
            this.Close();
        }

        private void frm_Update_and_Delete_Load(object sender, EventArgs e)
        {
            if (gender == "Male")
            {
                labGreeting.Text = $"Hello MR.{name}";
            }
            else
            {
                labGreeting.Text = $"Hello Miss.{name}";
            }

            Class_Information.ViewClassInfo(dataGridView1);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int schedule_id = -1;
            int getIndex = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    getIndex = i;
                    schedule_id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    break;
                }
            }

            if (schedule_id != -1)
            {
                if (MessageBox.Show($" Are Sure you want to delete ", "XXX", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Class_Information schedule_delete = new Class_Information(schedule_id);
                    string message = schedule_delete.Delete_Class_Info();
                    dataGridView1.Rows.RemoveAt(getIndex);
                    MessageBox.Show(message);
                }
                else
                {
                    MessageBox.Show("Delete Process Stoped Successfully!!!");
                }
            }
        }
    }
}
