using System;
using System.Text;

namespace Ex04CaesarCipher
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            EncryptText(input, sb);
            Console.WriteLine(sb.ToString());
        }

        private static StringBuilder EncryptText(string input, StringBuilder sb)
        {
            for (int i = 0; i < input.Length; i++)
            {               
                sb.Append((char)(input[i] + (char)3));
            }

            return sb;
        }
    }
}
