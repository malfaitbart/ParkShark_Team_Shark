using System;
using System.Runtime.Serialization;

namespace ParkShark.Model.Persons
{
    [Serializable]
    public class PersonException : Exception
    {
        public PersonException(string message) : base(message)
        {
        }
    }
}