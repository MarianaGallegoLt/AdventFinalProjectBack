using Advent.FinalProject.Contracts.Repository;
using Advent.FinalProject.Core.Handlers;
using Advent.FinalProject.Entities.DTOs;
using Advent.FinalProject.Entities.Entities;
using Advent.FinalProject.Entities.Utils;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Advent.FinalProject.Core.V1
{
    public class BookingCore
    {
        //CAMBIAR NOMBRE
        private readonly PaymentRecordCore _detailCore;
        private readonly PaymentCore _paymentCore;
        private readonly UserCore _userCore;
        private readonly IBookingRepository _context;
        private readonly ErrorHandler<Booking> _errorHandler;
        private readonly ILogger<Booking> _logger;
        private readonly IMapper _mapper;

        public BookingCore(
            IBookingRepository context, IPaymentRecordRepository contextDetails, ILogger<Booking> logger,
            IMapper mapper, ILogger<PaymentRecord> loggerDetails, IPaymentMethodRepository contextPayment, ILogger<PaymentMethod> loggerPayment,
            IUserRepository contextUser, ILogger<User> loggerUser
            )
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _errorHandler = new ErrorHandler<Booking>(logger);
            _detailCore = new(contextDetails, loggerDetails, mapper);
            _paymentCore = new(contextPayment, mapper, loggerPayment);
            _userCore = new(contextUser, loggerUser, mapper);
        }

        public async Task<ResponseService<BookingShowDto>> GetBooking(int id)
        {
            try
            {
                var result = await _context.GetByIdAsync(id);
                var resultDetails = await _detailCore.GetDetailsByBookingId(id);
                BookingShowDto bookingShow = new()
                {
                    BookingId = result.BookingId,
                    Details = resultDetails.ToArray(),
                    BookingDate = result.BookingDate,
                    PaymentToken = result.PaymentToken,
                    UserId = result.UserId,
                };
                return new ResponseService<BookingShowDto>(false, "Booking show", HttpStatusCode.OK, bookingShow);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "Show booking", new BookingShowDto());
            }
        }

        public async Task<ResponseService<BookingShowDto>> NewBooking(BookingCreateDto newBooking)
        {
            try
            {
                int totalAmount = 0;
                foreach (var detail in newBooking.Details)
                {
                    totalAmount = +detail.BookingFee;
                }

                string customerToken = await _userCore.GetCustomerTokenById(newBooking.UserId);
                string paymentToken = await _paymentCore.PayBooking(newBooking.PaymentMethodId, totalAmount, customerToken);
                Booking booking = new()
                {
                    BookingDate = newBooking.Date,
                    PaymentToken = paymentToken,
                    UserId = newBooking.UserId
                };

                var response = await _context.AddAsync(booking);

                List<PaymentRecord> bookingDetails = await _detailCore.AddDetails(response.Item1.BookingId, newBooking.Details.ToList());

                BookingShowDto bookingShow = new()
                {
                    BookingId = response.Item1.BookingId,
                    Details = bookingDetails.ToArray(),
                    BookingDate = response.Item1.BookingDate,
                    PaymentToken = response.Item1.PaymentToken,
                    UserId = response.Item1.UserId,
                };
                return new ResponseService<BookingShowDto>(false, response == null ? "No records found" : "User list", HttpStatusCode.OK, bookingShow);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "Create booking", new BookingShowDto());
            }
        }
    }
}
