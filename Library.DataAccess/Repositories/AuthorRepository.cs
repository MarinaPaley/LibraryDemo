namespace Library.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Library.DataAccess.Repositories.Abstraction;
    using Library.Domain;
    using NHibernate;

    public class AuthorRepository : IRepository<Author>
    {
        public bool Create<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Author> Filter(ISession session, System.Linq.Expressions.Expression<Func<Author, bool>> predicate)
        {
            return this.GetAll(session)
                .Where(predicate);
        }

        public Author Find(ISession session, System.Linq.Expressions.Expression<Func<Author, bool>> predicate)
        {
            return this.GetAll(session)
                .FirstOrDefault(predicate);
        }

        public Author Get(ISession session, int id) =>
                  session?.Get<Author>(id);

        public IQueryable<Author> GetAll(ISession session) =>
                  session?.Query<Author>();

        public bool Update<TEntity>(TEntity oldEntity, TEntity newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
