using CachingWithReflection.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CachingWithReflection.Repository
{
    public class ClientRepository
    {
        private List<Person> _people;

        public ClientRepository()
        {
            _people = new List<Person>();
        }

        public ClientRepository(List<Person> people)
        {
            _people = people ?? throw new ArgumentNullException(nameof(people));
        }

        public void AddClient(Person person)
        {
            _people.Add(person);
        }

        public Person GetById(int id)
        {
            return _people.First(person => person.Id == id);
        }

    }
}
