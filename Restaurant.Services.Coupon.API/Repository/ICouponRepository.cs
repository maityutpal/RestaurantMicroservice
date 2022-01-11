using Restaurant.Services.Coupon.API.Models.DTO;

namespace Restaurant.Services.Coupon.API.Repository
{
    public interface ICouponRepository
    {
        Task<CouponGiftDto> GetCouponByCode(string couponCode);
    }
}
