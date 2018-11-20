using System;

namespace ParkShark.Model.Persons.LicensePlates
{
    public class LicensePlate 
    {
        public string LicensePlateNumber { get; set; }
        public string Country { get; set; }

        public override bool Equals(object obj)
        {
            var plate = obj as LicensePlate;
            return plate != null &&
                   LicensePlateNumber == plate.LicensePlateNumber &&
                   Country == plate.Country;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LicensePlateNumber, Country);
        }

        private LicensePlate() { }

        public LicensePlate(string licensePlateNumber, string country)
        {
            LicensePlateNumber = licensePlateNumber;
            Country = country;
        }
    }
}
