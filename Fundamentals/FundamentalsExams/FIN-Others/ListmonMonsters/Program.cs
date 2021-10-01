using System;
using System.Collections.Generic;
using System.Linq;

namespace _02ListmonMonsters
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            List<Hyrdalisk> hydras = new List<Hyrdalisk>();
            List<Zergling> lings = new List<Zergling>();

            while (input!= "stopAddingArmy")
            {
                var monsterType = input.Split("(", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (monsterType[0]!= "Hydralisk" && monsterType[0]!= "Zergling")
                {
                    Console.WriteLine($"Can't instantiate abstract class {monsterType[0]} with abstract methods __init__");
                }
                else
                {
                    if (monsterType[0]== "Hydralisk")
                    {
                        //its hydra //Hydralisk({name}, {id}, {strength}, {ugliness}, {range}), remove the last )
                        var hydraData = monsterType[1].Remove(monsterType[1].Length - 1, 1);
                        var hydraItems = hydraData.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                        if (hydraItems.Length<5)
                        {
                            Console.WriteLine("__init__() missing 1 required positional argument: 'range'");
                        }
                        else
                        {
                            if (hydraItems[4].Contains("'"))
                            {
                                //is string is valid... add it
                                Hyrdalisk newHydra = new Hyrdalisk
                                    (hydraItems[0],
                                    int.Parse(hydraItems[1]),
                                    int.Parse(hydraItems[2]),
                                    int.Parse(hydraItems[3]),
                                    hydraItems[4]);
                                hydras.Add(newHydra);
                            }
                            else
                            {
                                Console.WriteLine("Range must be string");
                            }
                        }
                    }
                    else
                    {
                        //its zergling
                        var lingData = monsterType[1].Remove(monsterType[1].Length - 1, 1);
                        var lingItems = lingData.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                        if (lingItems.Length < 5)
                        {
                            Console.WriteLine("__init__() missing 1 required positional argument: 'speed'");                          
                        }
                        else
                        {
                            int value = 0;
                            if (int.TryParse(lingItems[4], out value))
                            {
                                //is int is valid... add it
                                Zergling newLing = new Zergling
                                    (lingItems[0],
                                    int.Parse(lingItems[1]),
                                    int.Parse(lingItems[2]),
                                    int.Parse(lingItems[3]),
                                    int.Parse(lingItems[4]));
                                lings.Add(newLing);
                            }
                            else
                            {
                                Console.WriteLine("Speed must be integer");
                            }
                        }
                        
                    }
                }
                input = Console.ReadLine();
            }
            //output
            var speed = 0;
            var strenght = 0;
            foreach (Zergling item in lings)
            {
                speed += item.Speed;
                strenght += item.Strength;
            }

            foreach (Hyrdalisk item in hydras)
            {
                strenght += item.Strength;
            }
            Console.WriteLine($"Overall speed of army: {speed}");
            Console.WriteLine($"Overall strength: {strenght}");
            Console.WriteLine($"Hydralisk: {hydras.Count}; Zergling: {lings.Count}");
        }
    }    
}
