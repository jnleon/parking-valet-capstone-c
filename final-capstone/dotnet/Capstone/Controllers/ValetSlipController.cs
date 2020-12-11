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
    //[Authorize(Roles = "admin, valet")]  //REMOVE COMMENT TO ENABLE AUTHORIZATION!!!
    public class ValetSlipController : ControllerBase
    {
        private readonly IValetSlipDAO valetSlipDAO;

        public ValetSlipController(IValetSlipDAO _valetSlipDAO)
        {
            valetSlipDAO = _valetSlipDAO;
        }
        
        // get by ticket id
        // https://localhost:44315/valetslip/t/1
        [HttpGet("t/{ticketid}")]
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
        // https://localhost:44315/valetslip/v/1
        [HttpGet("v/{valetid}")]
        public IActionResult GetByValetId(int valetid)
        {
            ValetSlip vs = valetSlipDAO.GetByValetId(valetid);

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

        // get by license plate
        // https://localhost:44315/valetslip/l/ABC123
        [HttpGet("l/{licensePlate}")]
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


        //private int? GetCurrentUserId()
        //{
        //    string userId = User.FindFirst("sub")?.Value;
        //    if (string.IsNullOrWhiteSpace(userId)) return null;
        //    int.TryParse(userId, out int userIdInt);
        //    return userIdInt;
        //}
    }
}