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
        // TODO: Откуда берем сессию?
        private readonly ISession session;

        public Book Get(int id) => this.session.Get<Book>(id);

        public Book Find(Expression<Func<Book, bool>> predicate) => this.GetAll().FirstOrDefault(predicate);

        public IQueryable<Book> GetAll() => this.session.Query<Book>();

        public IQueryable<Book> Filter(Expression<Func<Book, bool>> predicate) => this.GetAll().Where(predicate);
    }
}
