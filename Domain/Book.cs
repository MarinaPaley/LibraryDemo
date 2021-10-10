namespace Domain
{
    using Staff.Extensions;
    using System;
    using System.Collections.Generic;

    public class Book
    {
        public Book(int id, string title)
        {
            Id = id;

            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            Title = title;
        }

        public int Id { get; protected set; }

        public string Title { get; protected set; }

        public ISet<Author> Authors { get; protected set; } = new HashSet<Author>();

        public override string ToString()
        {
            // return $"{this.Title} {this.Authors.Join()}".Trim();
            return $"{Title} {string.Join(", ", Authors)}"; //.Trim();
        }
    }
}
