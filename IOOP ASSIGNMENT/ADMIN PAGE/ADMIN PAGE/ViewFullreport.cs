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
    public partial class ViewFullreport : Form
    {
        public ViewFullreport()
        {
            InitializeComponent();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnclosepage_Click(object sender, EventArgs e)
        {
            View_report viewreport = new View_report();
            this.Hide();
            viewreport.ShowDialog();
            this.Close();
        }

        private void dataFullreport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ViewFullreport_Load(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Level")
            {
                ClassAdmin aa = new ClassAdmin();
                aa.viewfulllevelreport(comboBox1.Text, dataFullreport);
            }
            else if(comboBox2.Text == "Subject")
            {
                ClassAdmin aa = new ClassAdmin();
                aa.viewfullsubjectreport(comboBox1.Text, dataFullreport);
            }
        }
    }
}
