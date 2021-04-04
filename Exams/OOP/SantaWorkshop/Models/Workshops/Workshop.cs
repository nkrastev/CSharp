using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }
        public void Craft(IPresent present, IDwarf dwarf)
        {
           
            while (
                !present.IsDone() || 
                dwarf.Energy==0 || 
                dwarf.Instruments.Any(x=>x.Power>0))
            {
                present.GetCrafted();
                dwarf.Work();
            }
        }
    }
}
