using System;
using System.Linq;
using System.Text;

namespace EmailValidator
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var command = Console.ReadLine();
            while (command!= "Complete")
            {
                var cmdAgrs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmdAgrs[0]=="Make" && cmdAgrs[1]== "Upper")
                {
                    input = input.ToUpper();
                    Console.WriteLine(input);
                }
                if (cmdAgrs[0] == "Make" && cmdAgrs[1] == "Lower")
                {
                    input = input.ToLower();
                    Console.WriteLine(input);
                }
                if (cmdAgrs[0]== "GetDomain")
                {
                    var count = int.Parse(cmdAgrs[1]);
                    PrintTheLastCount(input, count);
                }
                if (cmdAgrs[0]== "GetUsername")
                {
                    PrintUsername(input);
                }
                if (cmdAgrs[0]== "Replace")
                {                    
                    input = input.Replace(char.Parse(cmdAgrs[1]), '-');
                    Console.WriteLine(input);
                }
                if (cmdAgrs[0]== "Encrypt")
                {
                    EncryptInput(input);
                }
                command = Console.ReadLine();
            }
        }

        private static void EncryptInput(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write((int)input[i]+" ");
            }
            Console.WriteLine();
        }

        private static void PrintUsername(string input)
        {
            //o	Print the substring from the start of the Email until the @ symbol
            //o	If the Email doesn’t contain the @ symbol, print: 
            if (input.Contains('@'))
            {
                var indexOfSign = input.IndexOf('@');
                var substr = input.Substring(0, indexOfSign);
                Console.WriteLine(substr);
            }
            else
            {
                Console.WriteLine($"The email {input} doesn't contain the @ symbol.");
            }
        }

        private static void PrintTheLastCount(string input, int count)
        {
            for (int i = input.Length-count; i < input.Length; i++)
            {
                Console.Write(input[i]);
            }
            Console.WriteLine();
        }
    }
}
