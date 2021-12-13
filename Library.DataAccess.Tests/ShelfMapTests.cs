// <copyright file="ShelfMapTest.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using FluentNHibernate.Testing;
    using Library.DataAccess.Tests;
    using Library.Domain;
    using NHibernate.Cfg;
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для класса <see cref="Mappings.ShelfMap"/>.
    /// </summary>
    [TestFixture]
    public class ShelfMapTests : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // arrange
            var shelf = new Shelf(1, "Тестовая полка");

            // act & assert
            new PersistenceSpecification<Shelf>(this.Session)
                .VerifyTheMappings(shelf);
        }
    }
}