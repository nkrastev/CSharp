using Logger.Models.Enumarations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        void Append(IError error);

        Level Level { get; }
    }
}
