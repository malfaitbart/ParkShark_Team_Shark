using ParkShark.Model.Divisions;
using ParkShark.Services.Repositories.Divisions;
using System.Collections.Generic;

namespace ParkShark.Services.Services.Divisions
{
    public class DivisionService : IDivisionService
    {
        private readonly IDivisionRepository _divisionRepository;

        public DivisionService(IDivisionRepository divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        public Division CreateDivision(string name, int DirectorId)
        {
            var newdivision = new Division(name, DirectorId);
            _divisionRepository.SaveNewDivision(newdivision);
            return newdivision;
        }

        public List<Division> GetAll()
        {
            return _divisionRepository.GetAllDevisions();
        }
    }
}
