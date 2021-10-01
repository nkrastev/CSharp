using System;

namespace Mo01EncryptSortandPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());
            double[] encryptedValues = new double[numberOfStrings];

            for (int i = 0; i < numberOfStrings; i++)
            {
                string inputString = Console.ReadLine();
                double stringEncryptedValue = 0;

                //A, E, I, O, U, and sometimes Y.
                for (int j = 0; j < inputString.Length; j++)
                {
                    if ( inputString[j].ToString().ToLower() == "a" ||
                         inputString[j].ToString().ToLower() == "e" ||
                         inputString[j].ToString().ToLower() == "i" ||
                         inputString[j].ToString().ToLower() == "o" || 
                         inputString[j].ToString().ToLower() == "u" 
                         /*inputString[j].ToString().ToLower() == "y"*/
                        )
                    {
                        stringEncryptedValue += ((int)(inputString[j])*inputString.Length);
                    }
                    else
                    {
                        stringEncryptedValue += ((int)(inputString[j]) / inputString.Length);
                    }
                }
                encryptedValues[i] = stringEncryptedValue;
                //Console.WriteLine(stringEncryptedValue);


            }

            //print new array
            Array.Sort(encryptedValues);
            foreach (var item in encryptedValues)
            {
                Console.WriteLine(item);
            }
        }
    }
}
