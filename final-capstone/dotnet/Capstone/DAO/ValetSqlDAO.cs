using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class ValetSqlDAO : IValetDAO
    {
        public Valet Create(Valet valetToCreate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int idToDelete)
        {
            throw new NotImplementedException();
        }

        public Valet Get(int id)
        {
            throw new NotImplementedException();
        }

        public Valet GetByUserId(int user_id)
        {
            throw new NotImplementedException();
        }

        public List<Valet> List()
        {
            throw new NotImplementedException();
        }

        public Valet Update(int idToUpdate, Valet valetToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
