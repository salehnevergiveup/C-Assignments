using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;

namespace ADMIN_PAGE
{
    internal class Request
    {
        private string fristSubject; 
        private string secondSubject; 
        private string thirdSubject;
        private DateTime requestDate;
        private string requestStatus;
        private DateTime completionDate;
        private int studentID;
        private int receptionistID;
        private string useranme;
        private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
        public string SecondSubject { get => secondSubject; set => secondSubject = value;}
        public string ThirdSubject { get => thirdSubject; set => thirdSubject = value;}
        public DateTime CompletionDate { get => completionDate; set => completionDate = value; }

       public Request(int receptionistID, DateTime completionDate, String requestStatus, string usrename)
        {
            this.receptionistID = receptionistID; 
            this.requestStatus = requestStatus;

        }

       public static DataTable ViewRequistInfo()
        {
            con.Open(); /* 
                         * 
                         * Select student.Student_ID , student.name, Request.[ First_Subject],Second_Subject,
Request.Third_Subject,Request.Request_Date,Request_Status from Request join Student on Student.Student_ID = Request.Request_ID*/
                         
            SqlDataAdapter cmd = new SqlDataAdapter($"Select Student.name,Student.username," +
                                                    $" Request.[First_Subject], Request.Second_Subject," +
                                                    $" Request.Third_Subject,Request.Request_Date," +
                                                    $" Request_Status from Student "  +
                                                    $"join Request on Request.Student_ID = Student.Student_ID where Request_Status != 'rejected' and  Request_Status != 'Updated' ", con);
           
            DataTable dt1 = new DataTable();
            cmd.Fill(dt1);
            con.Close();
            return dt1;
        }
        public static string  updateRequestInfo(int receptionistID, DateTime completionDate, String requestStatus, string username)
        {
            // change  the  Requset status , change reciptinst ID , Complemte day with => reject and  complited
            con.Open();
            //slect the  user ID from the student  table 
            SqlCommand cmd = new SqlCommand($"select Student_ID from student where USERNAME =  '{username}'", con);
            int studentID = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if(studentID == 0)  return "enable To Compelet the  process!!!";

            if(requestStatus == "Under process") 
                {
                SqlCommand cmd1 = new SqlCommand($"Update Request set Receptionist_ID = '{receptionistID}', " +
                                         $"Request_Status = '{requestStatus}' " +
                                         $"where  Student_ID = '{studentID}'", con);
                int check = cmd1.ExecuteNonQuery();
                if (check == -1) return "enable To Compelet the  process!!!";
            }
            else
                {
                MessageBox.Show(completionDate.ToString());
                SqlCommand cmd1 = new SqlCommand($"Update Request set Receptionist_ID = '{receptionistID}',Completion_Date = " +
                                          $"'{Convert.ToDateTime(DateTime.Today)}',Request_Status = '{requestStatus}' " +
                                          $"where  Student_ID = '{studentID}'", con);
                cmd1.ExecuteNonQuery();
                //if (check == -1) return "enable To Compelet the  process!!!";

            }
            con.Close();
                return "";
        }

    }
}
