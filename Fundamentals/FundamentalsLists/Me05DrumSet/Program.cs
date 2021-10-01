using System;
using System.Collections.Generic;
using System.Linq;

namespace Me05DrumSet
{
    class Program
    {
        static void Main()
        {
            //input
            double savings = double.Parse(Console.ReadLine());            
            List<int> initialDrumSet = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> currentDrumSet = initialDrumSet.ToList();


            //commands
            string command = Console.ReadLine();           
            int hitPower = 0;
            
            while (command!= "Hit it again, Gabsy!")
            {
                hitPower = int.Parse(command);

                for (int i = 0; i < currentDrumSet.Count; i++)
                {
                    if (currentDrumSet[i]>hitPower)
                    {
                        //the current drum is OK, decrease the quality
                        currentDrumSet[i] -= hitPower;
                    }
                    else
                    {
                        //drum set has to be replaced if there are enought money
                        if (savings>=initialDrumSet[i]*3.0)
                        {
                            //buy new drum
                            savings -= initialDrumSet[i] * 3.0;
                            currentDrumSet[i] = initialDrumSet[i];
                        }
                        else
                        {
                            //not enought money, we dont remove it cause will result mix in indexes, set the value to -1
                            currentDrumSet[i] = -1;
                        }
                    }                    
                }
                command = Console.ReadLine();                                
                
            }

            //output   
            for (int i = 0; i < currentDrumSet.Count; i++)
            {
                if (currentDrumSet[i]>=0)
                {
                    Console.Write(currentDrumSet[i]+" ");
                }
            }
            Console.WriteLine();            
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
