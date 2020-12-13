using System;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IPatronDAO
    {
        Patron GetByUserId(int userId);
        Patron Get(int patronId);
    }
}
