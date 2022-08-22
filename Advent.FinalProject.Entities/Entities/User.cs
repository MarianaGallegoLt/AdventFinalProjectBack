using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.FinalProject.Entities.Entities
{
    public class User: Person
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedUserDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastLogout { get; set; }
        public string Status { get; set; }
        public string Token { get; set; }
    }
}
