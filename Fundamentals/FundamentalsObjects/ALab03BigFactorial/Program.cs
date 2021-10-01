using System;
using System.Numerics;

namespace ALab03BigFactorial
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factoriel = 1;

            for (int i = 1; i <= n; i++)
            {
                factoriel *= i;
            }

            Console.WriteLine(factoriel);
        }
    }
}
