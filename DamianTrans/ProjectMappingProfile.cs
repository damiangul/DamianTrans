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

            CreateMap<Car, CreateCarDto>();

            CreateMap<RegisterClientDto, Client>()
                .ForMember(r => r.Address, c => c.MapFrom(dto => new Address() {
                    City = dto.City,
                    PostCode = dto.PostCode,
                    Street = dto.Street,
                    Number = dto.Number,
                }));
        }
    }
}
