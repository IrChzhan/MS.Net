using BookStore.DataAccess.Entities;
﻿using System.Linq.Expressions;

namespace BookStore.Repository;

public interface IRepository<T> where T : BaseEntity
{
    IEnumerable<T> GetAll();
    IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);

    T? GetById(int id);

    T Save(T entity);

    void Delete(T entity);
}