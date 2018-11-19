using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return _context.Parkinglots.FirstOrDefault(parkinglot => parkinglot.Id == id);
        }

        public bool SaveNewParkinglot(Parkinglot parkinglot)
        {
            _context.Add(parkinglot);
            _context.SaveChanges();
            return true;
        }
    }

}
