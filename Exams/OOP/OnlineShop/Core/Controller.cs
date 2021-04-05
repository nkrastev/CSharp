using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(
            int computerId, 
            int id, 
            string componentType, 
            string manufacturer, 
            string model, 
            decimal price, 
            double overallPerformance, 
            int generation)
        {
            CheckIfComputerIdExists(computerId);
            IComputer searchedComputer = computers.FirstOrDefault(x => x.Id == computerId);       

            if (components.Any(x=>x.Id==id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }            
                        
            IComponent component = componentType switch
            {
                "CentralProcessingUnit" =>  new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                "Motherboard" =>            new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                "PowerSupply" =>            new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                "RandomAccessMemory" =>     new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                "SolidStateDrive" =>       new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                "VideoCard"=>              new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException("Component type is invalid.")
            };           

            components.Add(component);
            searchedComputer.AddComponent(component);

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(x=>x.Id==id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }
            
            IComputer computer = computerType switch
            {
                "DesktopComputer" => new DesktopComputer(id, manufacturer, model, price),
                "Laptop" => new Laptop(id, manufacturer, model, price),                
               
                _ => throw new ArgumentException("Computer type is invalid.")
            };
            
            computers.Add(computer);
            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckIfComputerIdExists(computerId);
            IComputer searchedComputer = computers.FirstOrDefault(x => x.Id == computerId);
                       
            if (peripherals.Any(x => x.Id == id))
            {
                //Judge Test 16 is the exception message
                throw new ArgumentException($"Peripheral with this id already exists.");
            }
            
            IPeripheral peripheral = peripheralType switch
            {
                "Headset" => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                "Keyboard" => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                "Monitor" => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                "Mouse" => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
               
                _ => throw new ArgumentException(ExceptionMessages.InvalidPeripheralType)
            };           

            peripherals.Add(peripheral);
            searchedComputer.AddPeripheral(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            //!!! THE COMMAND IS "BuyBestComputer"
            if (computers.Count==0 || !computers.Any(x => x.Price <= budget))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            computers = computers.OrderByDescending(x => x.OverallPerformance).ThenByDescending(x=>x.Price).ToList();
            IComputer buyBestItem = computers.FirstOrDefault();
            computers.Remove(buyBestItem);
            return buyBestItem.ToString();
        }

        public string BuyComputer(int id)
        {
            CheckIfComputerIdExists(id);
            IComputer forSale = computers.FirstOrDefault(x => x.Id == id);
            computers.Remove(forSale);
            return forSale.ToString();
        }

        public string GetComputerData(int id)
        {
            CheckIfComputerIdExists(id);
            IComputer computerWithData = computers.FirstOrDefault(x => x.Id == id);
            return computerWithData.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {           
            CheckIfComputerIdExists(computerId);
            IComputer searchedComputer = computers.FirstOrDefault(x => x.Id == computerId);
            IComponent searchedComponent = searchedComputer.Components.FirstOrDefault(x => x.GetType().Name == componentType);           
            if (searchedComponent==null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent, componentType, searchedComputer.GetType().Name, computerId));
            }
            searchedComputer.RemoveComponent(componentType);
            components.Remove(searchedComponent);            
            return $"Successfully removed {componentType} with id {searchedComponent.Id}.";

        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfComputerIdExists(computerId);

            IComputer searchedComputer = computers.FirstOrDefault(x => x.Id == computerId);

            IPeripheral searchedPeripheral = searchedComputer.Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (searchedPeripheral == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, searchedComputer.GetType().Name, computerId));
            }

            searchedComputer.RemovePeripheral(peripheralType);
            peripherals.Remove(searchedPeripheral);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, searchedPeripheral.Id);
        }

        private void CheckIfComputerIdExists(int computerId)
        {
            if (!computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
