﻿namespace MortalEngines.IO.Contracts
{
    public interface IWriter
    {
        void WriteLine(string line);

        void Write(string line);
    }
}