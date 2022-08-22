using Advent.FinalProject.Contracts.Repository;
using Advent.FinalProject.Core.V1;
using Advent.FinalProject.Entities.DTOs;
using Advent.FinalProject.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Advent.FinalProject.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserCore _core;

        public UsersController(ILogger<User> logger, IMapper mapper, IUserRepository context)
        {
            _core = new(context, logger, mapper);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<User>>> Get()
        {
            var response = await _core.GetAll();
            return StatusCode((int)response.StatusHttp, response);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserCreateDto user)
        {
            var response = await _core.CreateUser(user);
            return StatusCode((int)response.StatusHttp, response);
        }
    }
}
