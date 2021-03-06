﻿using ParkShark.Model.Divisions;
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
            (
                name,
                originalName,
                DirectorId,
                parentDivisionId
            );
            _divisionRepository.SaveNewDivision(newdivision);
            return newdivision;
        }

        public bool DeleteDivision(int id)
        {
            return _divisionRepository.DeleteDivision(id);
        }

        public List<Division> GetAll()
        {
            return _divisionRepository.GetAllDivisions();
        }

        public Division GetById(int id)
        {
            return _divisionRepository.GetById(id);
        }

        public bool UpdateDivision(Division division)
        {
            _divisionRepository.UpdateDivision(division);
            return true;
        }
    }
}
