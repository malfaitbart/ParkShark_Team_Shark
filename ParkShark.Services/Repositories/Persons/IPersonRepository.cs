using System.Collections.Generic;
using ParkShark.Model.Persons;

namespace ParkShark.Services.Repositories.Persons
{
    public interface IPersonRepository
    {
        bool SaveNewPerson(Person person);
        List<Person> GetAll();
    }
}