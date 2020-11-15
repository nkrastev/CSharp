using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main()
        {
            //how many cars can pass on green turn
            int n = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int passedCars = 0;

            string command = Console.ReadLine();

            while (command.ToLower()!="end")
            {
                if (command.ToLower()!="green")
                {
                    //add car to queue
                    cars.Enqueue(command);
                }

                if (command.ToLower()=="green")
                {
                    // N cars passed throught junction
                    for (int i = 1; i <= n; i++)
                    {
                        //if queue is empty, break, else pass car
                        if (cars.Count>=1)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            passedCars++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");

        }
    }
}
