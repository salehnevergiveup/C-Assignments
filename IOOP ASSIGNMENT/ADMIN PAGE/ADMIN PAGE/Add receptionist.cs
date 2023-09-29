using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;

namespace ADMIN_PAGE
{
    public partial class Add_receptionist : Form
    {
        public Add_receptionist()
        {
            InitializeComponent();
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //OpenFileDialog openf = new OpenFileDialog();
        private void btnMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMax.Visible = false;
            btnnormal.Visible = true;
        }

        private void btnmini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnnormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMax.Visible = true;
            btnnormal.Visible = false;
        }

        private void buttonmainpage_Click(object sender, EventArgs e)
        {
            AdminViewProfile profile = new AdminViewProfile();
            this.Hide();
            profile.ShowDialog();
            this.Close();
        }

        private void buttontutorlist_Click(object sender, EventArgs e)
        {
            TUTORLIST tutorlist = new TUTORLIST();
            this.Hide();
            tutorlist.ShowDialog();
            this.Close();
        }

        private void btnreceptionistlist_Click(object sender, EventArgs e)
        {
            AdminReceptionist receptionist = new AdminReceptionist();
            this.Hide();
            receptionist.ShowDialog();
            this.Close();
        }

        private void btnMonthlyIncome_Click(object sender, EventArgs e)
        {
            View_report viewreport = new View_report();
            this.Hide();
            viewreport.ShowDialog();
            this.Close();
        }

        private void btnback_Click(object sender, EventArgs e)
        {

            AdminReceptionist receptionist = new AdminReceptionist();
            this.Hide();
            receptionist.ShowDialog();
            this.Close();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            LoginForm loginform = new LoginForm();
            this.Hide();
            loginform.ShowDialog();
            this.Close();
        }
        bool sidebar;
        private void sidebartime_Tick(object sender, EventArgs e)
        {
            if(sidebar)
            {
                panelslidebar.Width -= 10;
                if (panelslidebar.Width == panelslidebar.MinimumSize.Width)
                {
                    sidebar = false;
                    sidebartime.Stop();
                }

            }
            else
            {
                panelslidebar.Width += 10;
                if (panelslidebar.Width == panelslidebar.MaximumSize.Width)
                {
                    sidebar = true;
                    sidebartime.Stop();
                }
            }
            
        }

        private void panelslidebar_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sidebartime.Start();
        }

        private void btnAddrecep_Click(object sender, EventArgs e)
        {
            string passwordd = txtRPassword.Text;
            string password_checked =txtRPasscomfirm.Text;
            string gender_Checked = "";
            if (rdFemale.Checked)
            {
                gender_Checked = "Female";
                
                
                if (password_checked != passwordd)
                {
                    MessageBox.Show("Password that you comfirm doesn't match with the password you enter\n Please reenter again");
                    txtRPassword.Clear();
                    txtRPasscomfirm.Clear();
                    txtRPassword.Focus();

                }
                else if (password_checked == passwordd)
                {
                    ClassReceptionist apprecep = new ClassReceptionist(txtrecepname.Text, txtRICPAss.Text, dtpRDOB.Value, txtrecepcontact.Text, txtrecepemail.Text, gender_Checked, textrecepaddress.Text, txtRuserName.Text, passwordd);
                    string apprecep1 = apprecep.addreceptionist();
                    MessageBox.Show(apprecep1);
                }
                
                

            }
            else if(rMale.Checked)
            {
                gender_Checked = "Male";

                if (password_checked != passwordd)
                {
                    MessageBox.Show("Password that you comfirm doesn't match with the password you enter\n Please reenter again");
                    txtRPassword.Clear();
                    txtRPasscomfirm.Clear();
                    txtRPassword.Focus();
                }
                else if (password_checked == passwordd)
                {
                    ClassReceptionist apprecep = new ClassReceptionist(txtrecepname.Text, txtRICPAss.Text, dtpRDOB.Value, txtrecepcontact.Text, txtrecepemail.Text, gender_Checked, textrecepaddress.Text, txtRuserName.Text, passwordd);
                    string apprecep1 = apprecep.addreceptionist();
                    MessageBox.Show(apprecep1);

                   /* string filename = System.IO.Path.GetFileName(openf.FileName);
                    if (filename == null)
                    {
                      MessageBox.Show("Please select a valid image.");
                    }
                    else
                    {
                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
                            //we already define our connection globaly. We are just calling the object of connection.
                            con.Open();
                            SqlCommand cmd = new SqlCommand("insert into Receptionist(Photo)values('\\Image\\" + filename + "')", con);
                            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                            System.IO.File.Copy(openf.FileName, path + "\\Image\\" + filename);
                            cmd.ExecuteNonQuery();
                            con.Close();
                    }*/
                 
                }

                
            }

        }

        private void btnbrowseImage_Click(object sender, EventArgs e)
        {
            
           /* //To where your opendialog box get starting location. My initial directory location is desktop.
            openf.InitialDirectory = "C://Desktop";
            //Your opendialog box title name.
            openf.Title = "Select image to be upload.";
            //which type image format you want to upload in database. just add them.
            openf.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            openf.FilterIndex = 1;
           try
            {
                if (openf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openf.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openf.FileName);
                        label1.Text = path;
                        recepPhoto.Image = new Bitmap(openf.FileName);
                        recepPhoto.SizeMode = PictureBoxSizeMode.StretchImage;

                    }
                }
                else
                {
                    MessageBox.Show("Please Upload image.");
                }
            }
            catch (Exception ex)
            {
                //it will give if file is already exits..
                MessageBox.Show(ex.Message);
            }*/
           
        }

        private void btnRclear_Click(object sender, EventArgs e)
        {
            txtRuserName.Clear();
            txtrecepcontact.Clear();
            txtrecepemail.Clear();
            txtrecepname.Clear();
            txtRICPAss.Clear();
            txtRPasscomfirm.Clear();
            txtRPassword.Clear();
        }
    }
}
