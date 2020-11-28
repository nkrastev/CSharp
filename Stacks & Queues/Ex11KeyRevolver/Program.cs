using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main()
        {
            var priceOfBullet = int.Parse(Console.ReadLine());
            var sizeOfGunBarrel = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var locks = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var theValue = int.Parse(Console.ReadLine());
            var bulletsShotCounter = 0;

            //fill in bullets in stack
            Stack<int> stackBullets = new Stack<int>();
            for (int i = 0; i < bullets.Length; i++)
            {
                stackBullets.Push(bullets[i]);
            }
            //fill in queue with locks
            Queue<int> queueLocks = new Queue<int>();
            for (int i = 0; i < locks.Length; i++)
            {
                queueLocks.Enqueue(locks[i]);
            }
            //while there is bullets for reload or locks
            while (queueLocks.Count != 0 && stackBullets.Count != 0)
            {
                //load the revolver
                Queue<int> queueRevolver = new Queue<int>();
                for (int i = 0; i < sizeOfGunBarrel; i++)
                {
                    if (stackBullets.Count > 0)
                    {
                        queueRevolver.Enqueue(stackBullets.Pop());
                    }
                }
                //shoots loop while there are bullets in revolver or locks left
                while (queueRevolver.Count > 0 && queueLocks.Count > 0)
                {
                    if (queueLocks.Peek() >= queueRevolver.Peek())
                    {
                        //lock crashed, remove lock, remove bullet
                        Console.WriteLine("Bang!");
                        queueLocks.Dequeue();
                        queueRevolver.Dequeue();
                        bulletsShotCounter++;
                    }
                    else
                    {
                        //lock remains at the same position, bullet shot
                        Console.WriteLine("Ping!");
                        queueRevolver.Dequeue();
                        bulletsShotCounter++;
                    }
                }

                if (stackBullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
                else
                {
                    if (queueLocks.Count > 0)
                    {
                        Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
                    }
                    break;
                }
            }

            if (queueLocks.Count == 0)
            {
                var profit = theValue - bulletsShotCounter * priceOfBullet;
                Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${profit}");
            }
        }
    }
}
