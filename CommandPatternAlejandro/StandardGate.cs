namespace CommandPatternAlejandro
{
    public class StandardGate : IGate
    {
        private CommandDispatcher Dispatcher;

        public StandardGate(CommandDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
        }
        public void Dispatch<T>(T command)
        {
            Dispatcher.Process(command);
        }
    }
}