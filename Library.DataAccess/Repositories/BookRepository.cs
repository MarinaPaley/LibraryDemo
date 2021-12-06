// <copyright file="BookRepository.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Library.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Library.DataAccess.Repositories.Abstraction;
    using Library.Domain;
    using NHibernate;

    public class BookRepository : IRepository<Book>
    {
        public Book Get(ISession session, int id) =>
            session?.Get<Book>(id);

        public Book Find(ISession session, Expression<Func<Book, bool>> predicate)
        {
            return this.GetAll(session).FirstOrDefault(predicate);
        }

        public IQueryable<Book> GetAll(ISession session) =>
            session?.Query<Book>();

        public IQueryable<Book> Filter(ISession session, Expression<Func<Book, bool>> predicate)
        {
            return this.GetAll(session).Where(predicate);
        }

        public bool Create<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update<TEntity>(TEntity oldEntity, TEntity newEntity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Выдает список авторов без соавторов.
        /// </summary>
        /// <param name="session"> сессия.</param>
        /// <returns> Список авторов без соавторов.</returns>
        public IQueryable<Author> AuthorsWithoutCollaborates(ISession session)
        {
            return this.Filter(
                session,
                b => b.Authors.Count < 2)
                .SelectMany(b => b.Authors)
                    .Distinct();
        }
    }
}
