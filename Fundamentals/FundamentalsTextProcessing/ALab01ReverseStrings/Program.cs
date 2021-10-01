using System;
using System.Text;

namespace ALab01ReverseStrings
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            while (input!="end")
            {                
                Console.WriteLine($"{input} = {ReverseItem(input)}");
                input = Console.ReadLine();
            }
        }

        private static string ReverseItem(string input)
        {
            //string reversedWord = "";
            StringBuilder sb = new StringBuilder();
            for (int i = input.Length-1; i >= 0; i--)
            {
                sb.Append(input[i]);
            }
            return sb.ToString();
        }
    }
}
