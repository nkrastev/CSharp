using System;
using System.Diagnostics;

namespace ConsoleAppTests
{
    public class Program
    {
        static void Main(string[] args)
        {
            EventLog eventLog = new EventLog();
            eventLog.Source = "Epay";

            Dictionary<string, string> boricaErrors = new Dictionary<string, string>()
            {
                {"01", "Refer to card issuer."},
                {"04", "PICK UP."},
                {"05", "Do not Honour."},
                {"06", "Error."},
                {"12", "Invalid transaction."},
                {"13", "Invalid amount."},
                {"14", "No such card."},
                {"15", "No such issuer."},
                {"16", "Customer cancellation."},
                {"30", "Format error."},
                {"65", "Soft Decline."},
                {"91", "Issuer or switch is inoperative."},
                {"96", "System Malfunction."},                
            };
            string errorContent = "";

            try
            {
                errorContent = boricaErrors["653"];
            }
            catch (Exception ex)
            {
                eventLog.WriteEntry("Unknown borica response code. "+ex.Message);
                errorContent = "Unknown error.";
            }

            Console.WriteLine(errorContent);

        }
    }
}
