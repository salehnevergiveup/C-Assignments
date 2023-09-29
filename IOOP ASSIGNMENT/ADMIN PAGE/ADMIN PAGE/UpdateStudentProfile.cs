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

namespace ADMIN_PAGE
{
    public partial class UpdateStudentProfile : Form
    {
        private static string username;
        public UpdateStudentProfile()
        {
            InitializeComponent();
        }
        public UpdateStudentProfile(string Username)
        {
            InitializeComponent();

            username = Username;
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateStudentProfile_Load(object sender, EventArgs e)
        {
            StudentOnly showStuDetails = new StudentOnly(username);
            StudentOnly.viewProfile(showStuDetails);
            txtStuName.Text = showStuDetails.Name;
            lblCurrentDOB.Text = showStuDetails.Dob.ToString();
            //dateTimePickerStuDOB.Value = showStuDetails.Dob;// use lable, only use date picker when insert data
            lblStuGen.Text = showStuDetails.Gender;
            lblStuLevel.Text = showStuDetails.Studylevel;
            txtConNum.Text = showStuDetails.Contactnum;
            txtEmail.Text = showStuDetails.Email;
            txtAddress.Text = showStuDetails.Address;
            lblStuEmMonth.Text = showStuDetails.Enrollment_Month1;
            txtICP.Text = showStuDetails.Ic_passport;
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            STUDENTViewProfile profile = new STUDENTViewProfile(username);
            this.Hide();
            profile.ShowDialog();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime newDOB = dateTimePickerStuDOB.Value;
            StudentOnly updatedetails = new StudentOnly(username);
            MessageBox.Show(updatedetails.updateProfile(txtStuName.Text, txtICP.Text, newDOB, lblStuLevel.Text, txtConNum.Text, txtEmail.Text, lblStuGen.Text, txtAddress.Text, lblStuEmMonth.Text));

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
