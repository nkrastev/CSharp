using System;

namespace Ex07WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            //water tank with capacity of 255 liters
            int numberOfLines = int.Parse(Console.ReadLine());
            double waterInTank = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                double currentInputLiters = int.Parse(Console.ReadLine());

                if (currentInputLiters<=255-waterInTank)
                {
                    waterInTank += currentInputLiters;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(waterInTank);
        }
    }
}
