using System;

namespace CommandPatternAlejandro
{
    public class ContainerCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private ICommandHandlerFactory _factory;

        public ContainerCommandHandlerDecorator(ICommandHandlerFactory factory)
        {
            _factory = factory;
        }
        public void Handle(TCommand command)
        {
            ICommandHandler<TCommand> handler = null;
            try
            {
                ICommandHandler commandHandler = _factory.CreateByName(command.GetType().FullName);
                handler = (ICommandHandler<TCommand>) commandHandler;
                handler.Handle(command);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }
    }
}