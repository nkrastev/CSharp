using System;

namespace SpringVacationTrip
{
    class Program
    {
        static void Main()
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            double priceFuelPerKm = double.Parse(Console.ReadLine());
            double foodExPerPersonPerDay = double.Parse(Console.ReadLine());
            double roomExPerPersonPerDay = double.Parse(Console.ReadLine());

            double foodExpenses = foodExPerPersonPerDay * people * days;
            double hotelExpenses = roomExPerPersonPerDay * people * days;

            if (people > 10)
            {
                hotelExpenses -= hotelExpenses * 0.25;
            }

            double totalExpenses = foodExpenses + hotelExpenses;

            for (int i = 1; i <= days; i++)
            {
                double distance = double.Parse(Console.ReadLine());
                totalExpenses += distance * priceFuelPerKm;

                if (i % 3 == 0 || i % 5 == 0)
                {
                    //additional expenses, which are 40% of the current value of the expenses
                    totalExpenses += totalExpenses * 0.4;
                }

                if (i % 7 == 0)
                {
                    // +dividing the amount of the current expenses by the group of people
                    double additionalMoney = totalExpenses / people*1.0;
                    totalExpenses -= additionalMoney;
                }

                if (totalExpenses>budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {totalExpenses-budget:f2}$ more.");
                    break;
                }
            }

            if (totalExpenses<=budget)
            {
                Console.WriteLine($"You have reached the destination. You have {budget-totalExpenses:f2}$ budget left.");
            }            
        }
    }
}
