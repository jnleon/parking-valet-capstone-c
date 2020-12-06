using System;
using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IParkingSpotDAO
    {
        ParkingSpot Get(int id);
        List<ParkingSpot> List();
        ParkingSpot Create(ParkingSpot parkingSpotToCreate);
        bool Delete(string idToDelete);
        ParkingSpot Update(ParkingSpot parkingSpotToUpdate);
    }
}