using ParkShark.Model.Persons;
using ParkShark.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkShark.Services.Repositories.Persons
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ParkSharkContext _context;

        public PersonRepository(ParkSharkContext context)
        {
            _context = context;
        }

        public List<Person> GetAll()
        {
            return _context.Persons.ToList();
        }

        public bool SaveNewPerson(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();

            return true;
        }
    }
}
