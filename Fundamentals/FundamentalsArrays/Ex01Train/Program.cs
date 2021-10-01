using System;

namespace MEx01Train
{
    class Program
    {
        static void Main()
        {
            int numberOfWagons = int.Parse(Console.ReadLine());
            int[] wagons = new int[numberOfWagons];
            int passangers = 0;

            for (int i = 0; i < wagons.Length; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
                passangers += wagons[i];
            }

            for (int i = 0; i < wagons.Length; i++)
            {
                Console.Write(wagons[i]+" ");
            }
            Console.WriteLine();
            Console.WriteLine(passangers);
        }
    }
}
