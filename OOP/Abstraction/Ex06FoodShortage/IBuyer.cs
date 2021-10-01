using System;
using System.Collections.Generic;
using System.Text;

namespace Ex06FoodShortage
{
    interface IBuyer
    {
        public string Name { get; set; }
        public int Food { get; set; }
        public void BuyFood();

    }
}
