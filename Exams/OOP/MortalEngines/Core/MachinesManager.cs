namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        private List<IMachine> machines;        

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();            
        }

        public string HirePilot(string name)
        {
            if (this.pilots.Any(x=>x.Name==name))
            {
                return $"Pilot {name} is hired already";
            }
            else
            {
                pilots.Add(new Pilot(name));
                return $"Pilot {name} hired";
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(x => x.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }
            else
            {
                var theTank = new Tank(name, attackPoints, defensePoints);
                machines.Add(theTank);
                return $"Tank {name} manufactured - attack: {theTank.AttackPoints}; defense: {theTank.DefensePoints}";
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(x => x.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }
            else
            {
                var theFighter = new Fighter(name, attackPoints, defensePoints);
                machines.Add(theFighter);
                return $"Fighter {name} manufactured - attack: {theFighter.AttackPoints}; defense: {theFighter.DefensePoints}; aggressive: ON";
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var message = string.Empty;
            if (!this.pilots.Any(x=>x.Name== selectedPilotName))
            {
                message= $"Pilot {selectedPilotName} could not be found";
            }
            else if (!this.machines.Any(x => x.Name == selectedMachineName))
            {
                message = $"Machine {selectedMachineName} could not be found";
            }
            else if (this.machines.Any(x=>x.Name==selectedMachineName && x.Pilot!=null))
            {
                message = $"Machine {selectedMachineName} is already occupied";
            }
            else
            {
                var theMachine = this.machines.FirstOrDefault(x => x.Name == selectedMachineName);
                var thePilot = this.pilots.FirstOrDefault(x => x.Name == selectedPilotName);
                theMachine.Pilot = thePilot;
                thePilot.AddMachine(theMachine);
                message = $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
            }
            return message;
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {            
            //check if machines exists
            if (!machines.Any(x=>x.Name==attackingMachineName))
            {
                return $"Machine {attackingMachineName} could not be found";
            }
            if (!machines.Any(x => x.Name == defendingMachineName))
            {
                return $"Machine {defendingMachineName} could not be found";
            }
            //check if machines are Alive
            var attachingMachine = machines.FirstOrDefault(x => x.Name == attackingMachineName);
            var defendingMachine = machines.FirstOrDefault(x => x.Name == defendingMachineName);

            if (attachingMachine.HealthPoints<=0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }
            if (defendingMachine.HealthPoints <= 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }
            //attach action
            attachingMachine.Attack(defendingMachine);
            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defendingMachine.HealthPoints}";
        }

        public string PilotReport(string pilotReporting) => this.pilots.FirstOrDefault(x => x.Name == pilotReporting).Report();       

        public string MachineReport(string machineName) => this.machines.FirstOrDefault(x => x.Name == machineName).ToString();              

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (!machines.Any(x=>x.Name==fighterName && x.GetType().Name == "Fighter"))
            {
                return $"Machine {fighterName} could not be found";
            }
            else
            {
                Fighter theFighter = (Fighter)machines.FirstOrDefault(x => x.Name == fighterName && x.GetType().Name=="Fighter");
                theFighter.ToggleAggressiveMode();
                return $"Fighter {fighterName} toggled aggressive mode";
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (!machines.Any(x => x.Name == tankName && x.GetType().Name == "Tank"))
            {
                return $"Machine {tankName} could not be found";
            }
            else
            {
                Tank theTank = (Tank)machines.FirstOrDefault(x => x.Name == tankName && x.GetType().Name == "Tank");
                theTank.ToggleDefenseMode();
                return $"Tank {tankName} toggled defense mode";
            }
        }
    }
}