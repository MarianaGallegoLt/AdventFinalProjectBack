﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.FinalProject.Entities.DTOs
{
    public class UserChangePasswordDto: UserLoginRequestDto
    {
        public string NewPassword { get; set; }
    }
}
