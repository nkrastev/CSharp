using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Models.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] args) 
        {
            Environment.Exit(0);
            return null;
        }
    }
}
