using System;

namespace CommandPatternAlejandro
{
    public class TransactionCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private ICommandHandler<TCommand> _inner;

        public TransactionCommandHandlerDecorator(ICommandHandler<TCommand> inner )
        {
            _inner = inner;
        }
        public void Handle(TCommand command)
        {
            Console.WriteLine("Starting Transaction");

            _inner.Handle(command);

            Console.WriteLine("Ending Transaction");
        }
    }
}