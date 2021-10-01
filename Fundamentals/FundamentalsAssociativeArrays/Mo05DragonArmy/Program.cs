using System;
using System.Collections.Generic;
using System.Linq;

namespace Mo05DragonArmy
{
    class Program
    {
        static void Main()
        {
            List<Dragon> dragonList = new List<Dragon>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string drType = input[0];
                string drName = input[1];
                string iDamage = input[2];
                string iHealth = input[3];
                string iArmor = input[4];

                int drDamage = CheckDamage(iDamage);
                int drHealth = CheckHealth(iHealth);
                int drArmor = CheckArmor(iArmor);
                
                Dragon newDragon = new Dragon(drType, drName, drDamage, drHealth, drArmor);                

                bool isDragonExist = false;
                foreach (Dragon item in dragonList)
                {
                    if (item.Name == drName && item.Type == drType)
                    {
                        //if such dragon exist in the list update data
                        item.Damage = drDamage;
                        item.Health = drHealth;
                        item.Armor = drArmor;
                        isDragonExist = true;
                        break;
                    }                    
                }

                if (!isDragonExist)
                {
                    //dragon doesnt exist, add new dragon
                    dragonList.Add(newDragon);
                }                
                
            }


            //output
            PrintDragons(dragonList);

        }
        static int CheckHealth(string inputData)
        {
            int intValue = 0;
            if (inputData == "null")
            {
                intValue = 250;
            }
            else intValue = int.Parse(inputData);
            return intValue;
        }
        static int CheckArmor(string inputData)
        {
            int intValue = 0;
            if (inputData == "null")
            {
                intValue = 10;
            }
            else intValue = int.Parse(inputData);
            return intValue;
        }
        static int CheckDamage(string inputData)
        {
            int intValue = 0;
            if (inputData == "null")
            {               
                intValue = 45;
                
            }
            else intValue = int.Parse(inputData);            
            return intValue;
        }

        static void PrintDragons(List<Dragon> dragonList)
        {
            List<string> dragonTypes = new List<string>();
            foreach (Dragon item in dragonList)
            {
                if (!dragonTypes.Contains(item.Type))
                {
                    dragonTypes.Add(item.Type);
                }
            }

            foreach (var item in dragonTypes)
            {                
                int totalDamage = 0;                
                int totalHealth = 0;                
                int totalArmor = 0;
                int dragonsCount = 0;
                //get stat for each type
                foreach (Dragon dragonItem in dragonList)
                {

                    if (dragonItem.Type==item)
                    {
                        //calculate avrg data for current type
                        totalDamage += dragonItem.Damage;
                        totalHealth += dragonItem.Health;
                        totalArmor += dragonItem.Armor;
                        dragonsCount++;
                    }
                }

                // print stat for current type
                double avrgDamage = totalDamage * 1.0 / dragonsCount;
                double avrgHealth = totalHealth * 1.0 / dragonsCount;
                double avrgArmor = totalArmor * 1.0 / dragonsCount;
                Console.WriteLine($"{item}::({avrgDamage:f2}/{avrgHealth:f2}/{avrgArmor:f2})");

                // print dragons from current type
                foreach (Dragon x in dragonList.OrderBy(x=>x.Name))
                {
                    if (x.Type == item)
                    {
                        //print dragon instance
                        Console.WriteLine($"-{x.Name} -> damage: {x.Damage}, health: {x.Health}, armor: {x.Armor}");
                    }
                }

            }

        }
    }

    public class Dragon
    {
        //constructor
        public Dragon(string type, string name, int damage, int health, int armor)
        {
            Type = type;
            Name = name;
            Damage = damage;
            Health = health;
            Armor = armor;
        }

        //properties
        public string Type { get; set; } = "null";
        public string Name { get; set; } = "null";
        public int Damage { get; set; } = 45;
        public int Health { get; set; } = 250;
        public int Armor { get; set; } = 10;
    }
}
