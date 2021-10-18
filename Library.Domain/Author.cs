namespace Domain
{
    using System;
    using Staff.Extensions;
    /// <summary>
    /// Автор.
    /// </summary>
    public class Author : IEquatable<Author>
    {/// <summary>
     /// Конструктор на автора.
     /// </summary>
     /// <param name="id"></param>
     /// <param name="lastName"></param>
     /// <param name="firstName"></param>
     /// <param name="middleName"></param>
        public Author(int id, string lastName, string firstName, string middleName = null)
        {
            this.Id = id;

            // this.FirstName = firstName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(firstName));

            var trimmed = firstName.TrimOrNull();
            if (trimmed == null)
                throw new ArgumentOutOfRangeException(nameof(firstName));
            this.FirstName = trimmed;

            if (lastName == null)
                throw new ArgumentNullException(nameof(lastName));
            LastName = lastName;
            MiddleName = middleName.TrimOrNull();
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

        public override string ToString() => this.FullName;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((Author)obj);
        }

        public bool Equals(Author other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
