using System;
using System.Linq;

namespace MEx09KaminoFactory
{
    class Program
    {
        static void Main()
        {
            Console.ReadLine();
            string[] bestDna = null;
            int bestLen = -1;
            int startIndex = -1;
            int bestDnaSum = 0;
            int bestSampleIndex = 0;

            int currentSampleIndex = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Clone them!")
                {
                    break;
                }

                string[] currentDna = input.Split('!', StringSplitOptions.RemoveEmptyEntries);
                int currentLen = 0;
                int currentBestLen = 0;
                int currentEndIndex = 0;

                for (int a = 0; a < currentDna.Length; a++)
                {
                    if (currentDna[a] == "1")
                    {
                        currentLen++;
                        if (currentLen > currentBestLen)
                        {
                            currentEndIndex = a;
                            currentBestLen = currentLen;
                        }
                    }
                    else
                    {
                        currentLen = 0;
                    }
                }

                int currentStartIndex = currentEndIndex - currentBestLen + 1;

                bool isCurrentDnaBetter = false;
                int currentDnaSum = currentDna.Select(int.Parse).Sum();

                if (currentBestLen > bestLen)
                {
                    isCurrentDnaBetter = true;
                }
                else if (currentBestLen == bestLen)
                {
                    if (currentStartIndex < startIndex)
                    {
                        isCurrentDnaBetter = true;
                    }
                    else if (currentStartIndex == startIndex)
                    {
                        if (currentDnaSum > bestDnaSum)
                        {
                            isCurrentDnaBetter = true;
                        }
                    }
                }

                currentSampleIndex++;

                if (isCurrentDnaBetter)
                {
                    bestDna = currentDna;
                    bestLen = currentBestLen;
                    startIndex = currentStartIndex;
                    bestDnaSum = currentDnaSum;
                    bestSampleIndex = currentSampleIndex;
                }
            }

            Console.WriteLine($"Best DNA sample {bestSampleIndex} with sum: {bestDnaSum}.");
            Console.WriteLine(string.Join(' ', bestDna));
        }
    }
}
