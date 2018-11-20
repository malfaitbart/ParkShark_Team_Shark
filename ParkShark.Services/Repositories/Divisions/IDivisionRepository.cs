using ParkShark.Model.Divisions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkShark.Services.Repositories.Divisions
{
    public interface IDivisionRepository
    {
        bool SaveNewDivision(Division division);
        List<Division> GetAllDivisions();
        Division GetById(int id);
        bool UpdateDivision(Division division);
        bool DeleteDivision(int id);
    }
}
