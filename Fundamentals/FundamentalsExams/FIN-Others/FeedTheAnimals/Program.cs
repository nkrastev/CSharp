using System;
using System.Collections.Generic;
using System.Linq;

namespace FeedTheAnimals
{
    class Program
    {
        static void Main()
        {
            var command = Console.ReadLine();
            List<Animal> list = new List<Animal>();

            while (command!= "Last Info")
            {
                var cmdArgs = command.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmdArgs[0]=="Add")
                {
                    AddAnimal(list, cmdArgs[1], cmdArgs[2], cmdArgs[3]);
                }
                if (cmdArgs[0]== "Feed")
                {
                    Feed(list, cmdArgs[1], cmdArgs[2], cmdArgs[3]);
                }
                command = Console.ReadLine();
            }

            list = list.OrderByDescending(x => x.FoodLimit).ThenBy(x => x.Name).ToList();
            PrintOutput(list);
        }

        private static void PrintOutput(List<Animal> list)
        {
            Dictionary<string, int> areas = new Dictionary<string, int>();
            Console.WriteLine("Animals:");
            foreach (Animal item in list)
            {
                Console.WriteLine($"{item.Name} -> {item.FoodLimit}g");
                if (areas.ContainsKey(item.Area))
                {
                    areas[item.Area]++;
                }
                else
                {
                    areas.Add(item.Area, 1);
                }
            }
            Console.WriteLine("Areas with hungry animals:");
            areas = areas.OrderByDescending(x => x.Value).ThenByDescending(x=>x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in areas)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }

        private static List<Animal> Feed(List<Animal> list, string v1, string v2, string v3)
        {
            var aniName = v1;
            var aniFood = int.Parse(v2);
            var aniArea = v3;
            
            foreach (Animal item in list)
            {
                if (item.Name==aniName)
                {
                    item.FoodLimit -= aniFood;
                    if (item.FoodLimit<=0)
                    {
                        //the animal is considered successfully fed 
                        Console.WriteLine($"{aniName} was successfully fed");
                        list.Remove(item);
                        break;
                    }
                }
            }
            return list;
        }

        private static List<Animal> AddAnimal(List<Animal> list, string v1, string v2, string v3)
        {
            var aniName = v1;
            var aniFoodLimit = int.Parse(v2);
            var aniArea = v3;
            var isExist = false;
            foreach (Animal item in list)
            {
                if (item.Name==aniName)
                {
                    isExist = true;
                    //add data to existing animal
                    item.FoodLimit += aniFoodLimit;
                    break;
                }
            }
            //insert new animal
            if (!isExist)
            { 
                list.Add(new Animal(aniName, aniFoodLimit, aniArea));   
            }
            return list;
        }
    }
}
