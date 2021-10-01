using System;

namespace Ex10TopNumber
{
    class Program
    {
        static void Main()
        {
            int range = int.Parse(Console.ReadLine());
            for (int i = 0; i < range; i++)
            {
                if (CheckTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool CheckTopNumber(int number)
        {            
            //Its sum of digits is divisible by 8
            bool firstCheck = false;
            bool secondCheck = false;
            string numberStr = number.ToString();
            int numbersSum = 0;
            for (int i = 0; i < numberStr.Length; i++)
            {
                numbersSum += int.Parse(numberStr[i].ToString());
            }
            if (numbersSum % 8 ==0)
            {
                firstCheck = true;
            }
            //Holds at least one odd digit, e.g. 232, 707, 87578
            for (int i = 0; i < numberStr.Length; i++)
            {
                int currentDigit = int.Parse(numberStr[i].ToString());
                if (currentDigit % 2!=0)
                {
                    secondCheck = true;
                    break;
                }
            }
            if (firstCheck && secondCheck)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
    }
}
