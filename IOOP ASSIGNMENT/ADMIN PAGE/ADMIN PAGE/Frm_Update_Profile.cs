using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ADMIN_PAGE
{
    public partial class Frm_Update_Profile : Form
    {
        string name, username, gender;
        public Frm_Update_Profile()
        {
            InitializeComponent();
        }

        public Frm_Update_Profile(string n, string un, string g)
        {
            InitializeComponent();
            Name = n;
            gender = g;
            username = un;
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

        // When user press the Log Out button from the sidebar, the system will bring the user out of the interface.
        private void btn_Log_Out_Click(object sender, EventArgs e)
        {
            LoginForm loginform = new LoginForm();
            this.Hide();
            loginform.ShowDialog();
            this.Close();
        }

        private void btn_Update2_Click(object sender, EventArgs e)
        {
            Tutor backup = new Tutor(username);
            Tutor.View_Tutor_Details(backup);
            Tutor tutor = new Tutor(username);
            tutor.Tutor_Name1 = txt_Name.Text;
            tutor.Username = txt_UserID.Text;
            tutor.Identity_card1 = txt_Identity_Card.Text;
            tutor.DOB1 = dateTimePicker1.Value;
            tutor.Contact_Num1 = txt_Contact_Num.Text;
            tutor.Email1 = txt_Email.Text;
            tutor.Address1 = txt_Address.Text;
            if (tutor.Gender == "Male")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            tutor.Level_of_teaching_1 = cmb_Level_of_Teaching_1.Text;
            tutor.Level_of_teaching_2 = cmb_Level_of_Teaching_2.Text;
            tutor.Level_of_teaching_3 = cmb_Level_of_Teaching_3.Text;
            tutor.Subject_Name_1 = cmb_Teaching_Subject_1.Text;
            tutor.Subject_Name_2 = cmb_Teaching_Subject_2.Text;
            tutor.Subject_Name_3 = cmb_Teaching_Subject_3.Text;


            Sub1.Text = cmb_Teaching_Subject_1.Text;
            Sub2.Text = cmb_Teaching_Subject_2.Text;
            Sub3.Text = cmb_Teaching_Subject_3.Text;
            LevelSub1.Text = cmb_Level_of_Teaching_1.Text;
            LevelSub2.Text = cmb_Level_of_Teaching_2.Text;
            LevelSub3.Text = cmb_Level_of_Teaching_3.Text;
            Tutor viewsub1 = new Tutor(Sub1.Text, LevelSub1.Text, labGreeting.Text);
            Tutor viewsub2 = new Tutor(Sub2.Text, LevelSub2.Text, labGreeting.Text);
            Tutor viewsub3 = new Tutor(Sub3.Text, LevelSub3.Text, labGreeting.Text);

            Tutor.Update_Profile(tutor, username);
            string gender = "";
            if (radioButton1.Checked) gender = "Male";
            if (radioButton2.Checked) gender = "Female";
        }

        private void cmb_Level_of_Teaching_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Level_of_Teaching_2.SelectedIndex >= 0 && cmb_Level_of_Teaching_2.SelectedIndex <= 2)
            {
                cmb_Teaching_Subject_2.Items.Clear();
                cmb_Teaching_Subject_2.Items.Add("Chinese");
                cmb_Teaching_Subject_2.Items.Add("English");
                cmb_Teaching_Subject_2.Items.Add("Bahasa Malaysia");
                cmb_Teaching_Subject_2.Items.Add("Mathematics");

            }
            if (cmb_Level_of_Teaching_2.SelectedIndex >= 3 && cmb_Level_of_Teaching_2.SelectedIndex <= 4)
            {
                cmb_Teaching_Subject_2.Items.Clear();
                cmb_Teaching_Subject_2.Items.Add("Additional Mathematics");
                cmb_Teaching_Subject_2.Items.Add("Biology");
                cmb_Teaching_Subject_2.Items.Add("Physics");
                cmb_Teaching_Subject_2.Items.Add("Chemistry");
                cmb_Teaching_Subject_2.Items.Add("Geography");
                cmb_Teaching_Subject_2.Items.Add("History");
                cmb_Teaching_Subject_2.Items.Add("Business");
                cmb_Teaching_Subject_2.Items.Add("Accounting");
                cmb_Teaching_Subject_2.Items.Add("Economics");
            }
            cmb_Teaching_Subject_2.Enabled = true;
        }

        private void cmb_Level_of_Teaching_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Level_of_Teaching_3.SelectedIndex >= 0 && cmb_Level_of_Teaching_3.SelectedIndex <= 2)
            {
                cmb_Teaching_Subject_3.Items.Clear();
                cmb_Teaching_Subject_3.Items.Add("Chinese");
                cmb_Teaching_Subject_3.Items.Add("English");
                cmb_Teaching_Subject_3.Items.Add("Bahasa Malaysia");
                cmb_Teaching_Subject_3.Items.Add("Mathematics");

            }
            if (cmb_Level_of_Teaching_3.SelectedIndex >= 3 && cmb_Level_of_Teaching_3.SelectedIndex <= 4)
            {
                cmb_Teaching_Subject_3.Items.Clear();
                cmb_Teaching_Subject_3.Items.Add("Chinese");
                cmb_Teaching_Subject_3.Items.Add("English");
                cmb_Teaching_Subject_3.Items.Add("Bahasa Malaysia");
                cmb_Teaching_Subject_3.Items.Add("Mathematics");
                cmb_Teaching_Subject_3.Items.Add("Additional Mathematics");
                cmb_Teaching_Subject_3.Items.Add("Biology");
                cmb_Teaching_Subject_3.Items.Add("Physics");
                cmb_Teaching_Subject_3.Items.Add("Chemistry");
                cmb_Teaching_Subject_3.Items.Add("Geography");
                cmb_Teaching_Subject_3.Items.Add("History");
                cmb_Teaching_Subject_3.Items.Add("Business Accounting");
                cmb_Teaching_Subject_3.Items.Add("Economics");
            }
            cmb_Teaching_Subject_3.Enabled = true;
        }

        private void cmb_Teaching_Subject_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_Level_of_Teaching_2.Enabled = true;
        }

        private void cmb_Teaching_Subject_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_Level_of_Teaching_3.Enabled = true;
        }

        private void btn_Clear2_Click(object sender, EventArgs e)
        {
            foreach (Control i in panel11.Controls)
            {
                if (i is TextBox || i is ComboBox)
                {
                    i.Text = "";
                }

            }
            foreach (Control i in panel13.Controls)
            {
                if (i is TextBox || i is ComboBox)
                {
                    i.Text = "";
                }

            }
            foreach (Control i in panel14.Controls)
            {
                if (i is TextBox || i is ComboBox)
                {
                    i.Text = "";
                }

            }

            foreach (Control i in panel15.Controls)
            {
                if (i is TextBox || i is ComboBox)
                {
                    i.Text = "";
                }

            }

        }

        private void cmb_Level_of_Teaching_1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmb_Level_of_Teaching_1.SelectedIndex >= 0 && cmb_Level_of_Teaching_1.SelectedIndex <= 2)
            {
                cmb_Teaching_Subject_1.Items.Clear();
                cmb_Teaching_Subject_1.Items.Add("Chinese");
                cmb_Teaching_Subject_1.Items.Add("English");
                cmb_Teaching_Subject_1.Items.Add("Bahasa Malaysia");
                cmb_Teaching_Subject_1.Items.Add("Mathematics");

            }
            if (cmb_Level_of_Teaching_1.SelectedIndex >= 3 && cmb_Level_of_Teaching_1.SelectedIndex <= 4)
            {
                cmb_Teaching_Subject_1.Items.Clear();
                cmb_Teaching_Subject_1.Items.Add("Additional Mathematics");
                cmb_Teaching_Subject_1.Items.Add("Biology");
                cmb_Teaching_Subject_1.Items.Add("Physics");
                cmb_Teaching_Subject_1.Items.Add("Chemistry");
                cmb_Teaching_Subject_1.Items.Add("Geography");
                cmb_Teaching_Subject_1.Items.Add("History");
                cmb_Teaching_Subject_1.Items.Add("Business");
                cmb_Teaching_Subject_1.Items.Add("Accounting");
                cmb_Teaching_Subject_1.Items.Add("Economics");
            }
            cmb_Teaching_Subject_1.Enabled = true;

        }

        private void Frm_Update_Profile_Load(object sender, EventArgs e)
        {
            if (gender == "Male")   // If the user's gender is "Male," will be addressed as Mr.
            {
                labGreeting.Text = $"Welcome Mr.{name}";
            }
            else   // If the user's gender is "Female," will be addressed as Miss.
            {
                labGreeting.Text = $"Welcome Miss.{name}";
            }

            Tutor tutor = new Tutor(username);

            Tutor.View_Tutor_Details(tutor);
            txt_Name.Text = tutor.Tutor_Name1;
            txt_UserID.Text = tutor.Username;
            txt_Identity_Card.Text = tutor.Identity_card1;
            //dateTimePicker1.Value = tutor.DOB1;
            txt_Contact_Num.Text = tutor.Contact_Num1;
            txt_Email.Text = tutor.Email1;
            txt_Address.Text = tutor.Address1;
            if (tutor.Gender == "Male")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            cmb_Level_of_Teaching_1.Text = tutor.Level_of_teaching_1;
            cmb_Level_of_Teaching_2.Text = tutor.Level_of_teaching_2;
            cmb_Level_of_Teaching_3.Text = tutor.Level_of_teaching_3;
            cmb_Teaching_Subject_1.Text = tutor.Subject_Name_1;
            cmb_Teaching_Subject_2.Text = tutor.Subject_Name_2;
            cmb_Teaching_Subject_3.Text = tutor.Subject_Name_3;
        }
    }
}
