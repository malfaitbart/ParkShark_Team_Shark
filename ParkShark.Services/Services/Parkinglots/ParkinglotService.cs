using ParkShark.Model.Parkinglots;
using ParkShark.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
