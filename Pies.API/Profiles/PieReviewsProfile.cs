using AutoMapper;

namespace Pies.API.Profiles
{
    public class PieReviewsProfile : Profile
    {
        public PieReviewsProfile()
        {
            CreateMap<Entities.PieReview, Models.PieReviewDto>();
            CreateMap<Models.PieReviewForCreationDto, Entities.PieReview>();
            CreateMap<Models.PieReviewForUpdateDto, Entities.PieReview>();
            CreateMap<Entities.PieReview, Models.PieReviewForUpdateDto>();
        }
    }
}
