using Advent.FinalProject.Contracts.Repository;
using Advent.FinalProject.Core.V1;
using Advent.FinalProject.Entities.DTOs;
using Advent.FinalProject.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Advent.FinalProject.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationCore _core;

        public AuthenticationController(ILogger<User> userLogger, IMapper mapper, IUserRepository userRepository, IConfiguration configuration)
        {
            _core = new(userRepository, userLogger, mapper, configuration);
        }
        // POST api/<AuthtenticationController>
        [HttpPost]
        public async Task<ActionResult<UserLoginDto>> Login([FromBody] UserLoginRequestDto request)
        {
            var response = await _core.AuthUser(request);
            return StatusCode((int)response.StatusHttp, response);

        }
    }
}
