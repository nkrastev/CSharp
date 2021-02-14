using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    class StartUp
    {
        static void Main()
        {
            var capacity = int.Parse(Console.ReadLine());
            var input = new Stack<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            var halls = new Queue<string>();
            var restaurant = new Dictionary<string, List<int>>();

            while (input.Any())
            {
                var current= input.Peek();
                if (char.IsLetter(current[0]))
                {
                    restaurant[current] = new List<int>();                    
                    halls.Enqueue(current);
                    input.Pop();                    
                }
                if (restaurant.Count == 0)
                {
                    input.Pop();                    
                }
                if (restaurant.Count!=0 && !char.IsLetter(current[0]))
                {
                    foreach (var item in restaurant)
                    {
                        if (item.Value.Sum() + int.Parse(current) <= capacity)
                        {
                            restaurant[item.Key].Add(int.Parse(current));
                            input.Pop();
                            break;
                        }
                        if (item.Value.Sum() + int.Parse(current) >= capacity && halls.Any())
                        {
                            Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", item.Value)}");
                            restaurant.Remove(item.Key);
                        }
                        break;
                    }
                }              
            }
        }
    }

}
