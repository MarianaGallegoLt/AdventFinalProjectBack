using Advent.FinalProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.FinalProject.Entities.DTOs
{
    public class UserCreateDto: Person
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
