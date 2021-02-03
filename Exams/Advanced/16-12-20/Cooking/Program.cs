using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {            
            var numBread = 0;
            var numCake = 0;
            var numPastry = 0;
            var numFruitPie = 0;

            var inputQueue = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var inputStack = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var liquid = new Queue<int>(inputQueue);
            var ingredient = new Stack<int>(inputStack);

            while (liquid.Count>0 && ingredient.Count>0)
            {
                if (liquid.Peek()+ingredient.Peek()==25)
                {
                    numBread++;
                    liquid.Dequeue();
                    ingredient.Pop();
                }
                else if (liquid.Peek() + ingredient.Peek() == 50)
                {
                    numCake++;
                    liquid.Dequeue();
                    ingredient.Pop();
                }
                else if (liquid.Peek() + ingredient.Peek() == 75)
                {
                    numPastry++;
                    liquid.Dequeue();
                    ingredient.Pop();
                }
                else if (liquid.Peek() + ingredient.Peek() == 100)
                {
                    numFruitPie++;
                    liquid.Dequeue();
                    ingredient.Pop();
                }
                else
                {
                    liquid.Dequeue();
                    //increase the value of the ingredient by 3
                    var tempNum = ingredient.Pop() + 3;
                    ingredient.Push(tempNum);

                }
            }


            //output
            if (numBread>0 && numCake>0 && numPastry>0 && numFruitPie>0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquid.Count>0)
            {
                Console.Write("Liquids left: ");
                Console.WriteLine(String.Join(", ",liquid));                
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredient.Count>0)
            {
                Console.Write("Ingredients left: ");
                Console.WriteLine(String.Join(", ", ingredient));
            }
            else
            {
                Console.WriteLine("Ingredients left: none");                
            }

            Console.WriteLine($"Bread: {numBread}");
            Console.WriteLine($"Cake: {numCake}");
            Console.WriteLine($"Fruit Pie: {numFruitPie}");
            Console.WriteLine($"Pastry: {numPastry}");


        }

    }
}
