using System;
using System.Collections.Generic;
using System.Linq;

namespace ALab06ParkingLot
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var parking = new HashSet<string>();
            while (input!="END")
            {
                var commands = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (commands[0]=="IN")
                {
                    parking.Add(commands[1]);
                }
                else
                {
                    if (parking.Contains(commands[1]))
                    {
                        parking.Remove(commands[1]);
                    }
                }
                input = Console.ReadLine();
            }
            if (parking.Count>0)
            {
                Console.WriteLine(String.Join("\n",parking));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
