using System;

namespace CachingWithReflection.Models
{
    [Caching(10)]
    public class Person
    {
        public Person(int id, string name, string surname, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            ExtraData = string.Empty;
            LastOrder = null;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ExtraData { get; set; }

        public DateTime? LastOrder { get; set; }
    }
}
