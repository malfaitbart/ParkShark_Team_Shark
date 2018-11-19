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
    }
}
