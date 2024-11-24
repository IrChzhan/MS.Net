using BookStore.DataAccess.Entities;
﻿using System.Linq.Expressions;

namespace BookStore.Repository;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();

    T? GetById(int id);

    T Save(T entity);

    void Delete(T entity);
}