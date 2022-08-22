using Advent.FinalProject.Contracts.Repository;
using Advent.FinalProject.Core.Handlers;
using Advent.FinalProject.Entities.DTOs;
using Advent.FinalProject.Entities.Entities;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.FinalProject.Core.V1
{
    //CAMBIAR NOMBRE
    public class PaymentRecordCore
    {
        private readonly IPaymentRecordRepository _context;
        private readonly ErrorHandler<PaymentRecord> _errorHandler;
        private readonly ILogger<PaymentRecord> _logger;
        private readonly IMapper _mapper;

        public PaymentRecordCore(IPaymentRecordRepository context, ILogger<PaymentRecord> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _errorHandler = new ErrorHandler<PaymentRecord>(logger);
        }
        public async Task<List<PaymentRecord>> AddDetails(int bookingId, List<PaymentRecordDto> payments)
        {
            List<PaymentRecord> details = new();
            foreach (var payment in payments)
            {
                PaymentRecord newPayment = _mapper.Map<PaymentRecord>(payment);
                newPayment.BookingId = bookingId;
                var result = await _context.AddAsync(newPayment);
                details.Add(result.Item1);
            }
            return details;
        }

        internal async Task<List<PaymentRecord>> GetDetailsByBookingId(int id)
        {
            return await _context.GetByFilterAsync(bd => bd.BookingId.Equals(id));
        }
    }
}
