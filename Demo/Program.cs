namespace Demo
{
    using System;
    using Domain;

    /// <summary>
    /// Класс для запуска исполняемого файла
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в программа
        /// </summary>
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
