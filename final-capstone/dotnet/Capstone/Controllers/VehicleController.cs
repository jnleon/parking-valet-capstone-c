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
        private readonly IVehicleDAO vehicleDAO;
        private readonly IValetDAO valetDAO;

        public VehicleController(IVehicleDAO _vehicleDAO, IValetDAO _valetDAO)
        {
            vehicleDAO = _vehicleDAO;
            valetDAO = _valetDAO;
        }
        
        // https://localhost:44315/vehicle
        [HttpGet]
        [Authorize(Roles = "admin, valet, owner")]
        public IActionResult List()
        {
            List<Vehicle> vehicles = vehicleDAO.List();

            if (vehicles == null)
            {
                return StatusCode(500);
            }
            else
            {
                // Switch to 200 OK
                return Ok(vehicles);
            }         
        }

        
        // https://localhost:44315/vehicle/ABC123
        [HttpGet("{id}")]
        [Authorize(Roles = "admin, valet, owner")]
        public IActionResult Get(string id)
        {
            Vehicle v = vehicleDAO.Get(id);

            if (v == null)
            {
                //return StatusCode(500);
                return NoContent();
            }
            else
            {
                // Switch to 200 OK
                return Ok(v);
            }
        }

        // https://localhost:44315/vehicle
        [HttpPost]
        [Authorize(Roles = "admin, valet, owner")]
        public IActionResult Create(NewVehicle vehicleToCreate)
        {
            Valet currentValet = valetDAO.GetByUserId((int)GetCurrentUserId());
            Vehicle createdVehicle = vehicleDAO.Create(vehicleToCreate, currentValet.ValetId);
            if (createdVehicle == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("", createdVehicle);
            }
        }

        private int? GetCurrentUserId()
        {
            string userId = User.FindFirst("sub")?.Value;
            if (string.IsNullOrWhiteSpace(userId)) return null;
            int.TryParse(userId, out int userIdInt);
            return userIdInt;
        }
    }
}