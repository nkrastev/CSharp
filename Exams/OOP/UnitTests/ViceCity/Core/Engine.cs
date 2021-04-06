using ViceCity.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.IO.Contracts;
using ViceCity.IO;
using System.Linq;

namespace ViceCity.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = new Controller();
        }
        public void Run()
        {
            string inputArgs;
            string message = null;
            while ((inputArgs = this.reader.ReadLine()) != "Exit")
            {
                string[] data = inputArgs.Split().ToArray();
                string command = data[0];
                try
                {
                    if (command == "AddPlayer")
                    {
                        message = this.controller.AddPlayer(data[1]);
                    }
                    else if (command == "AddGun")
                    {
                        message = this.controller.AddGun(data[1], data[2]);
                    }
                    else if (command == "AddGunToPlayer")
                    {
                        message = this.controller.AddGunToPlayer(data[1]);
                    }
                    else if (command == "Fight")
                    {
                        message = this.controller.Fight();
                    }

                }
                catch (Exception ae)
                {
                    message = ae.Message;
                }
                finally
                {
                    this.writer.WriteLine(message);
                }
            }
        }
    }
}
