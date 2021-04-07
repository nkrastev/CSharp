using MXGP.Core.Contracts;
using MXGP.IO;
using MXGP.IO.Contracts;
using System;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IChampionshipController championshipController;

        public Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
            this.championshipController = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var result = string.Empty;

                if (input[0] == "End")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "CreateRider")
                    {
                        var riderName = input[1];
                        result = championshipController.CreateRider(riderName);
                    }
                    else if (input[0] == "CreateMotorcycle")
                    {
                        var motorcycleType = input[1];
                        var model = input[2];
                        var horsepower = int.Parse(input[3]);
                        result = championshipController.CreateMotorcycle(motorcycleType, model, horsepower);
                    }
                    else if (input[0] == "AddMotorcycleToRider")
                    {
                        var riderName = input[1];
                        var motorcycleName = input[2];
                        result = championshipController.AddMotorcycleToRider(riderName, motorcycleName);
                    }
                    else if (input[0] == "AddRiderToRace")
                    {
                        var raceName = input[1];
                        var riderName = input[2];
                        result = championshipController.AddRiderToRace(raceName, riderName);
                    }
                    else if (input[0] == "CreateRace")
                    {
                        var raceName = input[1];
                        var raceLaps = int.Parse(input[2]);
                        result = championshipController.CreateRace(raceName, raceLaps);
                    }
                    else if (input[0] == "StartRace")
                    {
                        var raceName = input[1];
                        result = championshipController.StartRace(raceName);
                    }

                    writer.WriteLine(result);
                }

                catch (Exception exception)
                {
                    writer.WriteLine(exception.Message);
                }
            }
        }
    }
}