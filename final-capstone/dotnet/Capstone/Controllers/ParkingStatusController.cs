using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "admin, valet, owner")]
    public class ParkingStatusController : ControllerBase
    {
        private readonly IParkingStatusDAO parkingStatusDAO;

        public ParkingStatusController(IParkingStatusDAO _parkingStatusDAO)
        {
            parkingStatusDAO = _parkingStatusDAO;
        }

        // https://localhost:44315/parkingstatus/
        [HttpGet]
        public IActionResult List()
        {
            List<ParkingStatus> parkingStatuses = parkingStatusDAO.List();

            if (parkingStatuses == null)
            {
                return StatusCode(500);
            }
            else
            {
                return Ok(parkingStatuses);
            }         
        }

        // https://localhost:44315/parkingstatus/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ParkingStatus ps = parkingStatusDAO.Get(id);

            if (ps == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(ps);
            }
        }
    }
}