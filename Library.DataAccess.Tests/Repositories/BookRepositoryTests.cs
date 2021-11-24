// <copyright file="BookRepositoryTests.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Library.DataAccess.Tests.Repositories
{
    using Library.DataAccess.Repositories;
    using Library.Domain;
    using NHibernate;
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для <see cref="BookRepository"/>.
    /// </summary>
    [TestFixture]
    public class BookRepositoryTests
    {
        [Test]
        public void Get_ValidId_Success()
        {
            // arrange
            var targetId = 1;

            PrepareBookInStorage(targetId);

            var repository = GetRepository();

            // act
            var result = repository.Get(targetId);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(targetId, result.Id);
        }

        private static void PrepareBookInStorage(int targetId)
        {
            var book = new Book(targetId, "Тестовая");

            using (var session = GetSession())
            {
                session.Save(book);
                session.Flush();
            }
        }

        private static BookRepository GetRepository()
        {
            throw new System.NotImplementedException();
        }

        private static ISession GetSession()
        {
            throw new System.NotImplementedException();
        }
    }
}
