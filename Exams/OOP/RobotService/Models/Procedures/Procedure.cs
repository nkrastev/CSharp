using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private List<IRobot> robots;
        protected Procedure()
        {
            this.robots = new List<IRobot>();
        }

        protected List<IRobot> Robots
        {
            get=>this.robots;
            set => this.robots = value;
        }
        public abstract void DoService(IRobot robot, int procedureTime);
            
        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            foreach (var item in robots)
            {
                sb.AppendLine($" Robot type: {item.GetType().Name} - {item.Name} - Happiness: {item.Happiness} - Energy: {item.Energy}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
