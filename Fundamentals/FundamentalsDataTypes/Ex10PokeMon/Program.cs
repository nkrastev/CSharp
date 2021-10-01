using System;

namespace Ex10PokeMon
{
    class Program
    {
        static void Main()
        {
            int pokePower = int.Parse(Console.ReadLine());
            double percentCheck = (double)pokePower/2;
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int pokedTargets = 0;

            while (pokePower>=distance)
            {
                pokedTargets++;
                pokePower -= distance;
                if (pokePower==percentCheck && exhaustionFactor!=0)
                {
                    
                        pokePower /= exhaustionFactor;
                    
                }


                


            }

            Console.WriteLine(pokePower);
            Console.WriteLine(pokedTargets);

        }
    }
}
