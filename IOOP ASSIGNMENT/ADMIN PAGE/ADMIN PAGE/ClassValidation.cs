using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADMIN_PAGE
{
    internal class ClassValidation
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
            if ((chbxlist as CheckedListBox).CheckedItems.Count > start && (chbxlist as CheckedListBox).CheckedItems.Count < end)
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
    }
}
