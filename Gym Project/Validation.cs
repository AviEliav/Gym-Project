using System;
using System.Text.RegularExpressions;

namespace Gym_Project
{
    internal class Validation
    {

        public string ValidId(string value)
        {
            while (value.Length != 9 || !int.TryParse(value, out int num))
            {

                Console.WriteLine("\nYou enter wrong ID number, please try again!\nDon't forget to put 9 digits and use only numbers!");
                value = Console.ReadLine();
            }
            return value;
        }



        public string ValidFirstName(string value)
        {
            while (value.Length < 2)
            {
                Console.WriteLine("\nYou enter wrong Name, please try again!\nDon't forget to put more than 2 characters!");
                value = Console.ReadLine();
            }
            return value;
        }



        public string ValidLastName(string value)
        {
            while (value.Length < 2)
            {
                Console.WriteLine("\nYou enter wrong Last Name, please try again!\nDon't forget to put more than 2 characters!");
                value = Console.ReadLine();
            }
            return value;
        }




        public char ValidGender(char value)
        {
            while (value != 'M' && value != 'm' && value != 'F' && value != 'f' && value != 'O' && value != 'o')
            {
                Console.WriteLine("\nYou enter unknown character for gender, please try again!\nremember you can use only this options: F, M, O.");
                value = Console.ReadLine()[0];
            }
            return value;
        }




        public string ValidDOB(string value)
        {
            while (!(value.Length == 10 && value[2] == '/' && value[5] == '/' && DateTime.TryParse(value, out DateTime date)))
            {
                Console.WriteLine("\nThe format of the date is invalid!\nPlease try again!");
                value = Console.ReadLine();
            }
            return value;
        }



        public string ValidAddress(string value)
        {
            while (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value)) // "           "; ""; 
            {
                Console.WriteLine("\nYou have entered an empty address.\nPlease fil it out, and try again.");
                value = Console.ReadLine();
            }
            return value;
        }




        public string ValidPhoneNumber(string value)
        {
            while (value[0] != '0' || !int.TryParse(value, out int num))
            {
                value = GetValueFromUser("\nYou enter wrong phone, please try again!\ndon't forget to use only numbers and start with 0.");

            }
            return value;
        }




        public string ValidEmail(string value)
        {
            while (!value.Contains('@'))
            {
                Console.WriteLine("\nYou enter wrong email, please try again!\ndon't forget to use @");
                value = Console.ReadLine();
            }
            return value;
        }



       
        public double ValidHeight(string value)
        {
            double num;
            while (true)
            {
                if (!double.TryParse(value, out num))
                {
                    value = GetValueFromUser("\nYou have entered wrong height, please try again!");
                    continue;
                }
                if (num < 1.2 || num > 3)
                {
                    value = GetValueFromUser("\nYou have entered wrong height, please try again!");
                    continue;
                }
                break;

            }
            return num;

        }

        private string GetValueFromUser(string messageToUser)
        {
            Console.WriteLine(messageToUser);
            return Console.ReadLine();
        }

        public double ValidWeight(string value)
        {
            double num;
            while (true)
            {
                if (!double.TryParse(value, out num))
                {
                    value = GetValueFromUser("\nYou have entered wrong weight , please try again!");
                    continue;
                }
                if (num <30 || num > 300)
                {
                    value = GetValueFromUser("\nYou have entered wrong weight , please try again!");

                    continue;
                }
                break;               
            }
            return num;
        }




        public string ValidBankName(string value)
        {
            Regex pattern = new Regex(@"^\w{2,20}$");

            while (!pattern.IsMatch(value) || int.TryParse(value, out int num))
            {
                Console.WriteLine("\nWrong bank name, please try again");
                value = Console.ReadLine();
            }
            return value;
        }



        public string ValidBankBranch(string value)
        {
            while (!int.TryParse(value, out int num))
            {
                Console.WriteLine("\nWrong branch number, please try again.");
                value = Console.ReadLine();
            }
            return value;
        }



        public string ValidAccountNumber(string value)
        {
            while (!int.TryParse(value, out int num))
            {
                Console.WriteLine("\nwrong account number, please try again.");
                value = Console.ReadLine();
            }
            return value;
        }



        public string ValidProfession(string value)
        {
            Regex professoin = new Regex(@"^\w{2,20}");

            while (!professoin.IsMatch(value) || int.TryParse(value, out int num))
            {
                Console.WriteLine("\nWrong profession, please try again.");
                value = Console.ReadLine();
            }
            return value;
        }








    }
}
