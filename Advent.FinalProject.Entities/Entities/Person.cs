using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.FinalProject.Entities.Entities
{
    public  class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int ContactNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
