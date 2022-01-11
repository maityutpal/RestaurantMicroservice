using AutoMapper;
using Restaurant.Services.Coupon.API.Models;
using Restaurant.Services.Coupon.API.Models.DTO;

namespace Restaurant.Services.Coupon.API
{
    public  class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponGiftDto, CouponGift>().ReverseMap();
                
            });

            return mappingConfig;
        }
    }
}
