using ParkShark.Model.Addresses;

namespace ParkShark.API.Controllers.Parkinglots
{
    public class ParkinglotDto
    {
        public int Id { get; set; }
        public int DivisionId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int AvailablePlaces { get; set; }
        public decimal PricePerHour { get; set; }
        public int ContactPersonId { get; set; }
        public Address PlAddress { get; set; }
        public int BuildingTypeId { get; set; }
        
    }
}