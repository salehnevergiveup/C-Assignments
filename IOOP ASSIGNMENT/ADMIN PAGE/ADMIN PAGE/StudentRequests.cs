using System;
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
    public partial class StudentRequests : Form
    {
        string name, username, gender;
        public StudentRequests()
        {
            InitializeComponent();
        }

        public StudentRequests(string n, string un, string g)
        {
            InitializeComponent();
            name = n; 
            username = un;
            gender = g;
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckPayment checkPayment = new CheckPayment();
            checkPayment.ShowDialog();
        }

        private void btnRequistEdit_Click(object sender, EventArgs e)
        {
            // under process
            if (!Recepvalidation.checkSelected(dataGridViewRequist)) { MessageBox.Show("Sory,!!! you have to select row first"); return; }
            Receptionist receptionistId = new Receptionist(username);
            Receptionist.viewProfile(receptionistId);
            int recepID = receptionistId.ReceptionistID1;
            string status = "Under process";
            DateTime compDate = DateTime.Today;
            string userNameStud = Recepvalidation.getCellFromGridView(dataGridViewRequist, 1);
         
            Request.updateRequestInfo(recepID, compDate, status, userNameStud);

            string newSubjectOne = Recepvalidation.getCellFromGridView(dataGridViewRequist, 2);
            string newSubjectTwo = Recepvalidation.getCellFromGridView(dataGridViewRequist, 3);
            string newSubjectThree = Recepvalidation.getCellFromGridView(dataGridViewRequist, 4);
            
            UpdateSubjects updateSubjects = new UpdateSubjects(username, userNameStud , newSubjectOne, newSubjectTwo, newSubjectThree);
            updateSubjects.ShowDialog();
        }

     

        private void btnRequestPayment_Click(object sender, EventArgs e)
        {
            //under process 
            if (!Recepvalidation.checkSelected(dataGridViewRequist)) { MessageBox.Show("Sory,!!! you have to select row first"); return;}
            Receptionist receptionistId = new Receptionist(username);
            Receptionist.viewProfile(receptionistId);

            int recepID = receptionistId.ReceptionistID1;
            string status = "Under process";
            DateTime compDate = DateTime.Today;
            string userNameStud = Recepvalidation.getCellFromGridView(dataGridViewRequist, 1);
             Request.updateRequestInfo(recepID, compDate, status, userNameStud);
            CheckPayment checkPayment = new CheckPayment(userNameStud);
            checkPayment.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            btnMax.Visible = false;
            btnNormal.Visible = true;
            btnNormal.Location = btnMax.Location;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Normal;
            btnMax.Visible = true;
            btnNormal.Visible = false;
        }

        private void btnRequistSeach_Click(object sender, EventArgs e)
        {
            
            Recepvalidation.searchWithinGird(dataGridViewRequist, labMatched, txtRequestSearch.Text,0,1);

        }

        private void btnRequistReject_Click(object sender, EventArgs e)
        {
            /// status rejected 
            if (!Recepvalidation.checkSelected(dataGridViewRequist)) {MessageBox.Show("Sory,!!! you have to select row first"); return; }
            Receptionist receptionistId = new Receptionist(username);
            Receptionist.viewProfile(receptionistId);

            int recepID = receptionistId.ReceptionistID1;
            string status = "rejected";
            DateTime compDate = DateTime.Today;
           string userNameStud =  Recepvalidation.getCellFromGridView(dataGridViewRequist, 1); 
            Request.updateRequestInfo(recepID, compDate, status, userNameStud); 
        }

        private void StudentRequests_Load(object sender, EventArgs e)
        {
            labGreating.Text = $"Welcome {name}";
            dataGridViewRequist.DataSource = Request.ViewRequistInfo(); 
        }
    }
}
