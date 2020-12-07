using System;
using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IParkingStatusDAO
    {
        List<ParkingStatus> List();
        ParkingStatus Get(int id);
    }
}
