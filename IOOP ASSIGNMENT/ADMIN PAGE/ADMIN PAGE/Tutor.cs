using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ADMIN_PAGE
{
    internal class Tutor
    {
        // Member field
        private string Tutor_Name;
        private string Subject_Name1;
        private string Subject_Name2;
        private string Subject_Name3;
        private string Level_of_teaching1;
        private string Level_of_teaching2;
        private string Level_of_teaching3;
        private string User_ID;
        private string Identity_card;
        private DateTime DOB;
        private string gender;
        private string Contact_Num;
        private string Email;
        private string Address;
        private string username;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());

        public string Tutor_Name1 { get => Tutor_Name; set => Tutor_Name = value; }
        public string Subject_Name_1 { get => Subject_Name1; set => Subject_Name1 = value; }
        public string Subject_Name_2 { get => Subject_Name2; set => Subject_Name2 = value; }
        public string Subject_Name_3 { get => Subject_Name3; set => Subject_Name3 = value; }
        public string Level_of_teaching_1 { get => Level_of_teaching1; set => Level_of_teaching1 = value; }
        public string Level_of_teaching_2 { get => Level_of_teaching2; set => Level_of_teaching2 = value; }
        public string Level_of_teaching_3 { get => Level_of_teaching3; set => Level_of_teaching3 = value; }
        public string User_ID1 { get => User_ID; set => User_ID = value; }
        public string Identity_card1 { get => Identity_card; set => Identity_card = value; }
        public DateTime DOB1 { get => DOB; set => DOB = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Contact_Num1 { get => Contact_Num; set => Contact_Num = value; }
        public string Email1 { get => Email; set => Email = value; }
        public string Address1 { get => Address; set => Address = value; }
        public string Username { get => username; set => username = value; }
        public string Tutor_Name2 { get => Tutor_Name; set => Tutor_Name = value; }


        public Tutor(string subject1, string teaching_level1, string name)
        {
            this.Subject_Name1 = subject1;
            this.Level_of_teaching1 = teaching_level1;
            this.Tutor_Name = name;
        }

        public Tutor(string username)
        {
            this.username = username;
        }

        public static void View_Tutor_Details(Tutor obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand($"Select * from Tutor where username = '{obj.Username}'", con);
            
            SqlCommand cmd1 = new SqlCommand($"Select Subject_Name, Level from Teaching_Sub_Level where username = '{obj.Username}'", con);
            con.Close();
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                obj.Tutor_Name = rd.GetString(1);
                obj.DOB = rd.GetDateTime(2);
                obj.gender = rd.GetString(3);
                obj.Contact_Num = rd.GetString(4);
                obj.Email = rd.GetString(5);
                obj.Address = rd.GetString(6);
                obj.Identity_card = rd.GetString(7);
                //obj.username = rd.GetString(9);
            }
            con.Close();
           
            con.Open();
            List<string> subjectsx = new List<string>();
            List<string> levels = new List<string>();
            SqlDataReader rd1 = cmd1.ExecuteReader();
            while (rd1.Read())
            {
                subjectsx.Add(rd1.GetString(0));
                levels.Add(rd1.GetString(1));
            }
           
            obj.Subject_Name1 = subjectsx[0];
            if(subjectsx.Count == 2)
            {

                obj.Subject_Name2 = subjectsx[1];
            }

            if (subjectsx.Count == 3)
            {

                obj.Subject_Name2 = subjectsx[1];
                obj.Subject_Name3 = subjectsx[2];
            }
            obj.Level_of_teaching_1 = levels[0];

            if (levels.Count == 2)
            {

                obj.Level_of_teaching_2 = levels[1];
            }

            if (levels.Count == 3)
            {

                obj.Level_of_teaching_2 = levels[1];
                obj.Level_of_teaching_3 = levels[2];


            }
            con.Close();
        }
    
        public static void Update_Profile(Tutor obj,string username2)
        {
            string status;
            con.Open();
            SqlCommand cmd = new SqlCommand($"Update Tutor set Name = '{obj.Tutor_Name}', DOB = '{obj.DOB}', Gender = '{obj.Gender}', " +
                $"Contact_Num = '{obj.Contact_Num}', Email = '{obj.Email}', Address = '{obj.Address}', ICPassport = '{obj.Identity_card}'," +
                $" Username = '{obj.username}' where Username = '{username2}'", con);
            SqlCommand cmd2 = new SqlCommand($"Update Login set username= '{obj.username}' where username = '{username2}'", con);// the new  username  enterd by the user
            SqlCommand cmd3 = new SqlCommand($"Select count(*) from Login where username = '{obj.username}' and  username != '{username2}' ", con);

            
            int i = Convert.ToInt32(cmd3.ExecuteNonQuery().ToString());
            if(i == -1 )
            {
                
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();


                SqlCommand cmd4 = new SqlCommand($"Select Tutor_Subject_ID from Teaching_Sub_Level where username = '{obj.username}'", con);
                con.Close();
                con.Open();
                List<int> subjects = new List<int>();
                SqlDataReader rd = cmd4.ExecuteReader();
                while (rd.Read())
                {
                    subjects.Add(rd.GetInt32(0));
                }
                con.Close();

                con.Open();


                SqlCommand cmd5 = new SqlCommand($"Update Teaching_Sub_Level set Level = '{obj.Level_of_teaching1}', Subject_Name = '{obj.Subject_Name1}' " +
                    $"where Tutor_Subject_ID = '{subjects[0]}'", con);
                cmd5.ExecuteNonQuery();

                if (subjects.Count == -1 || obj.username == username2)
                {
                  
                    SqlCommand cmd6 = new SqlCommand($"Update Teaching_Sub_Level set Level = '{obj.Level_of_teaching2}', Subject_Name = '{obj.Subject_Name2}' " +
                        $"where Tutor_Subject_ID = '{subjects[1]}'", con);
                    cmd6.ExecuteNonQuery();
                }
                if (subjects.Count == 2)
                {
                    SqlCommand cmd6 = new SqlCommand($"Update Teaching_Sub_Level set Level = '{obj.Level_of_teaching2}', Subject_Name = '{obj.Subject_Name2}' " +
                        $"where Tutor_Subject_ID = '{subjects[1]}'", con);
                    SqlCommand cmd7 = new SqlCommand($"Update Teaching_Sub_Level set Level = '{obj.Level_of_teaching3}', Subject_Name = '{obj.Subject_Name3}' " +
                        $"where Tutor_Subject_ID = '{subjects[2]}'", con);
                    cmd6.ExecuteNonQuery();
                    cmd7.ExecuteNonQuery();
                }

            }
            else
            {

                MessageBox.Show("Duplicated username!");
            }

            // this is beacuse  if the user not change the  user name  the counter will be on so wil not allowed the  user to update other inforamtion
            con.Close();
            MessageBox.Show("Update process completed!");
        }
    }
}