using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace ADMIN_PAGE
{
    internal class StudentOnly
    {
        private string Studentid;
        private string name;
        private string ic_passport;
        private DateTime dob;
        private string studylevel;
        private string contactnum;
        private string email;
        private string gender;
        private string address;
        private string username;
        private string password;
        private string Enrollment_Month;

        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());

        public string Studentid1 { get => Studentid; set => Studentid = value; }
        public string Name { get => name; set => name = value; }
        public string Ic_passport { get => ic_passport; set => ic_passport = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string Studylevel { get => studylevel; set => studylevel = value; }
        public string Contactnum { get => contactnum; set => contactnum = value; }
        public string Email { get => email; set => email = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Address { get => address; set => address = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Enrollment_Month1 { get => Enrollment_Month; set => Enrollment_Month = value; }


        public StudentOnly(string name, string ic_passport, DateTime dob, string studylevel, string contactnum, string email, string gender, string address, string username, string password, string Enrollment_Month)
        {
            this.Name = name;
            this.Ic_passport = ic_passport;
            this.Dob = dob;
            this.Studylevel = studylevel;
            this.Contactnum = contactnum;
            this.Email = email;
            this.Gender = gender;
            this.Address = address;
            this.Username = username;
            this.Password = password;
            this.Enrollment_Month1 = Enrollment_Month;
          
        }

        public StudentOnly()
        {

        }

        public StudentOnly(string username)
        {
            this.Username = username;
        }

        public static void viewSchedule(DataGridView gf, string username)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand($"Select Student_ID from Student where Username  = '{username}'", con);
            int studentid = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            SqlDataAdapter cmd1 = new SqlDataAdapter($"select Schedule.Subject_Name, Tutor_Name, Schedule.Level, Duration, Start_Time, End_Time, Day, Venue from Schedule " +
                $"inner join Subjects on Schedule.Subject_ID = Subjects.Subject_ID " +
                $"inner join Student_Subject on Student_Subject.Subject_ID = Subjects.Subject_ID where Schedule.Username = '{username}'", con);
            DataTable dt1 = new DataTable();
            cmd1.Fill(dt1);
            gf.DataSource = dt1;
            con.Close();
        }

        public static void viewProfile(StudentOnly obj)
        {
            con.Open(); SqlCommand cmd = new SqlCommand($"Select * from Student where username = '{obj.Username}'", con);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                obj.name = rd.GetString(1);
                obj.dob = rd.GetDateTime(2);
                obj.gender = rd.GetString(3);
                obj.studylevel = rd.GetString(4); 
                obj.contactnum = rd.GetString(5);
                obj.email = rd.GetString(6);
                obj.address = rd.GetString(7);
                obj.Enrollment_Month = rd.GetString(8);
                obj.ic_passport = rd.GetString(9);

            }

            con.Close();

        }
        public string updateProfile(string name, string ic_passport, DateTime dob, string studylevel, string contactnum, string email, string gender, string address, string Enrollment_Month)
        {
            string status = null;
            con.Open();

            SqlCommand updatecmd = new SqlCommand($"Update Student set Name = '{name}',DOB = '{dob}', Study_Level = '{studylevel}', Contact_Num = '{contactnum}',Email = '{email}', Address = '{address}', Enrollment_Month= '{Enrollment_Month}', ICPassport = '{ic_passport}' where Username = '{this.username}'", con);
            
            int verifyUpdate = updatecmd.ExecuteNonQuery();
            if (verifyUpdate != 0)
            {
                status = "Update Successfully";
            }
            else
            {
                status = "Unable to update";
            }
            con.Close();
            return status;
        }


    }
}
