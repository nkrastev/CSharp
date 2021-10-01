using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex09PokemonDontGo
{
    class Program
    {
        static void Main()
        {
            List<int> inputList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int sumOfRemovedElements = 0;

            while (inputList.Count>0)
            {
                int currentIndex = int.Parse(Console.ReadLine());


                if (currentIndex<0)
                {
                    sumOfRemovedElements += inputList[0];
                    //increase or decrease elements with inputlist[0]                   
                    for (int i = 1; i < inputList.Count; i++)
                    {
                        if (inputList[i]<=inputList[0])
                        {
                            inputList[i] += inputList[0];
                        }
                        else
                        {
                            inputList[i] -= inputList[0];
                        }
                    }
                    inputList[0] = inputList[inputList.Count - 1];


                }
                if (currentIndex>=inputList.Count)
                {
                    sumOfRemovedElements += inputList[inputList.Count - 1];
                    //increase or decrease elements
                    for (int i = 0; i < inputList.Count-1; i++)
                    {
                        if (inputList[i] <= inputList[inputList.Count - 1])
                        {
                            inputList[i] += inputList[inputList.Count - 1];
                        }
                        else
                        {
                            inputList[i] -= inputList[inputList.Count - 1];
                        }
                    }
                    inputList[inputList.Count - 1] = inputList[0];
                }

                // remove element from the list and also increase decrease
                if (currentIndex<inputList.Count && currentIndex>=0)
                {                
                    sumOfRemovedElements += inputList[currentIndex];
                    int tempCurrentValue = inputList[currentIndex];
                    inputList.RemoveAt(currentIndex);

                    for (int i = 0; i < inputList.Count; i++)
                    {
                    
                        if (inputList[i]<=tempCurrentValue)
                        {
                            inputList[i] += tempCurrentValue;
                        }
                        else
                        {
                            inputList[i] -= tempCurrentValue;
                        }
                    }
                }

            }

            //output
            Console.WriteLine(sumOfRemovedElements);
            
        }
    }
}
