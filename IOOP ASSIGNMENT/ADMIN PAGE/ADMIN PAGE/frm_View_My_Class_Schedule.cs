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
    public partial class frm_View_My_Class_Schedule : Form
    {

        public static string name, username, gender;

        public frm_View_My_Class_Schedule()
        {
            InitializeComponent();
        }

        public frm_View_My_Class_Schedule(string n, string un, string g)
        {
            InitializeComponent();
            username = un;
            gender = g;
            name = n;
        }

        // To exit from the current page
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Add_Class_Information aa = new Frm_Add_Class_Information(username,gender,name);
            aa.ShowDialog();
            this.Close();
        }

        // Successfully exit from the page

        // To minimize the page
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        // When the user press the minimize button on the top right of the page, the interface will be minimized.

        private void frm_View_My_Class_Schedule_Load(object sender, EventArgs e)
        {
            if (gender == "Male") labGreeting.Text = $"Welcome Mr.{name}";
            else labGreeting.Text = $"welcome Miss.{name}";

            Class_Information.view_class_schedule(dataGridView1, username);  
        }
    }
}
