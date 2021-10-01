using System;
using System.Collections.Generic;
using System.Linq;

namespace Me02CarRace
{
    class Program
    {
        static void Main()
        {
            List<int> arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            double leftTime = 0;
            double rightTime = 0;

            //left car
            for (int i = 0; i < arr.Count/2; i++)
            {
                leftTime += arr[i];
                if (arr[i]==0)
                {
                    leftTime *= 0.8;
                }
               
            }

            //right car
            for (int i = arr.Count - 1; i > arr.Count / 2; i--)
            {
                rightTime += arr[i];
                if (arr[i] == 0)
                {
                    rightTime *= 0.8;
                }                
            }
            //The winner is {left/right} with total time: {total time}

            if (leftTime>rightTime)
            {
                Console.WriteLine($"The winner is right with total time: {rightTime}");
            }
            else
            {
                Console.WriteLine($"The winner is left with total time: {leftTime}");
            }

        }
    }
}
