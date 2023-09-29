using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ADMIN_PAGE
{
    internal class Class_Information
    {
        public string username;

        // member field
        private int Schedule_ID;
        private string Tutor_Name;
        private string Subject_Name1;
        private string Subject_Name2;
        private string Subject_Name3;
        private string Location;
        private string Day;
        private string Start_Time;
        private string End_Time;
        private string Duration;
        private double Subject_Fee;
        private string Level;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());

        public string Tutor_Name1 { get => Tutor_Name; set => Tutor_Name = value; }
        public string Subject_Name_1 { get => Subject_Name1; set => Subject_Name1 = value; }
        public string Subject_Name_2 { get => Subject_Name2; set => Subject_Name2 = value; }
        public string Subject_Name_3 { get => Subject_Name3; set => Subject_Name3 = value; }
        public string Location1 { get => Location; set => Location = value; }
        public string Day1 { get => Day; set => Day = value; }
        public string Start_Time1 { get => Start_Time; set => Start_Time = value; }
        public string End_Time1 { get => End_Time; set => End_Time = value; }
        public string Duration1 { get => Duration; set => Duration = value; }
        public double Subject_Fee1 { get => Subject_Fee; set => Subject_Fee = value; }
        public string Level1 { get => Level; set => Level = value; }


        public Class_Information(int schedule_id)
        {
            this.Schedule_ID = schedule_id;
        }

        public Class_Information() { }

        public Class_Information(string username)
        {
            this.username = username;
        }

        public string Add_Class_Information(string username)
        {
            string status;
            con.Open();
            SqlCommand cmd3 = new SqlCommand($"Select Subject_ID from Subjects where Subject_Name= '{Subject_Name1}'", con);
            int aa = Convert.ToInt32(cmd3.ExecuteScalar());
            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand($"Select Name from Tutor where username = '{username}'",con);
            con.Close();
            con.Open();
            string tutor = cmd2.ExecuteScalar().ToString();
            SqlCommand cmd1 = new SqlCommand ("insert into Schedule (Tutor_Name,Subject_ID,Subject_Name,Venue,Day,Start_Time,End_Time,Duration,Subject_Charges,Level,Username) values (@Tutor_Name,@subID,@Subject_Name,@Location,@Day,@Start_Time,@End_Time,@Duration,@Subject_Fee,@Level,@Username)", con);

                    /*
                    below is logic to prevent duplicate information for Add Class Information function
                    select count (*) from users where username = @name
                    if the count > 0, that means username already exist,
                    thus you should show error msg
                    */

            cmd1.Parameters.AddWithValue("@Tutor_Name", tutor);
            cmd1.Parameters.AddWithValue("@subID", aa);
            cmd1.Parameters.AddWithValue("@Subject_Name", Subject_Name1);
            cmd1.Parameters.AddWithValue("@Location", Location);
            cmd1.Parameters.AddWithValue("@Day", Day);
            cmd1.Parameters.AddWithValue("@Start_Time", Start_Time);
            cmd1.Parameters.AddWithValue("@End_Time", End_Time);
            cmd1.Parameters.AddWithValue("@Duration", Duration);
            cmd1.Parameters.AddWithValue("@Subject_Fee", Subject_Fee);
            cmd1.Parameters.AddWithValue("@Level", Level);
            cmd1.Parameters.AddWithValue("@Username", username);

            int i = cmd1.ExecuteNonQuery();
            if (i  > -1)
            {
                status = "Add class information Successful.";
                con.Close();
                return status;
            }
                
            else
            {
                status = "Unable to add class information.";
                con.Close();
                return status;
            } 
        }

        public string Update_Class_Info (string username)
        {
            // open connection with SQL Database
            con.Open();
            SqlCommand cmd3 = new SqlCommand($"Select Subject_ID from Subjects where Subject_Name= '{Subject_Name1}'", con);
            con.Close();
            int aa = Convert.ToInt32(cmd3.ExecuteScalar());
            
            con.Open();
            SqlCommand cmd2 = new SqlCommand($"Select Name from Tutor where username = '{username}'", con);
            string tutor = cmd2.ExecuteScalar().ToString();
            SqlCommand cmd1 = new SqlCommand($"Update Schedule set Tutor_Name = '{tutor}',Subject_ID = '{aa}' Subject_Name = '{Subject_Name1}', " +
                $"Venue = '{Location}', Day = '{Day}', Start_Time = '{Start_Time}', End_Time = '{End_Time}', Duration = '{Duration}'," +
                $" Subject_Charges = '{Subject_Fee}', Level = '{Level}' where Username = '{username}'", con);
       
            // execute query of update table data
            int i = cmd1.ExecuteNonQuery();
            if(i == -1)
            {
                return "Update process is not successful!";
            }
            // close connection with SQL Database
            con.Close();
            return "Update process is successful!";
        }


        public static void view_class_schedule(DataGridView gf,string  username)
        {
            con.Open();
            SqlDataAdapter cmd0 = new SqlDataAdapter ($"Select Schedule_ID, Subject_Name, Venue, Start_Time, " +
                $"End_Time, Duration, Day from Schedule where username = '{username}'", con);
            //SqlCommand    cmd1 = new SqlCommand("Select STRING_AGG(Level, ',') from Teaching_Sub_Level", con);
            DataTable table = new DataTable();
            cmd0.Fill(table);
            gf.DataSource = table; 
           
        }

        // call Tutor class method
        public static void View_Class_Details(Class_Information obj, int Schedule_ID)
        {
            // open connection with SQL Database
            con.Open();
            SqlCommand cmd = new SqlCommand($"Select * from Schedule where Schedule_ID = '{Schedule_ID}'", con);

            // Execute the SQL query by reading by row
            SqlDataReader rd = cmd.ExecuteReader();
            // get data from database
            while (rd.Read())
            {
                
                obj.Subject_Name1 = rd.GetString(1);
                obj.Tutor_Name = rd.GetString(2);
                obj.Level = rd.GetString(3);
                obj.Duration = Convert.ToString(rd.GetInt32(4));
                obj.Start_Time = rd.GetString(5);
                obj.End_Time = rd.GetString(6);
                obj.Day = rd.GetString(7);
                obj.Location = rd.GetString(8);
                obj.Subject_Fee = Convert.ToDouble(rd.GetDecimal(9));
                obj.username = rd.GetString(10);
            }
            // close connection with SQL Database
            con.Close();
        }

        public static void ViewClassInfo(DataGridView gd, string level = "", string subject = "")
        {
            if (level == "" && subject == "") { //$"join  Subjects on  Subjects.Subject_ID =  Student.Student_ID .Subject_ID "
                con.Open();//Student  Student_Subject  Subjects  Subject_ID Subject_Name Student_ID Subject_Name
                SqlDataAdapter cmd = new SqlDataAdapter($"SELECT Schedule_ID,Subject_Name, Level, Duration, Start_Time," +
                    $" End_Time, Venue, Day, Subject_Charges from Schedule ", con);

                DataTable dt1 = new DataTable();
                cmd.Fill(dt1);
                gd.DataSource = dt1;
            }
            else if (level == "" && subject != "")
            {
                SqlDataAdapter cmd = new SqlDataAdapter($"SELECT Schedule_ID, Subject_Name, Level, Duration," +
                    $" Start_Time, End_Time, Venue, Day, Subject_Charges from Schedule where Subject_Name = '{subject}'", con);
                DataTable dt1 = new DataTable();
                cmd.Fill(dt1);
                gd.DataSource = dt1;
                con.Close();
            }
            else if (level != "" && subject == "")
            {
                SqlDataAdapter cmd = new SqlDataAdapter($"SELECT Schedule_ID, Subject_Name, Level, Duration, " +
                    $"Start_Time, End_Time, Venue, Day, Subject_Charges from Schedule where Level = '{level}'", con);
                DataTable dt1 = new DataTable();
                cmd.Fill(dt1);
                gd.DataSource = dt1;
                con.Close();
            }
            else
            {
                SqlDataAdapter cmd = new SqlDataAdapter($"SELECT Schedule_ID, Subject_Name, Level, Duration, " +
                    $"Start_Time, End_Time, Venue, Day, Subject_Charges from Schedule where Subject_Name = '{subject}' " +
                    $"and Level = '{level}'", con);
                DataTable dt1 = new DataTable();
                cmd.Fill(dt1);
                gd.DataSource = dt1;
                con.Close();
            }

            con.Close();
        }

        public string Delete_Class_Info()
        {
            con.Open();
            //extract the  student_ID values
            SqlCommand cmd = new SqlCommand($"Delete from Schedule where Schedule_ID =  '{this.Schedule_ID}'", con);
            int Schedule_ID = cmd.ExecuteNonQuery();
            if (Schedule_ID == 0) return $"Sorry! Failed to delete!";
            
            return $"Class information has been deleted successfully!";
        }
    }
}
