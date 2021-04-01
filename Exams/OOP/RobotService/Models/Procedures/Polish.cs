using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class Polish : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }
            robot.ProcedureTime -= procedureTime;

            robot.Happiness -= 7;

            //Collection should contains all robots which has visited specific procedure.
            this.Robots.Add(robot);
        }
    }
}
