using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Models.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";
        public CommandInterpreter()
        {

        }
        public string Read(string args)
        {
            string[] commands = args.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string cmdName = commands[0]+COMMAND_POSTFIX;
            string[] cmdArgs = commands.Skip(1).ToArray();

            //get assembly to get all types
            Assembly assembly = Assembly.GetCallingAssembly();

            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == cmdName.ToLower());

            if (commandType==null)
            {
                throw new ArgumentException("Invalid Command");
            }

            //create instance
            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);

            string result = commandInstance.Execute(cmdArgs);
            return result;

        }
    }
}
