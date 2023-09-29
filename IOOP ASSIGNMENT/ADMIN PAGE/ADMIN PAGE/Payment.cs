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
    public partial class Payment : Form
    {
        private static string name, username, gender;
        public Payment()
        {
            InitializeComponent();
        }
        

        public Payment(string un, string n, string g)
        {
          InitializeComponent();
            username= un;
            name = n;
            gender = g; 
        }

        // close , min , max , normal size  start
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMax_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMax.Visible = false;
            btnNormal.Visible = true;
            btnNormal.Location = btnMax.Location;

        }

        private void btnMin_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnNormal_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMax.Visible = true;
            btnNormal.Visible = false;
        }
        // close , min , max , normal size  end


        //Sidebar start 
        bool sidebar;
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
        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            Sidebar.Start();
        }

        private void btnProfile_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ProfileRec profile = new ProfileRec(name,username, gender);
            profile.ShowDialog();
            this.Close();

        }
        private void btnAddStudent_Click_1(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            this.Hide();
            addStudent.ShowDialog();
            this.Close();

        }
        private void btnRemoveStudent_Click_1(object sender, EventArgs e)
        {
            StudentDataModifcation studentData = new StudentDataModifcation();
            studentData.ShowDialog();
            this.Close();

        }

        private void btnAccept_Click_1(object sender, EventArgs e)
        {
            string Studusername;
            if (!Recepvalidation.checkTextBoxes(txtPayUserName.Text)) { MessageBox.Show("Usernew Field Should not be empty!!!"); return; } 
            else Studusername = txtPayUserName.Text;

            ClassReceipt payReceipt = new ClassReceipt(Studusername);
            ClassReceipt.ViewPaymentInfo(payReceipt);

            bool result = Recepvalidation.checkTextBoxes(txtPayStudName.Text, txtPayStudPass.Text, CmbBoxPayStudMonth.Text, CmbBoxPayStudLevel.Text);
            if (!result) {
                MessageBox.Show($"Sorry {name} All Fields Should be filled out !!!");
                return; 
            }
            datePayDate.Value = DateTime.Today; 
             DateTime date = datePayDate.Value;

            ClassReceipt genReceipt = new ClassReceipt(payReceipt.SubjectID1, Convert.ToDouble(labSub1Fees.Text),date,payReceipt.StudentID1, CmbBoxPayStudMonth.Text,CmbBoxPayStudLevel.Text);



            if(labSub2Fees.Text != "")
            {
                genReceipt.SubjectID2 = payReceipt.SubjectID2;
                genReceipt.SubjectCharge2 = Convert.ToDouble(labSub2Fees.Text); 
            }

            if (labSub3Fees.Text != "")
            {
                genReceipt.SubjectID3 = payReceipt.SubjectID3;
                genReceipt.SubjectCharge3 = Convert.ToDouble(labSub3Fees.Text);
            }

           
            string message = genReceipt.AddPayment();
            MessageBox.Show(message);

            for (int i = 0; i < chlsbxPaySubject.Items.Count; i++)
            {
                    chlsbxPaySubject.SetItemChecked(i, false);
            }

            receipt receipt = new receipt(payReceipt.StudentName,txtPayStudPass.Text , date , CmbBoxPayStudMonth.Text, CmbBoxPayStudLevel.Text, payReceipt.SubjectName1, labSub1Fees.Text, payReceipt.SubjectName2, labSub2Fees.Text, payReceipt.SubjectName3, labSub3Fees.Text);
              receipt.ShowDialog();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
           foreach(Control i in panel4.Controls)
            {
               if( i is TextBox || i is ComboBox)
                {
                    i.Text = "";
                }
            }
            for (int i = 0; i < chlsbxPaySubject.Items.Count; i++)
            {
                chlsbxPaySubject.SetItemChecked(i, false);
            }
            labSub1.Text = "Subject1";
            labSub2.Text = "Subject2";
            labSub3.Text = "Subject3";
            labSub1Fees.Text = "";
            labSub2Fees.Text = "";
            labSub3Fees.Text = "";


        }

        private void Login_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
            this.Close();
        }

        private void datePayDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            labGreating.Text = $"Welcome TO Payment Form {name}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Studusername;
            if (!Recepvalidation.checkTextBoxes(txtPayUserName.Text)) { MessageBox.Show("username Field Should not be empty!!!"); return; } else Studusername = txtPayUserName.Text;  

            ClassReceipt receipt = new ClassReceipt(Studusername);
            ClassReceipt.ViewPaymentInfo(receipt);

            txtPayStudName.Text = receipt.StudentName;
            txtPayStudPass.Text = receipt.StudenIcPass;
            CmbBoxPayStudLevel.Text = receipt.Level;
            labSub1Fees.Text = receipt.SubjectCharge1.ToString();
            txtPayAmount.Text = receipt.SubjectCharge1.ToString() + "RM";


            for (int i = 0; i < chlsbxPaySubject.Items.Count; i++)
             {
                    if (chlsbxPaySubject.Items[i].ToString() == receipt.SubjectName1)
                    {

                        chlsbxPaySubject.SetItemChecked(i, true);
                    }


                }

           if (receipt.SubjectCharge2 != null)
            {
                labSub2Fees.Text = receipt.SubjectCharge2.ToString();
                for (int i = 0; i < chlsbxPaySubject.Items.Count; i++)
                {
                    if (chlsbxPaySubject.Items[i].ToString() == receipt.SubjectName2)
                    {
                        chlsbxPaySubject.SetItemChecked(i, true);   
                    }
                }
                txtPayAmount.Text = (receipt.SubjectCharge1 + receipt.SubjectCharge2).ToString() + "RM";
            }

            if (receipt.SubjectCharge3 != null)
            {
                labSub3Fees.Text = receipt.SubjectCharge3.ToString();
                for (int i = 0; i < chlsbxPaySubject.Items.Count; i++)
                {
       
                    if (chlsbxPaySubject.Items[i].ToString() == receipt.SubjectName3)
                    {

                        chlsbxPaySubject.SetItemChecked(i, true);
                    }

                }

                txtPayAmount.Text = (Math.Round(receipt.SubjectCharge1 + receipt.SubjectCharge2+ receipt.SubjectCharge3,2)).ToString()+"RM";
            }
            chlsbxPaySubject.Enabled = true;
            foreach (Control cont in panel4.Controls)
            {
                cont.Enabled = true;
            }


            //Sidebar end
        }


    }
}
