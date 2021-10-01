using System;
using System.Linq;
using System.Text;

namespace ALab2RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {                
                for (int j = 0; j < input[i].Length; j++)
                {
                    sb.Append(input[i]);
                }
            }

            Console.WriteLine(sb);

        }
    }
}
