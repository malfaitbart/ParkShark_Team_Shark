using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ParkShark.Model.Parkinglots;
using ParkShark.Services.Data;

namespace ParkShark.Services.Repositories.Parkinglots
{
    public class ParkinglotRepository: IParkinglotRepository
    {
        private readonly ParkSharkContext _context;

        public ParkinglotRepository(ParkSharkContext context)
        {
            _context = context;
        }

        public List<Parkinglot> GetAllParkinglots()
        {
            return _context.Parkinglots.ToList();
        }

        public Parkinglot GetOneParkinglot(int id)
        {
            //Use EF Core methods Find and FindAsync (this is faster in EF, cuts off the LINQ overhead)
            return _context.Parkinglots.FirstOrDefault(parkinglot => parkinglot.Id == id);
        }

        public bool UpdateParkinglot(Parkinglot parkinglot)
        {
            _context.Update(parkinglot);
            return (_context.SaveChanges() == 1);
        }


        public bool SaveNewParkinglot(Parkinglot parkinglot)
        {
            _context.Add(parkinglot);
            return (_context.SaveChanges() == 1);
        }
    }

}
