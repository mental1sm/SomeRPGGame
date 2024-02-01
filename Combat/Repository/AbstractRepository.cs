using System.Linq;
using Desert.Combat.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Desert.Combat.Repository;

public abstract class AbstractRepository<T> : IRepository<T> where T : class
{
    protected readonly GameContext Context;
    protected readonly DbSet<T> DbSet;
    
    public AbstractRepository(GameContext context)
    {
        Context = context;
        DbSet = Context.Set<T>();
    }
    
    public virtual IQueryable<T> GetAll()
    {
        return DbSet.AsQueryable();
    }
    
    public virtual void Add(T t)
    {
        DbSet.Add(t);
    }

    public virtual void Delete(T t)
    {
        DbSet.Remove(t);
    }

    public virtual void Update(T t)
    {
        DbSet.Update(t);
    }

    public void SaveChanges()
    {
        Context.SaveChanges();
    }
}