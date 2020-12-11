using System;
using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IValetSlipDAO
    {
        ValetSlip Get(int ticketId);
        ValetSlip GetByLicensePlate(string licensePlate);
        ValetSlip GetByValetId(int valetId);
    }
}