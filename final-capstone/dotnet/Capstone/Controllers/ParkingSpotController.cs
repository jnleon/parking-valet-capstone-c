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
    public class ParkingSpotController : ControllerBase
    {
        private readonly IParkingSpotDAO parkingSpotDAO;

        public ParkingSpotController(IParkingSpotDAO _parkingSpotDAO)
        {
            parkingSpotDAO = _parkingSpotDAO;
        }

        // https://localhost:44315/parkingspot/
        [HttpGet]
        public IActionResult List()
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

        // https://localhost:44315/parkingspot/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ParkingSpot ps = parkingSpotDAO.Get(id);

            if (ps == null)
            {
                //return StatusCode(500);
                return NoContent();
            }
            else
            {
                // Switch to 200 OK
                return Ok(ps);
            }
        }

        // https://localhost:44315/parkingspot/
        
        [HttpPost]
        [Authorize(Roles = "admin, owner")]
        public IActionResult Create(ParkingSpot parkingSpotToCreate)
        {
            ParkingSpot createdParkingSpot = parkingSpotDAO.Create(parkingSpotToCreate);
            if (createdParkingSpot == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("", createdParkingSpot);
            }
        }

        // https://localhost:44315/parkingspot/1
        [HttpPut("{id}")]
        [Authorize(Roles = "admin, owner, valet")]
        public IActionResult Update(int id, ParkingSpot parkingSpotToUpdate)
        {
            ParkingSpot updatedParkingSpot = parkingSpotDAO.Update(id, parkingSpotToUpdate);
            if (updatedParkingSpot == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(updatedParkingSpot);
            }
        }

        // https://localhost:44315/parkingspot/1
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin, owner")]
        public IActionResult Delete(int id)
        {
            if (parkingSpotDAO.Delete(id))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}