using BookStore.DataAccess;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly IDbContextFactory<BookStoreDbContext> _dbContextFactory;

    public Repository(IDbContextFactory<BookStoreDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    private BookStoreDbContext _context;
    private BookStoreDbContext GetContext()
    {
        _context = _context ?? _dbContextFactory.CreateDbContext();
        return _context;
    }
    public IQueryable<T> GetAll()
    {
        return GetContext().Set<T>();
    }

    public T? GetById(int id)
    {
        return GetContext().Set<T>().FirstOrDefault(x => x.Id == id);
    }
    
    public T Save(T entity)
    {
        if (entity.CreationTime == default(DateTime) && entity.ModificationTime == default(DateTime)) //More robust null check
        {
            entity.init();
            var result = GetContext().Set<T>().Add(entity);
            GetContext().SaveChanges();
            return result.Entity;
        }
        else
        {
            entity.ModificationTime = DateTime.UtcNow;
            GetContext().Set<T>().Update(entity); //More efficient update method
            GetContext().SaveChanges();
            return entity;
        }
    }

    public void Delete(T entity)
    {
        GetContext().Set<T>().Remove(entity);
        GetContext().SaveChanges();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
    // private DbContext _context;
    // public Repository(DbContext context)
    // {
    //     _context = context;
    // }
    //
    // public IQueryable<T> GetAll()
    // {
    //     return _context.Set<T>();
    // }
    //
    // public T? GetById(int id)
    // {
    //     return _context.Set<T>().FirstOrDefault(x => x.Id == id);
    // }
    //
    // public T Save(T entity)
    // {
    //     if (entity.CreationTime == entity.ModificationTime)
    //     {
    //         entity.init();
    //         var result = _context.Set<T>().Add(entity);
    //         _context.SaveChanges();
    //         return result.Entity;
    //     }
    //     else
    //     {
    //         entity.ModificationTime = DateTime.UtcNow;
    //         var result = _context.Set<T>().Attach(entity);
    //         _context.Entry(entity).State = EntityState.Modified;
    //         _context.SaveChanges();
    //         return result.Entity;
    //     }
    // }
    //
    // public void Delete(T entity)
    // {
    //     _context.Set<T>().Attach(entity);
    //     _context.Entry(entity).State = EntityState.Deleted;
    //     _context.SaveChanges();
    // }
}