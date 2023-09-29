using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace ADMIN_PAGE
{
    public partial class Assign_Subject : Form
    {
        public Assign_Subject()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TUTORLIST tutorlist = new TUTORLIST();
            this.Hide();
            tutorlist.ShowDialog();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            ClassTutor addsub1 = new ClassTutor(Sub1.Text, LevelSub1.Text, lbltutordisplay.Text);
            ClassTutor addsub2 = new ClassTutor(Sub2.Text, LevelSub2.Text, lbltutordisplay.Text);
            ClassTutor addsub3 = new ClassTutor(Sub3.Text, LevelSub3.Text, lbltutordisplay.Text);
            if (ltbxtutor.SelectedIndex > -1)
            {
                if (cbSublevel1.SelectedIndex > -1 && cbSublevel3.SelectedIndex < 0 && cbSublevel2.SelectedIndex < 0)
                {
                    string addsub11 = addsub1.addsubject1(lbltutordisplay.Text);
                    MessageBox.Show(addsub11);
                }
                else if (cbSublevel1.SelectedIndex > -1 && cbSublevel3.SelectedIndex < 0 && cbSublevel2.SelectedIndex > -1)
                {
                    string addsub11 = addsub1.addsubject1(lbltutordisplay.Text);
                    MessageBox.Show(addsub11);
                    string addsub22 = addsub2.addsubject2(lbltutordisplay.Text);
                    MessageBox.Show(addsub22);
                }
                else if (cbSublevel1.SelectedIndex > -1 && cbSublevel3.SelectedIndex > -1 && cbSublevel2.SelectedIndex > -1)
                {
                    string addsub11 = addsub1.addsubject1(lbltutordisplay.Text);
                    MessageBox.Show(addsub11);
                    string addsub22 = addsub2.addsubject2(lbltutordisplay.Text);
                    MessageBox.Show(addsub22);
                    string addsub33 = addsub3.addsubject3(lbltutordisplay.Text);
                    MessageBox.Show(addsub33);
                }
                else if (cbSublevel1.SelectedIndex < 0)
                {
                    MessageBox.Show("No subject is selected to assign to Tutor: ");
                }
            }
            else if (ltbxtutor.SelectedIndex == -1)
            {
                MessageBox.Show("Tutor havent selected,cannot assign subject ");
            }
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnmax.Visible = true;
            btnnormal.Visible = false;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnmax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnmax.Visible = false;
            btnnormal.Visible = true;
        }

        private void btnmini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnmain_Click(object sender, EventArgs e)
        {
            AdminViewProfile profile = new AdminViewProfile();
            this.Hide();
            profile.ShowDialog();
            this.Close();
        }

        private void btnreceplist_Click(object sender, EventArgs e)
        {
            AdminReceptionist receptionist = new AdminReceptionist();
            this.Hide();
            receptionist.ShowDialog();
            this.Close();
        }

        private void btnmontlyincome_Click(object sender, EventArgs e)
        {
            View_report viewreport = new View_report();
            this.Hide();
            viewreport.ShowDialog();
            this.Close();
        }

        private void btnviewlist_Click(object sender, EventArgs e)
        {
            TUTORLIST tutorlist = new TUTORLIST();
            this.Hide();
            tutorlist.ShowDialog();
            this.Close();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            LoginForm loginform = new LoginForm();
            this.Hide();
            loginform.ShowDialog();
            this.Close();
        }

        private void btntutorlist_Click(object sender, EventArgs e)
        {

        }

        private void panelslidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        bool sidebar;
        private void sidebartime_Tick_1(object sender, EventArgs e)
        {
            if (sidebar)
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

        private void Menu_Click(object sender, EventArgs e)
        {
            sidebartime.Start();
        }

        private void rbBM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbchinese_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ltbxtutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ltbxtutor.Items.Count >= 0)
            {
                lbltutordisplay.Text = ltbxtutor.SelectedItem.ToString();
            }
            else
            {
                lbltutordisplay.Text = "non selected";
            }
        }

        private void Assign_Subject_Load(object sender, EventArgs e)
        {
            ArrayList tname = new ArrayList();
            tname = ClassTutor.viewtutor();
            foreach(var item in tname)
            {
                ltbxtutor.Items.Add(item);
            }

            ArrayList sub1 = new ArrayList();
            sub1 = ClassTutor.viewSubject();
            foreach (var item in sub1)
            {
                cbTutorsub1.Items.Add(item);
            }

            ArrayList sub2 = new ArrayList();
            sub2 = ClassTutor.viewSubject();
            foreach (var item in sub2)
            {
                cbTutorsub2.Items.Add(item);
            }

            ArrayList sub3 = new ArrayList();
            sub3 = ClassTutor.viewSubject();
            foreach (var item in sub3)
            {
                cbTutorsub3.Items.Add(item);
            }
   

        }

        private void lbltutorselect_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbSublevel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTutorsub1.SelectedIndex > -1)
            {
                Sub1.Text = cbTutorsub1.Text;
                if (cbSublevel1.SelectedIndex > -1)
                {


                    if (cbTutorsub1.SelectedIndex == 4 || cbTutorsub1.SelectedIndex == 5 || cbTutorsub1.SelectedIndex == 6 || cbTutorsub1.SelectedIndex == 7
                        || cbTutorsub1.SelectedIndex == 8 || cbTutorsub1.SelectedIndex == 9 || cbTutorsub1.SelectedIndex == 10 || cbTutorsub1.SelectedIndex == 11)
                    {
                        if (cbSublevel1.SelectedIndex == 0 || cbSublevel1.SelectedIndex == 1 || cbSublevel1.SelectedIndex == 2)
                        {
                            MessageBox.Show("Subject you selected doesn't included in the level you selected");
                            cbSublevel1.SelectedItem = null;
                            //cbSublevel1.Text = "";
                            cbTutorsub1.Text = "";
                            LevelSub1.Text = "";
                            Sub1.Text = "No Selected";
                        }
                        else if (cbSublevel1.SelectedIndex == 3 || cbSublevel1.SelectedIndex == 4) ;
                        {

                            LevelSub1.Text = cbSublevel1.Text;
                                                    }
                    }
                    else if (cbTutorsub1.SelectedIndex == 0 || cbTutorsub1.SelectedIndex == 1 || cbTutorsub1.SelectedIndex == 2 || cbTutorsub1.SelectedIndex == 3)
                    {
                        Sub1.Text = cbTutorsub1.Text;
                        LevelSub1.Text = cbSublevel1.Text;
                    }
                }
                else if (cbTutorsub1.SelectedIndex == -1)
                {
                    MessageBox.Show("Pls selected level for subject1 first");
                }
            }
            else if (cbTutorsub1.SelectedIndex == -1 && cbSublevel1.SelectedIndex >-1 ) 
            {
                MessageBox.Show("Pls selected a subject first");
                cbSublevel1.SelectedItem = null;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cbTutorsub1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Sub1_Click(object sender, EventArgs e)
        {
           
        }

        private void cbSublevel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSublevel1.SelectedIndex > -1)
            {
                if (cbTutorsub2.SelectedIndex > -1)
                {
                    Sub2.Text = cbTutorsub2.Text;
                    if (cbSublevel2.SelectedIndex > -1)
                    {
                        if (cbTutorsub2.SelectedIndex == 4 || cbTutorsub2.SelectedIndex == 5 || cbTutorsub2.SelectedIndex == 6 || cbTutorsub2.SelectedIndex == 7
                            || cbTutorsub2.SelectedIndex == 8 || cbTutorsub2.SelectedIndex == 9 || cbTutorsub2.SelectedIndex == 10 || cbTutorsub2.SelectedIndex == 11)
                        {
                            if (cbSublevel2.SelectedIndex == 0 || cbSublevel2.SelectedIndex == 1 || cbSublevel2.SelectedIndex == 2)
                            {
                                MessageBox.Show("Subject you selected doesn't included in the level you selected");
                                cbSublevel2.SelectedItem = null;
                                cbTutorsub2.Text = "";
                                LevelSub2.Text = "";
                                Sub2.Text = "No Selected";
                            }
                            else if (cbSublevel2.SelectedIndex == 3 || cbSublevel2.SelectedIndex == 4) ;
                            {
                                if(cbTutorsub2.SelectedIndex > -1)
                                {
                                    LevelSub2.Text = cbSublevel2.Text;
                                }
                                else if(cbTutorsub2.SelectedIndex < 0)
                                {
                                    MessageBox.Show("Pls selected level for subject2 first");
                                    cbSublevel2.SelectedItem = null;
                                    LevelSub2.Text = "";
                                }
                            }
                        }
                        else if (cbTutorsub2.SelectedIndex == 0 || cbTutorsub2.SelectedIndex == 1 || cbTutorsub2.SelectedIndex == 2 || cbTutorsub2.SelectedIndex == 3)
                        {
                            Sub2.Text = cbTutorsub2.Text;
                            LevelSub2.Text = cbSublevel2.Text;
                        }
                    }
                    else if (cbTutorsub2.SelectedIndex < 0)
                    {
                        MessageBox.Show("Pls selected level for subject2 first");
                        cbSublevel2.SelectedItem = null;
                        LevelSub2.Text = "";
                    }
                }
                else if (cbTutorsub2.SelectedIndex == -1 && cbSublevel2.SelectedIndex > -1)
                {
                    MessageBox.Show("Pls selected a subject first");
                    cbSublevel2.SelectedItem = null;
                }
            }
            else if (cbSublevel1.SelectedIndex == -1)
            {
                cbSublevel2.SelectedItem = null;
                cbTutorsub2.Text = "";
                LevelSub2.Text = "";
                Sub3.Text = "No Selected";

            }
        }
        private void cbSublevel3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSublevel1.SelectedIndex > -1 && cbSublevel2.SelectedIndex > -1)
            {
                if (cbTutorsub3.SelectedIndex > -1)
                {
                    Sub3.Text = cbTutorsub3.Text;
                    if (cbSublevel3.SelectedIndex > -1)
                    {
                        if (cbTutorsub3.SelectedIndex == 4 || cbTutorsub3.SelectedIndex == 5 || cbTutorsub3.SelectedIndex == 6 || cbTutorsub3.SelectedIndex == 7
                            || cbTutorsub3.SelectedIndex == 8 || cbTutorsub3.SelectedIndex == 9 || cbTutorsub3.SelectedIndex == 10 || cbTutorsub3.SelectedIndex == 11)
                        {
                            if (cbSublevel3.SelectedIndex == 0 || cbSublevel3.SelectedIndex == 1 || cbSublevel3.SelectedIndex == 2)
                            {
                                MessageBox.Show("Subject you selected doesn't included in the level you selected");
                                cbSublevel3.SelectedItem = null;
                                //cbSublevel1.Text = "";
                                cbTutorsub3.Text = "";
                                LevelSub3.Text = "";
                                Sub3.Text = "No Selected";
                            }
                            else if (cbSublevel3.SelectedIndex == 3 || cbSublevel3.SelectedIndex == 4) ;
                            {
                                LevelSub3.Text = cbSublevel3.Text;
                            }
                        }
                        else if (cbTutorsub3.SelectedIndex == 0 || cbTutorsub3.SelectedIndex == 1 || cbTutorsub3.SelectedIndex == 2 || cbTutorsub3.SelectedIndex == 3)
                        {
                            Sub3.Text = cbTutorsub3.Text;
                            LevelSub3.Text = cbSublevel3.Text;
                        }
                    }
                    else if (cbTutorsub3.SelectedIndex < 0)
                    {
                        MessageBox.Show("Pls selected level for subject3 first");
                        cbSublevel3.SelectedItem = null;
                        LevelSub3.Text = "";
                    }

                }
                else if (cbTutorsub3.SelectedIndex == -1 && cbSublevel3.SelectedIndex > -1)
                {
                    MessageBox.Show("Pls selected a subject first");
                    cbSublevel3.SelectedItem = null;
                }
            }
            else if (cbSublevel1.SelectedIndex == -1 && cbSublevel2.SelectedIndex == -1)
            {
                cbSublevel3.SelectedItem = null;
                cbTutorsub3.Text = "";
                LevelSub3.Text = "";
                Sub3.Text = "No Selected";
            }
        }

        private void cbTutorsub2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSublevel1.SelectedIndex == -1)
            {
                MessageBox.Show("select the first subject first");
                cbTutorsub2.SelectedItem = null;
                LevelSub2.Text = "";
                Sub2.Text = "No Selected";
            }
        }

        private void cbTutorsub3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSublevel1.SelectedIndex == -1 || cbSublevel2.SelectedIndex == -1)
            {
                MessageBox.Show("select the first subject first");
                cbTutorsub3.SelectedItem = null;
                LevelSub3.Text = "";
                Sub3.Text = "No Selected";
            }
        }

        private void btnundo_Click(object sender, EventArgs e)
        {
            Assign_Subject assignsubjectpage = new Assign_Subject();
            this.Hide();
            assignsubjectpage.ShowDialog();
            this.Close();
        }
    }
}
