using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADMIN_PAGE
{

    public partial class RecepUpdateProfile : Form
    {
        static string name, username, gender;
        public RecepUpdateProfile()
        {
            InitializeComponent();
        }

        
        public RecepUpdateProfile(string n ,string un,string g)
        {
            InitializeComponent();
            name = n;
            username = un; 
            gender = g;
        }
       
   
        private void UpdateProfile_Load(object sender, EventArgs e)
        {
            //Globle ogject
            //Globle ogject
            Receptionist receptionist = new Receptionist(username);

            Receptionist.viewProfile(receptionist);
            txtStaffName.Text = name;
            txtStaffUserName.Text = username;
            txtStaffEmail.Text = receptionist.Email1;
            txtStaffBirthDay.Value = receptionist.DOB1;
            txtStaffAddres.Text = receptionist.Address1;
            txtStaffContactNo.Text = receptionist.Contact_Num1;
            txtStaffID.Text = receptionist.ICPassport1;
            labGreating.Text = $"Welcome to Profile Form {name}";
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {

            Receptionist backup = new Receptionist(username);
            Receptionist.viewProfile(backup);


            Receptionist updateInfo = new Receptionist(username);

            //for backup. 

            if (!Recepvalidation.checkTextBoxes(txtStaffName.Text)) { updateInfo.Name1 = name; txtStaffName.BringToFront();}
            else
            {
                if (Recepvalidation.checkName(txtStaffName.Text))
                {
                    updateInfo.Name1 = txtStaffName.Text;
                    txtStaffName.BringToFront();
                }
                else
                {
                    MessageBox.Show("invalid Name !!!!!");
                    txtStaffName.Focus();
                    txtStaffName.SendToBack();
                    return;
                }
            }
            if (!Recepvalidation.checkTextBoxes(txtStaffUserName.Text)) { updateInfo.Username2_1 = username; txtStaffUserName.BringToFront(); }
            else
            {
                if (Recepvalidation.checkUsername(txtStaffUserName.Text))
                {
                    updateInfo.Username2_1 = txtStaffUserName.Text;
                    txtStaffUserName.BringToFront();
                }
                else
                {
                    MessageBox.Show("invalid Name !!!!!");
                    txtStaffUserName.Focus();
                    txtStaffUserName.SendToBack();
                    return;
                }
            }

            if (!Recepvalidation.checkTextBoxes(txtStaffContactNo.Text)) updateInfo.Contact_Num1 = backup.Contact_Num1; else updateInfo.Contact_Num1 = txtStaffContactNo.Text;
            if (!Recepvalidation.checkTextBoxes(txtStaffAddres.Text)) updateInfo.Address1 = backup.Address1; else updateInfo.Address1 = txtStaffAddres.Text;
            if (!Recepvalidation.checkTextBoxes(txtStaffEmail.Text))
            { updateInfo.Email1 = backup.Email1; }
            else{ 
                if(Recepvalidation.CheckEmail(txtStaffEmail.Text))
                {
                    updateInfo.Email1 = txtStaffEmail.Text;
                }else
                {
                    MessageBox.Show("invalid Email Addrees!!!");
                    return;
                }
            }
            if (!Recepvalidation.checkTextBoxes(txtStaffID.Text)) updateInfo.ICPassport1 = backup.ICPassport1; else updateInfo.ICPassport1 = txtStaffID.Text;
            updateInfo.DOB1 = txtStaffBirthDay.Value;
            if (Recepvalidation.radioButtonsChecker(radiStaffMale))
            {
              updateInfo.Gender1 = "Male";
               
            }
            else if(Recepvalidation.radioButtonsChecker(radiStaffFemale))
            {
                updateInfo.Gender1 = "Female";
            }
            else
            {
                updateInfo.Gender1 = gender;

            }
            string Message = updateInfo.UpdateProfile();
            MessageBox.Show(Message);

        }


        // close , min , max , normal size  start
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   
        private void btnMin_Click(object sender, EventArgs e)
        {
             this.WindowState = FormWindowState.Minimized;
        
        }


        // close , min , max , normal size  end

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            changePassword changePassword = new changePassword(name, username,gender);
            changePassword.ShowDialog();

        }

        private void btnClosePage_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
