using System;
using System.Collections.Generic;
using System.Linq;

namespace Mo05LongestIncreasingSubsequence
{
    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();          
            List<List<int>> sequences = new List<List<int>>();

            //7 3 5 8 -1 0 6 7

            for (int i = 0; i < input.Length; i++)
            {
                //create new list for the first and next N sequences
                List<int> subsequence = new List<int>();
                
                for ( int j = i; j < input.Length-1; j++)
                {
                    //if current subseq does not have elements, add first
                    if (subsequence.Count==0)
                    {
                        subsequence.Add(input[j]);
                    }
                    
                    //if last element in current list is smaller than the element in the array looped
                    if (subsequence[subsequence.Count-1]<input[j+1])
                    {                        
                        subsequence.Add(input[j+1]);
                    }                    
                }                

                sequences.Add(subsequence);
            }



            //find max elements
            int maxNumberOfElements = 0;
            List<int> maxList = new List<int>();
            foreach (var item in sequences)
            {
                if (item.Count > maxNumberOfElements)
                {
                    maxList = item;
                }
            }

            foreach (var item in maxList)
            {
                Console.WriteLine(String.Join(" ", item));
            }


        }
    }
}
