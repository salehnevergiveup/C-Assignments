using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADMIN_PAGE
{
    internal class Recepvalidation
    {
        //Email Checkers
        public static bool CheckEmail(string email)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
            return emailRegex.IsMatch(email);

        }

        //name checker
        public static bool checkName(string name)
        {
            Regex validName = new Regex(@"^[\p{L}\p{M}' \.\-]+$");
            return validName.IsMatch(name);
        }
        //check single empty textbox
        //username checker 
        //At least one letter or number
        public static bool checkUsername(string user_name)
        {
            Regex validName = new Regex(@"^[a-zA-Z0-9]+$");
            return validName.IsMatch(user_name);
        }
        //username checker end 


        public static bool checkTextBoxes(string txtbox1 = "Empty", string txtbox2 = "Empty", string txtbox3 = "Empty", string txtbox4 = "Empty", string txtbox5 = "Empty", string txtbox6 = "Empty")
        {
            List<string> checkempty = new List<string>();
            checkempty.Add(txtbox1);
            checkempty.Add(txtbox2);
            checkempty.Add(txtbox3);
            checkempty.Add(txtbox4);
            checkempty.Add(txtbox5);
            checkempty.Add(txtbox6);
            foreach (string str in checkempty)
            {
                if (str == "")
                {
                    return false;

                }
            }

            return true;


        }



        // password and conf password checker
        public static bool passwordChecker(string pas1, string pas2)
        {
            if (pas1 == pas2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //password  length checker
        public static bool lengthChecker(string password)
        {
            if (password.Length >= 8 && password.Length <= 15)
            {
                return true;



            }

            return false;
        }

        //number of the subjects checker
        public static bool checkBoxCheker(Control chbxlist, int start, int end)
        {
            if ((chbxlist as CheckedListBox).CheckedItems.Count >= start && (chbxlist as CheckedListBox).CheckedItems.Count <= end)
            {
                return true;
            }
            else
                return false;
        }



        //Empty string Checker
        public static List<int> checkAllTextBox(Control textboxes)
        {
            // list to store the index of the empty textboxes
            List<int> textboxIndex = new List<int>();
            int counter = 0;
            foreach (var i in textboxes.Controls)
            {
                if (i is TextBox)
                {
                    if ((i as TextBox).Text == "")
                    {
                        textboxIndex.Add(counter);
                        return textboxIndex;
                    }

                }
                counter++;

            }
            return textboxIndex;
        }



        //check the radio buttons

        public static bool radioButtonsChecker(Control radioContiner)
        {
            foreach (Control cont in radioContiner.Controls)
            {
                if ((cont as RadioButton).Checked)
                {
                    return true;

                }

            }



            return false;
        }


        public static void searchWithinGird(DataGridView gd, Control lab, string text, int number1 , int number2)
        {
            int counter = 0;
            for (int i = 0; i < gd.Rows.Count; i++)

            {
                    if (gd.Rows[i].Cells[number1].Value.ToString() == text)
                    {
                        counter++;
                        gd.Rows[i].Selected = true;
                    }
                if (gd.Rows[i].Cells[number2].Value.ToString() == text)
                {
                    counter++;
                    gd.Rows[i].Selected = true;
                }




            }
             lab.Text = $"{counter} Matched!!!!";
        }


        public static bool checkSelected(DataGridView gd)
        {
           foreach(DataGridViewRow row in gd.Rows)
            {
                if(row.Selected == true)
                {
                    return true;
                }
            }
            return false;
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









    }
}

