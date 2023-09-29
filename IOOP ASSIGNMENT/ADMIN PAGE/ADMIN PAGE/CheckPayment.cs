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
    public partial class CheckPayment : Form
    {
        static string studUserName;
        public CheckPayment()
        {
            InitializeComponent();

        }
            public CheckPayment(string un)
            {
                InitializeComponent();
                studUserName = un;
            }

            private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckPayment_Load(object sender, EventArgs e)
        {
            ClassReceipt receipt = new ClassReceipt(studUserName);
            ClassReceipt.ViewPaymentInfo(receipt);
            labCheckPayName.Text = receipt.StudentName;
            labCheckPayID.Text = Convert.ToString(receipt.StudenIcPass);
            labCheckFees1.Text = receipt.SubjectCharge1.ToString() + "RM";
            labCheckSub1.Text = receipt.SubjectName1;
            labCheckPayAmount.Text = receipt.SubjectCharge1.ToString()+ "RM";

            if (receipt.SubjectName2 != null && receipt.SubjectName2 != "Empty") {
                labCheckSub2.Text =receipt.SubjectName2;
                labCheckFees2.Text = receipt.SubjectCharge2.ToString() + "RM";
                labCheckPayAmount.Text = (Math.Round(receipt.SubjectCharge1 + receipt.SubjectCharge2, 2)).ToString()+"RM";
            }
            if (receipt.SubjectName3 != null && receipt.SubjectName3 != "Empty")
            {
                labCheckSub2.Text = receipt.SubjectName3;
                labCheckFees2.Text = receipt.SubjectCharge3.ToString()+"RM";
                labCheckPayAmount.Text = (Math.Round(receipt.SubjectCharge1 + receipt.SubjectCharge2 + receipt.SubjectCharge3, 2)).ToString()+ "RM";

            }





        }
    }
}
