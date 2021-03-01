using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        private const string NUMBER_ERROR = "Invalid number!";
        private const string URL_ERROR = "Invalid URL!";
        public string Browse(string url)
        {
            if (url.Any(char.IsDigit))
            {
                return URL_ERROR;
            }
            else
            {
                return $"Browsing: {url}!";
            }            
        }

        public string Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                return NUMBER_ERROR;
            }
            else
            {
                return $"Calling... {number}";
            }
            
        }
    }
}
