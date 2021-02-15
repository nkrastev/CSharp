using System;
using System.Collections.Generic;
using System.Linq;

namespace TrojanInvasion
{
    class Program
    {
        static void Main()
        {
            var numberOfWaves = int.Parse(Console.ReadLine());
            var inputPlates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            Queue<int> plates = new Queue<int>(inputPlates);
            Stack<int> leftWarriors = new Stack<int>();

            for (int i = 1; i <= numberOfWaves; i++)
            {
                var inputWave = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
                Stack<int> wave = new Stack<int>(inputWave);
                if (i % 3==0)
                {
                    //third wave, read input for plate
                    int reinforcement = int.Parse(Console.ReadLine());
                    plates.Enqueue(reinforcement);
                }
                //start attack
                while (wave.Count>0 && plates.Count>0)
                {
                    if (wave.Peek()==plates.Peek())
                    {
                        wave.Pop();
                        plates.Dequeue();
                    }
                    else if (wave.Peek()> plates.Peek())
                    {
                        int value = plates.Peek();
                        plates.Dequeue();
                        int temp = wave.Pop();
                        wave.Push(temp - value);
                    }
                    else if (plates.Peek()>wave.Peek())
                    {
                        int value = wave.Peek();
                        wave.Pop();
                        int temp = plates.Dequeue();
                        plates.Enqueue(temp - value);
                    }

                    if (plates.Count ==0 )
                    {
                        leftWarriors = wave;
                        break;
                    }
                }
                
            }

            if (plates.Count>0)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", leftWarriors)}");
            }

           
        }
    }
}
