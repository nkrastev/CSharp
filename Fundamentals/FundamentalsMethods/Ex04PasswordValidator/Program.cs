using System;

namespace Ex04PasswordValidator
{
    class Program
    {
        static void Main()
        {
            string password = Console.ReadLine();



            if (FirstRule(password) != true) { Console.WriteLine("Password must be between 6 and 10 characters"); }
            if (SecondRule(password) != true) { Console.WriteLine("Password must consist only of letters and digits"); }
            if (ThirdRule(password) != true) { Console.WriteLine("Password must have at least 2 digits"); }

            if (FirstRule(password) && SecondRule(password) && ThirdRule(password))
            {
                Console.WriteLine("Password is valid");
            }


            
        }

        static bool FirstRule(string input)
        {
            //6 – 10 characters (inclusive)
            if (input.Length > 10 || input.Length < 6)
            {                
                return false;
            }
            else return true;            
        }

        static bool SecondRule(string input)
        {
            //Consists only of letters and digits
            bool foundOtherElement = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]) || Char.IsLetter(input[i]))
                {
                    foundOtherElement = false;
                }
                else { foundOtherElement = true; break; }                
            }
            if (foundOtherElement==true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool ThirdRule(string input)
        {
            //Password must have at least 2 digits
            int digitCounter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    digitCounter++;
                }
            }
            if (digitCounter>=2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
