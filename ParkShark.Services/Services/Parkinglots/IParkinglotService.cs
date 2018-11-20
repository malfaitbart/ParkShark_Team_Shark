using ParkShark.Model.Parkinglots;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Services.Services.Parkinglots
{
    public interface IParkinglotService
    {
        Parkinglot CreateParkinglot(Parkinglot newParkinglot);
        List<Parkinglot> GetAll();
        Parkinglot GetOneParkinglot(int id);
        bool ReduceAvailableParkingSpots(Parkinglot parkinglot);
    }
}
