using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace ADMIN_PAGE
{
    public partial class StudentDataModifcation : Form
    {
        string name, username, gender;
        public StudentDataModifcation()
        {
            InitializeComponent();
        }

        public StudentDataModifcation(string n, string un, string g)
        {
            InitializeComponent();
            name = n; 
            username = un;
            gender = g;
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


        bool sidebar;
        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMax.Visible = true;
            btnNormal.Visible = false;
        }

        // close , min , max , normal size End

        // sidebar start 

        private void Sidebar_Tick(object sender, EventArgs e)
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

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Sidebar.Start();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {

            this.Hide();
            ProfileRec profile = new ProfileRec();
            profile.ShowDialog();
            this.Close();

        }


        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent(name,username, gender);
            this.Hide();
            addStudent.ShowDialog();
            this.Close();

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment payment = new Payment(name,username,gender);
            payment.ShowDialog();
            this.Close();

        }

        //Search For Studets Start
        private void btnsStudSeach_Click(object sender, EventArgs e)
        {
            Recepvalidation.searchWithinGird(dataGridViewStud, label4, txtStudSearch.Text, 0,1);
        }
       


        private void studentDelete_Click(object sender, EventArgs e)
        {
            string removeStud = null;
            string StudName = null;
            int getIndex = 0;

            for(int i =0; i < dataGridViewStud.Rows.Count; i ++)
            {
                if (dataGridViewStud.Rows[i].Selected == true)
                {
                    getIndex = i;
                    StudName = dataGridViewStud.Rows[i].Cells[0].Value.ToString();
                    removeStud = dataGridViewStud.Rows[i].Cells[1].Value.ToString();
                    break; 
                }
            }

         
            if(removeStud !=null)
            {
                if (MessageBox.Show($"Mr Saleh Are Sure you want to delete {StudName}", "XXX", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("deleted");
                    Recep_Student studentDelete = new Recep_Student(removeStud, StudName);
                    string message = studentDelete.deletStudent();
                    dataGridViewStud.Rows.RemoveAt(getIndex);
                    MessageBox.Show(message); 

                }
                else
                {
                    MessageBox.Show("Delete Process Stoped Secussfully!!!");
                }

            }




        }
        private void button2_Click(object sender, EventArgs e)
        {
            //EditStudentData editStudentData = new EditStudentData(name,username, mrMiss,);
            //editStudentData.ShowDialog(); 
        }
        // once I click enter the  other page  data reomved
     
        private void button1_Click(object sender, EventArgs e)
        {
            StudentRequests studentRequests = new StudentRequests(name,username,gender);
            studentRequests.ShowDialog();
        }


        private void StudentDataModifcation_Load(object sender, EventArgs e)
        {
            labGreating.Text = $"Welcome to Profile Form {name}";
            dataGridViewStud.DataSource = Recep_Student.ViewStudentInfo()[0];
            dataGridViewStud.Rows[0].Cells[0].Selected = false; 

        }

        private void Login_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
            this.Close();
        }

        private void combTableType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combTableType.SelectedIndex== 0)
            {
             dataGridViewStud.DataSource = Recep_Student.ViewStudentInfo()[0];
                dataGridViewStud.Rows[0].Cells[0].Selected = false;
            }
            else {
               dataGridViewStud.DataSource = Recep_Student.ViewStudentInfo()[1];
                dataGridViewStud.Rows[0].Cells[0].Selected = false;
            }
          
        }

        private void dataGridViewStud_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    } 

}

        //Edit student  Data End
     
    

