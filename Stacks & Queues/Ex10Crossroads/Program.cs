using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main()
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());
            int passedCars = 0;
            bool isCrash = false;
            Queue<string> cars = new Queue<string>();
            

            string command = Console.ReadLine();
            while (command!="END")
            {
                int secondsForPass = greenLightSeconds;
                if (command=="green")
                {
                    //cars are passing if there are any in Queue
                    if (cars.Count>0)
                    {
                        while (secondsForPass>0 && cars.Count>0)
                        {
                            //car passes at green while there is time and if there are cars
                            if (secondsForPass>=cars.Peek().Length)
                            {
                                secondsForPass -= cars.Peek().Length;
                                cars.Dequeue();
                                passedCars++;
                            }
                            else
                            {
                                break;
                            }                            
                        }
                        if (secondsForPass>0 && cars.Count>0)
                        {
                            //new car enters the junction with the rest seconds
                            if (secondsForPass+freeWindowSeconds>=cars.Peek().Length)
                            {
                                //the car passes at the rest second + the free window
                                passedCars++;
                            }
                            else
                            {
                                //crash at rest seconds + free windows
                                int hitAtIndex = secondsForPass + freeWindowSeconds;
                                string carModel = cars.Peek();
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{carModel} was hit at {carModel[hitAtIndex]}.");
                                isCrash = true;
                                break;
                            }
                        }

                    }
                }
                else
                {
                    //add car to queue
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            if (!isCrash)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCars} total cars passed the crossroads.");
            }
            
        }
    }
}
