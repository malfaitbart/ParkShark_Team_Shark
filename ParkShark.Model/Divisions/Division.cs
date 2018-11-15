using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Model.Divisions
{
    public class Division
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int PersonDirectorId { get; private set; }
        public int ParentDivisionId { get; private set; }

        public Division(string name, int personDirectorId)
        {
            Name = name;
            PersonDirectorId = personDirectorId;
        }
    }
}
