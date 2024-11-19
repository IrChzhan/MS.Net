using System.Linq.Expressions;
using BookStore.DataAccess;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly IDbContextFactory<BookStoreDbContext> _context;

    public Repository(IDbContextFactory<BookStoreDbContext> context)
    {
        _context = context;
    }

    public IEnumerable<T> GetAll()
    {
        using var dbContext = _context.CreateDbContext();
        return dbContext.Set<T>().ToList();
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        using var dbContext = _context.CreateDbContext();
        return dbContext.Set<T>().Where(predicate).ToList();
    }

    public T? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public T? GetById(Guid id)
    {
        using var dbContext = _context.CreateDbContext();
        return dbContext.Set<T>().FirstOrDefault(e => e.Id == id);
    }

    public T Save(T entity)
    {
        using var dbContext = _context.CreateDbContext();
        if (dbContext.Set<T>().AsNoTracking().FirstOrDefault(e => e.Id == entity.Id) == null)
        {
            entity.Id = Guid.NewGuid();
            entity.CreationTime = DateTime.UtcNow;
            entity.ModificationTime = DateTime.UtcNow;
            var result = dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
            return result.Entity;
        }
        else
        {
            entity.ModificationTime = DateTime.UtcNow;
            var result = dbContext.Set<T>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
            return result.Entity;
        }
    }

    public void Delete(T entity)
    {
        using var dbContext = _context.CreateDbContext();
        dbContext.Set<T>().Remove(entity);
        dbContext.SaveChanges();
    }
}