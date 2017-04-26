using System.Linq;

namespace CommandPatternAlejandro
{
    public interface IRepository<T> where T : AggregateRoot
    { 
        IQueryable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}