using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

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
    }
}
