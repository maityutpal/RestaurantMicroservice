using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Services.Coupon.API.DbContexts;
using Restaurant.Services.Coupon.API.Models.DTO;

namespace Restaurant.Services.Coupon.API.Repository
{
    public class CouponRepository: ICouponRepository
    {
        private readonly ApplicationDbContext _db;
        protected IMapper _mapper;

        public CouponRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CouponGiftDto> GetCouponByCode(string couponCode)
        {
            var couponFromDb = await _db.Coupons.FirstOrDefaultAsync(u => u.CouponCode == couponCode);
            return _mapper.Map<CouponGiftDto>(couponFromDb);
        }
    }
}
