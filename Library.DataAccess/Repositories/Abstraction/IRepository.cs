// <copyright file="IRepository.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Library.DataAccess.Repositories.Abstraction
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<TEntity>
    {
        TEntity Get(int id);

        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
    }
}
