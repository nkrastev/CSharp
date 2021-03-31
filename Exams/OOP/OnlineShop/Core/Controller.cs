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
            if (components.Any(x=>x.Id==id))
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.ExistingComponentId));
            }            
            
            Enum.TryParse(componentType, out ComponentType typeOfComponent);
            IComponent component = typeOfComponent switch
            {
                ComponentType.CentralProcessingUnit =>  new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.Motherboard =>            new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.PowerSupply =>            new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.RandomAccessMemory =>     new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.SolidStateDrive =>        new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.VideoCard =>              new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComponentType)
            };

            IComputer searchedComputer = computers.FirstOrDefault(x => x.Id == computerId);
            components.Add(component);
            searchedComputer.AddComponent(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(x=>x.Id==id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            Enum.TryParse(computerType, out ComputerType typeOfComputer);
            IComputer computer = typeOfComputer switch
            {
                ComputerType.DesktopComputer => new DesktopComputer(id, manufacturer, model, price),
                ComputerType.Laptop => new Laptop(id, manufacturer, model, price),                
               
                _ => throw new ArgumentException(ExceptionMessages.InvalidComputerType)
            };
            
            computers.Add(computer);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheral);
            }

            Enum.TryParse(peripheralType, out PeripheralType typeOfPeripheral);
            IPeripheral peripheral = typeOfPeripheral switch
            {
                PeripheralType.Headset => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Keyboard => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Monitor => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Mouse => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
               
                _ => throw new ArgumentException(ExceptionMessages.InvalidPeripheralType)
            };

            IComputer searchedComputer = computers.FirstOrDefault(x => x.Id == computerId);
            peripherals.Add(peripheral);
            searchedComputer.AddPeripheral(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            if (computers.Count==0 || !computers.Any(x => x.Price < budget))
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }
            computers = computers.OrderByDescending(x => x.OverallPerformance).ToList();
            IComputer buyBestItem = computers.FirstOrDefault(x => x.Price < budget);
            computers.Remove(buyBestItem);
            return buyBestItem.ToString();
        }

        public string BuyComputer(int id)
        {
            if (!computers.Any(x=>x.Id==id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            IComputer forSale = computers.FirstOrDefault(x => x.Id == id);
            computers.Remove(forSale);
            return forSale.ToString();
        }

        public string GetComputerData(int id)
        {
            if (!computers.Any(x => x.Id ==id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            IComputer computerWithData = computers.FirstOrDefault(x => x.Id == id);
            return computerWithData.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            //TODO check if component exists
            if (!computers.Any(x=>x.Id==computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            IComputer searchedComputer = computers.FirstOrDefault(x => x.Id == computerId);
            IComponent searchedComponent = searchedComputer.Components.FirstOrDefault(x => x.GetType().Name == componentType);

            searchedComputer.RemoveComponent(componentType);
            components.Remove(searchedComponent);

            return string.Format(SuccessMessages.RemovedComponent, componentType, searchedComponent.Id);

        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            //TODO check if peripheral exists
            if (!computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            IComputer searchedComputer = computers.FirstOrDefault(x => x.Id == computerId);
            IPeripheral searchedPeripheral = searchedComputer.Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            searchedComputer.RemovePeripheral(peripheralType);
            peripherals.Remove(searchedPeripheral);

            return string.Format(SuccessMessages.RemovedComponent, peripheralType, searchedPeripheral.Id);
        }
    }
}
