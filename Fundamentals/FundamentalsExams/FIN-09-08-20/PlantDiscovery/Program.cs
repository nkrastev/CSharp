using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery
{
    class Program
    {
        static void Main()
        {
            List<Plant> plantsList = new List<Plant>();
            int n = int.Parse(Console.ReadLine());

            //read data
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Plant item = new Plant(input[0], int.Parse(input[1]), 0, 0, 0);
                if (plantsList.Contains(item))
                {
                    //If you receive a plant more than once, update its rarity
                    plantsList[plantsList.IndexOf(item)].Rarity = int.Parse(input[1]);
                }
                else
                {
                    plantsList.Add(item);
                }
            }

            //commands
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (command[0] != "Exhibition")
            {
                if (command[0] == "Rate:")
                {
                    //Rate: {plant} - {rating} – add the given rating to the plant (store all ratings)
                    string plantName = command[1];
                    double rating = double.Parse(command[3]);
                    bool isFound = false;
                    foreach (Plant item in plantsList)
                    {
                        if (item.Name == plantName)
                        {
                            item.RatingSum += rating;
                            item.RatingCount++;
                            item.AverageRating = item.RatingSum / item.RatingCount;
                            isFound = true;
                        }
                    }
                    if (!isFound)
                    {
                        Console.WriteLine("error");
                    }
                }

                if (command[0] == "Update:")
                {
                    //Update: {plant} - {new_rarity} – update the rarity of the plant with the new one
                    string plantName = command[1];
                    int rarity = int.Parse(command[3]);
                    bool isFound = false;
                    foreach (Plant item in plantsList)
                    {
                        if (item.Name == plantName)
                        {
                            item.Rarity = rarity;
                            isFound = true;
                        }
                    }
                    if (!isFound)
                    {
                        Console.WriteLine("error");
                    }
                }

                if (command[0] == "Reset:")
                {
                    //•	Reset: {plant} – remove all the ratings of the given plant
                    string plantName = command[1];
                    bool isFound = false;
                    foreach (Plant item in plantsList)
                    {
                        if (item.Name == plantName)
                        {
                            item.RatingSum = 0;
                            item.RatingCount = 0;
                            item.AverageRating = 0;///???
                            isFound = true;
                        }
                    }
                    if (!isFound)
                    {
                        Console.WriteLine("error");
                    }

                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            //sorting
            plantsList = plantsList.OrderByDescending(x => x.Rarity).ThenByDescending(x => x.AverageRating).ToList();

            //output
            Console.WriteLine("Plants for the exhibition:");
            foreach (Plant item in plantsList)
            {
                Console.WriteLine($"- {item.Name}; Rarity: {item.Rarity}; Rating: {item.AverageRating:f2}");
            }



        }
    }

    class Plant
    {
        //constructor
        public Plant(string name, int rarity, double ratingSum, int ratingCount, double avrgRating)
        {

            Name = name;
            Rarity = rarity;
            RatingSum = ratingSum;
            RatingCount = ratingCount;
            AverageRating = avrgRating;
        }
        //properties
        public string Name { get; set; }
        public int Rarity { get; set; }
        public double RatingSum { get; set; }
        public int RatingCount { get; set; }
        public double AverageRating { get; set; }
    }
}
