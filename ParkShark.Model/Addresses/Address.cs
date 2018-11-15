using Microsoft.EntityFrameworkCore;
using ParkShark.Infrastructure.Exceptions;

namespace ParkShark.Model.Addresses
{
    [Owned]
    public class Address : ModelCreationCheckClass
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string CityName { get; set; }


        public void CheckValues()
        {
            CheckFilledIn(StreetName, "StreetName");
            CheckFilledIn(StreetNumber, "StreetNumber");
            CheckFilledIn(PostalCode, "PostalCode");
            CheckFilledIn(CityName, "CityName");
        }


    }
}
