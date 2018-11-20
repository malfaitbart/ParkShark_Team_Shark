using ParkShark.Model.Parkinglots;
using ParkShark.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Infrastructure.Exceptions;
using ParkShark.Services.Repositories.Parkinglots;

namespace ParkShark.Services.Services.Parkinglots
{
    public class ParkinglotService : IParkinglotService
    {
        private readonly IParkinglotRepository _parkinglotRepository;

        public ParkinglotService(IParkinglotRepository parkinglotRepository)
        {
            this._parkinglotRepository = parkinglotRepository;
        }

        public Parkinglot CreateParkinglot(Parkinglot newParkinglot)
        {
            _parkinglotRepository.SaveNewParkinglot(newParkinglot);
            return newParkinglot;
        }

        public List<Parkinglot> GetAll()
        {
            return _parkinglotRepository.GetAllParkinglots();
        }

        public Parkinglot GetOneParkinglot(int id)
        {
            var parkinglot= _parkinglotRepository.GetOneParkinglot(id);
            if (parkinglot == null)
            {
                throw new EntityNotFoundException("GetOneParkinglot", "Parkinglot", id.ToString());
            }

            return parkinglot;
        }

        public bool ReduceAvailableParkingSpots(Parkinglot parkinglot)
        {
            if (parkinglot.AvailablePlaces == 0 )
            {
                throw new EntityNotValidException("Parkinglot", parkinglot.Id.ToString());
            }
            parkinglot.AvailablePlaces--;
            return _parkinglotRepository.UpdateParkinglot(parkinglot);
        }

    }
}
