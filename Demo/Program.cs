using System;

namespace Demo
{
    class Program
    {

        static void Main(string[] args)
        {
            var author = new Domain.Author(1, "Лев", "Николаевич" ,"Толстой");
            Console.WriteLine(author);

            var book = new Domain.Book(1, "Война и мир");
            book.Authors.Add(author);
            Console.WriteLine(book);
            Console.ReadKey(true);
        }
    }
}
