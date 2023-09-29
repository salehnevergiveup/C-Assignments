using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Collections;

namespace ADMIN_PAGE
{
    internal class ClassReceptionist
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
        private Image photo;

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
        public Image Photo { get => photo; set => photo = value; }

        public ClassReceptionist(string name,string ic_passport,DateTime dob,string contactnum,string email,string gender,string address,string username,string password)
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

        public ClassReceptionist(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public ClassReceptionist()
        {

        }
        //add receptionist 
        public string addreceptionist()
        {
            string status;
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Login(Username,Password,Role)values(@username,'123',@role)", con);
            SqlCommand cmd2 = new SqlCommand("insert into Receptionist(Name,DOB,Gender,Contact_Num,Email,Address,ICPassport,Username)values(@Name,@dob,@gender,@num,@email,@address,@ICPassport,@username)", con);
            SqlCommand cmd3 = new SqlCommand("select count(*) from Login where Username = @username", con);
            SqlCommand cmd4 = new SqlCommand($"select count(*) from Receptionist where Username = @username", con);
            //insert data to table according column
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("123", password);
            cmd.Parameters.AddWithValue("@role", "Receptionist");
            cmd2.Parameters.AddWithValue("@Name", Name);
            cmd2.Parameters.AddWithValue("@dob", dob);
            cmd2.Parameters.AddWithValue("@gender", gender);
            cmd2.Parameters.AddWithValue("@num", contactnum);
            cmd2.Parameters.AddWithValue("@email", email);
            cmd2.Parameters.AddWithValue("@address", address);
            cmd2.Parameters.AddWithValue("@ICPassport", ic_passport);
            cmd2.Parameters.AddWithValue("@username",username);
            
            cmd3.Parameters.AddWithValue("@username",username);
            cmd4.Parameters.AddWithValue("@username",username);

            int countCmd3 = Convert.ToInt32(cmd3.ExecuteScalar());
            int countCmd4 = Convert.ToInt32(cmd4.ExecuteScalar());
            //check if username exist in login and receptionist table
            if(countCmd3 > 0 || countCmd4 > 0)
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
        public void viewReceptionistlist(DataGridView gf)
        {
            con.Open();
            SqlDataAdapter cmd = new SqlDataAdapter($"Select * from Receptionist ", con);
            DataTable dt1 = new DataTable();
            cmd.Fill(dt1);

            gf.DataSource = dt1;
            con.Close();
        }

        public static ArrayList viewRecep()
        {
            //retrive data from  table and display in listbox 
            ArrayList Recep = new ArrayList();
            con.Open();
            SqlCommand cmd = new SqlCommand("select Name from Receptionist", con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Recep.Add(rd.GetString(0));
            }
            con.Close();
            return Recep;
        }
        public void DeleteRecep(string aa)
        {
            //delete row data in table
            string status = null;
            con.Open();
            SqlCommand cmdR = new SqlCommand($"Select Username from Receptionist where Name  = '{aa}'", con);
            string lk = cmdR.ExecuteScalar().ToString();
            con.Close();
            con.Open();
                SqlCommand cmd = new SqlCommand($"Delete from Receptionist where Username = '{lk}'", con);
                SqlCommand cmd2 = new SqlCommand($"Delete from Login where Username = '{lk}'", con);
                MessageBox.Show("Receptionist information already delete");
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                con.Close();

        }
    }
    
}
