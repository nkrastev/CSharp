using System;
using System.Linq;

namespace Ex05MultiplyBigNumber
{
    class Program
    {
        static void Main()
        {
            string bigNumber = Console.ReadLine();
            string multiplier = Console.ReadLine();
            
            bigNumber=bigNumber.TrimStart(new char[] { '0' });

            if (bigNumber=="0" || multiplier=="0" || bigNumber=="" || multiplier=="")
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(Multiply(bigNumber, multiplier));
            }

            

        }

        private static string Multiply(string bigNumber, string multiplier)
        {
            string result = "";
            int rest = 0;

            for (int i = bigNumber.Length-1; i >= 0; i--)
            {
                int digit = (int)Char.GetNumericValue(bigNumber[i]);

                int tempresult = digit * int.Parse(multiplier)+rest;
                rest = 0;

                int digitToAdd = tempresult % 10;
                rest = tempresult / 10;

                result += digitToAdd.ToString();
            }

            if (rest!=0)
            {
                result += rest;
            }

            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            result=new string(charArray);

            return result;
        }
    }
}
