using System;

namespace Pirates
{
    class Program
    {
        static void Main()
        {
            //input
            int days = int.Parse(Console.ReadLine());
            int plunderPerDay = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());
            double totalPlunder = 0;
            //calculations
            for (int i = 1; i <=days; i++)
            {
                totalPlunder += plunderPerDay;
                if (i % 3==0)
                {
                    totalPlunder += plunderPerDay * 0.5;
                }
                if (i % 5 == 0)
                {
                totalPlunder -= totalPlunder * 0.3;
                }
            }
            //output
            if (totalPlunder>=expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                if (expectedPlunder==0)
                {
                    Console.WriteLine($"Collected only 0% of the plunder.");
                }
                else
                {
                    Console.WriteLine($"Collected only {totalPlunder / expectedPlunder * 100:f2}% of the plunder.");
                }
                
            }
        }
    }
}
