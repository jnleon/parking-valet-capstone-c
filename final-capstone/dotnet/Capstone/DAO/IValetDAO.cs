using System;
using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IValetDAO
    {
        Valet Get(int id);
        Valet GetByUserId(int user_id);
        List<Valet> List();
        Valet Create(Valet valetToCreate);
        Valet Update(int idToUpdate, Valet valetToUpdate);
        bool Delete(int idToDelete);
    }
}