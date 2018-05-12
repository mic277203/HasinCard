using AutoMapper;
using HasinCard.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HasinCard.Core.AuoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<SysUsers, SysUsersResponseDto>();
        }
    }
}
