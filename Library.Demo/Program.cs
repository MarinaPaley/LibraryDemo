// <copyright file="Program.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Library.Demo
{
    using System;
    //// using System.Configuration;
    using System.Linq;

    using Library.DataAccess;
    using Library.DataAccess.Repositories;
    using Library.Domain;

    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            var author = new Author(1, "Толстой", "Лев", "Николаевич");

            var book = new Book(1, "Война и мир", author);

            Console.WriteLine($"{book} {author}");

            //// var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            var settings = new Settings();

            settings.AddDatabaseServer(@"LAPTOP-2ALR8J1J\SQLEXPRESS");

            settings.AddDatabaseName("SecuredLibrary");

            using var sessionFactory = Configurator.GetSessionFactory(settings, showSql: true);

            using (var session = sessionFactory.OpenSession())
            {
                session.Save(book);
                session.Save(author);
                session.Flush();
            }

            using (var session = sessionFactory.OpenSession())
            {
                var repo = new BookRepository();

                // TODO: Для наглядности нужно много книг с разным авторским составом!
                Console.WriteLine("Results through repo:");
                repo.Filter(session, b => b.Authors.Count < 2)
                    .SelectMany(b => b.Authors)
                    .Distinct()
                    .ToList()
                    .ForEach(Console.WriteLine);
                Console.WriteLine(new string('-', 25));
            }

            using (var session = sessionFactory.OpenSession())
            {
                var tmpBook = session.Query<Book>().First();

                Console.WriteLine(tmpBook);
            }

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Clear();
                    var persistentAuthor = session.Load<Author>(1);
                    var newBook = persistentAuthor.Books.FirstOrDefault();
                    if (newBook is null)
                    {
                        throw new ArgumentNullException(nameof(newBook));
                    }

                    var persistentBook = session.Get<Book>(newBook.Id);
                    //// persistentBook.Title = "Война и миръ";
                    //// session.SaveOrUpdate(persistentBook);
                    session.Delete(persistentBook);
                    transaction.Commit();
                }

                session.Flush();
            }
            
        }
    }
}
