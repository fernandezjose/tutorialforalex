namespace CommandPatternAlejandro
{
    public class LoggerCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private ICommandHandler<TCommand> _inner; 
        public LoggerCommandHandlerDecorator(ICommandHandler<TCommand> command )
        {
            _inner = command;
        }
        public void Handle(TCommand command)
        {
            _inner.Handle(command);
        }
    }
}