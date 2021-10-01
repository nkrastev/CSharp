using System;
using System.Numerics;

namespace Ex11Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberSnowballs = int.Parse(Console.ReadLine());
            BigInteger highestValue = 0;
            int highestSnow = 0;
            int highestTime = 0;
            int highestQuality = 0;

            for (int i = 0; i < numberSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());


                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime),snowballQuality);

                if (snowballValue > highestValue)
                {
                    highestValue = snowballValue;
                    highestSnow = snowballSnow;
                    highestTime = snowballTime;
                    highestQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{highestSnow} : {highestTime} = {highestValue} ({highestQuality})");
        }
    }
}
