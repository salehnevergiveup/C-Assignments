using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Security.Cryptography;
using System.Data;
using System.Windows.Forms;
using System.Reflection;

namespace ADMIN_PAGE
{
    internal class ClassTutor
    {
        private string id;
        private string name;
        private string ic_passport;
        private DateTime dob;
        private string contactnum;
        private string email;
        private string gender;
        private string address;
        private string username;
        private string password;
        private string subject1;
        private string subject2;
        private string subject3;
        private string teaching_level1;
        private string teaching_level2;
        private string teaching_level3;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Ic_passport { get => ic_passport; set => ic_passport = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string Contactnum { get => contactnum; set => contactnum = value; }
        public string Email { get => email; set => email = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Address { get => address; set => address = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Subject2 { get => subject2; set => subject2 = value; }
        public string Subject3 { get => subject3; set => subject3 = value; }
        public string Subject1 { get => subject1; set => subject1 = value; }
        public string Teaching_level1 { get => teaching_level1; set => teaching_level1 = value; }
        public string Teaching_level2 { get => teaching_level2; set => teaching_level2 = value; }
        public string Teaching_level3 { get => teaching_level3; set => teaching_level3 = value; }

        public ClassTutor(string name, string ic_passport, DateTime dob, string contactnum, string email, string gender, string address, string username, string password)
        {
            this.Name = name;
            this.Ic_passport = ic_passport;
            this.Dob = dob;
            this.Contactnum = contactnum;
            this.Email = email;
            this.Gender = gender;
            this.Address = address;
            this.Username = username;
            this.Password = password;
        }

        public ClassTutor(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public ClassTutor()
        {

        }

        public ClassTutor(string subject1, string teaching_level1, string name)
        {
            this.Subject1 = subject1;
            this.Teaching_level1 = teaching_level1;
            this.Name = name;
        }

        public string addtutor()
        {
            string status;
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Login(Username,Password,Role)values(@username,123,@role)", con);
            SqlCommand cmd2 = new SqlCommand("insert into Tutor(Name,DOB,Gender,Contact_Num,Email,Address,ICPassport,Username)values(@Name,@dob,@gender,@num,@email,@address,@ICPassport,@username)", con);
            SqlCommand cmd3 = new SqlCommand("select count(*) from Login where Username = @username", con);
            SqlCommand cmd4 = new SqlCommand($"select count(*) from Tutor where Username = @username", con);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("123", password);
            cmd.Parameters.AddWithValue("@role", "Tutor");
            cmd2.Parameters.AddWithValue("@Name", Name);
            cmd2.Parameters.AddWithValue("@dob", dob);
            cmd2.Parameters.AddWithValue("@gender", gender);
            cmd2.Parameters.AddWithValue("@num", contactnum);
            cmd2.Parameters.AddWithValue("@email", email);
            cmd2.Parameters.AddWithValue("@address", address);
            cmd2.Parameters.AddWithValue("@ICPassport", ic_passport);
            cmd2.Parameters.AddWithValue("@username", username);
            cmd3.Parameters.AddWithValue("@username", username);
            cmd4.Parameters.AddWithValue("@username", username);

            int countCmd3 = Convert.ToInt32(cmd3.ExecuteScalar());
            int countCmd4 = Convert.ToInt32(cmd4.ExecuteScalar());

            if (countCmd3 > 0 || countCmd4 > 0)
            {
                status = "Duplicated Username";
            }
            else
            {
                cmd2.ExecuteNonQuery();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    status = "register successfully";
                }
                else
                {
                    status = "unable to register";
                }
            }
            con.Close();
            return status;

        }

        public string addsubject1(string bj)
        {
            //add subject 1 in teaching_sub_level table
            string status = null;
            con.Open();
            SqlCommand cmd0 = new SqlCommand($"Select Username from Tutor where Name = '{bj}'", con);
            string lk = cmd0.ExecuteScalar().ToString();
            SqlCommand cmd = new SqlCommand("insert into Teaching_Sub_Level(Tutor_Name,Subject_Name,Level,Username)values(@name,@Subjectname,@level,@username)", con);
            SqlCommand cmd1 = new SqlCommand($"select count(*) from Teaching_Sub_Level where Tutor_Name = @tutorname", con);
            SqlCommand cmd2 = new SqlCommand($"select count(*) from Teaching_Sub_Level where Subject_Name = @Subjectname and Tutor_Name = @tutorname and Level = @level", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@Subjectname", subject1);
            cmd.Parameters.AddWithValue("@level", teaching_level1);
            cmd.Parameters.AddWithValue("@username", lk);
            cmd1.Parameters.AddWithValue($"@tutorname", name);
            cmd2.Parameters.AddWithValue($"@tutorname", name);
            cmd2.Parameters.AddWithValue($"@Subjectname", subject1);
            cmd2.Parameters.AddWithValue($"@level", teaching_level1);

            int count_cmd1 = Convert.ToInt32(cmd1.ExecuteScalar());
            int count_cmd2 = Convert.ToInt32(cmd2.ExecuteScalar());

            if (count_cmd1 < 3)
            {
                if (count_cmd2 == 1)
                {
                    status = "subject 1 recorded existed";
                    con.Close();
                    return status;
                }
                else if (count_cmd2 == 0)
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        status = "Subject1 Added Successfully";
                        con.Close();
                        return status;
                    }
                    else
                    {
                        status = "Unable to update";
                        con.Close();
                        return status;
                    }
                }
            }
            else if (count_cmd1 > 2)
            {
                status = "already reach maximum subject per tutor\n read the red word";

            }
            con.Close();
            return status;
        }

        public string addsubject2(string bj)
        {
            string status = null;
            con.Open();
            SqlCommand cmd0 = new SqlCommand($"Select Username from Tutor where Name = '{bj}'", con);
            string lk = cmd0.ExecuteScalar().ToString();
            SqlCommand cmd = new SqlCommand("insert into Teaching_Sub_Level(Tutor_Name,Subject_Name,Level,Username)values(@name,@Subjectname,@level,@username)", con);
            SqlCommand cmd1 = new SqlCommand($"select count(*) from Teaching_Sub_Level where Tutor_Name = @tutorname", con);
            SqlCommand cmd2 = new SqlCommand($"select count(*) from Teaching_Sub_Level where Subject_Name = @Subjectname and Tutor_Name = @tutorname and Level = @level", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@Subjectname", subject1);
            cmd.Parameters.AddWithValue("@level", teaching_level1);
            cmd.Parameters.AddWithValue("@username", lk);
            cmd1.Parameters.AddWithValue($"@tutorname", name);
            cmd2.Parameters.AddWithValue($"@tutorname", name);
            cmd2.Parameters.AddWithValue($"@Subjectname", subject1);
            cmd2.Parameters.AddWithValue($"@level", teaching_level1);

            int count_cmd1 = Convert.ToInt32(cmd1.ExecuteScalar());
            int count_cmd2 = Convert.ToInt32(cmd2.ExecuteScalar());

            if (count_cmd1 < 3)
            {
                if (count_cmd2 == 1)
                {
                    status = "subject 2 recorded existed";
                    con.Close();
                    return status;
                }
                else if (count_cmd2 == 0)
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        status = "Subject2 Added Successfully";
                        con.Close();
                        return status;
                    }
                    else
                    {
                        status = "Unable to update";
                        con.Close();
                        return status;
                    }
                }
            }
            else if (count_cmd1 > 2)
            {
                status = "already reach maximum subject per tutor\n read the red word";

            }
            con.Close();
            return status;
        }

        public string addsubject3(string bj)
        {
            string status = null;
            con.Open();
            SqlCommand cmd0 = new SqlCommand($"Select Username from Tutor where Name = '{bj}'", con);
            string lk = cmd0.ExecuteScalar().ToString();
            SqlCommand cmd = new SqlCommand("insert into Teaching_Sub_Level(Tutor_Name,Subject_Name,Level,Username)values(@name,@Subjectname,@level,@username)", con);
            SqlCommand cmd1 = new SqlCommand($"select count(*) from Teaching_Sub_Level where Tutor_Name = @tutorname", con);
            SqlCommand cmd2 = new SqlCommand($"select count(*) from Teaching_Sub_Level where Subject_Name = @Subjectname and Tutor_Name = @tutorname and Level = @level", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@Subjectname", subject1);
            cmd.Parameters.AddWithValue("@level", teaching_level1);
            cmd.Parameters.AddWithValue("@username", lk);
            cmd1.Parameters.AddWithValue($"@tutorname", name);
            cmd2.Parameters.AddWithValue($"@tutorname", name);
            cmd2.Parameters.AddWithValue($"@Subjectname", subject1);
            cmd2.Parameters.AddWithValue($"@level", teaching_level1);

            int count_cmd1 = Convert.ToInt32(cmd1.ExecuteScalar());
            int count_cmd2 = Convert.ToInt32(cmd2.ExecuteScalar());

            if (count_cmd1 < 3)
            {
                if (count_cmd2 == 1)
                {
                    status = "subject 3 recorded existed";
                    con.Close();
                    return status;
                }
                else if (count_cmd2 == 0)
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        status = "Subject3 Added Successfully";
                        con.Close();
                        return status;
                    }
                    else
                    {
                        status = "Unable to update";
                        con.Close();
                        return status;
                    }
                }
            }
            else if (count_cmd1 > 2)
            {
                status = "already reach maximum subject per tutor\n read the red word";

            }
            con.Close();
            return status;
        }



        public static ArrayList viewtutor()
        {
            // to display data on listbox
            ArrayList tutor = new ArrayList();
            con.Open();
            SqlCommand cmd = new SqlCommand("select Name from Tutor", con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                tutor.Add(rd.GetString(0));
            }
            con.Close();
            return tutor;
        }

        public static ArrayList viewSubject()
        {
            ArrayList subjects = new ArrayList();
            con.Open();
            SqlCommand cmd = new SqlCommand("select Subject_Name from Subjects", con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                subjects.Add(rd.GetString(0));
            }
            con.Close();
            return subjects;
        }
        public void viewdsearch(DataGridView gf,string df)
        {
            con.Open();
            List<int> sub = new List<int>();
            SqlCommand cmdR = new SqlCommand($"Select Username from Tutor where Name  = '{df}'", con);
            string lk = cmdR.ExecuteScalar().ToString();
            con.Close();
            con.Open();
            SqlCommand cmdt = new SqlCommand($"Select Tutor_Subject_ID from Teaching_Sub_Level where Username  = '{lk}'", con);
            SqlDataReader rd = cmdt.ExecuteReader();
            while (rd.Read())
            {
                sub.Add(rd.GetInt32(0));
            }
            con.Close();
            if (sub.Count > 2)
            {
                con.Open();
                SqlCommand cmd0 = new SqlCommand($"Select Subject_Name from Teaching_Sub_Level where Tutor_Subject_ID = '{sub[0]}'", con);
                SqlCommand cmd2 = new SqlCommand($"Select Level from Teaching_Sub_Level where Tutor_Subject_ID = '{sub[0]}'", con);
                SqlCommand cmd3 = new SqlCommand($"Select  Subject_Name from Teaching_Sub_Level where Tutor_Subject_ID = '{sub[1]}'", con);
                SqlCommand cmd4 = new SqlCommand($"Select  Level from Teaching_Sub_Level where Tutor_Subject_ID = '{sub[1]}'", con);
                SqlCommand cmd5 = new SqlCommand($"Select  Subject_Name from Teaching_Sub_Level where Tutor_Subject_ID = '{sub[2]}'", con);
                SqlCommand cmd6 = new SqlCommand($"Select  Level from Teaching_Sub_Level where Tutor_Subject_ID = '{sub[2]}'", con);
                string aa = cmd0.ExecuteScalar().ToString();
                string bb = cmd2.ExecuteScalar().ToString();
                string cc = cmd3.ExecuteScalar().ToString();
                string dd = cmd4.ExecuteScalar().ToString();
                string ee = cmd5.ExecuteScalar().ToString();
                string ff = cmd6.ExecuteScalar().ToString();

                //string bb = cmd1.ExecuteScalar().ToString();
                SqlDataAdapter cmd = new SqlDataAdapter($"Select TOP 1 '{aa}' as Subject1,'{bb}' as SubjectLevel1,'{cc}' as Subject2,'{dd}' as SubjectLevel2,'{ee}' as Subject3,'{ff}' as SubjectLevel3 from Tutor inner join Teaching_Sub_level on Tutor.Username = Teaching_Sub_level.Username where Tutor_Name = '{df}'", con);
                DataTable dt = new DataTable();
                cmd.Fill(dt);

                gf.DataSource = dt;
                con.Close();
            }
            else if (sub.Count == 1)
            {
                con.Open();
                SqlCommand cmd7 = new SqlCommand($"Select Subject_Name from Teaching_Sub_Level where Tutor_Subject_ID = '{sub[0]}'", con);
                SqlCommand cmd8 = new SqlCommand($"Select Level from Teaching_Sub_Level where Tutor_Subject_ID = '{sub[0]}'", con);
                
                string gg = cmd7.ExecuteScalar().ToString();
                string hh = cmd8.ExecuteScalar().ToString();
                SqlDataAdapter cmd11 = new SqlDataAdapter($"Select TOP 1 '{gg}' as Subject1,'{hh}' as SubjectLevel1 from Tutor inner join Teaching_Sub_level on Tutor.Username = Teaching_Sub_level.Username where Tutor_Name = '{df}'", con);
                DataTable dt1 = new DataTable();
                cmd11.Fill(dt1);
                
                gf.DataSource = dt1;
                con.Close();
            }
            else if (sub.Count == 2)
            {
                con.Open();
                SqlCommand cmd7 = new SqlCommand($"Select Subject_Name from Teaching_Sub_Level where Tutor_Subject_ID = '{sub[0]}'", con);
                SqlCommand cmd8 = new SqlCommand($"Select Level from Teaching_Sub_Level where Tutor_Subject_ID = '{sub[0]}'", con);
                SqlCommand cmd9 = new SqlCommand($"Select  Subject_Name from Teaching_Sub_Level where Tutor_Subject_ID = '{sub[1]}'", con);
                SqlCommand cmd10 = new SqlCommand($"Select  Level from Teaching_Sub_Level where Tutor_Subject_ID = '{sub[1]}'", con);
                
                string gg = cmd7.ExecuteScalar().ToString();
                string hh = cmd8.ExecuteScalar().ToString();
                string ii = cmd9.ExecuteScalar().ToString();
                string jj = cmd10.ExecuteScalar().ToString();

                
                SqlDataAdapter cmd11 = new SqlDataAdapter($"Select TOP 1 '{gg}' as Subject1,'{hh}' as SubjectLevel1,'{ii}' as Subject2,'{jj}' as SubjectLevel2 from Tutor inner join Teaching_Sub_level on Tutor.Username = Teaching_Sub_level.Username where Tutor_Name = '{df}'", con);
                DataTable dt1 = new DataTable();
                cmd11.Fill(dt1);

                gf.DataSource = dt1;
                con.Close();
            }
            else if(sub.Count == 0)
            {
                MessageBox.Show($"Tutor:'{df}'doesn't be assigned any subject yet");
            }
        }
        public void viewtutorlist(DataGridView gf)
        {
            con.Open();
            SqlDataAdapter cmd = new SqlDataAdapter($"Select * from Tutor ", con);
            DataTable dt1 = new DataTable();
            cmd.Fill(dt1);

            gf.DataSource = dt1;
            con.Close();
        }

        public void DeleteTutor(string aa)
        {
            string status = null;
            con.Open();
            SqlCommand cmdR = new SqlCommand($"Select Username from Tutor where Name  = '{aa}'", con);
            string lk = cmdR.ExecuteScalar().ToString();
            con.Close();
            con.Open();
            SqlCommand cmdf = new SqlCommand($"Select Count(*) from Teaching_Sub_Level where Username  = '{lk}'", con);
            SqlCommand cmdd = new SqlCommand($"Select Count(*) from Schedule where Username = '{lk}'", con);
            int countcmd1 = Convert.ToInt32(cmdf.ExecuteScalar().ToString());
            int countcmd2 = Convert.ToInt32(cmdd.ExecuteScalar().ToString());
            con.Close();
            if (countcmd1 == 0 && countcmd2 == 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"Delete from Tutor where Username = '{lk}'", con);
                SqlCommand cmd2 = new SqlCommand($"Delete from Login where Username = '{lk}'", con);
                MessageBox.Show("Tutor information already delete");
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                con.Close();

            }
            else if (countcmd1 > 0 && countcmd2 == 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"Delete from Tutor where Username = '{lk}'", con);
                SqlCommand cmd2 = new SqlCommand($"Delete from Teaching_Sub_Level where Username = '{lk}'", con);
                SqlCommand cmd3 = new SqlCommand($"Delete from Login where Username = '{lk}'", con);
                MessageBox.Show("Tutor information already delete,include information in subject");
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                con.Close();
            }
            else if (countcmd2 > 0 && countcmd1 > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"Delete from Tutor where Username = '{lk}'", con);
                SqlCommand cmd2 = new SqlCommand($"Delete from Teaching_Sub_Level where Username = '{lk}'", con);
                SqlCommand cmd3 = new SqlCommand($"Delete from Schedule where Username = '{lk}'", con);
                SqlCommand cmd4 = new SqlCommand($"Delete from Login where Username = '{lk}'", con);
                MessageBox.Show("Tutor information already delete,include information in subject and class");
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                con.Close();
            }
        }

        
    }
}
