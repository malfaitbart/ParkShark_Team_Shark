namespace ParkShark.Model.Persons.LicensePlates
{
    public class LicensePlate
    {
        public string LicensePlateNumber { get; set; }
        public string Country { get; set; }

        private LicensePlate() { }

        public LicensePlate(string licensePlateNumber, string country)
        {
            LicensePlateNumber = licensePlateNumber;
            Country = country;
        }
    }
}
