using System;
using Ninject;

namespace CommandPatternAlejandro
{
    public class NHibernateCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private ICommandHandler<TCommand> _inner;
        public IUnitOfWork UnitOfWork { get; set; }
    
        public NHibernateCommandHandlerDecorator(ICommandHandler<TCommand> inner, IUnitOfWork unitOfWork)
        {
            UnitOfWork = (UnitOfWork) unitOfWork;
            _inner = inner;
        }

        public void Handle(TCommand command)
        {
            UnitOfWork.BeginTransaction();
            Console.WriteLine("Starting dbContext");
            _inner.Handle(command);
            UnitOfWork.Commit();
            Console.WriteLine("Ending dbContext");
        }
    }
}