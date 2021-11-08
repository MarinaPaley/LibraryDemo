// <copyright file="Author.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>
namespace Library.Domain
{
    using System;
    using System.Collections.Generic;
    using Library.Staff.Extensions;

    /// <summary>
    /// Автор.
    /// </summary>
    public class Author : IEquatable<Author>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Author"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Author(int id, string lastName, string firstName, string middleName = null)
        {
            this.Id = id;

            // this.FirstName = firstName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(firstName));

            var trimmed = firstName.TrimOrNull();

            this.FirstName = trimmed ?? throw new ArgumentOutOfRangeException(nameof(firstName));

            this.LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.MiddleName = middleName.TrimOrNull();
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; protected set; }

        public string MiddleName { get; protected set; }

        public string LastName { get; protected set; }

        public string FullName => $"{LastName} {FirstName[0]}. {MiddleName?[0]}.".Trim();

        public ISet<Book> Books { get; protected set; } = new HashSet<Book>();

        public bool AddBook(Book book)
        {
            return book == null 
                ? throw new ArgumentNullException(nameof(book))
                : this.Books.Add(book);
        }

        /// <inheritdoc/>
        public override string ToString() => this.FullName;

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((Author)obj);
        }

        /// <inheritdoc cref="IEquatable{T}"/>
        public bool Equals(Author other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.Id == other.Id;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
