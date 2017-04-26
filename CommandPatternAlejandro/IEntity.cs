using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace CommandPatternAlejandro
{
    
    public class AggregateRoot
    {
        public virtual int Id { get; protected set; }
    }

}
