using AutoMapper;

namespace Pies.API.Profiles
{
    public class PieReviewsProfile : Profile
    {
        public PieReviewsProfile()
        {
            CreateMap<Entities.PieReview, Models.PieReviewDto>();
        }
    }
}
