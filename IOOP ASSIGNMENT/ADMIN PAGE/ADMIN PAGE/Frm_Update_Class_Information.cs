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
    public partial class Frm_Update_Class_Information : Form
    {
        public static int Schedule_ID;
        public static string name, username, gender;
        public Frm_Update_Class_Information()
        {
            InitializeComponent();
        }
        public Frm_Update_Class_Information(int Sch, string un)
        {
            InitializeComponent();
            Schedule_ID = Sch;
            username = un;
        }

        public Frm_Update_Class_Information(string n,string un,string g)
        {
            InitializeComponent();
            username = un;
            name = n;
            gender = g;
        }

        // To exit from the current page
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Successfully exit from the page

        // To minimize the page
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        // When the user press the minimize button on the top right of the page, the interface will be minimized.

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            Class_Information backup = new Class_Information(username);
            Class_Information.View_Class_Details(backup, Schedule_ID);
            Class_Information updateInfo = new Class_Information(username);

            //for backup.
            if (!Validation.checkTextBoxes(cmbSubject.Text)) updateInfo.Subject_Name_1 = backup.Subject_Name_1; else updateInfo.Subject_Name_1 = cmbSubject.Text;
            if (!Validation.checkTextBoxes(cmbLevel.Text)) updateInfo.Level1 = backup.Level1; else updateInfo.Level1 = cmbLevel.Text;
            if (!Validation.checkTextBoxes(cmbDay.Text)) updateInfo.Day1 = backup.Day1; else updateInfo.Day1 = cmbDay.Text;
            if (!Validation.checkTextBoxes(txtSubject_Fee.Text)) updateInfo.Subject_Fee1 = backup.Subject_Fee1; else updateInfo.Subject_Fee1 = Convert.ToDouble(txtSubject_Fee.Text);
            if (!Validation.checkTextBoxes(txtDuration.Text)) updateInfo.Duration1 = backup.Duration1; else updateInfo.Duration1 = txtDuration.Text;
            if (!Validation.checkTextBoxes(txt_Start_Time.Text)) updateInfo.Start_Time1 = backup.Start_Time1; else updateInfo.Start_Time1 = txt_Start_Time.Text;
            if (!Validation.checkTextBoxes(txt_End_Time.Text)) updateInfo.End_Time1 = backup.End_Time1; else updateInfo.End_Time1 = txt_End_Time.Text;
            if (!Validation.checkTextBoxes(txtLocation.Text)) updateInfo.Location1 = backup.Location1; else updateInfo.Location1 = txtLocation.Text;

            Class_Information classInfo = new Class_Information();
            classInfo.Duration1 = txtDuration.Text;
            classInfo.Location1 = txtLocation.Text;
            classInfo.Subject_Fee1 = Convert.ToDouble(txtSubject_Fee.Text);
            classInfo.Start_Time1 = txt_Start_Time.Text;
            classInfo.End_Time1 = txt_End_Time.Text;
            classInfo.Day1 = cmbDay.Text;
            classInfo.Level1 = cmbLevel.Text;
            classInfo.Subject_Name_1 = cmbSubject.Text;

           string message = classInfo.Update_Class_Info(username);
        }

        private void Frm_Update_Class_Information_Load(object sender, EventArgs e)
        {
            Class_Information ViewInfo = new Class_Information(Schedule_ID);
            Class_Information.View_Class_Details(ViewInfo, Schedule_ID);

            //for backup.
            cmbDay.Text = ViewInfo.Day1;
            cmbLevel.Text = ViewInfo.Level1;
            cmbSubject.Text = ViewInfo.Subject_Name_1;
            txtSubject_Fee.Text = Convert.ToString(ViewInfo.Subject_Fee1);
            txtDuration.Text = ViewInfo.Duration1;
            txt_Start_Time.Text = ViewInfo.Start_Time1;
            txt_End_Time.Text = ViewInfo.End_Time1;
            txtLocation.Text = ViewInfo.Location1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach(Control i in panel11.Controls)
            {
                if(i is TextBox ||  i is ComboBox)
                {
                    i.Text = "";
                }
            }
        }
    }
}

