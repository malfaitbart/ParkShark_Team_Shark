using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Model.Divisions;
using ParkShark.Services.Data;

namespace ParkShark.Services.Repositories
{
    public class DivisionRepository : IDivisionRepository
    {
        private readonly ParkSharkContext context;

        public DivisionRepository(ParkSharkContext context)
        {
            this.context = context;
        }

        public bool SaveNewDivision(Division division)
        {
            context.Add(division);
            context.SaveChanges();

            return true;
        }
    }
}
