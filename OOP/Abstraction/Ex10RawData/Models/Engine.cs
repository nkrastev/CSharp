using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData.Models
{
    public class Engine
    {
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
        

        public Engine(int engineSpeed, int enginePower)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;            
        }

        public Engine()
        {
        }
    }
}
