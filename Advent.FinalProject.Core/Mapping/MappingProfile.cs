using Advent.FinalProject.Entities.DTOs;
using Advent.FinalProject.Entities.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.FinalProject.Core.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //User
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserCreateDto>();

            //PaymentRecord
            CreateMap<PaymentRecordDto, PaymentRecord>();
            CreateMap<PaymentRecord, PaymentRecordDto>();
        }
    }
}
