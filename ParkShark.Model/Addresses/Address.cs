using Microsoft.EntityFrameworkCore;
using ParkShark.Infrastructure.Exceptions;

namespace ParkShark.Model.Addresses
{
    public class Address : ModelCreationCheckClass
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string CityName { get; set; }


        public void CheckValues()
        {
            CheckFilledIn(StreetName, "StreetName", this);
            CheckFilledIn(StreetNumber, "StreetNumber", this);
            CheckFilledIn(PostalCode, "PostalCode", this);
            CheckFilledIn(CityName, "CityName", this);
        }


    }
}
