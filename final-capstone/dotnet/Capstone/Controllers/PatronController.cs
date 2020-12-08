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
    public class PatronController : ControllerBase
    {
        private readonly IPatronDAO patronDAO;

        public PatronController(IPatronDAO _patronDAO)
        {
            patronDAO = _patronDAO;
        }

        // https://localhost:44315/patron/1
        [HttpGet("{id}")]
        public IActionResult GetByUserId(int id)
        {
            Patron p = patronDAO.GetByUserId(id);

            if (p == null)
            {
                //return StatusCode(500);
                return NoContent();
            }
            else
            {
                // Switch to 200 OK
                return Ok(p);
            }
        }
    }
}