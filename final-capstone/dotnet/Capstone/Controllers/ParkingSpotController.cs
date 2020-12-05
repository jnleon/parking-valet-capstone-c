using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParkingSpotController : ControllerBase
    {
        private readonly IParkingSpotDAO parkingSpotDAO;

        public ParkingSpotController(IParkingSpotDAO _parkingSpotDAO)
        {
            parkingSpotDAO = _parkingSpotDAO;
        }

        [HttpGet]
        public IActionResult GetAllParkingSpots()
        {
            List<ParkingSpot> parkingSpots = parkingSpotDAO.List();

            if (parkingSpots == null)
            {
                return StatusCode(500);
            }
            else
            {
                // Switch to 200 OK
                return Ok(parkingSpots);
            }         
        }
    }
}
