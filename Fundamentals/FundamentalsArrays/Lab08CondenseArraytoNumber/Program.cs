using System;
using System.Linq;

namespace Lab08CondenseArraytoNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int elementCounter = nums.Length;

            while (elementCounter>1)
            {
                int[] condensed = new int[nums.Length - 1];

                for (int i = 0; i < condensed.Length; i++)
                {
                    condensed[i] = nums[i] + nums[i + 1];
                }

                for (int i = 0; i < nums.Length - 1; i++)
                {
                    nums[i] = condensed[i];
                }
                elementCounter--;
            }
            Console.WriteLine(nums[0]);

        }
    }
}
