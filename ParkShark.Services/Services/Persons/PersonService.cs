using ParkShark.Model.Persons;
using ParkShark.Services.Repositories.Persons;
using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Infrastructure.Exceptions;

namespace ParkShark.Services.Services.Persons
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public List<Person> GetAll()
        {
            return _personRepository.GetAll();
        }

        //public Person GetById(int id)
        //{
        //    var personFound = _personRepository.GetById(id);
        //    if (personFound == null)
        //    {
        //        throw new EntityNotFoundException("GetById", "Person", id.ToString());
        //    }
        //    return personFound;
        //}

        public Person GetById(int id)
        {
            return _personRepository.GetById(id);
        }

        public Person SaveNewPerson(Person person)
        {
            _personRepository.SaveNewPerson(person);
            return person;
        }
    }
}
