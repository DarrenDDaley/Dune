using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dune.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dune.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public UserController()
        {
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Post([FromBody]UserApiModel user)
        {
            if (ModelState.IsValid) {
                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}