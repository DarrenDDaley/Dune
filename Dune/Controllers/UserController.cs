using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dune.Models;
using Dune.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dune.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
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
            var userAdd = new User()
            {
                UserId = Guid.NewGuid(),
                UserName = "something",
                Email = "darren.daley@email.com",
                Password = "password"
            };

            repository.InsertUser(userAdd);

            return Ok();
        }
    }
}