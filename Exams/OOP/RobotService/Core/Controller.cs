using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private Garage garage;
        private Dictionary<string, List<IRobot>> procedures;
        public Controller()
        {
            this.procedures = new Dictionary<string, List<IRobot>>();
            this.garage = new Garage();
        }
        public string Charge(string robotName, int procedureTime)
        {
            IfRobotExistInGarage(robotName);
            IRobot robot = garage.Robots[robotName];
            IProcedure charge = new Charge();
            charge.DoService(robot, procedureTime);
            AddProcedureNameAndRobot("Charge", robot);
            return $"{robotName} had charge procedure";
        }

        public string Chip(string robotName, int procedureTime)
        {
            IfRobotExistInGarage(robotName);
            IRobot robot = garage.Robots[robotName];
            IProcedure chip = new Chip();
            chip.DoService(robot, procedureTime);
            AddProcedureNameAndRobot("Chip", robot);
            return $"{robotName} had chip procedure";
        }

        public string History(string procedureType)
        {
            //DO not check if exist in garage
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(procedureType);
            foreach (var item in procedures[procedureType])
            {
                sb.AppendLine($" Robot type: {item.GetType().Name} - {item.Name} - Happiness: {item.Happiness} - Energy: {item.Energy}");
            }
            return sb.ToString().TrimEnd();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            //DO not check if exist in garage         
            IRobot robot = robotType switch
            {
                "HouseholdRobot"    => new HouseholdRobot(name, energy, happiness, procedureTime),
                "PetRobot"          => new PetRobot(name, energy, happiness, procedureTime),
                "WalkerRobot"       => new WalkerRobot(name, energy, happiness, procedureTime),                
                _ => throw new ArgumentException($"{robotType} type doesn't exist")
            };
            this.garage.Manufacture(robot);
            return $"Robot {name} registered successfully";           
        }

        public string Polish(string robotName, int procedureTime)
        {
            IfRobotExistInGarage(robotName);
            IRobot robot = garage.Robots[robotName];
            IProcedure polish = new Polish();
            polish.DoService(robot, procedureTime);
            AddProcedureNameAndRobot("Polish", robot);
            return $"{robotName} had polish procedure";
        }

        public string Rest(string robotName, int procedureTime)
        {
            IfRobotExistInGarage(robotName);
            IRobot robot = garage.Robots[robotName];
            IProcedure rest = new Rest();
            rest.DoService(robot, procedureTime);
            AddProcedureNameAndRobot("Rest", robot);
            return $"{robotName} had tech rest procedure";
        }

        public string Sell(string robotName, string ownerName)
        {
            IfRobotExistInGarage(robotName);            
            IRobot robot = garage.Robots[robotName];
            garage.Sell(robotName, ownerName);
            if (robot.IsChipped)
            {
                return $"{ownerName} bought robot with chip";
            }
            else
            {
                return $"{ownerName} bought robot without chip";
            }

        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IfRobotExistInGarage(robotName);
            IRobot robot = garage.Robots[robotName];
            IProcedure techCheck = new TechCheck();
            techCheck.DoService(robot, procedureTime);
            AddProcedureNameAndRobot("TechCheck", robot);
            return $"{robotName} had tech check procedure";
        }

        public string Work(string robotName, int procedureTime)
        {
            IfRobotExistInGarage(robotName);
            IRobot robot = garage.Robots[robotName];
            IProcedure work = new Work();
            work.DoService(robot, procedureTime);
            AddProcedureNameAndRobot("Work", robot);
            return $"{robotName} was working for {procedureTime} hours";
        }

        //NOTE: For each command except for "Manufacture" and "History",
        //you must check if a robot with that name exist in the garage.
        //If it doesn't, throw an ArgumentException with the message "Robot {robot name} does not exist". 
        private void IfRobotExistInGarage(string robotName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }            
        }
        private void AddProcedureNameAndRobot(string procedureName, IRobot robot)
        {
            if (procedures.ContainsKey(procedureName))
            {
                procedures[procedureName].Add(robot);
            }
            else
            {
                procedures.Add(procedureName, new List<IRobot>());
                procedures[procedureName].Add(robot);
            }            
        }
    }
}
