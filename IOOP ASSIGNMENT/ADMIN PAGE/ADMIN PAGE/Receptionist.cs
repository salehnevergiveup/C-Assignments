using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Metadata.Ecma335;

namespace ADMIN_PAGE
{
    internal class Receptionist
    {
        private int ReceptionistID; 
        private string username;
        private string username2;
        private string Name;
        private DateTime DOB;
        private string Gender;
        private string Contact_Num;
        private string Email;
        private string Address;
        private string ICPassport;
        private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());


        public Receptionist(string username)
        {
            this.username = username;


        }
       

        // Get and  Set Methods start
        public string Username2_1 { get => username2; set => username2 = value; }
        public string Name1 { get => Name; set => Name = value; }
        public DateTime DOB1 { get => DOB; set => DOB = value; }
        public string Gender1 { get => Gender; set => Gender = value; }
        public string Contact_Num1 { get => Contact_Num; set => Contact_Num = value; }
        public string Email1 { get => Email; set => Email = value; }
        public string Address1 { get => Address; set => Address = value; }
        public string ICPassport1 { get => ICPassport; set => ICPassport = value; }
        public int ReceptionistID1 { get => ReceptionistID; set => ReceptionistID = value; }

        //Get and set methods end




        public static void  viewProfile(Receptionist obj)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand($"Select * from Receptionist where username = '{obj.username}'", con);

            SqlDataReader rd = cmd.ExecuteReader();

            // Attriubts that not extracted from the login page 
            while(rd.Read())
            {
              obj.ReceptionistID = rd.GetInt32(0);
              obj.DOB = rd.GetDateTime(2);
              obj.Email = rd.GetString(5);
              obj.ICPassport = rd.GetString(7);
              obj.Address = rd.GetString(6);
              obj.Contact_Num = rd.GetString(4);
            }
            con.Close();
        }
        public string UpdateProfile()
        {
            string status;
            con.Open();
           SqlCommand cmd = new SqlCommand($"Update Receptionist set Name = '{this.Name}',DOB = '{this.DOB}',Username = '{this.username2}',Contact_Num = '{this.Contact_Num}',Email = '{this.Email}',Address = '{this.Address}',ICPassport = '{this.ICPassport}'  where Username = '{this.username}'", con);
           SqlCommand cmd2 = new SqlCommand($"Update Login set username= '{this.username2}' where username = '{this.username}'", con);// the new  username  enterd by the user
           SqlCommand cmd3 = new SqlCommand($"Select count(*) from Login where username = '{this.username2}' and  username != '{this.username}' ", con);

            int i = Convert.ToInt32(cmd3.ExecuteNonQuery().ToString());
            


            // this is beacuse  if the user not change the  user name  the counter will be on so wil not allowed the  user to update other inforamtion
            if(i == -1)
            {
        
                int k = Convert.ToInt32(cmd.ExecuteNonQuery().ToString());
                int j = Convert.ToInt32(cmd2.ExecuteNonQuery().ToString());
                if(j != 0 && k != 0)
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

        public string changePassword(string oldPassword, string confPassword, string newPassword)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand($"Select Password From login where Username = '{this.username}'", con);

            SqlCommand cmd2 = new SqlCommand($"Update Login set password = '{newPassword}' where username = '{username}'", con);

            string oldpass = cmd.ExecuteScalar().ToString();

            if (!Recepvalidation.passwordChecker(oldPassword, oldpass))
            {
                MessageBox.Show("Insrted Password not matched with the old passworld!!!!!");
                con.Close();
                return "1";
            }

            if (Recepvalidation.passwordChecker(newPassword, oldPassword))
            {
                MessageBox.Show("New password and  old password should not be the  same!!!!");
                con.Close();
                return "2";
            }

            if (!Recepvalidation.passwordChecker(newPassword, confPassword))
            {
                MessageBox.Show("conformation and  new password doesn't matched try again");
                con.Close();
                return "3";
            }

            if (!Recepvalidation.lengthChecker(newPassword)) { MessageBox.Show("password length should be between 8 to 15"); con.Close(); return ""; }
            if (!Recepvalidation.lengthChecker(confPassword)) { MessageBox.Show("password length should be between 8 to 15"); con.Close(); return ""; }
            if (!Recepvalidation.lengthChecker(oldPassword)) { MessageBox.Show("password length should be between 8 to 15"); con.Close(); return ""; }

            int checker = cmd2.ExecuteNonQuery();
            if (checker == 1) {MessageBox.Show("Password Updated Successfully"); con.Close(); return "4"; }
            else MessageBox.Show("Unable to update the password !!!!");

            con.Close();
            return "";

        }
    }












}
