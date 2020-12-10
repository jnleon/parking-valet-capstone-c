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

        public VehicleController(IVehicleDAO _vehicleDAO)
        {
            vehicleDAO = _vehicleDAO;
        }
        
        // https://localhost:44315/vehicle
        [HttpGet]
        //[Authorize(Roles = "admin, valet")]
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
                return Ok(vehicles); ;
            }         
        }

        
        // https://localhost:44315/vehicle/ABC123
        [HttpGet("{id}")]
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
        //[Authorize(Roles = "admin, valet")]
        public IActionResult Create(NewVehicle vehicleToCreate)
        {
            Vehicle createdVehicle = vehicleDAO.Create(vehicleToCreate);
            if (createdVehicle == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("", createdVehicle);
            }
        }        
    }
}