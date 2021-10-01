using System;
using System.Collections.Generic;
using System.Linq;

namespace _03EasterShopping
{
    class Program
    {
        static void Main()
        {
            List<string> shops = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command[0]== "Include")
                {                    
                    shops.Add(command[1]);
                }

                if (command[0]== "Visit")
                {
                    string position = command[1];
                    int numbers = int.Parse(command[2]);

                    if (numbers<=shops.Count && numbers>=0)
                    {
                        if (position == "first")
                        {
                            for (int j = 0; j < numbers;j++)
                            {
                                shops.RemoveAt(0);
                            }
                        }
                        else
                        {
                            for (int j = 0; j < numbers; j++)
                            {
                                shops.RemoveAt(shops.Count - 1);
                            }
                        }
                    }                    
                }

                if (command[0]== "Prefer")
                {
                    int indexShop1 = int.Parse(command[1]);
                    int indexShop2 = int.Parse(command[2]);                    

                    if (indexShop1>=0 && indexShop2>=0 && indexShop1<=shops.Count-1 && indexShop2<=shops.Count-1)
                    {
                        string temp = shops[indexShop1];
                        shops[indexShop1] = shops[indexShop2];
                        shops[indexShop2] = temp;
                    }
                }

                if (command[0]== "Place")
                {
                    string shopName = command[1];
                    int shopIndex = int.Parse(command[2]);
                    if (shopIndex>=0 && shopIndex<shops.Count)
                    {
                        shops.Insert(shopIndex + 1, shopName);
                    }
                }
            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(String.Join(" ",shops));

        }
    }
}
