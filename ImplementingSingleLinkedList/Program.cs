using System;

namespace CustomDataStructures
{
    /// <summary>
    /// Custom data structure - Linked List
    /// </summary>
    class Program
    {
        static void Main()
        {
            LinkedList myList = new LinkedList(new int[] { 3, 4, 6, 8 });

            myList.AddFirst(2);

            myList.AddAfter(myList.Find(2), 10);
            myList.AddBefore(myList.Find(2), 100);

            myList.RemoveLast();

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
           
        }
    }
}
