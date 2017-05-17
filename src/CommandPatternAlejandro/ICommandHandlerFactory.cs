using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPatternAlejandro
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> Create<T>();

        ICommandHandler CreateByName(string name);

        void Release(ICommandHandler handler);
    }
}
