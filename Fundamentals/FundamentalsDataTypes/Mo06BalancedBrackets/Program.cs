using System;

namespace Mo06BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            int openningBrakets = 0;
            int closingBrakets = 0;
            string nextExpectedBraket = "opening";
            bool isBalanced = true;

            for (int i = 0; i < numberOfInputs; i++)
            {
                string input = Console.ReadLine();
                if (input == ")" && nextExpectedBraket == "opening")
                {
                    isBalanced = false;
                    break;
                }
                if (input == "(" && nextExpectedBraket == "closing")
                {
                    isBalanced = false;
                    break;
                }

                if (input=="(" && nextExpectedBraket == "opening")
                {
                    openningBrakets++;
                    nextExpectedBraket = "closing";
                }
                if (input==")" && nextExpectedBraket=="closing")
                {
                    closingBrakets++;
                    nextExpectedBraket = "opening";
                }
            }

            if (openningBrakets==closingBrakets && isBalanced)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
