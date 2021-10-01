using System;

namespace Mo03FloatingEquality
{
    class Program
    {
        static void Main()
        {
            decimal numberA = decimal.Parse(Console.ReadLine());
            decimal numberB = decimal.Parse(Console.ReadLine());

           
            decimal difference = numberA - numberB;
            if (Math.Abs(difference) < (decimal)0.000001)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
