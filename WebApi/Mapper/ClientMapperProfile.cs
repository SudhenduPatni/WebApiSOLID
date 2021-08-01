using AutoMapper;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Mapper
{
    public class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {
            CreateMap<ClientCreate, Client>()
                .ForMember(c => c.ClientId, opt => opt.Ignore())
                .ForMember(c => c.ClientGlobalId, opt => opt.Ignore())
                .ForMember(c => c.CreatedDate, opt => opt.Ignore())
                .ForMember(c => c.ModifiedDate, opt => opt.Ignore())
                .ForMember(c => c.Status, opt => opt.Ignore());
        }
    }
}
