using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ADMIN_PAGE
{
    internal class ClassReceipt
    {
        private  string username;
        private string studentName;
        private  int studentID;
        private string studenIcPass;
        private string level;
        private string month;
        private DateTime paymentDate;
        private  int subjectID1; 
        private  int subjectID2;
        private int subjectID3;
        private double subjectCharge1;
        private double subjectCharge2;
        private double subjectCharge3;
        private string subjectName1;
        private string subjectName2;
        private string subjectName3;
        private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());

        // get set methods
        public string StudentName { get => studentName; set => studentName = value; }
        public int StudentID1 { get => studentID; set => studentID = value; }
        public string Level { get => level; set => level = value; }
        public  int SubjectID1 { get => subjectID1; set => subjectID1 = value; }
        public int SubjectID2 { get => subjectID2; set => subjectID2 = value; }
        public int SubjectID3 { get => subjectID3; set => subjectID3 = value; }
        public double SubjectCharge2 { get => subjectCharge2; set => subjectCharge2 = value; }
        public double SubjectCharge3 { get => subjectCharge3; set => subjectCharge3 = value; }
        public double SubjectCharge1 { get => subjectCharge1; set => subjectCharge1 = value; }
        public string SubjectName1 { get => subjectName1; set => subjectName1 = value; }
        public string SubjectName2 { get => subjectName2; set => subjectName2 = value; }
        public string SubjectName3 { get => subjectName3; set => subjectName3 = value; }
        public string StudenIcPass { get => studenIcPass; set => studenIcPass = value; }
        public DateTime PaymentDate { get => paymentDate; set => paymentDate = value; }

        //get set methods

        public ClassReceipt(string username)
        {
            this.username = username;
        }
        public ClassReceipt(int subjectID1 , Double fees , DateTime date,int student_ID ,string month, string level)
        {
            this.subjectID1 = subjectID1;
            this.subjectCharge1 =(double)fees;
            this.paymentDate = date;
            this.studentID = student_ID; 
            this.month= month;
            this.level = level; 
        }

        public  static void ViewPaymentInfo(ClassReceipt obj1)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand($"select Count(*) from Student where username = '{obj1.username}'", con);
            int checkUserName = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            con.Close();
            if (checkUserName == 0) { MessageBox.Show("username is not existed!!!");  return; }
            con.Open(); 

            //gathring the  student  pesronal inforamtion
            SqlCommand cmd1 = new SqlCommand($"select Student_ID ,Name ,ICPassport , Study_Level from student where username = '{obj1.username}'", con);
            SqlDataReader rd = cmd1.ExecuteReader();

            ArrayList studentData = new ArrayList();
            while (rd.Read())
            {
                studentData.Add(rd.GetInt32(0));// student id
                studentData.Add(rd.GetString(1));// student name 
                studentData.Add(rd.GetString(2));// ICPassport 
                studentData.Add(rd.GetString(3));//Study_Level
                

            }
            con.Close();


            //gatther  the  id of the subejcts 
            con.Open();
            SqlCommand cmd2 = new SqlCommand($"select Subject_ID from Student_Subject where Student_ID = {studentData[0]}", con);
            SqlDataReader rd1 = cmd2.ExecuteReader();
            List<int> subjectID = new List<int>(); 
            while (rd1.Read())
            {
                subjectID.Add(rd1.GetInt32(0));
            }
            con.Close();

            //gather subjects name 
            con.Open();
            ArrayList SubjectsName = new ArrayList();

            foreach(int i in subjectID)
            {
                SqlCommand cmd3 = new SqlCommand($"select Subject_Name from Subjects where Subject_ID = {i}", con);
                SubjectsName.Add(cmd3.ExecuteScalar().ToString());
            }

            con.Close();


            //gather subjects Fees  
            con.Open();

            ArrayList SubjectFees = new ArrayList();
            foreach (int i in subjectID)
            {
                
                SqlCommand cmd3 = new SqlCommand($"select Subject_Charges from Schedule where Subject_ID = {i}", con);
                SubjectFees.Add(Convert.ToDouble(cmd3.ExecuteScalar().ToString()));
            } 
            con.Close();
            con.Open();


            obj1.studentID =Convert.ToInt32(studentData[0]);
            obj1.studentName = studentData[1].ToString();
            obj1.studenIcPass= studentData[2].ToString();
            obj1.level = studentData[3].ToString();
            obj1.subjectName1 = SubjectsName[0].ToString();
            obj1.SubjectID1 = subjectID[0]; 
            obj1.subjectCharge1 = Convert.ToDouble(SubjectFees[0]);
            if (SubjectFees.Count > 1)
            { obj1.subjectCharge2 = Convert.ToDouble(SubjectFees[1]); 
              obj1.subjectName2 = SubjectsName[1].ToString();
                obj1.SubjectID2 = subjectID[1];
            }
            if (SubjectFees.Count == 3)
            {
                obj1.subjectCharge3 = Convert.ToDouble(SubjectFees[2]);
                obj1.subjectName3 = SubjectsName[2].ToString();
                obj1.SubjectID3 = subjectID[2];
            }

           
            con.Close();    
          

        }

        public string AddPayment()
        {
            string status = null;

            con.Open();
            //insert the  new payment  data
             SqlCommand cmd1 = new SqlCommand("insert into Receipt (Subject_ID,Fees,Date,Student_ID,Month,Level) values (@Subject_ID,@Fees,@Date, @Student_ID,@Month,@Level)", con);

            cmd1.Parameters.AddWithValue("@Subject_ID", this.subjectID1);
            cmd1.Parameters.AddWithValue("@Fees", this.subjectCharge1);
            cmd1.Parameters.AddWithValue("@Date", this.paymentDate);
            cmd1.Parameters.AddWithValue("@Student_ID", this.studentID);
            cmd1.Parameters.AddWithValue("@Month",this.month);
            cmd1.Parameters.AddWithValue("@Level", this.level);

            int check = cmd1.ExecuteNonQuery(); 
            if(check == 0) { MessageBox.Show("Enable to compelet payment process!!"); }

            //If student have two subjects
            if (this.SubjectID2 != null)
            {
               SqlCommand cmd2 = new SqlCommand("insert into Receipt (Subject_ID,Fees,Date,Student_ID,Month,Level) values (@Subject_ID,@Fees,@Date, @Student_ID,@Month,@Level)", con);

                cmd2.Parameters.AddWithValue("@Subject_ID", this.subjectID2);
                cmd2.Parameters.AddWithValue("@Fees", this.subjectCharge2);
                cmd2.Parameters.AddWithValue("@Date", this.paymentDate);
                cmd2.Parameters.AddWithValue("@Student_ID", this.studentID);
                cmd2.Parameters.AddWithValue("@Month", this.month);
                cmd2.Parameters.AddWithValue("@Level", this.level);
                 check = cmd2.ExecuteNonQuery();
                if (check == 0) { MessageBox.Show("Enable to compelet payment process!!"); }
            } 


            //if ths student has a three subjects
            if(subjectID3 != null)
            {
               SqlCommand cmd3 = new SqlCommand("insert into Receipt(Subject_ID,Fees,Date,Student_ID,Month,Level) values (@Subject_ID,@Fees,@Date, @Student_ID,@Month,@Level)", con);
                cmd3.Parameters.AddWithValue("@Subject_ID", this.subjectID3);
                cmd3.Parameters.AddWithValue("@Fees", this.subjectCharge3);
                cmd3.Parameters.AddWithValue("@Date", this.paymentDate);
                cmd3.Parameters.AddWithValue("@Student_ID", this.studentID);
                cmd3.Parameters.AddWithValue("@Month", this.month);
                cmd3.Parameters.AddWithValue("@Level", this.level);
                check = cmd3.ExecuteNonQuery();
                if (check == 0) { MessageBox.Show("Enable to compelet payment process!!"); }
            }

            con.Close();
            return "payment process completed successfully";
        }
    }





  
}
