using AutoMapper;
using NET_Core_API_Exception_Handling.Application.DTOs;
using NET_Core_API_Exception_Handling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET_Core_API_Exception_Handling.Application.MappingProfile
{
    public class MapperResolver : Profile
    {
        public MapperResolver()
        {
            CreateMap<Person, PersonDTO>()
            .ForMember(p => p.PersonID, dest => dest.MapFrom(d => d.ID))
            .ForMember(p => p.MartialStatus, dest => dest.MapFrom(d => d.MartialStatus.ToString()))
            .ReverseMap();
        }


    }
}
