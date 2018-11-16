using ParkShark.Model.Parkinglots;
using ParkShark.Model.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Model.Divisions
{
    public class Division
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public int DirectorID { get; set; }
        public Person Director { get; set; }
        public int? ParentDivisionId { get; set; }
        public ICollection<Parkinglot> Parkinglots { get; } = new List<Parkinglot>();
    }
}
