using System;
using System.Collections.Generic;
using AutoMapper;
using Dune.Models;
using Dune.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dune.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private IUserRepository repository;

        public UserController(IMapper mapper, IUserRepository repository)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
            var userModel = mapper.Map<User>(user);
            userModel.UserId = Guid.NewGuid();

            return Ok();
        }
    }
}