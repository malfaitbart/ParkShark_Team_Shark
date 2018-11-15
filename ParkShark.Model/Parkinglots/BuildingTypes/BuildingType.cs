using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Model.Parkinglots.BuildingTypes
{
    public class BuildingType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Parkinglot> Parkinglots { get; } = new List<Parkinglot>();


    }
}
