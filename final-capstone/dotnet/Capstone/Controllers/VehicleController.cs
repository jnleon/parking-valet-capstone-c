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
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleDAO vehicleSqlDao;

        public VehicleController(IVehicleDAO _vehicleSpotDAO)
        {
            vehicleSqlDao = _vehicleSpotDAO;
        }
        /*
        // https://localhost:44315/vehicle
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
        */
        [HttpPost]
        //[Authorize(Roles = "admin, valet")]
        public IActionResult Create(NewVehicle vehicle)
        {
            Vehicle car = vehicleSqlDao.AddVehicle(vehicle);
            if (car == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("", car);
            }
        }

        /*// https://localhost:44315/parkingspot/1
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
        }*/

        
    }
}