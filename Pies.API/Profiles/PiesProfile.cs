using AutoMapper;
using Pies.API.Helpers;

namespace Pies.API.Profiles
{
    public class PiesProfile : Profile
    {
        public PiesProfile()
        {
            CreateMap<Entities.Pie, Models.PieDto>();
            CreateMap<Models.PieForCreationDto, Entities.Pie>();
            CreateMap<Entities.Pie, Models.PieFullDto>();
            CreateMap<Entities.Pie, Models.PieDto>()
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateCreated.GetCurrentAge(src.DateDeleted)));
            CreateMap<Models.PieForCreationWithDateDeletedDto, Entities.Pie>();

            //CreateMap<Entities.Pie, Models.PieDto>()
            //    .ForMember(
            //        dest => dest.Name,
            //        opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            //    .ForMember(
            //        dest => dest.Age,
            //        opt => opt.MapFrom(src => src.DateCreated.GetCurrentAge(src.DateDeleted)));
        }
    }
}
