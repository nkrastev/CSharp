using System;

namespace TheHuntingGames
{
    class Program
    {
        static void Main()
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterDayPerson = double.Parse(Console.ReadLine());
            double foodDayPerson = double.Parse(Console.ReadLine());

            double totalFood = days * players * foodDayPerson;
            double totalWater = days * players * waterDayPerson;

            bool areReady = true;

            for (int i = 1; i <= days; i++)
            {
                double dailyEnergeLoss = double.Parse(Console.ReadLine());

                groupEnergy -= dailyEnergeLoss;

                if (groupEnergy<=0)
                {
                    areReady = false;
                    break;
                }

                if (i%2==0)
                {
                    groupEnergy += groupEnergy * 0.05;
                    totalWater -= totalWater * 0.3;
                }

                if (i%3 ==0)
                {
                    totalFood = totalFood - totalFood / players;
                    groupEnergy += groupEnergy * 0.1;
                }
            }

            if (areReady)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
            }
        }
    }
}
