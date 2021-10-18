using Library.Domain;

namespace Library.Demo
{
    using System;
    using Library.Demo;
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book(1, "Война и мир");
            var author = new Author(1, "Толстой", "Лев", "Николаевич");

            Console.WriteLine($"{book} {author}");
        }
    }
}
