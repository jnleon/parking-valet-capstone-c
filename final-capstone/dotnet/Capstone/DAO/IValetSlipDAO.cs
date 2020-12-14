using System;
using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IValetSlipDAO
    {
        ValetSlip Get(int ticketId);
        ValetSlip GetByLicensePlate(string licensePlate);
        List<ValetSlip> GetByValetId(int valetId);
        ValetSlip ParkVehicle(int idToUpdate, ValetSlip valetSlipForVehicleToPark);
        ValetSlip PickupVehicle(int idToUpdate, ValetSlip valetSlipForVehicleToPickup);
        ValetSlip RequestPickupVehicle(int idToUpdate, ValetSlip valetSlipForVehicleToRequestPickup);
    }
}