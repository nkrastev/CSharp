using System;
using System.Linq;

namespace MEx05TopIntegers
{
    class Program
    {
        static void Main()
        {
            //Write a program to find all the top integers in an array. 
            //A top integer is an integer which is bigger than all the elements to its right. 
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            
            for (int i = 0; i < arr.Length; i++)
            {
                // element arr[i], position "i"
                int currentElement = arr[i];
                bool isTop = false;
                for ( int j = i+1; j < arr.Length; j++)
                {
                    if (currentElement>arr[j])
                    {
                        //Console.WriteLine("Ok");
                        isTop = true;
                    }
                    else
                    {
                        //Console.WriteLine("Not OK, skip next checks");
                        isTop = false;
                        break;
                    }
                }
                if (isTop)
                {
                    Console.Write(currentElement+" ");
                }
                
            }
            int lastIndex = arr.Length - 1;
            Console.Write(arr[lastIndex]);
        }
    }
}
