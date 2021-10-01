using System;
using System.Globalization;
using System.Linq;

namespace Mo04FoldandSum
{
    class Program
    {
        static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = arr.Length / 4;
            
            int currentPos = 0;
            int[] firstRowLeft = new int[k];
            for ( int j = k-1; j >= 0; j--)
            {                
                firstRowLeft[currentPos] = arr[j];
                currentPos++;
            }

            currentPos = 0;
            int[] firstRowRight = new int[k];
            for (int j = arr.Length-1; j >= 3 * k; j--)
            {                
                firstRowRight[currentPos] = arr[j];
                currentPos++;
            }
            
            currentPos = 0;
            int[] secondRow = new int[k * 2];
            for (int j = k; j < arr.Length-k; j++)
            {                
                secondRow[currentPos] = arr[j];
                currentPos++;
            }

            currentPos = 0;
            int[] firstRow = new int[k * 2];
            for (int i = 0; i < k; i++)
            {
                firstRow[i] = firstRowLeft[i];
            }
            for (int i = k; i < 2*k; i++)
            {
                firstRow[i] = firstRowRight[currentPos];
                currentPos++;
            }

            //output
            for (int i = 0; i < 2*k; i++)
            {
                Console.Write((firstRow[i]+secondRow[i])+" ");
            }

        }
    }
}
