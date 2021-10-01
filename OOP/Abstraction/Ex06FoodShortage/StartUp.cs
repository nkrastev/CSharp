using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex06FoodShortage
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var list = new HashSet<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input.Length==4)
                {
                    //citizen
                    Citizen item = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    list.Add(item);
                }
                if (input.Length==3)
                {
                    //rebel
                    Rebel item = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    list.Add(item);
                }
            }

            //eating
            var command = Console.ReadLine();
            while (command!="End")
            {
                foreach (var item in list)
                {
                    if (item.Name==command)
                    {
                        item.BuyFood();
                    }
                }
                command = Console.ReadLine();
            }

            //output                      
            Console.WriteLine(list.Sum(x=>x.Food));
            

            
        }
    }
}
