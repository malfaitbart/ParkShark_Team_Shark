using Microsoft.EntityFrameworkCore;

namespace ParkShark.Model.Addresses
{
    [Owned]
    public class Address
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string CityName { get; set; }
    }
}
