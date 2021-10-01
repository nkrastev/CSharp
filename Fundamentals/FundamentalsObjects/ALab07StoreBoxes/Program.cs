using System;
using System.Collections.Generic;
using System.Linq;

namespace ALab07StoreBoxes
{
    class Program
    {
        static void Main()
        {
            //Until you receive "end", you will be receiving data in the following format: 
            //{Serial Number} {Item Name} {Item Quantity} {itemPrice}

            List<Box> boxesList = new List<Box>();

            List<string> commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (commands[0] != "end")
            {
                Box newBox = new Box
                {
                    SerialNumber = commands[0],
                    Item = new Item
                    {
                        Name = commands[1],
                        Price = double.Parse(commands[3])
                    },
                    ItemQuantity = int.Parse(commands[2]),
                    PriceForABox= int.Parse(commands[2]) * double.Parse(commands[3])
                };

                // adding new object to the list
                boxesList.Add(newBox);

                commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            }

            PrintBoxObjects(boxesList);



        }

        private static void PrintBoxObjects(List<Box> boxesList)
        {
            boxesList=boxesList.OrderByDescending(x => x.PriceForABox).ToList();            

            foreach (Box item in boxesList)
            {
                Console.WriteLine(item.SerialNumber);
                Console.WriteLine($"-- {item.Item.Name} - ${item.Item.Price:f2}: {item.ItemQuantity}");
                Console.WriteLine($"-- ${item.Item.Price*item.ItemQuantity:f2}");
               
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForABox { get; set; }
    }
}
