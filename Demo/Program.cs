namespace Demo
{
    using System;
    using Domain;

    internal class Program
    {
        private static void Main()
        {
            var author = new Author(1, "Толстой", "Лев", "Николаевич");
            Console.WriteLine(author);

            var book = new Book(1, "Война и мир");
            book.Authors.Add(author);
            Console.WriteLine(book);

            Console.ReadKey(true);
        }
    }
}
