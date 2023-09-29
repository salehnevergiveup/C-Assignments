using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN_PAGE
{
    internal class Student
    {
        // Member field
        private string Student_Name;
        private string Student_ID;
        private string Level;
        private string Gender;
        private DateTime DOB;
        private string Contact_Num;
        private string Email;
        private string Address;
        private string username;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());

        public string Student_Name1 { get => Student_Name; set => Student_Name = value; }
        public string Student_ID1 { get => Student_ID; set => Student_ID = value; }
        public string Level1 { get => Level; set => Level = value; }
        public string Gender1 { get => Gender; set => Gender = value; }
        public DateTime DOB1 { get => DOB; set => DOB = value; }
        public string Contact_Num1 { get => Contact_Num; set => Contact_Num = value; }
        public string Email1 { get => Email; set => Email = value; }
        public string Address1 { get => Address; set => Address = value; }
        public string Username { get => username; set => username = value; }

        public Student(string Student_Name, string Student_ID, string Level, string Gender, 
            DateTime DOB, string Contact_Num, string Email, string Address, string username)
        {
            this.Student_Name = Student_Name;
            this.Student_ID = Student_ID;
            this.Level = Level;
            this.Gender = Gender;
            this.DOB = DOB;
            this.Contact_Num = Contact_Num;
            this.Email = Email;
            this.Address = Address;
            this.username = username;
        }

        public Student(string username)
        {
            this.username = username;
        }

        public Student(string Student_Name, string Gender, string username)
        {
            this.Student_Name = Student_Name;
            this.Gender = Gender;
            this.username = username;
        }

        public static void ViewStudentInfo(DataGridView gd, string level = "" , string subject = "")
        {
            //$"join  Subjects on  Subjects.Subject_ID =  Student.Student_ID .Subject_ID "
            con.Open();//Student  Student_Subject  Subjects  Subject_ID Subject_Name Student_ID Subject_Name

            if (level == "" && subject == "")
            {
                SqlDataAdapter cmd = new SqlDataAdapter($"SELECT Subject_Name , Student.Name,Username, Study_Level, Gender, DOB, Contact_Num, Email, Address from Student " +
                                                         $"JOIN Student_Subject on Student_Subject.Student_ID = Student.Student_ID " +
                                                         $"JOIN Subjects on Subjects.Subject_ID = Student_Subject.Subject_ID", con);
                DataTable dt1 = new DataTable();
                cmd.Fill(dt1);
                gd.DataSource = dt1;
            }
            else if(level== "" && subject != "" )
            {
                SqlDataAdapter cmd = new SqlDataAdapter($"SELECT Subject_Name , Student.Name,Username, Study_Level, Gender, DOB, Contact_Num, Email, Address from Student " +
                                                         $"JOIN Student_Subject on Student_Subject.Student_ID = Student.Student_ID " +
                                                         $"JOIN Subjects on Subjects.Subject_ID = Student_Subject.Subject_ID where Study_level = '{level}'", con);
                DataTable dt1 = new DataTable();
                cmd.Fill(dt1);
                gd.DataSource = dt1;
            }
            else if (level != "" && subject == "")
            {
                SqlDataAdapter cmd = new SqlDataAdapter($"SELECT Subject_Name , Student.Name,Username, Study_Level, Gender, DOB, Contact_Num, Email, Address from Student " +
                                                         $"JOIN Student_Subject on Student_Subject.Student_ID = Student.Student_ID " +
                                                         $"JOIN Subjects on Subjects.Subject_ID = Student_Subject.Subject_ID where subject_name =  '{subject}'", con);
                DataTable dt1 = new DataTable();
                cmd.Fill(dt1);
                gd.DataSource = dt1;
            }
            else
            {
                SqlDataAdapter cmd = new SqlDataAdapter($"SELECT Subject_Name , Student.Name,Username, Study_Level, Gender, DOB, Contact_Num, Email, Address from Student " +
                                                         $"JOIN Student_Subject on Student_Subject.Student_ID = Student.Student_ID " +
                                                         $"JOIN Subjects on Subjects.Subject_ID = Student_Subject.Subject_ID where study_level = '{level}' and subject_name ='{subject}'", con);
                DataTable dt1 = new DataTable();
                cmd.Fill(dt1);
                gd.DataSource = dt1;
            }
          
            con.Close();

        }
    }
}
