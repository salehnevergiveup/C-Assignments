using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace ADMIN_PAGE
{
    public partial class STUDENTViewProfile : Form
    {
        private static string username;
        public STUDENTViewProfile()
        {
            InitializeComponent();
        }
        public STUDENTViewProfile(string Username)
        {
            InitializeComponent();

            username = Username;
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ViewProfile_Load(object sender, EventArgs e)
        {
            StudentOnly showStuDetails = new StudentOnly(username);
            StudentOnly.viewProfile(showStuDetails);
            lblStuName1.Text = showStuDetails.Name;
            lblStuDOB.Text = showStuDetails.Dob.ToString();
            lblStuGen.Text = showStuDetails.Gender;
            lblStuLevel.Text = showStuDetails.Studylevel;
            lblStuCN.Text = showStuDetails.Contactnum;
            lblStuEmail.Text = showStuDetails.Email;
            lblStuAdd.Text = showStuDetails.Address;
            lblStuEM.Text = showStuDetails.Enrollment_Month1;
            lblStuICP1.Text = showStuDetails.Ic_passport;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateStudentProfile profile = new UpdateStudentProfile(username);
            this.Hide();
            profile.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Studentviewsche schedule = new Studentviewsche(username);
            this.Hide();
            schedule.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewRequests request = new ViewRequests(username);
            this.Hide();
            request.ShowDialog();
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
    }
}
