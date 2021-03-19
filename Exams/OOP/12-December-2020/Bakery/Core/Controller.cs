using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<BakedFood>	bakedFoods;
        private List<Drink>	drinks;
        private List<Table>	tables;

        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;

        private decimal totalBill = 0;


        public Controller()
        {
            this.tables = new List<Table>();
            this.drinks = new List<Drink>();
            this.bakedFoods = new List<BakedFood>();
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }        

        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type != "Tea" && type != "Water")
            {
                throw new ArgumentException();
            }
            Drink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }
            this.drinks.Add(drink);
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type!="Cake" && type!="Bread" )
            {
                throw new ArgumentException("Deeba");
            }
            BakedFood food = null;

            //TODO reflection to take the type???
            if (type=="Cake")
            {
                food = new Cake(name, price);
            }
            if (type=="Bread")
            {
                food = new Bread(name, price);
            }
            this.bakedFoods.Add(food);
            return $"Added {name} ({food.GetType().Name}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type != "InsideTable" && type != "OutsideTable")
            {
                throw new ArgumentException();
            }
            Table table = null;
           
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            this.tables.Add(table);
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            List<Table> freeTables = new List<Table>();
            foreach (Table item in tables)
            {
                if (!item.IsReserved)
                {
                    freeTables.Add(item);
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in freeTables)
            {
                sb.AppendLine(item.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {           
            return $"Total income: {totalBill:f2}lv";
        }
        
        public string LeaveTable(int tableNumber)
        {
            Table target = tables.Where(x => x.TableNumber == tableNumber).FirstOrDefault();
            totalBill += target.GetBill();
            return $"Table: {tableNumber}"+Environment.NewLine+$"Bill: {target.GetBill():f2}";            
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            string message = "";
            bool isTableExisting = false;
            bool isDrinkExisting = false;

            foreach (Table item in tables)
            {
                if (item.TableNumber == tableNumber)
                {
                    isTableExisting = true;
                    break;
                }
            }
            foreach (Drink item in drinks)
            {
                if (item.Name == drinkName && item.Brand==drinkBrand)
                {
                    isDrinkExisting = true;
                    break;
                }
            }

            if (isDrinkExisting && isTableExisting)
            {
                message = $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                Table targetTable = tables.Where(x => x.TableNumber == tableNumber).FirstOrDefault();
                Drink targetDrink = drinks.Where(x => x.Name == drinkName && x.Brand==drinkBrand).FirstOrDefault();
                targetTable.OrderDrink(targetDrink);
            }
            else if (!isTableExisting)
            {
                message = $"Could not find table {tableNumber}";
            }
            else if (!isDrinkExisting)
            {
                message = $"There is no {drinkName} {drinkBrand} available";
            }

            return message;
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            string message = "";
            bool isTableExisting = false;
            bool isMealExisting = false;

            foreach (Table item in tables)
            {
                if (item.TableNumber==tableNumber)
                {
                    isTableExisting = true;
                    break;
                }
            }
            foreach (BakedFood item in bakedFoods)
            {
                if (item.Name==foodName)
                {
                    isMealExisting = true;
                    break;
                }
            }
            if (isMealExisting && isTableExisting)
            {
                message = $"Table {tableNumber} ordered {foodName}";
                Table targetTable = tables.Where(x => x.TableNumber == tableNumber).FirstOrDefault();
                BakedFood targetFood = bakedFoods.Where(x => x.Name == foodName).FirstOrDefault();
                targetTable.OrderFood(targetFood);
            }
            else if (!isTableExisting)
            {
                message = $"Could not find table {tableNumber}";
            }
            else if (!isMealExisting)
            {
                message = $"No {foodName} in the menu";
            }

            return message;
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);
            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            else
            {
                table.Reserve(numberOfPeople);
                return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
            }
        }
    }
}
