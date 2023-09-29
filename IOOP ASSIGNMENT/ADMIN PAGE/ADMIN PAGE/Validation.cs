using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADMIN_PAGE
{
    internal class Validation
    {

        //time checker 
        public static bool CheckTime(string time)
        {
            Regex timeRegex = new Regex(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9](:[0-5][0-9])?$", RegexOptions.IgnoreCase);
            return timeRegex.IsMatch(time);
        }

        //subject_fee checker 
        public static bool CheckSubject_Fee(string Subject_Fee)
        {
            decimal number;
            return Decimal.TryParse(Subject_Fee, out number);
        }

        //check single empty textbox
        public static bool checkTextBoxes(string txtbox1 = "Empty", string txtbox2 = "Empty", string txtbox3 = "Empty", string txtbox4 = "Empty", string txtbox5 = "Empty", string txtbox6 = "Empty", string txtbox7 = "Empty", string txtbox8 = "Empty", string txtbox9 = "Empty", string txtbox10 = "Empty")
        {
            List<string> checkempty = new List<string>();
            checkempty.Add(txtbox1);
            checkempty.Add(txtbox2);
            checkempty.Add(txtbox3);
            checkempty.Add(txtbox4);
            checkempty.Add(txtbox5);
            checkempty.Add(txtbox6);
            checkempty.Add(txtbox7);
            checkempty.Add(txtbox8);
            checkempty.Add(txtbox9);
            checkempty.Add(txtbox10);
            foreach (string str in checkempty)
            {
                if (str != "Empty")
                {
                    if (str == "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static string getCellFromGridView(DataGridView gd, int number)
        {
            string cellValue = "";



            for (int i = 0; i < gd.Rows.Count; i++)
            {
                if (gd.Rows[i].Selected == true)
                {
                    cellValue = gd.Rows[i].Cells[number].Value.ToString();
                    break;
                }
            }

            return cellValue;
        }

        public static bool checkSelected(DataGridView gd)
        {
            foreach (DataGridViewRow row in gd.Rows)
            {
                if (row.Selected == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
