using System;

namespace Mo05MultiplicationSign
{
    class Program
    {
        static void Main()
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());

            int counterNegative = 0;
            if (num1<0)
            {
                counterNegative++;
            }
            if (num2<0)
            {
                counterNegative++;
            }
            if (num3<0)
            {
                counterNegative++;
            }

            if (num1==0 || num2==0 || num3==0)
            {
                Console.WriteLine("zero");
            }
            else if (num1 > 0 && num2 > 0 && num3 > 0)
            {
                Console.WriteLine("positive");
            }
            else if(counterNegative%2==0)
            {
                Console.WriteLine("positive");
            }
            else
            {
                Console.WriteLine("negative");
            }
        }
    }
}
