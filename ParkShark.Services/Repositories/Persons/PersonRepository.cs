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

        public Person GetById(int id)
        {
            //Use Find, FindAsync from EF Core
            return _context.Persons.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveNewPerson(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();

            //return (_context.SaveChanges() == 1) make it explicit that the changes were saved
            return true;
        }
    }
}
