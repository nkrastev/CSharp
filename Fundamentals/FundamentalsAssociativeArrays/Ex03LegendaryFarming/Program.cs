using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03LegendaryFarming
{
    class Program
    {
        static void Main()
        {
            //Shadowmourne - requires 250 Shards;
            //Valanyr - requires 250 Fragments;
            //Dragonwrath - requires 250 Motes

            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();
            bool endInput = false;
            keyMaterials.Add("shards",0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("motes", 0);

            while (true)
            {
                List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int i = 0; i < input.Count; i=i+2)
                {
                    // read data by pairs
                    int itemQuantity = int.Parse(input[i]);
                    string itemMaterial = input[i + 1].ToLower();
                    // add to Dict
                    if (itemMaterial== "shards")
                    {
                        keyMaterials["shards"] += itemQuantity;
                    }
                    if (itemMaterial == "fragments")
                    {
                        keyMaterials["fragments"] += itemQuantity;
                    }
                    if (itemMaterial == "motes")
                    {
                        keyMaterials["motes"] += itemQuantity;
                    }
                    //junk materials
                    if (itemMaterial!= "motes" && itemMaterial!= "fragments" && itemMaterial!= "shards")
                    {
                        if (!junkMaterials.ContainsKey(itemMaterial))
                        {
                            junkMaterials.Add(itemMaterial, itemQuantity);
                        }
                        else
                        {
                            junkMaterials[itemMaterial] += itemQuantity;
                        }
                    }
                    
                    //check for break
                    if (keyMaterials["shards"] >= 250 || keyMaterials["fragments"] >= 250 || keyMaterials["motes"] >= 250)
                    {
                        endInput = true;
                        break;
                    }
                }
                if (endInput)
                {
                    break;
                }
            }
            if (keyMaterials["shards"] >= 250)
            {
                Console.WriteLine("Shadowmourne obtained!");
                keyMaterials["shards"] -= 250;
            }
            else if (keyMaterials["fragments"] >= 250)
            {
                Console.WriteLine("Valanyr obtained!");
                keyMaterials["fragments"] -= 250;
            }
            else
            {
                Console.WriteLine("Dragonwrath obtained!");
                keyMaterials["motes"] -= 250;
            }

            Dictionary<string, int> sortedKeyMaterials = keyMaterials
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x=>x.Key, x=>x.Value);



            Dictionary<string, int> sortedJunkMaterials = junkMaterials
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key,x=>x.Value);                                  

            foreach (var item in sortedKeyMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in sortedJunkMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
