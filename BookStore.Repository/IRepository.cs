using BookStore.DataAccess.Entities;

namespace BookStore.Repository;

public interface IRepository<T> where T : IBaseEntity
{
    IQueryable<T> GetAll(object unknown);

    T? GetById(int id);

    T Save(T entity);

    void Delete(T entity);
}