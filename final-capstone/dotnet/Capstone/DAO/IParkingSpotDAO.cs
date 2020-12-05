using System;
using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IParkingSpotDAO
    {
        ParkingSpot Get(string id);
        List<ParkingSpot> List();
        ParkingSpot Create(ParkingSpot parkingSpotToCreate);
        bool Delete(string idToDelete);
        ParkingSpot Update(ParkingSpot parkingSpotToCreate);
    }
}