using ParkShark.Model.Divisions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Services.Services.Divisions
{
    public interface IDivisionService
    {
        Division CreateDivision(string name, string originalName, int DirectorId, int? parentDivisionId = null);
        List<Division> GetAll();
    }
}
