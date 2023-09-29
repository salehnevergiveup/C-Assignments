using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace ADMIN_PAGE
{
    public partial class AddStudent : Form
    {
        static string R_name, R_username, R_gender;  
        public AddStudent()
        {
            InitializeComponent();
        }

        public AddStudent(string n , string un , string g)
        {
            InitializeComponent();
            R_name = n; ;
            R_username = un;
            R_gender = g;
           

        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            labGreating.Text = $"Welcome Add Student Form {R_name}";

        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Recepvalidation.checkBoxCheker(chbxlsStudSubjects, 1, 3))
            {
                MessageBox.Show($"Sorry!!!!{R_name} subjects should be beteewn 1 to 3");
                return;

            }
            List<string> subjects = new List<string>();
            foreach (string i in chbxlsStudSubjects.CheckedItems) {subjects.Add(i); }

                bool sub = Recepvalidation.checkTextBoxes(txtStudName.Text, combStudLevel.Text, txtStudId.Text, combEnrolMonth.Text);
            if(!sub)
            {
                MessageBox.Show($"Kindly {R_name} name , Level , Student ID and Month of Enrollments can not be Empty!!");
                return;
            }

           Recep_Student student = new Recep_Student(txtStudName.Text, combStudLevel.Text, subjects[0], txtStudId.Text,combEnrolMonth.Text);

            if (txtStudEmail.Text != "")
            {
                if (!Recepvalidation.CheckEmail(txtStudEmail.Text))
                {

                    MessageBox.Show($"Sorry!!!! {R_name} invalid Email address");
                    //student.Email1 = "Empty@g.com";
                    return;

                }
                else student.Email1 = txtStudEmail.Text;
            }
           else student.Email1 = "Empty@g.com";
            if (txtStudAddress.Text != "") student.Address1 = txtStudContactNum.Text; else student.Address1 = "Empty";
            if (txtStudContactNum.Text != "") student.ContactNumber1 = txtStudContactNum.Text; else student.ContactNumber1 = "Empty";
            if (radiStudMale.Checked) student.Gender = "Male"; else if (radiStudFemale.Checked) student.Gender = "Female"; else student.Gender = "Empty";
            if (subjects.Count  == 2) student.Subject2 = subjects[1]; else student.Subject2 = "Empty";
            if (subjects.Count == 3){
                student.Subject2 = subjects[1];  
                student.Subject3 = subjects[2];
            }
            student.DOB1 = dateStudBirthday.Value;

            //Execute the function
            string message = student.AddStudent();
            MessageBox.Show(message);
            subjects.Clear();
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


        //Sidebar  start 
        bool sidebar;
        private void Sidebar_Tick_1(object sender, EventArgs e)
        {
            if (sidebar)
            {
                panelSidebar.Width -= 10;
                if (panelSidebar.Width == panelSidebar.MinimumSize.Width)
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


        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            Sidebar.Start();

        }

        private void btnProfile_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ProfileRec profile = new ProfileRec();
            profile.ShowDialog();
            this.Close();
           
        }

 
        private void btnPay_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment payment = new Payment(R_name, R_username, R_gender);
            payment.ShowDialog();
            this.Close();
        }

        private void chbxlsStudSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combStudLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            chbxlsStudSubjects.Items.Clear();
            if (combStudLevel.SelectedIndex >= 0 && combStudLevel.SelectedIndex <= 2)
            {
                chbxlsStudSubjects.Items.Add("Chinese");
                chbxlsStudSubjects.Items.Add("English");
                chbxlsStudSubjects.Items.Add("Bahasa Malaysia");
                chbxlsStudSubjects.Items.Add("Mathematics");

            }

            if (combStudLevel.SelectedIndex >= 3 && combStudLevel.SelectedIndex <= 4)
            {
                chbxlsStudSubjects.Items.Add("Chinese");
                chbxlsStudSubjects.Items.Add("English");
                chbxlsStudSubjects.Items.Add("Bahasa Malaysia");
                chbxlsStudSubjects.Items.Add("Mathematics");
                chbxlsStudSubjects.Items.Add("Additional Mathematics");
                chbxlsStudSubjects.Items.Add("Biology");
                chbxlsStudSubjects.Items.Add("Physics");
                chbxlsStudSubjects.Items.Add("Chemistry");
                chbxlsStudSubjects.Items.Add("Geography");
                chbxlsStudSubjects.Items.Add("History");
                chbxlsStudSubjects.Items.Add("Business Accounting");
                chbxlsStudSubjects.Items.Add("Economics");
            }

        }

        private void Login_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
        }

        private void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            StudentDataModifcation studentData = new StudentDataModifcation(R_name, R_username, R_gender);
            studentData.ShowDialog();
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach(Control i in panel4.Controls)
            {
                if(i is TextBox || i is ComboBox)
                {
                    i.Text = "";
                }
            }
            for (int i = 0; i <  chbxlsStudSubjects.Items.Count; i++)
            {
                chbxlsStudSubjects.SetItemChecked(i, false);
            }

        }

        //Sidebar End
    }
}
