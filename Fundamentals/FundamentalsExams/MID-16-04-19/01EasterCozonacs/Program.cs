using System;

namespace _01EasterCozonacs
{
    class Program
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            double priceKGfloor = double.Parse(Console.ReadLine());

            double pricePackEggs = priceKGfloor * 0.75;
            double price250milk= (priceKGfloor+priceKGfloor*0.25)/ 4;

            double priceCozunac = priceKGfloor + pricePackEggs + price250milk;
            int eggsNumbers=0;
            int cozunacsNumber = 0;

            while (budget>=priceCozunac)
            {
                budget -= priceCozunac;
                eggsNumbers += 3;
                cozunacsNumber++;
                if (cozunacsNumber % 3==0)
                {                    
                    eggsNumbers -= cozunacsNumber - 2;
                }
            }

            Console.WriteLine($"You made {cozunacsNumber} cozonacs! Now you have {eggsNumbers} eggs and {budget:f2}BGN left.");
        }
    }
}
