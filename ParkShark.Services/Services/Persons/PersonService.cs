using ParkShark.Model.Persons;
using ParkShark.Services.Repositories.Persons;
using System;
using System.Collections.Generic;
using System.Text;

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

        public Person SaveNewPerson(Person person)
        {
            _personRepository.SaveNewPerson(person);
            return person;
        }
    }
}
