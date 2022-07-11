using AutoMapper;
using N5.Core.DTOs;
using N5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PermissionEntity, PermissionDto>();
            CreateMap<PermissionEntity, PermissionFindDto>();
            CreateMap<PermissionDto, PermissionEntity>();
        }
    }
}
