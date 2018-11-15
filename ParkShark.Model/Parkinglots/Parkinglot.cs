using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Model.Addresses;
using ParkShark.Model.Divisions;
using ParkShark.Model.Parkinglots.BuildingTypes;
using ParkShark.Model.Persons;

namespace ParkShark.Model.Parkinglots
{
    public class Parkinglot
    {
        public int Id { get; set; }
        public int DivisionId { get; set; }
        public Division PlDivision { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerHour { get; set; }
        public int ContactPersonId { get; set; }
        public Person ContactPerson { get; set; }
        public Address PlAddress { get; set; }
        public int BuildingTypeId { get; set; }
        public BuildingType PlBuildingType { get; set; }
        

    }
}
