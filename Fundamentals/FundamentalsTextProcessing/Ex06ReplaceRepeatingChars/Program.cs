using System;
using System.Text;

namespace Ex06ReplaceRepeatingChars
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            
            for (int i = 0; i < input.Length-1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    input.Remove(i, 1);
                }
                else
                {
                    sb.Append(input[i]);
                }                    
            }

            //add last symbols           
            sb.Append(input[input.Length - 1]);

            Console.WriteLine(sb.ToString());
            
            
        }
    }
}
