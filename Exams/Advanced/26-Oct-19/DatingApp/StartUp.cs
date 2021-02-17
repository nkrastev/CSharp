using System;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp
{
    class StartUp
    {
        static void Main()
        {
            Stack<int> male = new Stack<int>(
                Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> female = new Queue<int>(
                Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int matches = 0;

            while (male.Count>0 && female.Count>0)
            {
                //Console.WriteLine($"To Match: m{male.Peek()} - f{female.Peek()}");
                if (male.Peek()==female.Peek())
                {
                    matches++;
                    male.Pop();
                    female.Dequeue();
                    continue;
                }
                
                if (male.Peek() <= 0 || female.Peek() <= 0)
                {
                    if (male.Peek() <= 0)
                    {
                        male.Pop();
                    }
                    else
                    {
                        female.Dequeue();
                    }
                    continue;
                }

                if (male.Peek() % 25 == 0 || female.Peek() % 25 == 0)
                {
                    
                    if (male.Peek() % 25 == 0)
                    {
                        //Console.WriteLine("Male Value with 25");
                        male.Pop();
                        if (male.Count>0)
                        {
                            male.Pop();
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                    else
                    {
                        //Console.WriteLine("FE Male Value with 25");
                        female.Dequeue();
                        if (female.Count>0)
                        {
                            female.Dequeue();
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                    continue;
                }

                if (male.Peek() != female.Peek())
                {
                    //just different
                    female.Dequeue();
                    var temp = male.Pop();
                    male.Push(temp - 2);
                }                                    
                                
            }

            Console.WriteLine($"Matches: {matches}");
            if (male.Count>0)
            {
                Console.WriteLine($"Males left: {String.Join(", ",male)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }
            if (female.Count > 0)
            {
                Console.WriteLine($"Females left: {String.Join(", ", female)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
