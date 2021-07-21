using AutoMapper;

namespace Pies.API.Profiles
{
    public class PiesProfile : Profile
    {
        public PiesProfile()
        {
            CreateMap<Entities.Pie, Models.PieDto>();
        }
    }
}
