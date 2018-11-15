using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Model.Divisions
{
    public class Division
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public int PersonDirectorId { get; set; }
        public int? ParentDivisionId { get; set; }

    }
}
