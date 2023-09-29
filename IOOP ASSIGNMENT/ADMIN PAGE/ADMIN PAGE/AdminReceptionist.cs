using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADMIN_PAGE
{
    public partial class AdminReceptionist : Form
    {
        public AdminReceptionist()
        {
            InitializeComponent();
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            if (comboBoxReceptionist.Text == "")
            {
                MessageBox.Show("You didnt select any tutor yet");
            }
            else if (comboBoxReceptionist.Text != "")
            {
                if (MessageBox.Show($"Do You want to delete Receptionist:,'{comboBoxReceptionist.Text}'", "Remove Receptionist", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ClassReceptionist deleterecepp = new ClassReceptionist();
                    deleterecepp.DeleteRecep(comboBoxReceptionist.Text);

                    AdminReceptionist receptionist = new AdminReceptionist();
                    this.Hide();
                    receptionist.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Action Denied", "Remove Receptionist");
                }
            }
            
        }

        private void btnnormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnmaxi.Visible = true;
            btnnormal.Visible = false;
        }

        private void btnmini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnmaxi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnmaxi.Visible = false;
            btnnormal.Visible = true;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnmain_Click(object sender, EventArgs e)
        {
            AdminViewProfile profile = new AdminViewProfile();
            this.Hide();
            profile.ShowDialog();
            this.Close();
        }

        private void btntutorlist_Click(object sender, EventArgs e)
        {
            TUTORLIST tutorlist = new TUTORLIST();
            this.Hide();
            tutorlist.ShowDialog();
            this.Close();
        }

        private void btnmonthlyincome_Click(object sender, EventArgs e)
        {
            View_report viewreport = new View_report();
            this.Hide();
            viewreport.ShowDialog();
            this.Close();
        }

        private void btnaddreppage_Click(object sender, EventArgs e)
        {
            Add_receptionist addreceptionist = new Add_receptionist();
            this.Hide();
            addreceptionist.ShowDialog();
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

        private void panel12_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Receptionist_Load_1(object sender, EventArgs e)
        {
            ClassReceptionist viewgv = new ClassReceptionist();
            viewgv.viewReceptionistlist(datarecep);
            
            ArrayList Rname = new ArrayList();
            Rname =ClassReceptionist.viewRecep();
            foreach (var item in Rname)
            {
                comboBoxReceptionist.Items.Add(item);
            }
        }
    }
}
