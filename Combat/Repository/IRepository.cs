using System.Linq;

namespace Desert.Combat.Repository;

public interface IRepository<T> where T : class
{
    IQueryable<T> GetAll();
    void Add(T t);
    void Delete(T t);
    void Update(T t);
    void SaveChanges();
}