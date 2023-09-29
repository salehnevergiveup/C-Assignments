using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ADMIN_PAGE
{
   internal class Recep_Student
    {
        private string Name;
        private  int   studentID1;
        private string studentID; 
        private string ContactNumber;
        private string Email;
        private string level; 
        private DateTime DOB; 
        private string Address;
        private string username;
        private string gender;
        private string subject1; 
        private string subject2;
        private string subject3;
        private string Enrollment_Month;
       private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
        public string Subject2 { get => subject2; set => subject2 = value; }
        public string Subject3 { get => subject3; set => subject3 = value; }
        public string Gender { get => gender; set => gender = value; }
        public string ContactNumber1 { get => ContactNumber; set => ContactNumber = value; }
        public string Email1 { get => Email; set => Email = value; }
        public string Address1 { get => Address; set => Address = value; }
        public DateTime DOB1 { get => DOB; set => DOB = value; }
        public string Subject1 { get => subject1; set => subject1 = value; }
        public string StudentID { get => studentID; set => studentID = value; }
        public string Name1 { get => Name; set => Name = value; }
        public int StudentID1 { get => studentID1; set => studentID1 = value; }

        public Recep_Student(string name,string level, string subject1, string studentID,string Enrollment_Month)
        {
            this.Name = name;
            this.level = level;
            this.subject1 = subject1;
            this.studentID =studentID;
            this.Enrollment_Month = Enrollment_Month;
        } 
        public Recep_Student(string username)
        {
            this.username = username;

        }

       public Recep_Student(string username , string name)
        {
            this.username = username;
            this.Name = name;
        }
        public string AddStudent()
        {
            con.Open();
            //Genret username 
            string newUserName = null; 
            while (true) {
                Random rnd = new Random();
                int userRand = rnd.Next();
               newUserName = "Student" + userRand;
                SqlCommand cmd = new SqlCommand($"select Count(*) from Login where username = '{newUserName}'", con);
                int checkUserName = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                if (checkUserName == 0 ) break; 
                                     }

           // (txtbox as TextBox).Text = newUserName;

            //inser new data to the  login inforamtion 
            SqlCommand cmd1 = new SqlCommand("insert into Login(Username,password,role) values  (@username,12345678,'student')", con);

            cmd1.Parameters.AddWithValue("@username", newUserName);
           
            // add new student  lofin details 
            int check = cmd1.ExecuteNonQuery();
            if (check == 0) return "unable to register";




            //Name DOB Gender Study_Level Contact_Num Email Address Enrollment_Month ICPassport Username ,DOB ,,@dob

//            SqlCommand cmd2 = new SqlCommand("insert into Student (Name,Gender,Study_Level,Contact_Num,Email,Address,Enrollment_Month,ICPassport,Username) values (@Name,@gender,@Study_Level,@num,@email,@address,@Enrollment_Month,@ICPassport,@username)", con);


            SqlCommand cmd2 = new SqlCommand("insert into Student(Name,DOB,Gender,Study_Level,Contact_Num,Email,Address,Enrollment_Month,ICPassport,Username)values(@Name,@dob,@gender, @Study_Level,@num,@email,@address,@Enrollment_Month,@ICPassport,@username)", con);

            cmd2.Parameters.AddWithValue("@Name", this.Name);
            cmd2.Parameters.AddWithValue("@dob", this.DOB);
            cmd2.Parameters.AddWithValue("@gender", this.gender);
            cmd2.Parameters.AddWithValue("@Enrollment_Month", this.Enrollment_Month);
            cmd2.Parameters.AddWithValue("@Study_Level", this.level);
            cmd2.Parameters.AddWithValue("@num", this.ContactNumber);
            cmd2.Parameters.AddWithValue("@email", this.Email);
            cmd2.Parameters.AddWithValue("@address",this.Address);
            cmd2.Parameters.AddWithValue("@ICPassport", this.studentID);
            cmd2.Parameters.AddWithValue("@username", newUserName);

            //insert stdent  info into student  tabel 
            cmd2.ExecuteNonQuery();
            if (check == 0) return "unable to register";

            //Get the  id of the subjects and student 
            SqlCommand cmd3 = new SqlCommand($"select Student_ID from Student where username = '{newUserName}'", con);
            SqlCommand cmd4= new SqlCommand($"select Subject_ID from Subjects where Subject_Name = '{this.subject1}'", con);
            SqlCommand cmd5 = new SqlCommand($"select Subject_ID from Subjects where Subject_Name = '{this.subject2}'", con);
            SqlCommand cmd6 = new SqlCommand($"select Subject_ID from Subjects where Subject_Name = '{this.Subject3}'", con);


            int subID1, subID2 ,subID3, stuID;
           




            /// storing the  Ids of the  subjects and the student.
            stuID = Convert.ToInt32(cmd3.ExecuteScalar()); 
            subID1= Convert.ToInt32(cmd4.ExecuteScalar().ToString());
           



            // strore the  first subject 
            SqlCommand cmd7 = new SqlCommand("insert into Student_Subject(Subject_ID,Student_ID) values  (@SubjectID,@Student_ID) ", con);
           cmd7.Parameters.AddWithValue("@Student_ID", stuID);
           cmd7.Parameters.AddWithValue("@SubjectID", subID1);
            check = cmd7.ExecuteNonQuery();
            if (check == 0) return "unable to register";



            
            if (this.Subject2 != "Empty" && this.Subject2 != null)
            {
                subID2 = Convert.ToInt32(cmd5.ExecuteScalar().ToString());
                // strore the  Second subject
                SqlCommand cmd8 = new SqlCommand("insert into Student_Subject(Subject_ID,Student_ID) values  (@Subject_ID,@Student_ID) ", con);
                cmd8.Parameters.AddWithValue("@Student_ID", stuID);
                cmd8.Parameters.AddWithValue("@Subject_ID", subID2);
                check = cmd8.ExecuteNonQuery();
                if (check == 0) return "unable to register";

            }
            if (this.Subject3 != "Empty" && this.Subject3 != null)
            {
                MessageBox.Show(this.subject3);
                subID3 = Convert.ToInt32(cmd6.ExecuteScalar().ToString());

                // strore the thired subject 
                SqlCommand cmd9 = new SqlCommand("insert into Student_Subject(Subject_ID,Student_ID) values  (@Student_Subject,@Student_ID) ", con);
                cmd9.Parameters.AddWithValue("@Student_ID", stuID);
                cmd9.Parameters.AddWithValue("@Student_Subject", subID3);
                check = cmd9.ExecuteNonQuery();
                if (check == 0) return "unable to register";
            }
          



            MessageBox.Show("Done yehhho!!!!");
            con.Close();
           return "register successfully"; 
        }

  
        public static  List<DataTable>  ViewStudentInfo()
        {
                con.Open();
                SqlDataAdapter cmd = new SqlDataAdapter($"select Name,Username ,DOB,Gender ,Study_Level,Contact_Num,Email,Enrollment_Month from Student", con);
                 con.Close();
                 con.Open();
            SqlDataAdapter cmd1 = new SqlDataAdapter("select Name,Username,Study_Level, Subject_Name from Student " +
                                                         "JOIN Student_Subject on Student_Subject.Student_ID = Student.Student_ID" +
                                                         " Join Subjects on Subjects.Subject_ID = Student_Subject.Subject_ID", con);
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                cmd.Fill(dt1);
                cmd1.Fill(dt2);
                con.Close();
            List<DataTable> datagraid = new List<DataTable>();
            datagraid.Add(dt1); 
            datagraid.Add(dt2);
            return  datagraid;
        }


        public string deletStudent()
        {
            con.Open();
            //extract the  student_ID values
            SqlCommand cmd = new SqlCommand($"select Student_ID from student where USERNAME =  '{this.username}'", con);
            int StudentID = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (StudentID == 0) return $"Sorry Failed to delete {this.Name}";
            List<string> tablesName = new List<string>();
            tablesName.Add("Receipt");
            tablesName.Add("Request");
            tablesName.Add("Student_Subject");
            tablesName.Add("student");
            foreach (string str in tablesName)
            {
                SqlCommand Cmd1 = new SqlCommand($"Select count(*) from {str} where Student_ID = {StudentID}", con);
                int check = Convert.ToInt32(Cmd1.ExecuteScalar().ToString());
                if (check == 0) continue;

                SqlCommand cmd2 = new SqlCommand($"Delete {str} where Student_ID = {StudentID}", con);
                   check = cmd2.ExecuteNonQuery();
                if (check == -1) return $"Sorry Failed to delete {this.Name}";
            }
            SqlCommand cmd3 = new SqlCommand($"Delete from Login where username = '{this.username}'", con);
            int checker = cmd3.ExecuteNonQuery();
            if (checker == -1) return $"Sorry Failed to delete {this.Name}";

            return $"{this.Name},Deleted successfully from the  system";
        }


        public static void viewstudentSubjectDetiles(Recep_Student obj)
        {
            con.Open();
            SqlCommand Cmd = new SqlCommand($"Select Student_ID  from student where username= '{obj.username}'", con);
            int studentIDID = Convert.ToInt32(Cmd.ExecuteScalar().ToString());

            //fetch data from the  student  table
            SqlCommand Cmd1 = new SqlCommand($"Select Student.Name  from student where username = '{obj.username}'", con);
            SqlCommand Cmd2 = new SqlCommand($"Select ICPassport from student where username = '{obj.username}'", con);
            
            string studname = Cmd1.ExecuteScalar().ToString();
            string studIcPass = Cmd2.ExecuteScalar().ToString();

            //fetch subjects data form the  sujects tabel
            SqlCommand Cmd3 = new SqlCommand($"select  subjects.Subject_Name from Subjects " +
                                             $"join Student_Subject on subjects.Subject_ID = Student_Subject.Subject_ID " +
                                             $"where Student_Subject.Student_ID = {studentIDID}", con);
             
           

            con.Close();

            con.Open();
            List<string> subjs = new List<string>();
            SqlDataReader  rd = Cmd3.ExecuteReader(); 
            while(rd.Read())
            {
                subjs.Add(rd.GetString(0)); 

            }
            con.Close();

            obj.Name = studname;
            obj.studentID1 = studentIDID;
            obj.studentID = studIcPass;
            obj.Subject1 = subjs[0]; 
            if(subjs.Count == 2 )
            {
                obj.Subject2 = subjs[1];
            }
            if(subjs.Count ==3)
            {
                obj.Subject2 = subjs[1];
                obj.subject2= subjs[2]; 

            }

        }


        public static string updateSubjects(int studentID , List<string> subjectList)
        {
            con.Open();
            //festch the  subjects Ids
            int counter = 0;
            List <string> subjectListID = new List<string>();
            foreach(string i in subjectList)
            {
                SqlCommand cmd = new SqlCommand($"Select Subject_ID from subjects where Subject_Name = '{i}'", con);
                subjectListID.Add(cmd.ExecuteScalar().ToString());
            }
            SqlCommand cmd1 = new SqlCommand($"Update Student_Subject set Subject_ID = '{Convert.ToInt32(subjectListID[0])}'  where Student_ID = '{studentID}'", con);
             int checker = cmd1.ExecuteNonQuery();
            if(checker <= 0) { return "processo filled!!!";} 

            if(subjectListID.Count == 2)
            {
                SqlCommand cmd2 = new SqlCommand($"Update Student_Subject set Subject_ID = '{Convert.ToInt32(subjectListID[1])}'  where Student_ID = '{studentID}'", con);
                checker = cmd2.ExecuteNonQuery();
                if (checker <= 0) { return "processo filled!!!"; }
            }
            if(subjectListID.Count == 3)
            {
                SqlCommand cmd2 = new SqlCommand($"Update Student_Subject set Subject_ID = '{Convert.ToInt32(subjectListID[1])}'  where Student_ID = '{studentID}'", con);
                checker = cmd2.ExecuteNonQuery();
                if (checker <= 0) { return "processo filled!!!"; }
                SqlCommand cmd3 = new SqlCommand($"Update Student_Subject set Subject_ID = '{Convert.ToInt32(subjectListID[2])}'  where Student_ID = '{studentID}'", con);
                checker = cmd3.ExecuteNonQuery();
                if (checker <= 0) { return "processo filled!!!"; }
            }
            con.Close();
            return "process completed successfully";
        }

    }
}


