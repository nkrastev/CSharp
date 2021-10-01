using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05DateModifier
{
    public class DateModifier
    {
        //fields
        private string dateItem;

        //properties
        public string DateItem{get;set;}


        //methods
        public static int Calculate(string first, string second)
        {           
            DateTime firstDate = DateTime.ParseExact($"{first}", "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact($"{second}", "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
            var difference = Math.Abs((firstDate.Date - secondDate.Date).Days);
            return difference;
        }
    }
}
