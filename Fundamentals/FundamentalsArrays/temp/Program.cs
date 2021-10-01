using System;
using System.Linq;

namespace temp
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 1; i <= count; i++)
            {
                long[] arr = Console.ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();

                long num1 = Math.Abs(arr[0]);
                long num2 = Math.Abs(arr[1]);

                string num1ToStr = num1.ToString();
                string num2ToStr = num2.ToString();
                long sum1 = 0;
                long sum2 = 0;

                for (int firstNum = 0; firstNum < num1ToStr.Length; firstNum++)
                {
                    long current1 = num1 % 10;
                    sum1 += current1;
                    if (num1 > 0)
                    {
                        num1 /= 10;

                    }
                    
                }
                for (int secondNum = 0; secondNum < num2ToStr.Length; secondNum++)
                {
                    long current2 = num2 % 10;
                    sum2 += current2;
                    if (num2 > 0)
                    {
                        num2 /= 10;

                    }
                    
                }

                if (sum1 >= sum2)
                {
                    Console.WriteLine(sum1);
                }
                else
                {
                    Console.WriteLine(sum2);
                }
            }
        }
    }
}
