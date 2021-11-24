// <copyright file="BookMapTests.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Library.DataAccess.Tests
{
    using FluentNHibernate.Testing;
    using Library.Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты на правила отображения <see cref="Library.DataAccess.Mappings.BookMap"/>.
    /// </summary>
    [TestFixture]
    internal class BookMapTests : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // arrange
            var book = new Book(1, "Тестовая книга");

            // act & assert
            new PersistenceSpecification<Book>(this.Session)
                .VerifyTheMappings(book);
        }
    }
}