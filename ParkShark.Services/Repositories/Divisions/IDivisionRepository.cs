using ParkShark.Model.Divisions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Services.Repositories.Divisions
{
    public interface IDivisionRepository
    {
        bool SaveNewDivision(Division division);
        List<Division> GetAllDevisions();
    }
}
