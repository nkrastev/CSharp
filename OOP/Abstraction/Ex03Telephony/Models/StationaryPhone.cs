using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03Telephony
{
    public class StationaryPhone : ICallable
    {
        private const string NUMBER_ERROR = "Invalid number!";
        public string Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                return NUMBER_ERROR;
            }
            else
            {
                return $"Dialing... {number}";
            }
            
        }
    }
}
