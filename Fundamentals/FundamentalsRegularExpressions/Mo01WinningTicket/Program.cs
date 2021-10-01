using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mo01WinningTicket
{
    class Program
    {
        static void Main()
        {
            string[] tickets = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();            

            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i].Length>20 || tickets[i].Length<20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    TicketValidator(tickets[i]);
                }
            }
        }

        private static void TicketValidator(string ticket)
        {
            bool isMatch = true;
            //split ticket on two sides
            string leftSide = ticket.Substring(0, 10);
            string rightSide = ticket.Substring(10, 10);

            Regex regex = new Regex(@"(\@{6,10}|\${6,10}|\^{6,10}|\#{6,10})");

            var leftMatch = regex.Match(leftSide);
            var rightMatch = regex.Match(rightSide);

            if (!leftMatch.Success || !rightMatch.Success)
            {
                Console.WriteLine($"ticket \"{ ticket}\" - no match");
                isMatch = false;
            }

            // if left and right matches are with diff number of symbols
            int minLenght = Math.Min(leftMatch.Length, rightMatch.Length);

            //get equal sides for compare
            string leftPart = leftMatch.Value.Substring(0, minLenght);
            string rightPart = rightMatch.Value.Substring(0, minLenght);

            if (leftPart==rightPart && isMatch)
            {
                if (leftPart.Length == 10)
                {
                    Console.WriteLine($"ticket \"{ ticket}\" - {minLenght}{leftPart[0]} Jackpot!");                    
                }
                else
                {
                    Console.WriteLine($"ticket \"{ ticket}\" - {minLenght}{leftPart[0]}");
                    
                }
            }            
        }
    }
}
