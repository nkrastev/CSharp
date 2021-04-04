using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs;
        private PresentRepository presents;
        private Workshop workshop;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
            this.workshop = new Workshop();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = dwarfType switch
            {
                "HappyDwarf" =>     new HappyDwarf(dwarfName),
                "SleepyDwarf" =>    new SleepyDwarf(dwarfName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType)
            };
            
            //casting... otherwise structural changes needed
            if (dwarf.GetType().Name== "HappyDwarf")
            {
                dwarfs.Add((HappyDwarf)dwarf);
            }
            else
            {
                dwarfs.Add((SleepyDwarf)dwarf);
            }            
            return String.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {            
            Instrument instrument = new Instrument(power);
            IDwarf targetDwarf = dwarfs.FindByName(dwarfName);
            if (targetDwarf==null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }
            targetDwarf.AddInstrument(instrument);
            return String.Format(OutputMessages.InstrumentAdded, power, dwarfName);
        }

        public string AddPresent(string presentName, int energyRequired)
        {            
            Present present = new Present(presentName, energyRequired);
            presents.Add(present);
            return String.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {     

            Present present = presents.FindByName(presentName);
            List<Dwarf> assignedDwarfs = dwarfs.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy).ToList();

            if (assignedDwarfs.Count==0)
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            foreach (var dwarf in assignedDwarfs)
            {
                this.workshop.Craft(present, dwarf);
                if (present.IsDone())
                {
                    break;
                }
            }
            
            foreach (var dwarf in assignedDwarfs)
            {
                if (dwarf.Energy == 0)
                {
                    this.dwarfs.Remove(dwarf);
                }
            }

            //output
            if (present.IsDone())
            {
                return String.Format(OutputMessages.PresentIsDone, presentName);
            }
            else
            {
                return String.Format(OutputMessages.PresentIsNotDone, presentName);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            int countCraftedPresents = presents.Models.Where(x => x.IsDone()).ToList().Count;
            sb.AppendLine($"{countCraftedPresents} presents are done!");
            sb.AppendLine("Dwarfs info:");
            foreach (var item in dwarfs.Models)
            {
                var notBroken = item.Instruments.Where(x => x.IsBroken() == false).ToList();
                sb.AppendLine($"Name: {item.Name}");
                sb.AppendLine($"Energy: {item.Energy}");
                sb.AppendLine($"Instruments: {notBroken.Count} not broken left");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
