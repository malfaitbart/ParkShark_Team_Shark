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

        public Division CreateDivision(string name, string originalName, int DirectorId, int? parentDivisionId = null)
        {
            var newdivision = new Division
            {
                Name = name,
                OriginalName = originalName,
                DirectorID = DirectorId,
                ParentDivisionId = parentDivisionId
            };
            _divisionRepository.SaveNewDivision(newdivision);
            return newdivision;
        }

        public List<Division> GetAll()
        {
            return _divisionRepository.GetAllDevisions();
        }
    }
}
