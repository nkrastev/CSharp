using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class TechCheck : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }
            robot.ProcedureTime -= procedureTime;

            //removes 8 energy and checks current robot(set IsChecked to true).If robot is already checked, just remove 8 energy again.
            robot.Energy -= 8;
            robot.IsChecked = true;

            //Collection should contains all robots which has visited specific procedure.
            this.Robots.Add(robot);
        }
    }
}
