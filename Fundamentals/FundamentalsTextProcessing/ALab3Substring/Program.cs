using System;

namespace ALab3Substring
{
    class Program
    {
        static void Main()
        {
            string firstString = Console.ReadLine().ToLower();
            string secondString = Console.ReadLine().ToLower();
            
            while (secondString.Contains(firstString))
            {
                int indexToStartRemove = secondString.IndexOf(firstString);
                int lenghtToBeRemoved = firstString.Length;

                secondString = secondString.Remove(indexToStartRemove, lenghtToBeRemoved);
            }

            Console.WriteLine(secondString);
        }

    }
}
