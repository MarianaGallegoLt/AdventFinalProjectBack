using Advent.FinalProject.Contracts.Repository;
using Advent.FinalProject.Core.V1;
using Advent.FinalProject.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Advent.FinalProject.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentCore _core;
        public PaymentsController(IPaymentMethodRepository context, ILogger<PaymentMethod> logger, IMapper mapper)
        {
            _core = new(context, mapper, logger);
        }


        // GET api/<PaymentsController>/5
        [HttpGet("Methods/{idUser}")]
        public async Task<ActionResult<List<PaymentMethod>>> GetPaymentMethods(int idUser)
        {
            var response = await _core.GetAllMethods(idUser);
            return StatusCode((int)response.StatusHttp, response);
        }
    }
}
