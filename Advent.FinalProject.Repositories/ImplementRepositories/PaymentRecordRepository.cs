using Advent.FinalProject.Contracts.Repository;
using Advent.FinalProject.DataAccess.Context;
using Advent.FinalProject.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advent.FinalProject.Repositories.ImplementRepositories
{
    public class PaymentRecordRepository : IPaymentRecordRepository
    {
        private readonly MySqlContext _context;

        public PaymentRecordRepository()
        {
            _context = new();
        }

        public async Task<Tuple<PaymentRecord, bool>> AddAsync(PaymentRecord entity)
        {
            try
            {
                var result = _context.PaymentRecords.Add(entity);
                await _context.SaveChangesAsync();
                return Tuple.Create(result.Entity, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<List<PaymentRecord>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<PaymentRecord>> GetByFilterAsync(Expression<Func<PaymentRecord, bool>> expressionFilter = null)
        {
            try
            {
                return await _context.PaymentRecords.Where<PaymentRecord>(expressionFilter).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<PaymentRecord> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<PaymentRecord, bool>> UpdateAsync(PaymentRecord entity)
        {
            throw new NotImplementedException();
        }
    }
}
