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
    [Authorize]
    public class BookingsController : ControllerBase
    {
        private readonly BookingCore _core;

        public BookingsController(
            IBookingRepository context, IPaymentRecordRepository contextDetails, ILogger<Booking> logger,
            IMapper mapper, ILogger<PaymentRecord> loggerDetails, IPaymentMethodRepository contextPayment, ILogger<PaymentMethod> loggerPayment,
            IUserRepository contextUser, ILogger<User> loggerUser
            )
        {
            _core = new(context, contextDetails, logger, mapper, loggerDetails, contextPayment, loggerPayment, contextUser, loggerUser);
        }

        // GET api/<PaymentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingShowDto>> GetBooking(int id)
        {
            var response = await _core.GetBooking(id);
            return StatusCode((int)response.StatusHttp, response);
        }

        // POST api/<PaymentsController>
        [HttpPost]
        public async Task<ActionResult<BookingShowDto>> NewBooking([FromBody] BookingCreateDto newBooking)
        {
            var response = await _core.NewBooking(newBooking);
            return StatusCode((int)response.StatusHttp, response);
        }
    }
}
