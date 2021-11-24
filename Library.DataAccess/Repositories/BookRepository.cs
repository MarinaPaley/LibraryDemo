// <copyright file="BookRepository.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Library.DataAccess.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Library.DataAccess.Repositories.Abstraction;
    using Library.Domain;
    using NHibernate;

    public class BookRepository : IRepository<Book>
    {
        public Book Get(ISession session, int id) => session?.Get<Book>(id);

        public Book Find(ISession session, Expression<Func<Book, bool>> predicate)
        {
            return this.GetAll(session).FirstOrDefault(predicate);
        }

        public IQueryable<Book> GetAll(ISession session) => session?.Query<Book>();

        public IQueryable<Book> Filter(ISession session, Expression<Func<Book, bool>> predicate)
        {
            return this.GetAll(session).Where(predicate);
        }
    }
}
