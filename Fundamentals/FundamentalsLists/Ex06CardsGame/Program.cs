using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex06CardsGame
{
    class Program
    {
        static void Main()
        {
            List<int> firstPlayer = ReadIntegerListFromLine();
            List<int> secondPlayer = ReadIntegerListFromLine();

            while (true)
            {

                if (firstPlayer.Count==0 || secondPlayer.Count==0){break;}

                //equal cards, remove both
                if (firstPlayer[0]==secondPlayer[0])
                {
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                    
                }

                if (firstPlayer.Count == 0 || secondPlayer.Count == 0) { break; }

                if (firstPlayer[0]>secondPlayer[0])
                {
                    //increase first list with two cards
                    firstPlayer.Add(firstPlayer[0]);
                    firstPlayer.Add(secondPlayer[0]);
                    //remove the compared cards
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);                    
                }
                
                if (firstPlayer.Count == 0 || secondPlayer.Count == 0) { break; }

                if (firstPlayer[0] < secondPlayer[0])
                {
                    //increase second list with two cards
                    secondPlayer.Add(secondPlayer[0]);
                    secondPlayer.Add(firstPlayer[0]);
                    //remove the compared cards
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);                    
                }
            }


            if (firstPlayer.Count>0)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayer.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayer.Sum()}");
            }

        }

        static List<int> ReadIntegerListFromLine()
        {
            List<int> listItem = Console.ReadLine().Split().Select(int.Parse).ToList();
            return listItem;
        }

        

    }
}
