using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex05BombNumbers
{
    class Program
    {
        static void Main()
        {
            //input
            List<int> numbersList = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] specialAndRange = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int specialNumber = specialAndRange[0];
            int range = specialAndRange[1];
            
            int indexOfSpecial = numbersList.FindIndex(item => item == specialNumber);

            while (indexOfSpecial>=0)
            {
                //delete "range" elements
                int startPositionForDelete = indexOfSpecial - range;
                int endPositionForDelete = indexOfSpecial + range;
                if (startPositionForDelete < 0)
                {
                    startPositionForDelete = 0;
                }
                if (endPositionForDelete>numbersList.Count-1)
                {
                    endPositionForDelete = numbersList.Count - 1;
                }
                //Console.WriteLine("Start Position "+ startPositionForDelete);
                //Console.WriteLine("End Position " + endPositionForDelete);

                for (int i = 0; i <=(endPositionForDelete-startPositionForDelete); i++)
                {
                    numbersList.RemoveAt(startPositionForDelete);

                }




                // check if there is another special number and loop it
                indexOfSpecial = numbersList.FindIndex(item => item == specialNumber);
            }


            // find index if it is negative the number is not in the list!!!
            //Console.WriteLine("Index of Special number"+indexOfSpecial);

            //Console.WriteLine(String.Join(" ",numbersList));

            int sumOfList=numbersList.Sum();
            Console.WriteLine(sumOfList);

        }
    }
}
