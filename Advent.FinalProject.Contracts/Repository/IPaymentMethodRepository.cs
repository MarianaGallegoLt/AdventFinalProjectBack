using Advent.FinalProject.Contracts.Generics;
using Advent.FinalProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.FinalProject.Contracts.Repository
{
    public interface IPaymentMethodRepository : IGenericActionDbAddUpdate<PaymentMethod>, IGenericActionDbQuery<PaymentMethod>
    {
    }
}
