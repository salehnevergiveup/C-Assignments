using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Configuration;
using System.Data;

namespace ADMIN_PAGE
{
    internal class manageRequests
    {
        private int requestid;
        private string requesttitle;
        private string sub1;
        private string sub2;
        private string sub3;   
        private DateTime requestdate;
        private string requeststatus;
        private DateTime completiondate;
        private string username;
        private int studentid;
        private int recepid;

        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());

        public int Requestid { get => requestid; set => requestid = value; }
        public string Requesttitle { get => requesttitle; set => requesttitle = value; }
        public string Sub1 { get => sub1; set => sub1 = value; }
        public string Sub2 { get => sub2; set => sub2 = value; }
        public string Sub3 { get => sub3; set => sub3 = value; }
        public DateTime Requestdate { get => requestdate; set => requestdate = value; }
        public string Requeststatus { get => requeststatus; set => requeststatus = value; }
        public DateTime Completiondate { get => completiondate; set => completiondate = value; }
        public string Username { get => username; set => username = value; }
        public int Studentid { get => studentid; set => studentid = value; }
        public int Recepid { get => recepid; set => recepid = value; }

        public manageRequests(int requestid)
        {
            this.Requestid = requestid;
        }

        public manageRequests() 
        { 
        
        }
        
        public manageRequests(string requesttitle, string sub1, string sub2, string sub3, DateTime requestdate)
        {
            this.Requesttitle = requesttitle;
            this.Sub1 = sub1;
            this.Sub2 = sub2;
            this.Sub3 = sub3;
            this.Requestdate = requestdate;
        }
        public manageRequests(string username)
        {
            this.Username = username;
        }
        public string addRequests(string username)
        {
            string status;
            con.Open(); 
            
            SqlCommand cmd = new SqlCommand($"Select Student_ID from Student where Username = '{username}'", con);
            string student = cmd.ExecuteScalar().ToString();
            SqlCommand requestcmd = new SqlCommand("insert into Request(Request_Title,First_Subject, " +
                "Second_Subject, Third_Subject, Request_Date, Request_Status, Completion_Date, Student_ID, Receptionist_ID)" +
                "values(@requesttitle, @sub1, @sub2, @sub3, @requestdate, 'Pending', NULL, @studentid, NULL)", con);
            con.Close();
            requestcmd.Parameters.AddWithValue("@requesttitle", requesttitle);
            requestcmd.Parameters.AddWithValue("@sub1", sub1);
            requestcmd.Parameters.AddWithValue("@sub2", sub2);
            requestcmd.Parameters.AddWithValue("@sub3", sub3);
            requestcmd.Parameters.AddWithValue("@requestdate", requestdate);
            requestcmd.Parameters.AddWithValue("@studentid", student);
            con.Open();
            int verifyrequest = requestcmd.ExecuteNonQuery();
            if (verifyrequest != 0)
            {
                status = "Request Sent Successfully";
            }
            else
            {
                status = "Unable to Send Request";
            }
           con.Close();
           return status;

        }

        public string deleteRequest()
        {
            con.Open();
            //extract the  student_ID values
            SqlCommand cmd = new SqlCommand($"Delete from Request where Request_ID =  '{this.Requestid}'", con);
            int Request_ID = cmd.ExecuteNonQuery();
            if (Request_ID == 0) return $"!Failed to delete request!";

            return $"Request has been deleted successfully!";
        }

        public static void viewRequests(DataGridView gf, string username)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand($"Select Student_ID from Student where Username  = '{username}'", con);
            int studentid = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            SqlDataAdapter cmd1 = new SqlDataAdapter($"select Request_ID, Request_Title, First_Subject, Second_Subject, Third_Subject, Request_Date, Request_Status, Completion_Date from Request inner join Student on Request.Student_ID = Student.Student_ID where Student.Username = '{username}'", con);
            DataTable dt1 = new DataTable();
            cmd1.Fill(dt1);
            gf.DataSource = dt1;
            con.Close();
        }
    }
}
