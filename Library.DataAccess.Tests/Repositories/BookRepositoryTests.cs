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

            using var session = GetSession();

            PrepareBookInStorage(session, targetId);

            var repository = GetRepository();

            // act
            var result = repository.Get(session, targetId);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(targetId, result.Id);
        }

        private static void PrepareBookInStorage(ISession session, int targetId)
        {
            var book = new Book(targetId, "Тестовая");

            session.Save(book);
            session.Flush();
            session.Clear();
        }

        private static BookRepository GetRepository() => new BookRepository();

        private static ISession GetSession() => TestsConfigurator.BuildSessionForTest(showSql: true);
    }
}
