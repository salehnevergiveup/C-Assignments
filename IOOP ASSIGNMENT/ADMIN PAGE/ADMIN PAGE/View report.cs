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
using System.Xml.Linq;

namespace ADMIN_PAGE
{
    public partial class View_report : Form
    {
        public ListBox aa, bb, cc;
        public View_report()
        {
            InitializeComponent();

        }

        public View_report(ListBox.ObjectCollection items)
        {
            InitializeComponent();

            listBoxsubject.Items.AddRange(items);
        }


        public View_report(string un)
        {
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMax.Visible = true;
            btnNormal.Visible = false;
        }

        private void btnmini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMax.Visible = false;
            btnNormal.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void btnTutorlist_Click(object sender, EventArgs e)
        {
            TUTORLIST tutorlist = new TUTORLIST();
            this.Hide();
            tutorlist.ShowDialog();
            this.Close();
        }

        private void btnReceplist_Click(object sender, EventArgs e)
        {
            AdminReceptionist receptionist = new AdminReceptionist();
            this.Hide();
            receptionist.ShowDialog();
            this.Close();
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnfullreportpage_Click(object sender, EventArgs e)
        {
            /*if (listBoxsubject.Items.Count == 0 || listboxlevel.Items.Count == 0 || listboxmonth.Items.Count == 0)
            {
                MessageBox.Show("Some data is missing, cannot generate report!");
            }
            else if (listBoxsubject.Items.Count == 0 && listboxlevel.Items.Count == 0 && listboxmonth.Items.Count == 0)
            {*/
                ViewFullreport viewfullreport = new ViewFullreport();
                this.Hide();
                viewfullreport.ShowDialog();
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

        
        private void View_report_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnviewSubjecttotal_Click(object sender, EventArgs e)
        {
            if(checkedListBoxSubject.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one subject and Month");
            }
            else if (checkedListBoxSubject.CheckedItems.Count >0)
            {
                ClassAdmin bb = new ClassAdmin();
                bb.viewtotalincomesubject(checkedListBoxSubject, listBoxsubject, listboxlevel, listboxmonth, lblTotalicome1);
            }
            
        }

        private void btnviewlevelTotal_Click(object sender, EventArgs e)
        {
            if (cltbxLevel.CheckedItems.Count == 0 )
            {
                MessageBox.Show("Please select at least one Level");
            }
            else if (cltbxLevel.CheckedItems.Count > 0 )
            {
                ClassAdmin bb = new ClassAdmin();
                bb.viewtotalincomelevel(cltbxLevel, listBoxsubject, listboxlevel, listboxmonth, lblTotalicome1);
            }
        }
            

        private void btnViewMonthtotal_Click(object sender, EventArgs e)
        {
            if (cltbxMonth.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one Month");
            }
            else if (cltbxMonth.CheckedItems.Count > 0)
            {
                ClassAdmin bb = new ClassAdmin();
                bb.viewtotalincomemonth(cltbxMonth, listBoxsubject, listboxlevel, listboxmonth, lblTotalicome1);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            View_report viewreport = new View_report();
            this.Hide();
            viewreport.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
//cltbxLevel,cltbxMonth,
