using AutoMapper;

namespace Pies.API.Profiles
{
    public class ShopsProfile : Profile
    {
        public ShopsProfile()
        {
            CreateMap<Entities.Shop, Models.ShopDto>();
        }
    }
}
