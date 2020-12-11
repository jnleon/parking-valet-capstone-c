using System;
using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IValetDAO
    {
        Valet GetByUserId(int user_id);
    }
}