using System;

namespace CookingMasterClass
{
    class Program
    {
        static void Main()
        {
            //input
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double pFlour = double.Parse(Console.ReadLine());
            double pEgg = double.Parse(Console.ReadLine());            
            double pApron = double.Parse(Console.ReadLine());
            //calculation
            int freePacks = students / 5;
            double neededMoney = pApron * (students + Math.Ceiling(students*0.2)) + pEgg * 10 * (students) + pFlour * (students - freePacks);
            //output
            if (neededMoney<=budget)
            {
                Console.WriteLine($"Items purchased for {neededMoney:f2}$.");
            }
            else
            {
                Console.WriteLine($"{(neededMoney-budget):f2}$ more needed.");
            }          
        }
    }
}
