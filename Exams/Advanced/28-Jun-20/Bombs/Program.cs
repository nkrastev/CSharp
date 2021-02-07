using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputEffect = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var inputCasing = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            var countDatura = 0;
            var countCherry = 0;
            var countSmoke = 0;

            var effect = new Queue<int>(inputEffect);
            var casing = new Stack<int>(inputCasing);

            while (effect.Count>0 && casing.Count>0)
            {
                if (effect.Peek()+casing.Peek()==40)
                {
                    countDatura++;
                    effect.Dequeue();
                    casing.Pop();
                }
                else if (effect.Peek() + casing.Peek() == 60)
                {
                    countCherry++;
                    effect.Dequeue();
                    casing.Pop();
                }
                else if (effect.Peek() + casing.Peek() == 120)
                {
                    countSmoke++;
                    effect.Dequeue();
                    casing.Pop();
                }
                else
                {
                    var temp = casing.Pop();
                    temp -= 5;
                    casing.Push(temp);
                }
                if (countCherry>=3 && countDatura>=3 && countSmoke>=3)
                {
                    break;
                }
            }

            //output
            if (countCherry >= 3 && countDatura >= 3 && countSmoke >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effect.Count>0)
            {
                Console.Write("Bomb Effects: ");
                Console.WriteLine(String.Join(", ",effect));
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (casing.Count > 0)
            {
                Console.Write("Bomb Casings: ");
                Console.WriteLine(String.Join(", ", casing));
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {countCherry}");
            Console.WriteLine($"Datura Bombs: {countDatura}");
            Console.WriteLine($"Smoke Decoy Bombs: {countSmoke}");
        }
    }
}
