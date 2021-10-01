using System;

namespace Ex08BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfKegs = int.Parse(Console.ReadLine());
            string biggestModel="";
            decimal biggestVolume = 0;

            for (int i = 0; i < numberOfKegs; i++)
            {
                string currentModel = Console.ReadLine();
                float currentRadius = float.Parse(Console.ReadLine());
                int currentHeight = int.Parse(Console.ReadLine());
                decimal volumeOfKeg = (decimal)(Math.PI * currentRadius * currentRadius * currentHeight);

                if (volumeOfKeg>biggestVolume)
                {
                    biggestVolume = volumeOfKeg;
                    biggestModel = currentModel;
                }
            }

            Console.WriteLine(biggestModel);
        }
    }
}
