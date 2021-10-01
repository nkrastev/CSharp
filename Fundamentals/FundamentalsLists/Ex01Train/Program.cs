using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex01Train
{
    class Program
    {
        static void Main()
        {
            //input
            List<int> wagonsList = ReadListOfWagons();
            int maxWagonCapacity = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0]!="end")
            {
                if (command[0]=="Add")
                {
                    //Add {passengers} – add a wagon to the end with the given number of passengers.
                    int pax = int.Parse(command[1]);
                    AddWagonWithPax(wagonsList,pax,maxWagonCapacity);

                }
                else
                {
                    //{passengers} - find an existing wagon to fit every passenger, starting from the first wagon.
                    int paxToFit = int.Parse(command[0]);                    
                    FindExistingWagon(wagonsList,paxToFit, maxWagonCapacity);

                }
                command = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(String.Join(" ", wagonsList));
            
        }

        private static List<int> FindExistingWagon(List<int> wagons, int paxToFit, int maxCapacity)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                if (maxCapacity-wagons[i]>=paxToFit)
                {
                    wagons[i] += paxToFit;
                    break;
                }
            }

            return wagons;
        }

        private static List<int> AddWagonWithPax(List<int> wagons, int passangers, int maxCapacity)
        {
            if (passangers<=maxCapacity)
            {
                wagons.Add(passangers);
            }
            return wagons;
        }

        static List<int> ReadListOfWagons()
        {
            List<int> inputList = Console.ReadLine().Split().Select(int.Parse).ToList();
            return inputList;
        }

    }
}
