using ParkShark.Model.Divisions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Services.Repositories
{
    public interface IDivisionRepository
    {
        bool SaveNewDivision(Division division);
    }
}
