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
    public class ValetSlipController : ControllerBase
    {
        private readonly IValetSlipDAO valetSlipDAO;
        private readonly IVehicleValetSlipPatronDAO vehicleValetSlipPatronDAO;

        public ValetSlipController(IValetSlipDAO _valetSlipDAO, IVehicleValetSlipPatronDAO _vehicleValetSlipPatronDAO)
        {
            valetSlipDAO = _valetSlipDAO;
            vehicleValetSlipPatronDAO = _vehicleValetSlipPatronDAO;
        }
        
        // get by ticket id
        // https://localhost:44315/valetslip/ticket/1
        [HttpGet("ticket/{ticketid}")]
        [Authorize(Roles = "admin, valet, patron, owner")]
        public IActionResult Get(int ticketid)
        {
            ValetSlip vs = valetSlipDAO.Get(ticketid);

            if (vs == null)
            {
                //return StatusCode(500);
                return NoContent();
            }
            else
            {
                // Switch to 200 OK
                return Ok(vs);
            }
        }

        // get by valet id
        // https://localhost:44315/valetslip/valet/1
        [HttpGet("valet/{valetid}")]
        [Authorize(Roles = "admin, valet, owner")]
        public IActionResult GetByValetId(int valetid)
        {
            List<ValetSlip> valetSlips = valetSlipDAO.GetByValetId(valetid);

            if (valetSlips == null)
            {
                //return StatusCode(500);
                return NoContent();
            }
            else
            {
                // Switch to 200 OK
                return Ok(valetSlips);
            }
        }

        // get by license plate
        // https://localhost:44315/valetslip/licenseplate/ABC123
        [HttpGet("licenseplate/{licensePlate}")]
        [Authorize(Roles = "admin, valet, patron, owner")]
        public IActionResult GetByLicensePlate(string licensePlate)
        {
            ValetSlip vs = valetSlipDAO.GetByLicensePlate(licensePlate);

            if (vs == null)
            {
                //return StatusCode(500);
                return NoContent();
            }
            else
            {
                // Switch to 200 OK
                return Ok(vs);
            }
        }

        // https://localhost:44315/valetslip/alldata
        [HttpGet("alldata")]
        [Authorize(Roles = "admin, valet, owner")]
        public IActionResult GetAllData()
        {
            List<VehicleValetSlipPatron> v = vehicleValetSlipPatronDAO.List();
            if (v == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(v);
            }
        }

        // https://localhost:44315/valetslip/alldatapickuprequested
        [HttpGet("alldatapickuprequested")]
        [Authorize(Roles = "admin, valet, owner")]
        public IActionResult GetAllDataPickupRequested()
        {
            List<VehicleValetSlipPatron> v = vehicleValetSlipPatronDAO.ListPickupRequested();
            if (v == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(v);
            }
        }

        // park vehicle
        // https://localhost:44315/valetslip/parkvehicle/1
        [HttpPut("parkvehicle/{id}")]
        [Authorize(Roles = "admin, valet, owner")]
        public IActionResult ParkVehicle(int id, ValetSlip ValetSlipToUpdate)
        {
            ValetSlip updatedValetSlip = valetSlipDAO.ParkVehicle(id, ValetSlipToUpdate);
            if (updatedValetSlip == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(updatedValetSlip);
            }
        }

        // request vehicle pick up
        // https://localhost:44315/valetslip/pickupvehicle/1
        [HttpPut("pickupvehicle/{id}")]
        [Authorize(Roles = "admin, valet, owner")]
        public IActionResult PickupVehicle(int id, ValetSlip ValetSlipToUpdate)
        {
            ValetSlip updatedValetSlip = valetSlipDAO.PickupVehicle(id, ValetSlipToUpdate);
            if (updatedValetSlip == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(updatedValetSlip);
            }
        }

        // pick up vehicle
        // https://localhost:44315/valetslip/requestpickupvehicle/1
        [HttpPut("requestpickupvehicle/{id}")]
        [Authorize(Roles = "admin, valet, patron, owner")]
        public IActionResult RequestPickupVehicle(int id, ValetSlip ValetSlipToUpdate)
        {
            ValetSlip updatedValetSlip = valetSlipDAO.RequestPickupVehicle(id, ValetSlipToUpdate);
            if (updatedValetSlip == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(updatedValetSlip);
            }
        }
    }
}