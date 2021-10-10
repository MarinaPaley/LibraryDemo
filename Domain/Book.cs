using System;
using System.Collections.Generic;

namespace Domain
{
    public class Book
    {
        public Book(int id, string title)
        {
            Id = id;
            if (title == null)
                throw new ArgumentNullException(nameof(title), "title cannot be null");
            Title = title;
        }

        public int Id { get; protected set; }

        public string Title { get; protected set; }

        public ISet<Author> Authors = new HashSet<Author>();

        public override string ToString()
        {
            return $"{Title} {String.Join(", ", Authors)}";
        }
    }
}
