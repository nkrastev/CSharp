using System;

namespace _1DisneylandJourney
{
    class Program
    {
        static void Main()
        {
            double journeyCosts = double.Parse(Console.ReadLine());
            int numberMonths = int.Parse(Console.ReadLine());

            double savedMoney = 0;
            double moneyPerMonth = journeyCosts * 0.25;

            for (int i = 1; i <= numberMonths; i++)
            {                                
                if (i>1 && i % 2 !=0)
                {
                    //clothes
                    savedMoney -= savedMoney * 0.16;
                }

                if (i % 4==0)
                {
                    //bonus
                    savedMoney += savedMoney * 0.25;
                }

                //saving per month
                savedMoney += moneyPerMonth;
            }

            if (savedMoney>=journeyCosts)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {(savedMoney-journeyCosts):f2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {(journeyCosts-savedMoney):f2}lv. more.");
            }
        }
    }
}
