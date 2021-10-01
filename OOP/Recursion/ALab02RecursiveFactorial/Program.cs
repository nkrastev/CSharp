using System;

namespace ALab02RecursiveFactorial
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));
        }

        private static int Factorial(int n)
        {
            if (n==1)
            {
                return 1;
            }
            return n * (Factorial(n - 1));
        }
    }
}
