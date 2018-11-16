using ParkShark.Model.Persons;
using System.Collections.Generic;

namespace ParkShark.Services.Services.Persons
{
    public  interface IPersonService
    {
        Person SaveNewPerson(Person person);
        List<Person> GetAll();
    }
}