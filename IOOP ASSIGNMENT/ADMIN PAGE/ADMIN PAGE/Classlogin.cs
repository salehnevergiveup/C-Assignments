using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ADMIN_PAGE
{
    internal class Classlogin
    {
        private string username;
        private string password;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public Classlogin(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Login()
        {
            
            string gender = null;
            string name = null;
            string status = null;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            //check if Username exist in login table or not
            SqlCommand cmd = new SqlCommand($"Select count(*) from Login where Username ='{username}' and Password = '{password}'", con);
            
            int count = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            if (count > 0)
            {
                SqlCommand cmd1 = new SqlCommand($"Select Role  from Login where Username ='{username}' and Password = '{password}'", con);
                string loginRole = cmd1.ExecuteScalar().ToString();
                ClassReceptionist loginnn = new ClassReceptionist(username, password);
                SqlCommand cmd3 = new SqlCommand($"Select * from {loginRole} where Username = '{username}' ", con);
                SqlDataReader rd = cmd3.ExecuteReader();
                while (rd.Read()) {
                    name = rd.GetString(1);
                    gender = rd.GetString(3);
                }
                //to identify the role of the user and direct to each page respectively
                if (loginRole == "Admin")
                {
                    AdminViewProfile a = new AdminViewProfile(name,gender,username);
                    a.ShowDialog();
                    
                }
                else if (loginRole == "student")
                {
                    STUDENTViewProfile c = new STUDENTViewProfile(username);
                    c.ShowDialog();
                }
                else if (loginRole == "Tutor")
                {
                    Frm_Add_Class_Information d = new Frm_Add_Class_Information(name, username, gender);
                    d.ShowDialog();
                    
                }
                else if(loginRole == "Receptionist")
                {
                    ProfileRec b = new ProfileRec(name, gender, username);
                    b.ShowDialog();
                }
                else
                    status = "Invalid username/password";
                con.Close();
            }
            return status;
        }
    }
}
