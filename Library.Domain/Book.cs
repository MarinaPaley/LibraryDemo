// <copyright file="Book.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>


namespace Library.Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extensions;

    /// <summary>
    /// Книга.
    /// </summary>
    public class Book
    {
        public Book(int id, string title, params Author[] authors) 
            : this(id, title, new HashSet<Author>(authors))
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        public Book(int id, string title, ISet<Author> authors = null)
        {
            this.Id = id;

            var trimmedTitle = title.TrimOrNull();

            this.Title = trimmedTitle ?? throw new ArgumentOutOfRangeException(nameof(title));

            if (authors != null)
            {
                foreach (var author in authors)
                {
                    this.Authors.Add(author);
                    author.AddBook(this);
                }
            }
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; protected set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public ISet<Author> Authors { get; protected set; } = new HashSet<Author>();

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.Title} {this.Authors.Join()}".Trim();
        }
    }
}
