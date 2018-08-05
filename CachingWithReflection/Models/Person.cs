using System;

namespace CachingWithReflection.Models
{
    [Caching(60)]
    public class Person : ICachingModel
    {
        public Person()
        {
        }

        public Person(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public override string ToString()
        {
            return "Id : " + Id + " Name : " + Name + " Surname : " + Surname;
        }
    }
}
