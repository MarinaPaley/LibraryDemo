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
        /// <param name="id"> Идентификатор. </param>
        /// <param name="lastName"> Фамилия. </param>
        /// <param name="firstName"> Имя. </param>
        /// <param name="middleName"> Отчество. </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// В случае если <paramref name="lastName"/> или <paramref name="firstName"/> <see langword="null"/>, пустая строка
        /// или строка, содержащая только пробельные символы.
        /// </exception>
        public Author(int id, string lastName, string firstName, string middleName = null)
        {
            this.Id = id;
            this.FirstName = firstName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(firstName));
            this.LastName = lastName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(lastName));
            this.MiddleName = middleName.TrimOrNull();
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Author"/>.
        /// </summary>
        [Obsolete("For ORM", true)]
        protected Author()
        {
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public virtual int Id { get; protected set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public virtual string FirstName { get; protected set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public virtual string LastName { get; protected set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public virtual string MiddleName { get; protected set; }

        /// <summary>
        /// Полное имя.
        /// </summary>
        public virtual string FullName => $"{this.LastName} {this.FirstName[0]}. {this.MiddleName?[0]}.".Trim();

        /// <summary>
        /// Множество книг.
        /// </summary>
        public virtual ISet<Book> Books { get; protected set; } = new HashSet<Book>();

        /// <summary>
        /// Метод, добавляющий книгу автору.
        /// </summary>
        /// <param name="book"> Добавляемая книга. </param>
        /// <returns>
        /// Флаг успешности выполнения операции:
        /// <see langword="true"/> – книга была успешно добавлена,
        /// <see langword="false"/> в противном случае.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// В случае если <paramref name="book"/> – <see langword="null"/>.
        /// </exception>
        public virtual bool AddBook(Book book)
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
            return !ReferenceEquals(null, obj) && (ReferenceEquals(this, obj) || this.Equals(obj as Author));
        }

        /// <inheritdoc cref="IEquatable{T}"/>
        public virtual bool Equals(Author other)
        {
            return !ReferenceEquals(null, other) && (ReferenceEquals(this, other) || this.Id == other.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Id;
    }
}
