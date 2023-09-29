using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ADMIN_PAGE
{
    public partial class Studentviewsche : Form
    {
        private static string username;

        public Studentviewsche()
        {
            InitializeComponent();
        }
        public Studentviewsche(string Username)
        {
            InitializeComponent();

            username = Username;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void ViewSchedule_Load(object sender, EventArgs e)
        {
            lbl_Stu_Name.Text = (username + "'s Timetable");
            StudentOnly.viewSchedule(dataGridViewStuSchedule, username);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ViewRequests request = new ViewRequests(username);
            this.Hide();
            request.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            STUDENTViewProfile profile = new STUDENTViewProfile(username);
            this.Hide();
            profile.ShowDialog();
            this.Close();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            this.Hide();
            logout.ShowDialog();
            this.Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMax.Visible = true;
            btnNormal.Visible = false;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMax.Visible = true;
            btnNormal.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridViewStuSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbl_Stu_Name_Click(object sender, EventArgs e)
        {

        }
    }
}
