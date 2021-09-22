using AutoMapper;
using DamianTrans.Entities;
using DamianTrans.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<CreateCarDto, Car>();
        }
    }
}
