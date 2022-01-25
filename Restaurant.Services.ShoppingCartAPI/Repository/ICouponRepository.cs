using Restaurant.Services.ShoppingCartAPI.Models.DTO;

namespace Restaurant.Services.ShoppingCartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCoupon(string couponName);
    }
}
