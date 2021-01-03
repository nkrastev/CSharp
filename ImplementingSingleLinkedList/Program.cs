using System;

namespace CustomDataStructures
{
    class Program
    {
        static void Main()
        {
            LinkedList myList = new LinkedList(new int[] { 3, 4, 6, 8 });

            myList.AddFirst(2);

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
           
        }
    }
}
