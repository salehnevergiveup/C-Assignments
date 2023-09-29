using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Windows.Forms;
using System.Reflection.Emit;
using System.Drawing;
using System.Data;

namespace ADMIN_PAGE
{
    internal class ClassAdmin
    {
        //add class member
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
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());

        //add property get and set 
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

        //Add contructor
        public ClassAdmin(string id, string name, string ic_passport, DateTime dob, string contactnum, string email, string gender, string address)
        {
            this.Id = id;
            this.Name = name;
            this.Ic_passport = ic_passport;
            this.Dob = dob;
            this.Contactnum = contactnum;
            this.Email = email;
            this.Gender = gender;
            this.Address = address;
        }

        public ClassAdmin()
        {
        }

        public ClassAdmin(string username)
        {
            this.Username = username;
        }
        public ClassAdmin(string name, string gender, string username)
        {
            this.Name = name;
            this.Gender = gender;
            this.Username = username;
        }

        //call admin class method
        public static void viewdetails(ClassAdmin obj)
        {
            //open connection with SQL database
            
            con.Open(); SqlCommand cmd = new SqlCommand($"Select * from Admin where username = '{obj.Username}'", con);
            //excute sql query to read row
            SqlDataReader rd = cmd.ExecuteReader();
            // get data from database 
            while (rd.Read())
            {
                obj.dob = rd.GetDateTime(2);
                obj.contactnum = rd.GetString(4);
                obj.email = rd.GetString(5);
                obj.address = rd.GetString(6);
                obj.ic_passport = rd.GetString(7);

            }
            //clse connection with SQL database
            con.Close();

        }
        public string updateProfile(string name, DateTime dob, string username2, string contact, string email, string address, string icPassport)
        {
            string status = null;
            con.Open();
            //Password = '{newpassword},,string newpassword  txtNewPassword.Text
            SqlCommand cmd = new SqlCommand($"Update Admin set Name = '{name}',DOB = '{dob}',Username = '{username2}',Contact_Num = '{contact}',Email = '{email}',Address = '{address}',ICPassport = '{icPassport}' where Username = '{this.username}'", con);
            SqlCommand cmd2 = new SqlCommand($"Update Login set username= '{username2}' where username = '{username}'", con);// the new  username  enterd by the user
            SqlCommand cmd3 = new SqlCommand($"Select count(*) from Login where username = '{username}'", con);
            //convert number of counting index from string to interger
            int countcmd3 = Convert.ToInt32(cmd3.ExecuteScalar().ToString());

            
            if (countcmd3 == 0 || (countcmd3 == 1))
            {
                //excecute query of update table data
                int i = cmd.ExecuteNonQuery();
                int j = cmd2.ExecuteNonQuery();
                if (i != 0 & j != 0)
                {
                    status = "Update Successfully";
                }
                else
                {
                    status = "Unable to update";
                }
            }
            else
            {
                status = "Sorry!!! username already exists enter another user name";
            }

            con.Close();
            return status;
        }

        public string updatePassword(string password)
        {
            string status = null;
            con.Open();
            SqlCommand cmd = new SqlCommand($"Update Login set Password = '{password}' where Username = '{this.username}'", con);
            cmd.ExecuteNonQuery();
            status = "Update Successfully";
            con.Close();
            return status;

        }
        public void viewtotalincomelevel(CheckedListBox rr, ListBox cc,ListBox dd, ListBox ff, Control hh)
        { 
            //clear item before insert new item in listbox
            cc.Items.Clear();
            dd.Items.Clear();
            ff.Items.Clear();
            //add checkeditem into listbox
            foreach (string checkedItem in rr.CheckedItems)
            {
                dd.Items.Add(checkedItem);
            }
            cc.Items.Add("All Subjects");
            ff.Items.Add("All Month");
            con.Open();
            double sum = 0;
            //add sum total of each subject fee in
            foreach (string Level1 in dd.Items) {
                SqlCommand cmd3 = new SqlCommand($"select Fees from Receipt where Level = '{Level1}'", con);
                sum += Convert.ToDouble(cmd3.ExecuteScalar().ToString());
            }
            con.Close();
            //convert interger to string
            hh.Text = "RM " + sum.ToString();
        }
        //CheckedListBox rr, CheckedListBox kk,
        public void viewtotalincomesubject(CheckedListBox bb,  ListBox cc, ListBox dd, ListBox ff, Control hh)
        {
            cc.Items.Clear();
            dd.Items.Clear();
            ff.Items.Clear();

            dd.Items.Add("All Level");
            foreach (string checkedItem in bb.CheckedItems)
            {
                cc.Items.Add(checkedItem);
            }

            
            ff.Items.Add("All Month");
            

            con.Open();
            double sum = 0;
            foreach (string subjects in cc.Items)
            {
                SqlCommand cmd = new SqlCommand($"select Subject_ID from Subjects where Subject_Name = '{subjects}'", con);
                string valueID = cmd.ExecuteScalar().ToString();


            }
            foreach (string valueID in cc.Items)
            {

                SqlCommand cmd3 = new SqlCommand($"select Fees from Receipt where Subject_ID = (select Subject_ID from Subjects where Subject_Name = '{valueID}')", con);
                sum += Convert.ToDouble(cmd3.ExecuteScalar().ToString());
            }
            con.Close();
            hh.Text = "RM " + sum.ToString();
        }
        public void viewtotalincomemonth( CheckedListBox kk, ListBox cc, ListBox dd, ListBox ff, Control hh)
        {
            cc.Items.Clear();
            dd.Items.Clear();
            ff.Items.Clear();
            foreach (string checkedItem in kk.CheckedItems)
            {
                ff.Items.Add(checkedItem);
            }
                cc.Items.Add("All Subjects");
                dd.Items.Add("All Level");
        
            con.Open();
            double sum = 0;

            foreach (string month1 in ff.Items)
            {

                SqlCommand cmd3 = new SqlCommand($"select Fees from Receipt where Month = '{month1}'", con);
                sum += Convert.ToDouble(cmd3.ExecuteScalar().ToString());
            }
            con.Close();
            hh.Text = "RM " + sum.ToString();
        }
        public void viewfulllevelreport( string aa,DataGridView gf)
        {
            // add new table and insert data into datagridview
            con.Open();
            SqlDataAdapter cmd = new SqlDataAdapter($"Select Month,Level,Student_ID,Subjects.Subject_Name,Fees from Receipt inner join Subjects on Receipt.Subject_ID = Subjects.Subject_ID where Month = '{aa}' order by Level", con);
            DataTable dt1 = new DataTable();
            cmd.Fill(dt1);
            gf.DataSource = dt1;
            con.Close();

        }

        public void viewfullsubjectreport(string aa, DataGridView gf)
        {

            con.Open();
            SqlDataAdapter cmd = new SqlDataAdapter($"Select Month,Subjects.Subject_Name,Student_ID,Level,Fees from Receipt inner join Subjects on Receipt.Subject_ID = Subjects.Subject_ID where Month = '{aa}' order by Subjects.Subject_Name", con);
            DataTable dt1 = new DataTable();
            cmd.Fill(dt1);
            gf.DataSource = dt1;
            con.Close();

        }
    }
}

