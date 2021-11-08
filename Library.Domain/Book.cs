// <copyright file="Book.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Library.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Library.Staff.Extensions;

    /// <summary>
    /// Книга.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="authors"></param>
        public Book(int id, string title, params Author[] authors)
            : this(id, title, new HashSet<Author>(authors))
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="title"> Название. </param>
        /// <param name="authors"> Множество авторов. </param>
        public Book(int id, string title, ISet<Author> authors = null)
        {
            this.Id = id;

            this.Title = title.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(title));

            // NOTE: Перебираем множество авторов или пустое множество (если передан null)
            foreach (var author in authors ?? Enumerable.Empty<Author>())
            {
                this.Authors.Add(author);
                author.AddBook(this);
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
        public override string ToString() => $"{this.Title} {this.Authors.Join()}".Trim();
    }
}
