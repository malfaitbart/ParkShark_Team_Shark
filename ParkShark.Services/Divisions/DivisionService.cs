using ParkShark.Model.Divisions;
using ParkShark.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Services.Divisions
{
    public class DivisionService : IDivisionService
    {
        private readonly IDivisionRepository divisionRepository;

        public DivisionService(IDivisionRepository divisionRepository)
        {
            this.divisionRepository = divisionRepository;
        }

        public Division CreateDivision(string name, int DirectorId)
        {
            var newdivision = new Division(name, DirectorId);
            divisionRepository.SaveNewDivision(newdivision);
            return newdivision;
        }
    }
}
