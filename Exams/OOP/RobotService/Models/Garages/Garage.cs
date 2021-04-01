using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Models.Garages
{
    public abstract class Garage : IGarage
    {        
        private readonly Dictionary<string, IRobot> robots;
        private int capacity;

        public Garage()
        {     
            this.robots = new Dictionary<string, IRobot>();
        }

        public int Capacity 
        {
            get => capacity; 
            private set => capacity = 10; 
        }


        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public void Manufacture(IRobot robot)
        {           
            if (this.Capacity>=10)
            {
                throw new ArgumentException("Not enough capacity");
            }
            if (this.robots.Any(x=>x.Key==robot.Name))
            {
                throw new ArgumentException($"Robot {robot.Name} already exist");
            }            
            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
           
            if (!this.robots.Any(x=>x.Key==robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            var targetRobotAsDictionery = this.robots.FirstOrDefault(x => x.Key == robotName);
            IRobot targetRobot = targetRobotAsDictionery.Value;

            this.robots.Remove(targetRobot.Name);

            targetRobot.IsBought = true;
            targetRobot.Owner = ownerName;

        }
    }
}
