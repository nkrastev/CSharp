using System;

namespace Mo02PascalTriangle
{
    class Program
    {
        static void Main()
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            int[] upperArray = new int[numberOfRows];
            int[] lineArray = new int[numberOfRows];

            upperArray[0] = 1;
            for (int i = 1; i < upperArray.Length; i++)
            {
                upperArray[i] = 0;
            }
            for (int i = 0; i < upperArray.Length; i++)
            {
                if (upperArray[i]!=0)
                {
                    Console.Write(upperArray[i] + " ");
                }
                
            }
            Console.WriteLine();

            //1 0 0 0 0 0 0 0 0 0
            //calculate next lines based on first one
            
            for (int i = 1; i < numberOfRows; i++)
            {                                
                lineArray[0] = 1;
                //set values to current line
                for (int j = 1; j < lineArray.Length; j++)
                {
                    lineArray[j] = upperArray[j - 1] + upperArray[j];
                }
                //print current line
                for (int j = 0; j < lineArray.Length; j++)
                {
                    if (lineArray[j]!=0)
                    {
                        Console.Write(lineArray[j] + " ");
                    }
                    
                }

                //set upper array to current line
                for (int k = 0; k < lineArray.Length; k++)
                {
                    upperArray[k] = lineArray[k];
                }
                Console.WriteLine();





            }


            
        }
    }
}
