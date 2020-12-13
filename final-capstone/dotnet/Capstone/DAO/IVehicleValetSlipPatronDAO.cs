using System;
using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IVehicleValetSlipPatronDAO
    {
        List<VehicleValetSlipPatron> List();
    }
}