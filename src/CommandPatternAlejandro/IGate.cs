namespace CommandPatternAlejandro
{
    public interface IGate
    {
        void Dispatch<T>(T command);
    }
}