using Chronometer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronometer.Entities
{
    public class Chronometer : IChronometer
    {
        
        public string GetTime => throw new NotImplementedException();

        public List<string> Laps => throw new NotImplementedException();

        public string Lap()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
