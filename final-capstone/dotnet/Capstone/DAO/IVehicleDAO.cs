using System;
using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IVehicleDAO
    {
        Vehicle Create(NewVehicle vehicleToCreate);
        List<Vehicle> List();
        Vehicle Get(string licensePlate);
    }
}
