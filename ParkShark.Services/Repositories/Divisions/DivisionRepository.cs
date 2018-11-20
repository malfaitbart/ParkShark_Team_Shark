using ParkShark.Model.Divisions;
using ParkShark.Services.Data;
using System.Collections.Generic;
using System.Linq;

namespace ParkShark.Services.Repositories.Divisions
{
    public class DivisionRepository : IDivisionRepository
    {
        private readonly ParkSharkContext _context;

        public DivisionRepository(ParkSharkContext context)
        {
            _context = context;
        }

        public bool DeleteDivision(int id)
        {
            var divisiontodelete = _context.Divisions.FirstOrDefault(d => d.Id == id);
            if (divisiontodelete != null)
            {
                _context.Divisions.Remove(divisiontodelete);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Division> GetAllDivisions()
        {
            return _context.Divisions.ToList();
        }

        public Division GetById(int id)
        {
            return _context.Divisions.FirstOrDefault(d => d.Id == id);
        }

        public bool SaveNewDivision(Division division)
        {
            _context.Add(division);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateDivision(Division division)
        {
            _context.Update(division);
            _context.SaveChanges();
            return true;
        }
    }
}
