using AutoMapper;

namespace Pies.API.Profiles
{
    public class PiesProfile : Profile
    {
        public PiesProfile()
        {
            CreateMap<Entities.Pie, Models.PieDto>();
            CreateMap<Models.PieForCreationDto, Entities.Pie>();

            //CreateMap<Entities.Author, Models.AuthorDto>()
            //    .ForMember(
            //        dest => dest.Name,
            //        opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            //    .ForMember(
            //        dest => dest.Age,
            //        opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));
        }
    }
}
