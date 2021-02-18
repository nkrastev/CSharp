using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Contracts
{
    public interface IFile
    {
        ILayout layout { get; }
        string Path { get; }
        long Size { get; }

        string Write(IError error);
    }
}
