using Advent.FinalProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.FinalProject.Entities.DTOs
{
    //QUE ES ESTOOOOOOO
    public class BookingShowDto: Booking
    {
        public PaymentRecord[] Details { get; set; }
    }
}
