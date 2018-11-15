using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParkShark.Model.Divisions;
using ParkShark.Services.Data;

namespace ParkShark.Services.Repositories.Divisions
{
    public class DivisionRepository : IDivisionRepository
    {
        private readonly ParkSharkContext _context;

        public DivisionRepository(ParkSharkContext context)
        {
            _context = context;
        }

        public List<Division> GetAllDevisions()
        {
            return _context.Divisions.ToList();
        }

        public bool SaveNewDivision(Division division)
        {
            _context.Add(division);
            _context.SaveChanges();

            return true;
        }
    }
}
