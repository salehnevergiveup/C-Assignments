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
    public partial class ViewRequests : Form
    {
        private static string username;
        public ViewRequests()
        {
            InitializeComponent();
        }
        public ViewRequests(string Username)
        {
            InitializeComponent();
            username = Username;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Studentviewsche schedule = new Studentviewsche(username);
            this.Hide();
            schedule.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            STUDENTViewProfile profile = new STUDENTViewProfile(username);
            this.Hide();
            profile.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MakeRequest addRequest = new MakeRequest(username);
            this.Hide();
            addRequest.ShowDialog();
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ViewRequests_Load(object sender, EventArgs e)
        {
            manageRequests.viewRequests(dataGridViewRequests, username);
        }

        private void btnDeleteR_Click(object sender, EventArgs e)
        {
            int requestid = -1;
            int getIndex = 0;
            for (int i = 0; i < dataGridViewRequests.Rows.Count; i++)
            {
                if (dataGridViewRequests.Rows[i].Selected == true)
                {
                    getIndex = i;
                    requestid = Convert.ToInt32(dataGridViewRequests.Rows[i].Cells[0].Value.ToString());
                    break;
                }
            }

            if (requestid != -1)
            {
                if (MessageBox.Show($" Are Sure you want to delete ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    manageRequests request_delete = new manageRequests(requestid);
                    string message = request_delete.deleteRequest();
                    dataGridViewRequests.Rows.RemoveAt(getIndex);
                    MessageBox.Show(message);
                }
                else
                {
                    MessageBox.Show("Delete Process Stoped");
                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
