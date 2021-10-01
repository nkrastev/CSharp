using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex06Wardrobe
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var wardrobe = ReadData(n); //list of objects
            var filter = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var searchedColor = filter[0];
            var searchedCloth = filter[1];
            var groupedWardrobe = wardrobe.GroupBy(x=>x.Color).Select(grp => grp.ToList()).ToList();

            for (int i = 0; i < groupedWardrobe.Count; i++)
            {
                //additional loop by colors cause of grouping :D                
                int colorCounter = 0;
                foreach (Clothing item in groupedWardrobe[i])
                {
                    if (colorCounter == 0)
                    {
                        Console.WriteLine(item.Color+" clothes:");
                        colorCounter = 1;
                    }
                    if (item.Color==searchedColor && item.Type== searchedCloth)
                    {
                        Console.WriteLine($"* {item.Type} - {item.Count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Type} - {item.Count}");
                    }                   
                }
            }
        }

        private static List<Clothing> ReadData(int n)
        {
            var data = new List<Clothing>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var color = input[0];
                var typesOfClothing = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
                //loop throught list of clothes
                for (int j = 0; j < typesOfClothing.Count; j++)
                {
                    //create new instance of clothing    
                    Clothing newClothing = new Clothing(typesOfClothing[j], color, 1);

                    if (data.Any(x=>x.Type.Contains(typesOfClothing[j])))
                    {
                        //current clothing is in wardrobe, increase count
                        int index=data.FindIndex(x => x.Type==typesOfClothing[j]);
                        data[index].Count++;
                    }
                    else
                    {
                        //add clothing in the DATA list
                        data.Add(newClothing);
                    }                    
                }
            }
            return data;            
        }
    }
    class Clothing
    {
        //constructor
        public Clothing (string type, string color, int count)
        {
            Type = type;
            Color = color;
            Count = count;
        }
        //properties
        public string Type { get; set; }
        public string Color { get; set; }
        public int Count { get; set; }
    }
}
