namespace CommandPatternAlejandro
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}