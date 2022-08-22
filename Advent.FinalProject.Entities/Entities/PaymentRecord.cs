using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.FinalProject.Entities.Entities
{
    public class PaymentRecord
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public int ContainerId { get; set; }
        public double BookingFee { get; set; }
    }
}
