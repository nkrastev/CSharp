using System;

namespace CustomDataStructures
{
    class Program
    {
        static void Main()
        {
            LinkedList myList = new LinkedList(new int[] { 3, 4, 6, 8 });

            myList.AddFirst(2);

            myList.AddAfter(myList.Find(2), 10);
            myList.AddBefore(myList.Find(2), 100);


            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
           
        }
    }
}
