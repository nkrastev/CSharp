using System;

namespace Ex09PalindromeIntegers
{
    class Program
    {
        static void Main()
        {

            string command = Console.ReadLine();
            
            while (command!="END")
            {                            
                int currentNumber = int.Parse(command);
                Console.WriteLine(PalindromeCheck(currentNumber).ToString().ToLower());
                command = Console.ReadLine();
            }
        }

        static bool PalindromeCheck(int n)
        {
            bool result = false;
            string numberStr = n.ToString();
            for (int i = 0; i < numberStr.Length; i++)
            {
                if (numberStr[i]==numberStr[numberStr.Length-1-i])
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}
