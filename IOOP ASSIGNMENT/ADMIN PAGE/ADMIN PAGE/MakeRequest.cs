using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ADMIN_PAGE
{
    public partial class MakeRequest : Form
    {
        private static string username;
        public MakeRequest()
        {
            InitializeComponent();
        }
        public MakeRequest(string Username)
        {
            InitializeComponent();
            username = Username;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MakeRequest_Load(object sender, EventArgs e)
        {
            lblStuUsername.Text = (username);
            lblTilte.Text = "Change Subject";
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void cbStudyLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewRequests request = new ViewRequests(username);
            this.Hide();
            request.ShowDialog();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Studentviewsche schedule = new Studentviewsche(username);
            this.Hide();
            schedule.ShowDialog();
            this.Close();
        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            STUDENTViewProfile profile = new STUDENTViewProfile(username);
            this.Hide();
            profile.ShowDialog();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DateTime RDate = dateTimePickerRD.Value;
            string sub1 = cmbSub1.Items[cmbSub1.SelectedIndex].ToString();
            string sub2 = cmbSub2.Items[cmbSub2.SelectedIndex].ToString();
            string sub3 = cmbSub3.Items[cmbSub3.SelectedIndex].ToString();
            manageRequests newrequest = new manageRequests(lblTilte.Text,sub1, sub2, sub3, RDate);
            MessageBox.Show(newrequest.addRequests(username));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ViewRequests request = new ViewRequests(username);
            this.Hide();
            request.ShowDialog();
            this.Close();
        }

        private void lblTilte_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMax.Visible = false;
            btnNormal.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMax.Visible = true;
            btnNormal.Visible = false;
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

        private void panel4_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void cmbSub3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
