using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime<procedureTime)
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }
            robot.ProcedureTime -= procedureTime;
          
            robot.Happiness -= 5;
            if (robot.IsChipped==true)
            {
                throw new ArgumentException($"{robot.Name} is already chipped");
            }
            robot.IsChipped = true;

            //Collection should contains all robots which has visited specific procedure.
            this.Robots.Add(robot);
        }
    }
}
