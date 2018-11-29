using ParkShark.Model.Parkinglots;
using ParkShark.Model.Persons;
using System.Collections.Generic;

namespace ParkShark.Model.Divisions
{
    public class Division
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public int DirectorID { get; set; }
        public Person Director { get; set; }
        public int? ParentDivisionId { get; set; }
        public Division ParentDivision { get; set; }
        public ICollection<Parkinglot> Parkinglots { get; } = new List<Parkinglot>();
        public ICollection<Division> Divisions { get; } = new List<Division>();

        private Division()
        {
        }

        public Division(string name, string originalName, int directorID, int? parentDivisionId)
        {
            //No validation of the domain class
            Name = name;
            OriginalName = originalName;
            DirectorID = directorID;
            ParentDivisionId = parentDivisionId;
        }
        public Division(int id, string name, string originalName, int directorID, int? parentDivisionId)
        {
            Id = id;
            Name = name;
            OriginalName = originalName;
            DirectorID = directorID;
            ParentDivisionId = parentDivisionId;
        }
    }
}
