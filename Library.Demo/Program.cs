namespace Library.Demo
{
    using System;
    using System.Configuration;
    using System.Linq;

    using Library.DataAccess;
    using Library.Demo;
    using Library.Domain;

    class Program
    {
        static void Main(string[] args)
        {
            var author = new Author(1, "Толстой", "Лев", "Николаевич");
            var book = new Book(1, "Война и мир", author);

            Console.WriteLine($"{book} {author}");

            // var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

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
                var tmpBook = session.Query<Book>().First();

                Console.WriteLine(tmpBook);
            }
        }
    }
}
