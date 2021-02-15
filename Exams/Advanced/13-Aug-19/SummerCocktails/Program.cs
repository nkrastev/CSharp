using System;
using System.Collections.Generic;
using System.Linq;

namespace SummerCocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Mimosa  150
            Daiquiri    250
            Sunshine    300
            Mojito  400*/
            var countMimosa = 0;
            var countDaiquiri = 0;
            var countSunshine = 0;
            var countMojito = 0;

            var ingedientsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var freshnessInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

            Queue<int> ingredients = new Queue<int>(ingedientsInput);
            Stack<int> freshness = new Stack<int>(freshnessInput);

            while (ingredients.Count>0 && freshness.Count>0)
            {
                if (ingredients.Peek()*freshness.Peek()==150)
                {
                    countMimosa++;
                    ingredients.Dequeue();
                    freshness.Pop();
                    continue;
                }
                if (ingredients.Peek() * freshness.Peek() == 250)
                {
                    countDaiquiri++;
                    ingredients.Dequeue();
                    freshness.Pop();
                    continue;
                }
                if (ingredients.Peek() * freshness.Peek() == 300)
                {
                    countSunshine++;
                    ingredients.Dequeue();
                    freshness.Pop();
                    continue;
                }
                if (ingredients.Peek() * freshness.Peek() == 400)
                {
                    countMojito++;
                    ingredients.Dequeue();
                    freshness.Pop();
                    continue;
                }
                if (ingredients.Peek()==0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                if (ingredients.Peek()!=0 &&
                    ingredients.Peek() * freshness.Peek() != 150 &&
                    ingredients.Peek() * freshness.Peek() != 250 &&
                    ingredients.Peek() * freshness.Peek() != 300 &&
                    ingredients.Peek() * freshness.Peek() != 400
                    )
                {
                    freshness.Pop();
                    int temp = ingredients.Dequeue() + 5;
                    ingredients.Enqueue(temp);
                    continue;
                }

            }

            if (countDaiquiri>0 && countMimosa>0 && countMojito>0 && countSunshine>0)
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
            }

            if (ingredients.Count>0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            if (countDaiquiri>0)
            {
                Console.WriteLine($" # Daiquiri --> {countDaiquiri}");
            }
            if (countMimosa > 0)
            {
                Console.WriteLine($" # Mimosa --> {countMimosa}");
            }
            if (countMojito > 0)
            {
                Console.WriteLine($" # Mojito --> {countMojito}");
            }
            if (countSunshine > 0)
            {
                Console.WriteLine($" # Sunshine --> {countSunshine}");
            }

        }
    }
}
