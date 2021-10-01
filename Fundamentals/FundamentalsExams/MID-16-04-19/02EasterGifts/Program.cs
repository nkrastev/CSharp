using System;
using System.Collections.Generic;
using System.Linq;

namespace _02EasterGifts
{
    class Program
    {
        static void Main()
        {
            List<string> gifts = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input!= "No Money")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string giftItem = command[1];

                if (command[0]== "OutOfStock")
                {                
                    OutOfStockCommand(gifts, giftItem);
                }
                if (command[0]== "Required")
                {                
                    int index = int.Parse(command[2]);
                    RequiredCommand(gifts, giftItem, index);
                }
                if (command[0]== "JustInCase")
                {
                    JustInCaseCommand(gifts, giftItem);
                }
                input = Console.ReadLine();
            }

            //output
            PrintOutput(gifts);
        }

        private static void PrintOutput(List<string> gifts)
        {
            foreach (var item in gifts)
            {
                if (item!="None")
                {
                    Console.Write(item+" ");
                }
            }
        }

        private static List<string> JustInCaseCommand(List<string> gifts, string giftItem)
        {
            if (gifts.Count>=1)
            {
                gifts[gifts.Count - 1] = giftItem;
            }

            return gifts;
        }

        private static List<string> RequiredCommand(List<string> gifts, string giftItem, int index)
        {
            if (index>=0 && index<gifts.Count)
            {
                gifts[index] = giftItem;
            }

            return gifts;
        }

        private static List<string> OutOfStockCommand(List<string> gifts, string giftItem)
        {
            for (int i = 0; i < gifts.Count; i++)
            {
                if (gifts[i]==giftItem)
                {
                    gifts[i] = "None";
                }
            }
            
            return gifts;
        }
    }
}
