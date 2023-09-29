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
    public partial class TUTORLIST : Form
    {
        public TUTORLIST()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnnormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnmax.Visible = true;
            btnnormal.Visible = false;
        }

        private void btnmini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnmax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnmax.Visible = false;
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

        private void btnrecplist_Click(object sender, EventArgs e)
        {
            AdminReceptionist receptionist = new AdminReceptionist();
            this.Hide();
            receptionist.ShowDialog();
            this.Close();
        }

        private void btnmonthlyreport_Click(object sender, EventArgs e)
        {
            View_report viewreport = new View_report();
            this.Hide();
            viewreport.ShowDialog();
            this.Close();
        }


        private void btnlogout_Click(object sender, EventArgs e)
        {
            LoginForm loginform = new LoginForm();
            this.Hide();
            loginform.ShowDialog();
            this.Close();
        }

        private void panelslidebar_Paint(object sender, PaintEventArgs e)
        {

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

        private void datatutor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TUTORLIST_Load(object sender, EventArgs e)
        {
            ArrayList tname = new ArrayList();
            tname = ClassTutor.viewtutor();
            foreach (var item in tname)
            {
                comboBoxTutor.Items.Add(item);
            }

            ArrayList tname1 = new ArrayList();
            tname = ClassTutor.viewtutor();
            foreach (var item in tname)
            {
               comboTutor.Items.Add(item);
            }

            ClassTutor viewgv = new ClassTutor();
            viewgv.viewtutorlist(datatutor); 
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnassignsubpage_Click(object sender, EventArgs e)
        {
            Assign_Subject assignsubjectpage = new Assign_Subject();
            this.Hide();
            assignsubjectpage.ShowDialog();
            this.Close();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (comboBoxTutor.Text == "")
            {
                MessageBox.Show("You didnt select any tutor yet");
            }
            else if (comboBoxTutor.Text != "")
            {
                ClassTutor viewgv = new ClassTutor();
                viewgv.viewdsearch(datasubject, comboBoxTutor.Text);
            }
        }

        private void btndeltetutor_Click(object sender, EventArgs e)
        {
            if(comboTutor.Text == "")
            {
                MessageBox.Show("You didnt select any tutor yet");
            }
            else if(comboTutor.Text != "")
            {
                if (MessageBox.Show($"Do You want to delete tutor:,'{comboTutor.Text}'", "Remove Tutor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ClassTutor deletetutor = new ClassTutor();
                    deletetutor.DeleteTutor(comboTutor.Text);

                    TUTORLIST tutorlist = new TUTORLIST();
                    this.Hide();
                    tutorlist.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Action Denied", "Remove Tutor");
                }
            }
        }

        private void btnaddtutorpage_Click_1(object sender, EventArgs e)
        {
            addtutor addtutor = new addtutor();
            this.Hide();
            addtutor.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
