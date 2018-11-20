using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Infrastructure.Exceptions;
using ParkShark.Model.Addresses;
using ParkShark.Model.Divisions;
using ParkShark.Model.Parkinglots.BuildingTypes;
using ParkShark.Model.Persons;

namespace ParkShark.Model.Parkinglots
{
    public class Parkinglot : ModelCreationCheckClass
    {
        public int Id { get; set; }
        public int DivisionId { get; set; }
        public Division PlDivision { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int AvailablePlaces { get; set; }
        public decimal PricePerHour { get; set; }
        public int ContactPersonId { get; set; }
        public Person ContactPerson { get; set; }
        public Address PlAddress { get; set; }
        public int BuildingTypeId { get; set; }
        public BuildingType PlBuildingType { get; set; }

        public void CheckValues()
        {
            CheckFilledIn(Name, "Name", this);
            CheckFilledIn(Capacity, "Capacity", this);
            CheckFilledIn(DivisionId, "DivisionId", this);
            CheckFilledIn(PricePerHour, "PricePerHour", this);
            CheckFilledIn(ContactPersonId, "ContactPersonId", this);
            PlAddress.CheckValues();
            //CheckFilledIn(PlAddress, "Parkinglot-Address", this);
            CheckFilledIn(BuildingTypeId, "BuildingTypeId", this);
        }
    }
}

