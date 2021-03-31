using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {

        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;        

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance):
            base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance
        {
            get
            {
                if (this.components.Count==0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    return base.OverallPerformance + this.Components.Average(x => x.OverallPerformance);
                }
            }            
        }
        public override decimal Price => this.Peripherals.Sum(x => x.Price) + this.Components.Sum(x => x.Price) + base.Price;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Overall Performance: {this.OverallPerformance:F2}. Price: {this.Price:F2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            sb.AppendLine($" Components ({this.components.Count}):");
            
            foreach (var item in this.components)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            //if there are no peripherals division by 0
            double overrallP = this.peripherals.Any() ? this.Peripherals.Average(p => p.OverallPerformance) : 0;

            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({overrallP:F2}):");

            foreach (var item in this.peripherals)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public void AddComponent(IComponent component)
        {            
            if (this.components.Any(x=>x.GetType().Name==component.GetType().Name))
            {
                throw new ArgumentException((string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id)));
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }
            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (this.components.Count==0 || !this.components.Any(x=>x.GetType().Name==componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }
            IComponent searchedComponent = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            this.components.Remove(searchedComponent);
            return searchedComponent;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.peripherals.Count == 0 || !this.peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }
            IPeripheral searchedPeripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            this.peripherals.Remove(searchedPeripheral);
            return searchedPeripheral;
        }
    }
}