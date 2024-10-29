using MS.Net.DataAccess.Entities;

namespace MS.Net.DataAccess.Repository;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();

    T? GetById(int id);

    T Save(T entity);

    void Delete(T entity);
}