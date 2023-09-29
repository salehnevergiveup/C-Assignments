using System;
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


    
    public partial class receipt : Form

    {
        private string StudentName, StudPass, date, PayStudMonth, PayStudLevel, SubjectName1, Sub1Fees, SubjectName2, Sub2Fees, SubjectName3, Sub3Fees, TotalPayment;
        public receipt()
        {
            InitializeComponent();
        }
        public receipt(string conStudentName,string conStudPass, DateTime condate, string conPayStudMonth, string conPayStudLevel, string conSubjectName1, string conSub1Fees, string conSubjectName2, string conSub2Fees, string conSubjectName3, string conSub3Fees)
        {
            InitializeComponent();
            StudentName = conStudentName;
            StudPass = conStudPass;
            PayStudMonth = conPayStudMonth;
            PayStudLevel = conPayStudLevel;
            SubjectName1 = conSubjectName1;
            Sub1Fees = conSub1Fees;
            TotalPayment = conSub1Fees; 
            date = condate.ToString();



             if(conSubjectName2 != "")
            {
               SubjectName2 = conSubjectName2;
               Sub2Fees= conSub2Fees;
                TotalPayment = (Convert.ToDouble(Sub1Fees) + Convert.ToDouble(Sub2Fees)).ToString();
            }
            if(conSubjectName3 != "")
            {
                SubjectName3= conSubjectName3;
                Sub3Fees= conSub3Fees;
                TotalPayment = (Convert.ToDouble(conSub1Fees) + Convert.ToDouble(conSub2Fees) + Convert.ToDouble(conSub3Fees)).ToString();

            }
        }


        private void receipt_Load(object sender, EventArgs e)
        {
            Random random = new Random();

            labReceiptId.Text =Convert.ToString(random.Next(100000));
            labStudName.Text = StudentName;
            labPayStudPass.Text = StudPass;
            labPayDate.Text = date;
            labPaymentMonth.Text = PayStudMonth;
            labPayStudLevel.Text = PayStudLevel;
            labPaySubjectOne.Text = Sub1Fees + "RM" ;
            if (Sub2Fees != "") labPaySubjectTwo.Text = Sub2Fees + "RM";
            if (Sub3Fees != "") labPaySubjectThree.Text = Sub3Fees + "RM";
            labSubjectName1.Text = SubjectName1;
            if (SubjectName2 != "") labSubjectName2.Text = SubjectName2;
            if (SubjectName3 != "") labSubjectName3.Text = SubjectName3;
            labPayAmount.Text = TotalPayment + "RM";




        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
