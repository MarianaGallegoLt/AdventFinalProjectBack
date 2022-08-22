using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.FinalProject.Entities.Entities
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        //QUE ES ESOOOOOOO
        public string Last4 { get; set; }
    }
}
