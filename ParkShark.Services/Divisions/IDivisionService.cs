using ParkShark.Model.Divisions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Services.Divisions
{
    public interface IDivisionService
    {
        Division CreateDivision(string name, int DirectorId);
    }
}
