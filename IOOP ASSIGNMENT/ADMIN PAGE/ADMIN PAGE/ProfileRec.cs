using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace ADMIN_PAGE
{
    public partial class ProfileRec : Form
    {
        public static string name, gender, username;
        public ProfileRec()
        {
            InitializeComponent();
        }

        public ProfileRec(string u, string g, string un)
        {
            InitializeComponent();
                name = u;
                gender = g;
                username = un;
             
        }


        private void panel11_Paint(object sender, PaintEventArgs e)
        {

           
            

        }

        private void ProfileRec_Load(object sender, EventArgs e)
        {
            labGreating.Text = $"Welcome to Profile Form {name}";
            Receptionist userReceptionist = new Receptionist(username);
            Receptionist.viewProfile(userReceptionist);
            labStaffName.Text = name;
            labStaffUsername.Text = username;
            labStaffGender.Text = gender;
            labSatffPosition.Text = "Receptionist";
            labStaffId.Text = userReceptionist.ICPassport1;
            labStaffEmail.Text = userReceptionist.Email1;
            labStaffContact.Text = userReceptionist.Contact_Num1;
            labStaffBirthday.Text = userReceptionist.DOB1.ToString();
            labStaffAddress.Text = userReceptionist.Address1;
            foreach (Control txt in panel11.Controls)
            {
                if (txt is Label && (txt as Label).Text == "")
                {
                    (txt as Label).Text = "XXXXXXXXXXXX";

                }
            }

        }

        // close , min , max , normal size  start

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMax.Visible = false;
            btnNormal.Visible = true;
            btnNormal.Location = btnMax.Location;

        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMax.Visible = true;
            btnNormal.Visible = false;
        }

        // close , min , max , normal size  end


        // sidebar  start 
        bool sidebar; 

        private void Sidebar_Tick(object sender, EventArgs e)
        {
            if(sidebar)
            {
                panelSidebar.Width -= 10;
                if(panelSidebar.Width == panelSidebar.MinimumSize.Width)
                {
                    sidebar = false;
                    Sidebar.Stop();


                }

            }
            else
            {
                panelSidebar.Width += 10;
                if (panelSidebar.Width == panelSidebar.MaximumSize.Width)
                {
                    sidebar = true;
                    Sidebar.Stop();
                }


            }


        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            Sidebar.Start();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent(name, username, gender);
            this.Hide();
            addStudent.ShowDialog();
            this.Close();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment payment = new Payment(name, username, gender);
            payment.ShowDialog();
            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
            this.Close();
        }

        private void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentDataModifcation studentDataModifcation = new StudentDataModifcation(name, username, gender);
            studentDataModifcation.ShowDialog();
            this.Close();
        }

        private void btnStaffUpdate_Click(object sender, EventArgs e)
        {
            RecepUpdateProfile updateProfile = new RecepUpdateProfile(name,username, gender);
            //this.Hide();
            updateProfile.ShowDialog();
            // this.Close()   
        }


        //sidebar end


     
    }
}
