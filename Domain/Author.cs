namespace Domain
{
    using System;
    using Staff.Extensions;

    public class Author : IEquatable<Author>
    {
        public Author(int id, string lastName, string firstName, string middleName = null)
        {
            this.Id = id;

            // this.FirstName = firstName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(firstName));

            var trimmed = firstName.TrimOrNull();
            if (trimmed == null)
                throw new ArgumentOutOfRangeException(nameof(firstName));
            this.FirstName = trimmed;

            if (lastName == null)
                throw new ArgumentNullException(nameof(lastName), "LastName cannot be null");
            LastName = lastName;
            MiddleName = middleName;
        }

        public int Id { get; protected set; }

        public string FirstName { get; protected set; }

        public string MiddleName { get; protected set; }

        public string LastName { get; protected set; }

        public string FullName => $"{LastName} {FirstName[0]}. {MiddleName?[0]}.".Trim();

        public override string ToString() => this.FullName;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((Author) obj);
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
