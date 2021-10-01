using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ex02CharacterMultiplier
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string str1 = input[0];
            string str2 = input[1];
            
            int sum = MultiplyAndSum(str1, str2);

            if (str1.Length > str2.Length)
            {                
                for (int i = Math.Min(str1.Length, str2.Length); i < Math.Max(str1.Length, str2.Length); i++)
                {
                    sum += str1[i];
                }
            }

            if (str2.Length > str1.Length)
            {
                for (int i = Math.Min(str1.Length, str2.Length); i < Math.Max(str1.Length, str2.Length); i++)
                {
                    sum += str2[i];
                }
            }


            Console.WriteLine(sum);
        }

        private static int MultiplyAndSum(string str1, string str2)
        {
           int sum = 0;

           for (int i = 0; i < Math.Min(str1.Length, str2.Length); i++)
            {
                sum += str1[i] * str2[i];
            }           

            return sum;
        }
    }
}
