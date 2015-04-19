namespace CommandPatternAlejandro
{
    public class CommandDispatcher
    {
        private ICommandHandlerFactory Factory;

        public CommandDispatcher(ICommandHandlerFactory factory)
        {
            Factory = factory;
        }

        public void Process<T>(T command)
        {
            ICommandHandler<T> handler = Factory.Create<T>();
            
            handler.Handle(command);
        }
    }
}