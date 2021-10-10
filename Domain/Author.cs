using System;

namespace Domain
{
    public class Author
    {
        public Author(int id, string firstName, string middleName, string lastName)
        {
            Id = id;
            if (firstName == null)
                throw new ArgumentNullException(nameof(firstName), "FirstName cannot be null");
            FirstName = firstName;
            if (lastName == null)
                throw new ArgumentNullException(nameof(lastName), "LastName cannot be null");
            LastName = lastName; 
            MiddleName = middleName;
        }

        public int Id { get; protected set; }

        public string FirstName { get; protected set; }

        public string MiddleName { get; protected set; }

        public string LastName { get; protected set; }

        public string FullName => ToString();

        public override string ToString()
        {
            if (MiddleName == null)
                return $"{ LastName} {FirstName[0]}.";
            return $"{ LastName} {FirstName[0]}. {MiddleName[0]}.";
        }
    }
}
