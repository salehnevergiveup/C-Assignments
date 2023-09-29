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
    
    public partial class UpdateSubjects : Form
    {
        public UpdateSubjects()
        {
            InitializeComponent();
        }
        public static string receptUSerName, StuduserName, newSubjectOne, newSubjectTwo, newSubjectThree;

   

        public UpdateSubjects(string recUn, string stdUn,string sub1,string sub2,string sub3)
        {
            InitializeComponent();

            receptUSerName = recUn;
            StuduserName = stdUn;
            newSubjectOne = sub1;
            newSubjectTwo = (Recepvalidation.checkTextBoxes(sub2)) ? sub2 : "New Subject2";
            newSubjectThree= (Recepvalidation.checkTextBoxes(sub3)) ? sub3 : "New Subject3";
            
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Recep_Student student1 = new Recep_Student(StuduserName);
            Recep_Student.viewstudentSubjectDetiles(student1);
            List<string> subjectsList = new List<string>();
            subjectsList.Add(labUpdateNewSub1.Text);
            if(labUpdateNewSub2.Text != "New Subject2") subjectsList.Add(labUpdateNewSub2.Text);
            if (labUpdateNewSub3.Text != "New Subject3") subjectsList.Add(labUpdateNewSub3.Text);
            string message =  Recep_Student.updateSubjects(student1.StudentID1,subjectsList);
            MessageBox.Show(message);

            //status change to updated 
            /// status rejected 
            Receptionist receptionistId = new Receptionist(receptUSerName);
            Receptionist.viewProfile(receptionistId);
            int recepID = receptionistId.ReceptionistID1;
            string status = "Updated";
            DateTime compDate = DateTime.Today;
            string userNameStud = StuduserName;
            Request.updateRequestInfo(recepID, compDate, status, userNameStud);

        }

        private void UpdateSubjects_Load(object sender, EventArgs e)
        {
            labUpdateNewSub1.Text = newSubjectOne;
            labUpdateNewSub2.Text = newSubjectTwo;
            labUpdateNewSub3.Text = newSubjectThree;
            Recep_Student student1 = new Recep_Student(StuduserName);
            Recep_Student.viewstudentSubjectDetiles(student1);
            labUpdateName.Text=  student1.Name1;
            labUpdateID.Text = student1.StudentID; 
             labUpdateSub1.Text = student1.Subject1;
             labUpdateSub2.Text =  student1.Subject2;
            labUpdateSub3.Text =  student1.Subject3;
            if (newSubjectTwo == "New Subject2") cmbSub2.Enabled = false;
            if (newSubjectThree == "New Subject3") cmbSub3.Enabled = false;


        }
        private void labCheckFees3_Click_1(object sender, EventArgs e)
        {

        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /// status rejected 
            Receptionist receptionistId = new Receptionist(receptUSerName);
            Receptionist.viewProfile(receptionistId);
            int recepID = receptionistId.ReceptionistID1;
            string status = "rejected";
            DateTime compDate = DateTime.Today;
            string userNameStud = StuduserName;
            Request.updateRequestInfo(recepID, compDate, status, userNameStud);
        }
    }
}
