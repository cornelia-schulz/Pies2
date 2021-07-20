using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pies.API.Profiles
{
    public class PieTypeProfile : Profile
    {
        public PieTypeProfile()
        {
            CreateMap<Entities.PieType, Models.PieTypeDto>();
        }
    }
}
